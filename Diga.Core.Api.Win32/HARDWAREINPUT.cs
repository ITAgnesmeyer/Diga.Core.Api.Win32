using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct HARDWAREINPUT {
    
        /// DWORD->unsigned int
        public uint uMsg;
    
        /// WORD->unsigned short
        public ushort wParamL;
    
        /// WORD->unsigned short
        public ushort wParamH;
    }
}