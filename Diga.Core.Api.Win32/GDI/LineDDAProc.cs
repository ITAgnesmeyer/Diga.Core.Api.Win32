using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.GDI
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void LineDDAProc(int param0, int param1, IntPtr param2);
}