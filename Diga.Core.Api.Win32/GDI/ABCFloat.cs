using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.GDI
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ABCFloat
    {

        /// FLOAT->float
        public float abcfA;

        /// FLOAT->float
        public float abcfB;

        /// FLOAT->float
        public float abcfC;
    }
}