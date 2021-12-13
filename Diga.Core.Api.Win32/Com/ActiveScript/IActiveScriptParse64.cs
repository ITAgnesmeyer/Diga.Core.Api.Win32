using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using EXCEPINFO = System.Runtime.InteropServices.ComTypes.EXCEPINFO;

namespace Diga.Core.Api.Win32.Com.ActiveScript
{
    [InterfaceType(1)]
    [Guid("C7EF7658-E1EE-480E-97EA-D52CB4D76D17")]
    [ComImport]
    public interface IActiveScriptParse64
    {
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int InitNew();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int AddScriptlet(
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrDefaultName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrCode,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrItemName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrSubItemName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrEventName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrDelimiter,
            [In] ulong dwSourceContextCookie,
            [In] uint ulStartingLineNumber,
            [In] uint dwFlags,
            [MarshalAs(UnmanagedType.BStr)] out string pbstrName,
            [MarshalAs(UnmanagedType.LPArray), Out] EXCEPINFO[] pexcepinfo);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int ParseScriptText(
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrCode,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrItemName,
            [MarshalAs(UnmanagedType.IUnknown), In] object punkContext,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrDelimiter,
            [In] ulong dwSourceContextCookie,
            [In] uint ulStartingLineNumber,
            [In] uint dwFlags,
            [MarshalAs(UnmanagedType.Struct)] out object pvarResult,
            [MarshalAs(UnmanagedType.LPArray), Out] EXCEPINFO[] pexcepinfo);
    }
}