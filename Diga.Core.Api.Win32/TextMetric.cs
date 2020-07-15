using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct TextMetric
    {

        /// LONG->int
        public int tmHeight;

        /// LONG->int
        public int tmAscent;

        /// LONG->int
        public int tmDescent;

        /// LONG->int
        public int tmInternalLeading;

        /// LONG->int
        public int tmExternalLeading;

        /// LONG->int
        public int tmAveCharWidth;

        /// LONG->int
        public int tmMaxCharWidth;

        /// LONG->int
        public int tmWeight;

        /// LONG->int
        public int tmOverhang;

        /// LONG->int
        public int tmDigitizedAspectX;

        /// LONG->int
        public int tmDigitizedAspectY;

        /// WCHAR->wchar_t->unsigned short
        public ushort tmFirstChar;

        /// WCHAR->wchar_t->unsigned short
        public ushort tmLastChar;

        /// WCHAR->wchar_t->unsigned short
        public ushort tmDefaultChar;

        /// WCHAR->wchar_t->unsigned short
        public ushort tmBreakChar;

        /// BYTE->unsigned char
        public byte tmItalic;

        /// BYTE->unsigned char
        public byte tmUnderlined;

        /// BYTE->unsigned char
        public byte tmStruckOut;

        /// BYTE->unsigned char
        public byte tmPitchAndFamily;

        /// BYTE->unsigned char
        public byte tmCharSet;
    }
}