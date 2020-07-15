using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PaletteEntry
    {

        /// BYTE->unsigned char
        public byte peRed;

        /// BYTE->unsigned char
        public byte peGreen;

        /// BYTE->unsigned char
        public byte peBlue;

        /// BYTE->unsigned char
        public byte peFlags;
    }
}