using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    /// Return Type: LRESULT->LONG_PTR->int
    ///param0: HWND->HWND__*
    ///param1: UINT->unsigned int
    ///param2: WPARAM->UINT_PTR->unsigned int
    ///param3: LPARAM->LONG_PTR->int
    [UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall)]
    public delegate int WndProc(System.IntPtr param0, uint param1, System.IntPtr param2, System.IntPtr param3);

}