using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Com
{
    [ComImport]
    [Guid("00000114-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleWindow
    {
        IntPtr GetWindow();
        void Dummy_ContextSensitiveHelp();
    }
}