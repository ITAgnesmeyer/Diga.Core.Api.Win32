using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Explicit)]
    public struct INPUT_UNION 
    {
    
        /// MOUSEINPUT->tagMOUSEINPUT
        [FieldOffset(0)]
        public MOUSEINPUT mi;
    
        /// KEYBDINPUT->tagKEYBDINPUT
        [FieldOffset(0)]
        public KEYBDINPUT ki;
    
        /// HARDWAREINPUT->tagHARDWAREINPUT
        [FieldOffset(0)]
        public HARDWAREINPUT hi;
    }
}