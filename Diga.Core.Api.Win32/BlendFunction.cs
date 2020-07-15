using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BlendFunction
    {

        /// BYTE->unsigned char
        public byte BlendOp;

        /// BYTE->unsigned char
        public byte BlendFlags;

        /// BYTE->unsigned char
        public byte SourceConstantAlpha;

        /// BYTE->unsigned char
        public byte AlphaFormat;
    }
}