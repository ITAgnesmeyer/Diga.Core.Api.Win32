using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Com
{
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