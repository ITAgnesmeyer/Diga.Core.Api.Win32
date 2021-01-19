using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.GDI
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DesignVector
    {

        /// DWORD->unsigned int
        public uint dvReserved;

        /// DWORD->unsigned int
        public uint dvNumAxes;

        /// LONG[16]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I4)]
        public int[] dvValues;
    }
}