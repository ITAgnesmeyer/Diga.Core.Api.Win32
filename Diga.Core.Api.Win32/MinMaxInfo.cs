namespace Diga.Core.Api.Win32
{
    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct MinMaxInfo {
    
        /// POINT->tagPOINT
        public Point ptReserved;
    
        /// POINT->tagPOINT
        public Point ptMaxSize;
    
        /// POINT->tagPOINT
        public Point ptMaxPosition;
    
        /// POINT->tagPOINT
        public Point ptMinTrackSize;
    
        /// POINT->tagPOINT
        public Point ptMaxTrackSize;
    }
}