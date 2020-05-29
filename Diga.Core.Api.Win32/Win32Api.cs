﻿using System;


namespace Diga.Core.Api.Win32
{
    public static class Win32Api
    {
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

        public static int MakeLong(int loWord, int hiWord)
        {
            return (hiWord << 16) | (loWord & 0xffff);
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
    }
}


