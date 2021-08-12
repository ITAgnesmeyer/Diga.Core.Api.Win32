using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Dwm
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UNSIGNED_RATIO
    {

        /// UINT32->unsigned int
        public uint uiNumerator;

        /// UINT32->unsigned int
        public uint uiDenominator;
    }
}