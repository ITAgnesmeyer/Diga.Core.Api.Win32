using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Com.ActiveScript
{
    [Guid("71EE5B20-FB04-11D1-B3A8-00A0C911E8B2")]
    [InterfaceType(1)]
    [ComImport]
    public interface IActiveScriptParseProcedure2_32 : IActiveScriptParseProcedure32
    {
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new int ParseProcedureText(
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrCode,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrFormalParams,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrProcedureName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrItemName,
            [MarshalAs(UnmanagedType.IUnknown), In] object punkContext,
            [MarshalAs(UnmanagedType.LPWStr), In] string pstrDelimiter,
            [In] uint dwSourceContextCookie,
            [In] uint ulStartingLineNumber,
            [In] uint dwFlags,
            [MarshalAs(UnmanagedType.IDispatch)] out object ppdisp);
    }
}