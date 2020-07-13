using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct MonitorInfo 
    {
        public uint cbSize;
    
        public Rect rcMonitor;
    
        public Rect rcWork;
    
        public uint dwFlags;
    }
}