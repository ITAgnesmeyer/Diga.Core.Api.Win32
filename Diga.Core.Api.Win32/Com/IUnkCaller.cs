using System;

namespace Diga.Core.Api.Win32.Com
{
    internal interface IUnkCaller
    {
        int QueryInterface(IntPtr thisPtr, ref Guid riid, out IntPtr ppvObject);

        int AddRef(IntPtr thisPtr);

        int Release(IntPtr thisPtr);
    }
}