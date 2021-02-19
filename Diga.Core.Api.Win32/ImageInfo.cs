using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ImageInfo
    {
        public IntPtr hbmImage;
        public IntPtr hbmMask;
        public int Unused1;
        public int Unused2;
        public int rcImage_left;
        public int rcImage_top;
        public int rcImage_right;
        public int rcImage_bottom;
    }
}