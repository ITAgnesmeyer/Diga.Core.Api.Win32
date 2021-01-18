using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Diga.Core.Api.Win32.Tools
{

    public class ByteReader
    {
        
        private ApiHandleRef Handle;
        public int Positon { get; set; }
        public ByteReader(IntPtr ptr)
        {
            
            this.Handle = ptr;
            this.Positon = 0;
        }

        public ByteReader(IntPtr ptr, int postion)
        {
            this.Handle = ptr;
            this.Positon = postion;
        }

        public int GetNextInt()
        {
            byte[] bytes = GetBytes<int>();

            return BitConverter.ToInt32(bytes, 0);
        }

        public uint GetNextUInt()
        {
            byte[] bytes = GetBytes<uint>();
            return BitConverter.ToUInt32(bytes, 0);
        }

        public long GetNextLong()
        {
            byte[] bytes = GetBytes<long>();
            return BitConverter.ToInt64(bytes, 0);
        }

        public bool GetNextBool()
        {
            byte[] bytes = GetBytes<bool>();
            return BitConverter.ToBoolean(bytes, 0);
        }

        public char GetNextChar()
        {
            byte[] bytes = GetBytes<char>();
            return BitConverter.ToChar(bytes, 0);
        }

        public double GetNextDouble()
        {
            byte[] bytes = GetBytes<double>();
            return BitConverter.ToDouble(bytes, 0);
        }

        public short GetNextShort()
        {
            byte[] bytes = GetBytes<short>();
            return BitConverter.ToInt16(bytes, 0);
        }

        public sbyte GetNextSByte()
        {
            byte b = GetNextByte();
            return (sbyte)b;
        }
        public ushort GetNextUShort()
        {
            byte[] bytes = GetBytes<ushort>();
            return BitConverter.ToUInt16(bytes, 0);
        }

        public float GetNextFloat()
        {
            byte[] bytes = GetBytes<float>();
            return BitConverter.ToSingle(bytes, 0);
        }

        public ulong GetNextULong()
        {
            byte[] bytes = GetBytes<ulong>();
            return BitConverter.ToUInt64(bytes, 0);
        }
        public byte GetNextByte()
        {

            byte b = GetCurrentByte();
            MoveNext();
            return b;
        }

        public void Move(int len)
        {
            this.Positon = this.Positon + len;
        }

        public void MoveTo(int index)
        {
            this.Positon = index;
        }
        public void MoveNext()
        {
            this.Positon++;
        }

        public void MoveBack()
        {
            this.Positon--;
        }

        public void MoveBack(int len)
        {
            this.Positon -= len;
        }
        public void MoveBack<T>()
        {
            int len = Marshal.SizeOf<T>();
            this.Positon -= len;
        }

        public void MoveForward<T>()
        {
            int len = Marshal.SizeOf<T>();
            this.Positon += len;
        }

        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        public byte GetCurrentByte()
        {
            byte b;
            try
            {
                b = Marshal.ReadByte(this.Handle, this.Positon);
            }
            catch (AccessViolationException)
            {
                throw new Exception("Attempt to read outside the protected memory area->Position:" + this.Positon);
            }
            
            return b;
        }


        public void DWordAlign()
        {
            int pos = this.Positon;
            pos = (pos + 3) & ~3;
            this.Positon = pos;
        }

        public byte[] GetBytes(int len)
        {
            byte[] bytes = new byte[len];
            int counter = 0;
            while (counter < len)
            {

                bytes[counter] = GetCurrentByte();


                MoveNext();
                counter++;
            }
            return bytes;
        }
        public byte[] GetBytes<T>()
        {
            int len = Marshal.SizeOf<T>();
            return GetBytes(len);
        }

        public int FindNextZero()
        {
            
            int oldPos = this.Positon;
            MoveToNextZero();
            int zeroPos = this.Positon;
            this.Positon = oldPos;
            return zeroPos;
        }

        public byte[] GetNextWcharBytes()
        {
            return GetBytes(2);
        }

        public string ReadWCharUpToNts(bool withNts = false)
        {
            string value = GetNextWchar();
            if (value == "\0")
            {
                if (withNts)
                {
                    return value;
                }
                return "";

            }

            string ti = value;
            while (ti != "\0")
            {
                ti = GetNextWchar();
                if (ti != "\0")
                {
                    value += ti;
                }
                else
                {
                    if (withNts)
                    {
                        value += ti;
                    }
                }

            }
            return value;
        }
        public string GetNextWchar()
        {
            byte[] bytes = GetNextWcharBytes();
            string str = Encoding.Unicode.GetString(bytes);
            return str;
        }
        public byte[] GetUntilNextZero()
        {
            int nextZeroIndex = FindNextZero();
            int len = nextZeroIndex - this.Positon;
            return GetBytes(len);

        }

        public uint GetNextDWordAsUint()
        {
            byte[] bytes = GetBytes(4);
            return BitConverter.ToUInt32(bytes, 0);
        }

        public int GetNextDWordAsInt()
        {
            byte[] bytes = GetBytes(4);
            return BitConverter.ToInt32(bytes, 0);
        }

        public short GetNextWordAsShort()
        {
            byte[] bytes = GetBytes(2);
            return BitConverter.ToInt16(bytes, 0);
        }

        public ushort GetNextWordAsUShort()
        {
            byte[] bytes = GetBytes(2);
            return BitConverter.ToUInt16(bytes, 0);
        }

        public void MoveToNextZero()
        {
            byte b = 1;
            while (b != 0)
            {
                b = GetCurrentByte();
                if (b != 0)
                    MoveNext();
            }
        }


    }
}
