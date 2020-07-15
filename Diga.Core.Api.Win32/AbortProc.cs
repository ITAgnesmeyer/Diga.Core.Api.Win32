using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int AbortProc([In()] IntPtr param0, int param1);
}