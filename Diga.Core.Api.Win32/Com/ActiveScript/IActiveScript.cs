using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EXCEPINFO = System.Runtime.InteropServices.ComTypes.EXCEPINFO;

namespace Diga.Core.Api.Win32.Com.ActiveScript
{
    [Guid("BB1A2AE1-A4F9-11CF-8F20-00805F2CD064")]
    [InterfaceType(1)]
    [ComImport]
    public interface IActiveScript
    {
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int SetScriptSite([MarshalAs(UnmanagedType.Interface), In] IActiveScriptSite pass);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetScriptSite([In] ref Guid riid, out IntPtr ppvObject);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int SetScriptState([ComAliasName("Microsoft.VisualStudio.Debugger.Interop.SCRIPTSTATE"), In] SCRIPTSTATE ss);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetScriptState([ComAliasName("Microsoft.VisualStudio.Debugger.Interop.SCRIPTSTATE"), MarshalAs(UnmanagedType.LPArray), Out] SCRIPTSTATE[] pssState);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int Close();

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int AddNamedItem([MarshalAs(UnmanagedType.LPWStr), In] string pstrName, [In] uint dwFlags);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int AddTypeLib([In] ref Guid rguidTypeLib, [In] uint dwMajor, [In] uint dwMinor, [In] uint dwFlags);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetScriptDispatch([MarshalAs(UnmanagedType.LPWStr), In] string pstrItemName, [MarshalAs(UnmanagedType.IDispatch)] out object ppdisp);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetCurrentScriptThreadID([ComAliasName("Microsoft.VisualStudio.Debugger.Interop.SCRIPTTHREADID")] out uint pstidThread);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetScriptThreadID([In] uint dwWin32ThreadId, [ComAliasName("Microsoft.VisualStudio.Debugger.Interop.SCRIPTTHREADID")] out uint pstidThread);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetScriptThreadState([ComAliasName("Microsoft.VisualStudio.Debugger.Interop.SCRIPTTHREADID"), In] uint stidThread, [ComAliasName("Microsoft.VisualStudio.Debugger.Interop.SCRIPTTHREADSTATE"), MarshalAs(UnmanagedType.LPArray), Out] SCRIPTTHREADSTATE[] pstsState);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int InterruptScriptThread([ComAliasName("Microsoft.VisualStudio.Debugger.Interop.SCRIPTTHREADID"), In] uint stidThread, [MarshalAs(UnmanagedType.LPArray), In] EXCEPINFO[] pexcepinfo, [In] uint dwFlags);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int Clone([MarshalAs(UnmanagedType.Interface)] out IActiveScript ppscript);
    }
}