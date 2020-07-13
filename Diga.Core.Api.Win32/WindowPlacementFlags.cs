using System;

namespace Diga.Core.Api.Win32
{
    [Flags]
    public enum WindowPlacementFlags : uint
    {
        WPF_SETMINPOSITION = WindowPlacementFlagConst.WPF_SETMINPOSITION,
        WPF_RESTORETOMAXIMIZED = WindowPlacementFlagConst.WPF_RESTORETOMAXIMIZED,
        WPF_ASYNCWINDOWPLACEMENT = WindowPlacementFlagConst.WPF_ASYNCWINDOWPLACEMENT,
    }
}