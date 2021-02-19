using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Diga.Core.Api.Win32.Com
{
    [ComImport()]
    [Guid("00000002-0000-0000-c000-000000000046")]
    [InterfaceType(System.Runtime.InteropServices.ComInterfaceType.InterfaceIsIUnknown)]
    [SuppressUnmanagedCodeSecurity()]
    public interface IMalloc
    {
        [PreserveSig]
        IntPtr Alloc(int cb);

        [PreserveSig]
        IntPtr Realloc(IntPtr pv, int cb);

        [PreserveSig]
        void Free(IntPtr pv);

        [PreserveSig]
        int GetSize(IntPtr pv);

        [PreserveSig]
        int DidAlloc(IntPtr pv);

        [PreserveSig]
        void HeapMinimize();
    }
}