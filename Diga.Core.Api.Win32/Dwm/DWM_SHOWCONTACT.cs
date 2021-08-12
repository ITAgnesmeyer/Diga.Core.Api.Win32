namespace Diga.Core.Api.Win32.Dwm
{
    public enum DWM_SHOWCONTACT
    {

        /// DWMSC_DOWN -> 0x00000001
        DWMSC_DOWN = 1,

        /// DWMSC_UP -> 0x00000002
        DWMSC_UP = 2,

        /// DWMSC_DRAG -> 0x00000004
        DWMSC_DRAG = 4,

        /// DWMSC_HOLD -> 0x00000008
        DWMSC_HOLD = 8,

        /// DWMSC_PENBARREL -> 0x00000010
        DWMSC_PENBARREL = 16,

        /// DWMSC_NONE -> 0x00000000
        DWMSC_NONE = 0,

        /// DWMSC_ALL -> 0xFFFFFFFF
        DWMSC_ALL = -1,
    }
}