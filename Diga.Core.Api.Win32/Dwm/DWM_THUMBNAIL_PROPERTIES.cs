using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Dwm
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DWM_THUMBNAIL_PROPERTIES
    {

        /// DWORD->unsigned int
        public uint dwFlags;

        /// RECT->tagRECT
        public Rect rcDestination;

        /// RECT->tagRECT
        public Rect rcSource;

        /// BYTE->unsigned char
        public byte opacity;

        /// BOOL->int
        [MarshalAs(UnmanagedType.Bool)]
        public bool fVisible;

        /// BOOL->int
        [MarshalAs(UnmanagedType.Bool)]
        public bool fSourceClientAreaOnly;
    }
}