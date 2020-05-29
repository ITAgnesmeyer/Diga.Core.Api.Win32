using System;
using System.Runtime.InteropServices;

// ReSharper disable IdentifierTypo

namespace Diga.Core.Api.Win32
{
   

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    //[StructLayout(LayoutKind.Sequential)]
    public struct WndClassEx
    {
        [MarshalAs(UnmanagedType.U4)] public int cbSize;
        [MarshalAs(UnmanagedType.U4)] public uint style;
        public IntPtr lpfnWndProc;
        public int cbClsExtra;
        public int cbWndExtra;
        public IntPtr hInstance;
        public IntPtr hIcon;
        public IntPtr hCursor;
        public IntPtr hbrBackground;
        public string lpszMenuName;
        public string lpszClassName;
        public IntPtr hIconSm;

        public static WndClassEx Build()
        {
            var nw = new WndClassEx();
            nw.cbSize = Marshal.SizeOf(typeof(WndClassEx));
            return nw;
        }
    }
}