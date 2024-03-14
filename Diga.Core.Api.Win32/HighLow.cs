
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    public static class HiLowExtension
    {
        public static int X(this HighLow input)
        {
            return input.iLow;
        }
        public static int Y(this HighLow input)
        {
            return input.iHigh;
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct HighLow
    {
        public int iLow;
        public int iHigh;
    }
}