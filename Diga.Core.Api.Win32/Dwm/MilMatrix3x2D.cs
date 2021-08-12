using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Dwm
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MilMatrix3x2D
    {

        /// DOUBLE->double
        public double S_11;

        /// DOUBLE->double
        public double S_12;

        /// DOUBLE->double
        public double S_21;

        /// DOUBLE->double
        public double S_22;

        /// DOUBLE->double
        public double DX;

        /// DOUBLE->double
        public double DY;
    }
}