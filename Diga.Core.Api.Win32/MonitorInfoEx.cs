using System.Runtime.InteropServices;


namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
    public struct MonitorInfoEx 
    {
    
        public uint cbSize;
    
        public Rect rcMonitor;
    
        public Rect rcWork;
    
        public uint dwFlags;
        
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=32)]
        public string szDevice;

        
    }
}