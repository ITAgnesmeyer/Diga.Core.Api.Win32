using System;
using System.Runtime.InteropServices;
using System.Text;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Local

namespace Diga.Core.Api.Win32
{
    

    public static class Win32Api
    {

        public static string MakeInterSourceString(int id)
        {
            return $"#{id}";
        }
        public static IntPtr MakeInterSource(string id)
        {
            if(int.TryParse(id, out int idInt))
            {
                return MakeInterSource(idInt);
            }

            return MakeInterSource(0);
        }
        public static IntPtr MakeInterSource(int id)
        {
            return new IntPtr(id);
        }
        public static IntPtr MakeInterSource(uint id)
        {
            return new IntPtr(id);
        }
        public static int HiWord(int number)
        {
            if ((number & 0x80000000) == 0x80000000)
                return (number >> 16);
            else
                return (number >> 16) & 0xffff;
        }

        public static int LoWord(int number)
        {
            return number & 0xffff;
        }
       
        public static uint GetIntPtrUInt(IntPtr ptr)
        {
            uint result = unchecked(IntPtr.Size == 8 ? (uint)ptr.ToInt64() : (uint)ptr.ToInt32());
            return result;
        }
        public static HighLow MakeHiLo(IntPtr lParam)
        {
            HighLow hl = new HighLow();
            uint uHiLow = GetIntPtrUInt(lParam);
            hl.iLow = unchecked((short)uHiLow);
            hl.iHigh = unchecked((short)(uHiLow >> 16));
            return hl;
        }
        public static int MakeLong(int loWord, int hiWord)
        {
            return (hiWord << 16) | (loWord & 0xffff);
        }

        public static ushort LoWord(uint nValue)
        {
            return (ushort) (nValue & 0xffff);
        }

        public static ushort HiWord(uint nValue)
        {
            return (ushort) (nValue >> 16);
        }

        public static Byte LoByte(ushort nValue)
        {
            return (byte) (nValue & 0xff);
        }

        public static byte HiByte(ushort nValue)
        {
            return (byte) (nValue >> 8);
        }

        public static IntPtr HiLoToLParam(HighLow hiLo)
        {
            return MakeLParam(hiLo.iLow, hiLo.iHigh);
        }
        public static IntPtr MakeLParam(int loWord, int hiWord)
        {
            return (IntPtr)((hiWord << 16) | (loWord & 0xffff));
        }

        public static int MulDiv(int number, int numerator, int denominator)
        {
            if (denominator == 0) return 0;
            return (int)((long)number * numerator / denominator);
        }

        public static int MulDivReverse(int number, int numerator, int dimension)
        {
            if (numerator == 0) return 0;
            return (int)((long)number * dimension / numerator);
        }

        public static byte BoolToByte(bool input)
        {
            if (input) return 1;
            return 0;
        }

        public static bool ByteToBool(byte input)
        {
            if (input == 1) return true;
            return false;
        }

        public static string PtrToUtf8(IntPtr nativeString)
        {
            string str = null;
            if (nativeString != IntPtr.Zero)
            {
                int nativeUTF8Size = GetNativeUTF8Size(nativeString);
                byte[] numArray = new byte[nativeUTF8Size - 1];
                Marshal.Copy(nativeString, numArray, 0, nativeUTF8Size - 1);
                str = Encoding.UTF8.GetString(numArray, 0, numArray.Length);
            }
            return str;
        }

        public static string PtrToUtf8(IntPtr nativeString, int size)
        {
            string str = null;
            if (nativeString != IntPtr.Zero)
            {
                byte[] numArray = new byte[size];
                Marshal.Copy(nativeString, numArray, 0, size);
                str = Encoding.UTF8.GetString(numArray, 0, numArray.Length);
            }
            return str;
        }

        public static int GetNativeUTF8Size(IntPtr nativeString)
        {
            int num = 0;
            if (nativeString != IntPtr.Zero)
            {
                while (Marshal.ReadByte(nativeString, num) > 0)
                {
                    num++;
                }
                num++;
            }
            return num;
        }

        public static byte[] GetUtf8Bytes(string sourceText)
        {
            if (sourceText == null)
            {
                return null;
            }
            int byteCount = Encoding.UTF8.GetByteCount(sourceText) + 1;
            byte[] numArray = new byte[byteCount];
            byteCount = Encoding.UTF8.GetBytes(sourceText, 0, sourceText.Length, numArray, 0);
            numArray[byteCount] = 0;
            return numArray;
        }

        public static uint MakeLcId(int lgid, int srtid)
        {
            return ((uint)(ushort)srtid << 16) | (ushort)lgid;
        }

        public static  bool IsResource(IntPtr r)
        {
            uint value = GetIntPtrUInt(r);

            var retVal = (value >> 16) > 0;
            return retVal;
        }
    }
}


