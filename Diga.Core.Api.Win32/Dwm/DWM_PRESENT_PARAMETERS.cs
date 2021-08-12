using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Dwm
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DWM_PRESENT_PARAMETERS
    {

        /// UINT32->unsigned int
        public uint cbSize;

        /// BOOL->int
        [MarshalAs(UnmanagedType.Bool)]
        public bool fQueue;

        /// DWM_FRAME_COUNT->ULONGLONG->unsigned __int64
        public ulong cRefreshStart;

        /// UINT->unsigned int
        public uint cBuffer;

        /// BOOL->int
        [MarshalAs(UnmanagedType.Bool)]
        public bool fUseSourceRate;

        /// UNSIGNED_RATIO->_UNSIGNED_RATIO
        public UNSIGNED_RATIO rateSource;

        /// UINT->unsigned int
        public uint cRefreshesPerFrame;

        /// DWM_SOURCE_FRAME_SAMPLING->Anonymous_58420a72_91da_4ea8_a22e_855a24991792
        public DWM_SOURCE_FRAME_SAMPLING eSampling;
    }
}