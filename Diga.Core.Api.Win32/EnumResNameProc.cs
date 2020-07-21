using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall,CharSet =CharSet.Auto)]
    public delegate int EnumResNameProc([In] IntPtr hModule, [In] string lpType, [In] string lpName, [In] IntPtr lParam);
}