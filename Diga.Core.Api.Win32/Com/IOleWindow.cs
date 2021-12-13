using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Com
{
    [Guid("00000114-0000-0000-C000-000000000046")]
    [InterfaceType(1)]
    [ComConversionLoss]
    [ComImport]
    public interface IOleWindow
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetWindow(out IntPtr phwnd);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ContextSensitiveHelp([In] int fEnterMode);
    }
}