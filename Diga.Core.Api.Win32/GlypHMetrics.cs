using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GlypHMetrics
    {

        /// UINT->unsigned int
        public uint gmBlackBoxX;

        /// UINT->unsigned int
        public uint gmBlackBoxY;

        /// POINT->tagPOINT
        public Point gmptGlyphOrigin;

        /// short
        public short gmCellIncX;

        /// short
        public short gmCellIncY;
    }
}