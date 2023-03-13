using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Com.ActiveScript
{
    /// <summary>
    /// If the Windows Script engine allows the source code text for procedures to be added to the script,
    /// it implements the IActiveScriptParseProcedure interface.
    /// For interpreted scripting languages that have no independent authoring environment,
    /// such as VBScript, this provides an alternate mechanism (other than IActiveScriptParse or IPersist*)
    /// to add script procedures to the namespace.
    /// </summary>
    [Guid("AA5B6A80-B834-11D0-932F-00A0C90DCAA9")]
    [InterfaceType(1)]
    [ComImport]
    public interface IActiveScriptParseProcedure32
    {
        /// <summary>
        /// Parses the given code procedure and adds the procedure to the name space.
        /// </summary>
        /// <param name="pstrCode">[in] Address of the procedure text to evaluate. The interpretation of this string depends on the scripting language.</param>
        /// <param name="pstrFormalParams">[in] Address of formal parameter names for the procedure. The parameter names must be separated with the appropriate delimiters for the scripting engine. The names should not be enclosed in parentheses.</param>
        /// <param name="pstrProcedureName">[in] Address of procedure name to be parsed.</param>
        /// <param name="pstrItemName">[in] Address of the item name that gives the context in which the procedure is to be evaluated. If this parameter is NULL, the code is evaluated in the scripting engine's global context.</param>
        /// <param name="punkContext">[in] Address of the context object. This object is reserved for use in a debugging environment, where such a context may be provided by the debugger to represent an active run-time context. If this parameter is NULL, the engine uses pstrItemName to identify the context.</param>
        /// <param name="pstrDelimiter">[in] Address of the end-of-procedure delimiter. When pstrCode is parsed from a stream of text, the host typically uses a delimiter, such as two single quotation marks (''), to detect the end of the procedure. This parameter specifies the delimiter that the host used, allowing the scripting engine to provide some conditional primitive preprocessing (for example, replacing a single quotation mark ['] with two single quotation marks for use as a delimiter). Exactly how (and if) the scripting engine makes use of this information depends on the scripting engine. Set this parameter to NULL if the host did not use a delimiter to mark the end of the procedure.</param>
        /// <param name="dwSourceContextCookie">[in] Application-defined value that is used for debugging purposes.</param>
        /// <param name="ulStartingLineNumber">[in] Zero-based value that specifies which line the parsing will begin at.</param>
        /// <param name="dwFlags"></param>
        /// <param name="ppdisp"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int ParseProcedureText(
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