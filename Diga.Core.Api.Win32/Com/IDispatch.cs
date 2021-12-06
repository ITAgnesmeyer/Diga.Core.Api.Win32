using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Com
{
    [ComImport()]
    [Guid("00020400-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDispatch
    {
        [PreserveSig]
        int GetTypeInfoCount(out int Count);

        [PreserveSig]
        int GetTypeInfo
        (
            [MarshalAs(UnmanagedType.U4)] int iTInfo,
            [MarshalAs(UnmanagedType.U4)] int lcid,
            out System.Runtime.InteropServices.ComTypes.ITypeInfo typeInfo
        );

        [PreserveSig]
        int GetIDsOfNames
        (
            ref Guid riid,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)]
            string[] rgsNames,
            int cNames,
            int lcid,
            [MarshalAs(UnmanagedType.LPArray)] int[] rgDispId
        );

        [PreserveSig]
        int Invoke
        (
            int dispIdMember,
            [In] ref Guid riid,
            uint lcid,
            ushort wFlags,
            [Out, In] ref System.Runtime.InteropServices.ComTypes.DISPPARAMS pDispParams,
            [Out] out object pVarResult,
            [Out, In] ref System.Runtime.InteropServices.ComTypes.EXCEPINFO pExcepInfo,
            [Out, MarshalAs(UnmanagedType.LPArray)] IntPtr[] pArgErr
        );
    }
}