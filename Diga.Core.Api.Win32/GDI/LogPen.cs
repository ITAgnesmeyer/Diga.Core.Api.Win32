using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.GDI
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LogPen
    {

        /// UINT->unsigned int
        public uint lopnStyle;

        /// POINT->tagPOINT
        public Point lopnWidth;

        /// COLORREF->DWORD->unsigned int
        public uint lopnColor;
    }
}