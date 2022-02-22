using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Com
{
    [ComImport]
    [Guid("000001ce-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    interface IComThreadingInfo
    {
        APTTYPE GetCurrentApartmentType();
        THDTYPE GetCurrentThreadType();
        Guid GetCurrentLogicalThreadId();
        void SetCurrentLogicalThreadId([In] Guid rguid);
    }
}