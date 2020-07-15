using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GlyphSet
    {

        /// DWORD->unsigned int
        public uint cbThis;

        /// DWORD->unsigned int
        public uint flAccel;

        /// DWORD->unsigned int
        public uint cGlyphsSupported;

        /// DWORD->unsigned int
        public uint cRanges;

        /// WCRANGE[1]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.Struct)]
        public WCrange[] ranges;
    }
}