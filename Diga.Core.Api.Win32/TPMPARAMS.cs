using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TPMPARAMS
    {

        /// UINT->unsigned int
        public uint cbSize;

        /// RECT->tagRECT
        public Rect rcExclude;
    }
}