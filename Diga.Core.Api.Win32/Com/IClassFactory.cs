using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Com
{
    [ComImport]
    [Guid("00000001-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IClassFactory
    {
        [PreserveSig]
        int CreateInstance([In] IntPtr pUnkOuter, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid, [Out] out IntPtr ppvObject);
        [PreserveSig]
        int LockServer([In] bool fLock);
    }
}