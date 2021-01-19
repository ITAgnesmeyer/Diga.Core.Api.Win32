using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.GDI
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int MfEnumProc([In()] IntPtr hdc, [In()] IntPtr lpht, [In()] ref MetaRecord lpMR, int nObj, [In()] IntPtr param);
}