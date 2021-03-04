namespace Diga.Core.Api.Win32
{
    [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall)]
    public delegate int WndEumProc(System.IntPtr hWnd, System.IntPtr lParam);
}