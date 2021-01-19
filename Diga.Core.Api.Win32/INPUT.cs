using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct INPUT 
    {
    
        /// DWORD->unsigned int
        public uint type;
    
        /// Anonymous_dccf47da_5155_438b_92bc_41adbefe840c
        public INPUT_UNION Union1;
    }
}