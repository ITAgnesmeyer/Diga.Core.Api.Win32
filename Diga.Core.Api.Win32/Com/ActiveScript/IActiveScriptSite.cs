using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using EXCEPINFO = System.Runtime.InteropServices.ComTypes.EXCEPINFO;

namespace Diga.Core.Api.Win32.Com.ActiveScript
{
    [Guid("DB01A1E3-A42B-11CF-8F20-00805F2CD064")]
    [InterfaceType(1)]
    [ComImport]
    public interface IActiveScriptSite
    {
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetLCID(out uint plcid);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetItemInfo([MarshalAs(UnmanagedType.LPWStr), In] string pstrName, [In] uint dwReturnMask, [MarshalAs(UnmanagedType.IUnknown)] out object ppiunkItem, [MarshalAs(UnmanagedType.Interface)] ITypeInfo ppti);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetDocVersionString([MarshalAs(UnmanagedType.BStr)] out string pbstrVersion);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int OnScriptTerminate([MarshalAs(UnmanagedType.Struct), In] ref object pvarResult, [MarshalAs(UnmanagedType.LPArray), In] EXCEPINFO[] pexcepinfo);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int OnStateChange([ComAliasName("Microsoft.VisualStudio.Debugger.Interop.SCRIPTSTATE"), In] SCRIPTSTATE ssScriptState);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int OnScriptError([MarshalAs(UnmanagedType.Interface), In] IActiveScriptError pscripterror);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int OnEnterScript();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int OnLeaveScript();
    }
}