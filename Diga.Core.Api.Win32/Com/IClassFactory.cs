using System;
using System.Runtime.InteropServices;
#if NET8_0_OR_GREATER

//using System.Runtime.InteropServices.Marshalling;
#endif
namespace Diga.Core.Api.Win32.Com
{


//#if NET8_0_OR_GREATER
//    [Guid("00000001-0000-0000-C000-000000000046")]
//    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
//    [GeneratedComInterface]
//    public partial interface IClassFactory
//    {
//        [PreserveSig]
//        int CreateInstance(IntPtr pUnkOuter, GUID riid, [MarshalAs(UnmanagedType.Interface)] out IntPtr ppvObject);
//        [PreserveSig]
//        int LockServer([MarshalAs(UnmanagedType.Bool)] bool fLock);
//    }
//#else

    [ComImport]
    [Guid("00000001-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IClassFactory
    {
        [PreserveSig]
        int CreateInstance([In] IntPtr pUnkOuter, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid, [Out] out IntPtr ppvObject);
        [PreserveSig]
        int LockServer([In, MarshalAs(UnmanagedType.Bool)] bool fLock);
    }
//#endif
}