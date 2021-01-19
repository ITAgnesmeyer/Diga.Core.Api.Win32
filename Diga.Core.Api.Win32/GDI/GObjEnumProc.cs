using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.GDI
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int GObjEnumProc(IntPtr param0, IntPtr param1);
}