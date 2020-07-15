using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MetaRecord
    {

        /// DWORD->unsigned int
        public uint rdSize;

        /// WORD->unsigned short
        public ushort rdFunction;

        /// WORD[1]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.U2)]
        public ushort[] rdParm;
    }
}