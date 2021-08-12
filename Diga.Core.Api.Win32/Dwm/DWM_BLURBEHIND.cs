using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Dwm
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DWM_BLURBEHIND
    {

        /// DWORD->unsigned int
        public uint dwFlags;

        /// BOOL->int
        [MarshalAs(UnmanagedType.Bool)]
        public bool fEnable;

        /// HRGN->HRGN__*
        public System.IntPtr hRgnBlur;

        /// BOOL->int
        [MarshalAs(UnmanagedType.Bool)]
        public bool fTransitionOnMaximized;
    }
}