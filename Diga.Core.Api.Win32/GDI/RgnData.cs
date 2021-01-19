using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.GDI
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct RgnData
    {

        /// RGNDATAHEADER->_RGNDATAHEADER
        public RgnDataHeader rdh;

        /// char[1]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public string Buffer;
    }
}