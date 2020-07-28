using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SystemTimeRange
    {
        public SystemTime RangeStart;
        public SystemTime RangeEnd;
    }
}