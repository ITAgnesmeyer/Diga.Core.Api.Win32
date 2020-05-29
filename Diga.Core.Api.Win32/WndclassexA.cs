using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{

    [StructLayout(LayoutKind.Sequential)]
    public struct WndclassexA {
    
        /// UINT->unsigned int
        public uint cbSize;
    
        /// UINT->unsigned int
        public uint style;
    
        /// WNDPROC
        public WndProc lpfnWndProc;
    
        /// int
        public int cbClsExtra;
    
        /// int
        public int cbWndExtra;
    
        /// HINSTANCE->HINSTANCE__*
        public System.IntPtr hInstance;
    
        /// HICON->HICON__*
        public System.IntPtr hIcon;
    
        /// HCURSOR->HICON->HICON__*
        public System.IntPtr hCursor;
    
        /// HBRUSH->HBRUSH__*
        public System.IntPtr hbrBackground;
    
        /// LPCSTR->CHAR*
        [MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string lpszMenuName;
    
        /// LPCSTR->CHAR*
        [MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string lpszClassName;
    
        /// HICON->HICON__*
        public System.IntPtr hIconSm;

    }
}