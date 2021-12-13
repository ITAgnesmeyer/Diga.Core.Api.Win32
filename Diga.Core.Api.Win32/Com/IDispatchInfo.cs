using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Com
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("00020400-0000-0000-C000-000000000046")]
    public interface IDispatchInfo
    {
        [PreserveSig]
        int GetTypeInfoCount(out int typeInfoCount);

        void GetTypeInfo(int typeInfoIndex, int lcid, out IntPtr typeInfo);

        [PreserveSig]
        int GetDispId(ref Guid riid, ref string name, int nameCount, int lcid, out int dispId);

        // NOTE: The real IDispatch also has an Invoke method next, but we don't need it.
    }
}