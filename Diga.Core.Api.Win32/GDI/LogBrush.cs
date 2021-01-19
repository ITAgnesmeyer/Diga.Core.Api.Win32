using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.GDI
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LogBrush
    {

        /// UINT->unsigned int
        public uint lbStyle;

        /// COLORREF->DWORD->unsigned int
        public uint lbColor;

        /// ULONG_PTR->unsigned int
        public uint lbHatch;
    }
}