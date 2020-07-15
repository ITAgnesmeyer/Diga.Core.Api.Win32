using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Bitmap
    {

        /// LONG->int
        public int bmType;

        /// LONG->int
        public int bmWidth;

        /// LONG->int
        public int bmHeight;

        /// LONG->int
        public int bmWidthBytes;

        /// WORD->unsigned short
        public ushort bmPlanes;

        /// WORD->unsigned short
        public ushort bmBitsPixel;

        /// LPVOID->void*
        public IntPtr bmBits;
    }
}