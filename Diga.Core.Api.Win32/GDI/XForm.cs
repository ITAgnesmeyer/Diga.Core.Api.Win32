using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.GDI
{
    [StructLayout(LayoutKind.Sequential)]
    public struct XForm
    {

        /// FLOAT->float
        public float eM11;

        /// FLOAT->float
        public float eM12;

        /// FLOAT->float
        public float eM21;

        /// FLOAT->float
        public float eM22;

        /// FLOAT->float
        public float eDx;

        /// FLOAT->float
        public float eDy;
    }
}