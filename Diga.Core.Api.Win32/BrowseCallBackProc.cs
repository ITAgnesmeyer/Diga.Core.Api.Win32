using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int BrowseCallBackProc(IntPtr hwnd, uint msg, IntPtr lp, IntPtr wp);
}