using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using EXCEPINFO = System.Runtime.InteropServices.ComTypes.EXCEPINFO;

namespace Diga.Core.Api.Win32.Com.ActiveScript
{
    [Guid("BB1A2AE2-A4F9-11CF-8F20-00805F2CD064")]
    [InterfaceType(1)]
    [ComImport]
    public interface IActiveScriptParse32
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
            [In] uint dwSourceContextCookie,
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
            [In] uint dwSourceContextCookie,
            [In] uint ulStartingLineNumber,
            [In] uint dwFlags,
            [MarshalAs(UnmanagedType.Struct)] out object pvarResult,
            [MarshalAs(UnmanagedType.LPArray), Out] EXCEPINFO[] pexcepinfo);
    }
}