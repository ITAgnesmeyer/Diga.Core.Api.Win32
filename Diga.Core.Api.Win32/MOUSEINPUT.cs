using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MOUSEINPUT {
    
        /// LONG->int
        public int dx;
    
        /// LONG->int
        public int dy;
    
        /// DWORD->unsigned int
        public uint mouseData;
    
        /// DWORD->unsigned int
        public uint dwFlags;
    
        /// DWORD->unsigned int
        public uint time;
    
        /// ULONG_PTR->unsigned int
        public uint dwExtraInfo;
    }
}