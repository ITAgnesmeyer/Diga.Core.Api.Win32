using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Com.ActiveScript
{
    [Guid("FE7C4271-210C-448D-9F54-76DAB7047B28")]
    [InterfaceType(1)]
    [ComImport]
    public interface IActiveScriptParseProcedure2_64 : IActiveScriptParseProcedure64
    {
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new int ParseProcedureText(
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrCode,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrFormalParams,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrProcedureName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrItemName,
            [MarshalAs(UnmanagedType.IUnknown), In] object punkContext,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrDelimiter,
            [In] ulong dwSourceContextCookie,
            [In] uint ulStartingLineNumber,
            [In] uint dwFlags,
            [MarshalAs(UnmanagedType.IDispatch)] out object ppdisp);
    }
}