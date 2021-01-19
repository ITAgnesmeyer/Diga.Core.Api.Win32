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

        /// <summary>
        /// Current Byte-Postion
        /// </summary>
        public int Positon { get; set; }

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="ptr">Byte-Pointer</param>
        public ByteReader(IntPtr ptr)
        {
            
            this.Handle = ptr;
            this.Positon = 0;
        }

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="ptr">Byte-Pointer</param>
        /// <param name="postion">Start-Postion</param>
        public ByteReader(IntPtr ptr, int postion)
        {
            this.Handle = ptr;
            this.Positon = postion;
        }

        /// <summary>
        /// Read the next bytes as Integer
        /// </summary>
        /// <returns>Integer</returns>
        public int GetNextInt()
        {
            byte[] bytes = GetBytes<int>();

            return BitConverter.ToInt32(bytes, 0);
        }


        /// <summary>
        /// Read the next bytes as UInt
        /// </summary>
        /// <returns>UInt</returns>
        public uint GetNextUInt()
        {
            byte[] bytes = GetBytes<uint>();
            return BitConverter.ToUInt32(bytes, 0);
        }

        /// <summary>
        /// Read the next bytes as long
        /// </summary>
        /// <returns>Long</returns>
        public long GetNextLong()
        {
            byte[] bytes = GetBytes<long>();
            return BitConverter.ToInt64(bytes, 0);
        }
        /// <summary>
        /// Read the next byte as Boolean
        /// </summary>
        /// <returns>Boolean</returns>
        public bool GetNextBool()
        {
            byte[] bytes = GetBytes<bool>();
            return BitConverter.ToBoolean(bytes, 0);
        }

        /// <summary>
        /// Read the next bytes as Char
        /// </summary>
        /// <returns>Char</returns>
        public char GetNextChar()
        {
            byte[] bytes = GetBytes<char>();
            return BitConverter.ToChar(bytes, 0);
        }
        /// <summary>
        /// Read the next bytes as Double
        /// </summary>
        /// <returns>Double</returns>
        public double GetNextDouble()
        {
            byte[] bytes = GetBytes<double>();
            return BitConverter.ToDouble(bytes, 0);
        }
        /// <summary>
        /// Read the next bytes as Short
        /// </summary>
        /// <returns>Short</returns>
        public short GetNextShort()
        {
            byte[] bytes = GetBytes<short>();
            return BitConverter.ToInt16(bytes, 0);
        }

        /// <summary>
        /// Read the next byte as SByte
        /// </summary>
        /// <returns>SByte</returns>
        public sbyte GetNextSByte()
        {
            byte b = GetNextByte();
            return (sbyte)b;
        }
        /// <summary>
        /// Read the next Bytes as UShort
        /// </summary>
        /// <returns>UShort</returns>
        public ushort GetNextUShort()
        {
            byte[] bytes = GetBytes<ushort>();
            return BitConverter.ToUInt16(bytes, 0);
        }
        /// <summary>
        /// Read the next Bytes as Float
        /// </summary>
        /// <returns>Float</returns>
        public float GetNextFloat()
        {
            byte[] bytes = GetBytes<float>();
            return BitConverter.ToSingle(bytes, 0);
        }
        /// <summary>
        /// Read the next Bytes as ULong
        /// </summary>
        /// <returns>ULong</returns>
        public ulong GetNextULong()
        {
            byte[] bytes = GetBytes<ulong>();
            return BitConverter.ToUInt64(bytes, 0);
        }
        /// <summary>
        /// Get the next Byte
        /// </summary>
        /// <returns></returns>
        public byte GetNextByte()
        {

            byte b = GetCurrentByte();
            MoveNext();
            return b;
        }

        /// <summary>
        /// Move the position in byte-array to left from 
        /// current position
        /// </summary>
        /// <param name="len">length to move right</param>
        public void Move(int len)
        {
            this.Positon = this.Positon + len;
        }
        /// <summary>
        /// move the position in byte-array to given position
        /// </summary>
        /// <param name="index">new position</param>
        public void MoveTo(int index)
        {
            this.Positon = index;
        }

        /// <summary>
        /// Moves to next byte
        /// </summary>
        public void MoveNext()
        {
            this.Positon++;
        }

        /// <summary>
        /// Moves position one left
        /// </summary>
        public void MoveBack()
        {
            this.Positon--;
        }

        /// <summary>
        /// moves the position in byte-array left
        /// </summary>
        /// <param name="len">lenth to move left</param>
        public void MoveBack(int len)
        {
            this.Positon -= len;
        }
        /// <summary>
        /// Moves laft lent is size of Type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void MoveBack<T>()
        {
            int len = Marshal.SizeOf<T>();
            this.Positon -= len;
        }
        /// <summary>
        /// Moves right lenth Size of Type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void MoveForward<T>()
        {
            int len = Marshal.SizeOf<T>();
            this.Positon += len;
        }

        /// <summary>
        /// Get The current Bye
        /// </summary>
        /// <returns>Byte</returns>
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
        /// <summary>
        /// Get Bytes from current position
        /// </summary>
        /// <param name="len">len to read</param>
        /// <returns></returns>
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
        /// <summary>
        /// Get Bytes form current postion lenth Size of Type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public byte[] GetBytes<T>()
        {
            int len = Marshal.SizeOf<T>();
            return GetBytes(len);
        }

        /// <summary>
        /// Find the next Positon 0-BYTE
        /// </summary>
        /// <returns>position of next 0-BYTE</returns>
        public int FindNextZero()
        {
            
            int oldPos = this.Positon;
            MoveToNextZero();
            int zeroPos = this.Positon;
            this.Positon = oldPos;
            return zeroPos;
        }

        /// <summary>
        /// Read the next bytes for a WCHAR
        /// </summary>
        /// <returns></returns>
        public byte[] GetNextWcharBytes()
        {
            return GetBytes(2);
        }

        /// <summary>
        /// Reads the next byte until NTS and returns String
        /// </summary>
        /// <param name="withNts">including NTS-Char</param>
        /// <returns>String</returns>
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
        /// <summary>
        /// Get nex bytes as String(WCHAR)
        /// </summary>
        /// <returns></returns>
        public string GetNextWchar()
        {
            byte[] bytes = GetNextWcharBytes();
            string str = Encoding.Unicode.GetString(bytes);
            return str;
        }

        /// <summary>
        /// Read all bytes until next 0-BYTE
        /// </summary>
        /// <returns></returns>
        public byte[] GetUntilNextZero()
        {
            int nextZeroIndex = FindNextZero();
            int len = nextZeroIndex - this.Positon;
            return GetBytes(len);

        }
        /// <summary>
        /// Read next DWort(size 4) as Uint
        /// </summary>
        /// <returns>UINT</returns>
        public uint GetNextDWordAsUint()
        {
            byte[] bytes = GetBytes(4);
            return BitConverter.ToUInt32(bytes, 0);
        }
        /// <summary>
        /// Read next DWor(siez 4) as Int
        /// </summary>
        /// <returns>Int</returns>

        public int GetNextDWordAsInt()
        {
            byte[] bytes = GetBytes(4);
            return BitConverter.ToInt32(bytes, 0);
        }

        /// <summary>
        /// Read next Word(siez 2) as Short
        /// </summary>
        /// <returns>Short</returns>
        public short GetNextWordAsShort()
        {
            byte[] bytes = GetBytes(2);
            return BitConverter.ToInt16(bytes, 0);
        }

        /// <summary>
        /// Read next Wort(Size 2) as UShort
        /// </summary>
        /// <returns>UShort</returns>
        public ushort GetNextWordAsUShort()
        {
            byte[] bytes = GetBytes(2);
            return BitConverter.ToUInt16(bytes, 0);
        }
        /// <summary>
        /// Moves current postion to next 0-Byte
        /// </summary>
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
