using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RgbQuad
    {

        /// BYTE->unsigned char
        public byte rgbBlue;

        /// BYTE->unsigned char
        public byte rgbGreen;

        /// BYTE->unsigned char
        public byte rgbRed;

        /// BYTE->unsigned char
        public byte rgbReserved;
    }
}