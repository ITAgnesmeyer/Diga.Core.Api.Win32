using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.GDI
{
    [StructLayout(LayoutKind.Explicit)]
    public struct DevModeUnion2
    {

        /// DWORD->unsigned int
        [FieldOffset(0)]
        public uint dmDisplayFlags;

        /// DWORD->unsigned int
        [FieldOffset(0)]
        public uint dmNup;
    }
}