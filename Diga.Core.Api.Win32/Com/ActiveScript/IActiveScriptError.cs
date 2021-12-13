using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using EXCEPINFO = System.Runtime.InteropServices.ComTypes.EXCEPINFO;

namespace Diga.Core.Api.Win32.Com.ActiveScript
{
    [Guid("EAE1BA61-A4ED-11CF-8F20-00805F2CD064")]
    [InterfaceType(1)]
    [ComImport]
    public interface IActiveScriptError
    {
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetExceptionInfo([MarshalAs(UnmanagedType.LPArray), Out] EXCEPINFO[] pexcepinfo);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetSourcePosition(
            out uint pdwSourceContext,
            out uint pulLineNumber,
            out int plCharacterPosition);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetSourceLineText([MarshalAs(UnmanagedType.BStr)] out string pbstrSourceLine);
    }
}