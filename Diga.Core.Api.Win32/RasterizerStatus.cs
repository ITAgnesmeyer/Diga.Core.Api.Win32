using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RasterizerStatus
    {

        /// short
        public short nSize;

        /// short
        public short wFlags;

        /// short
        public short nLanguageID;
    }
}