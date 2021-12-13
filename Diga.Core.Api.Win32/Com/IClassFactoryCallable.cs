using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Com
{


    [ComImport]
    [Guid("00000001-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IClassFactoryCallable
    {
        [return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)]
        object CreateInstance(
            [MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter,
            [In] ref Guid riid);

        void LockServer(
            [MarshalAs(UnmanagedType.Bool)] bool fLock);
    }
}