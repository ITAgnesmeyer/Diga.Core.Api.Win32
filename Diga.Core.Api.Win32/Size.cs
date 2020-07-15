using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Size
    {

        /// LONG->int
        public int cx;

        /// LONG->int
        public int cy;
    }
}