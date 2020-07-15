using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RgnDataHeader
    {

        /// DWORD->unsigned int
        public uint dwSize;

        /// DWORD->unsigned int
        public uint iType;

        /// DWORD->unsigned int
        public uint nCount;

        /// DWORD->unsigned int
        public uint nRgnSize;

        /// RECT->tagRECT
        public Rect rcBound;
    }
}