using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int EnhMfEnumProc([In] IntPtr hdc, [In] IntPtr lpht, [In] ref EnhMetaRecord lpmr, int hHandles, [In] IntPtr data);
}