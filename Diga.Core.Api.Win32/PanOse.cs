using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PanOse
    {

        /// BYTE->unsigned char
        public byte bFamilyType;

        /// BYTE->unsigned char
        public byte bSerifStyle;

        /// BYTE->unsigned char
        public byte bWeight;

        /// BYTE->unsigned char
        public byte bProportion;

        /// BYTE->unsigned char
        public byte bContrast;

        /// BYTE->unsigned char
        public byte bStrokeVariation;

        /// BYTE->unsigned char
        public byte bArmStyle;

        /// BYTE->unsigned char
        public byte bLetterform;

        /// BYTE->unsigned char
        public byte bMidline;

        /// BYTE->unsigned char
        public byte bXHeight;
    }
}