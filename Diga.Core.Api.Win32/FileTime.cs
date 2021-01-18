using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FileTime 
    {
    
        /// DWORD->unsigned int
        public uint dwLowDateTime;
    
        /// DWORD->unsigned int
        public uint dwHighDateTime;
    }
}