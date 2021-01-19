using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.GDI
{
    [StructLayout(LayoutKind.Sequential)]
    public struct EnhMetaRecord
    {

        /// DWORD->unsigned int
        public uint iType;

        /// DWORD->unsigned int
        public uint nSize;

        /// DWORD[1]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.U4)]
        public uint[] dParm;
    }
}