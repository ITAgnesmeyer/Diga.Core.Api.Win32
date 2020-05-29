using System.Runtime.InteropServices;



namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct LogFontW
    {
        /// LONG->int
        public int lfHeight;

        /// LONG->int
        public int lfWidth;

        /// LONG->int
        public int lfEscapement;

        /// LONG->int
        public int lfOrientation;

        /// LONG->int
        public int lfWeight;

        /// BYTE->unsigned char
        public byte lfItalic;

        /// BYTE->unsigned char
        public byte lfUnderline;

        /// BYTE->unsigned char
        public byte lfStrikeOut;

        /// BYTE->unsigned char
        public byte lfCharSet;

        /// BYTE->unsigned char
        public byte lfOutPrecision;

        /// BYTE->unsigned char
        public byte lfClipPrecision;

        /// BYTE->unsigned char
        public byte lfQuality;

        /// BYTE->unsigned char
        public byte lfPitchAndFamily;

        /// WCHAR[32]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string lfFaceName;
    }
}