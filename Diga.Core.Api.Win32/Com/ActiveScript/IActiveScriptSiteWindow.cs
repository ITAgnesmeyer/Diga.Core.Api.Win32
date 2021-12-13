using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Com.ActiveScript
{
    [ComConversionLoss]
    [InterfaceType(1)]
    [Guid("D10F6761-83E9-11CF-8F20-00805F2CD064")]
    [ComImport]
    public interface IActiveScriptSiteWindow
    {
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetWindow([ComAliasName("Microsoft.VisualStudio.Debugger.Interop.wireHWND")] out IntPtr phwnd);

        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int EnableModeless([In] int fEnable);
    }
}