using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ABC
    {

        /// int
        public int abcA;

        /// UINT->unsigned int
        public uint abcB;

        /// int
        public int abcC;
    }
}