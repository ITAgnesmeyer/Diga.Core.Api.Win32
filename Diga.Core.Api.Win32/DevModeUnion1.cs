using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Explicit)]
    public struct DevModeUnion1
    {

        /// Anonymous_865d3c92_fe8c_4ee6_9601_a9eb2536957e
        [FieldOffset(0)]
        public DevModeUnion1Struct1 Struct1;

        /// Anonymous_1b5f787e_41ca_472c_8595_3484490ffe0c
        [FieldOffset(0)]
        public DevModeUnion1Struct2 Struct2;
    }
}