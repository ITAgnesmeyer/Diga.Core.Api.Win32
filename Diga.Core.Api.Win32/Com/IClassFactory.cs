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


    internal interface IUnkCaller
    {
        int QueryInterface(IntPtr thisPtr, ref Guid riid, out IntPtr ppvObject);

        int AddRef(IntPtr thisPtr);

        int Release(IntPtr thisPtr);
    }


    public class UnknownWrapper : IUnkCaller, IClassFactory
    {
        private ApiHandleRef ThisPtr;

        public UnknownWrapper(IntPtr ptr)
        {
            this.ThisPtr = ptr;
        }
        int IUnkCaller.QueryInterface(IntPtr thisPtr, ref Guid riid, out IntPtr ppvObject)
        {
                return Marshal.QueryInterface(thisPtr, ref riid, out ppvObject);
        }

        int IUnkCaller.AddRef(IntPtr thisPtr)
        {
            return Marshal.AddRef(thisPtr);
        }

        int IUnkCaller.Release(IntPtr thisPtr)
        {
            return Marshal.Release(thisPtr);
        }

        int IClassFactory.CreateInstance(IntPtr pUnkOuter, Guid riid, out IntPtr ppvObject)
        {
            return ((IUnkCaller) this).QueryInterface(pUnkOuter, ref riid, out ppvObject);
        }

        int IClassFactory.LockServer( bool fLock)
        {
            return Ole32.CoLockObjectExternal(this.ThisPtr, fLock, true);
        }

        
    }
}