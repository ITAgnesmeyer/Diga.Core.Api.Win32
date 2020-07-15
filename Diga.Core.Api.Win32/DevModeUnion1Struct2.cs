using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DevModeUnion1Struct2
    {

        /// POINTL->_POINTL
        public Point dmPosition;

        /// DWORD->unsigned int
        public uint dmDisplayOrientation;

        /// DWORD->unsigned int
        public uint dmDisplayFixedOutput;
    }
}