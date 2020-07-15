using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DevModeUnion1Struct1
    {

        /// short
        public short dmOrientation;

        /// short
        public short dmPaperSize;

        /// short
        public short dmPaperLength;

        /// short
        public short dmPaperWidth;

        /// short
        public short dmScale;

        /// short
        public short dmCopies;

        /// short
        public short dmDefaultSource;

        /// short
        public short dmPrintQuality;
    }
}