using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.GDI
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Fixed
    {

        /// WORD->unsigned short
        public ushort fract;

        /// short
        public short value;
    }
}