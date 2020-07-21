using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall,CharSet = CharSet.Auto)]
    public delegate int EnumResLangProc([In] IntPtr hModule, [In]  string lpType, [In]  string lpName, ushort wLanguage, [In] IntPtr lParam);
}