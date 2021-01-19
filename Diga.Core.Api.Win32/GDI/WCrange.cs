using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.GDI
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WCrange
    {

        /// WCHAR->wchar_t->unsigned short
        public ushort wcLow;

        /// USHORT->unsigned short
        public ushort cGlyphs;
    }
}