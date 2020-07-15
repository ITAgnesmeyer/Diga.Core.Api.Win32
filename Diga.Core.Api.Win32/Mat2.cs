using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Mat2
    {

        /// FIXED->_FIXED
        public Fixed eM11;

        /// FIXED->_FIXED
        public Fixed eM12;

        /// FIXED->_FIXED
        public Fixed eM21;

        /// FIXED->_FIXED
        public Fixed eM22;
    }
}