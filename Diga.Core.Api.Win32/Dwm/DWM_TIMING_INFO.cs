using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Dwm
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DWM_TIMING_INFO
    {

        /// UINT32->unsigned int
        public uint cbSize;

        /// UNSIGNED_RATIO->_UNSIGNED_RATIO
        public UNSIGNED_RATIO rateRefresh;

        /// QPC_TIME->ULONGLONG->unsigned __int64
        public ulong qpcRefreshPeriod;

        /// UNSIGNED_RATIO->_UNSIGNED_RATIO
        public UNSIGNED_RATIO rateCompose;

        /// QPC_TIME->ULONGLONG->unsigned __int64
        public ulong qpcVBlank;

        /// DWM_FRAME_COUNT->ULONGLONG->unsigned __int64
        public ulong cRefresh;

        /// UINT->unsigned int
        public uint cDXRefresh;

        /// QPC_TIME->ULONGLONG->unsigned __int64
        public ulong qpcCompose;

        /// DWM_FRAME_COUNT->ULONGLONG->unsigned __int64
        public ulong cFrame;

        /// UINT->unsigned int
        public uint cDXPresent;

        /// DWM_FRAME_COUNT->ULONGLONG->unsigned __int64
        public ulong cRefreshFrame;

        /// DWM_FRAME_COUNT->ULONGLONG->unsigned __int64
        public ulong cFrameSubmitted;

        /// UINT->unsigned int
        public uint cDXPresentSubmitted;

        /// DWM_FRAME_COUNT->ULONGLONG->unsigned __int64
        public ulong cFrameConfirmed;

        /// UINT->unsigned int
        public uint cDXPresentConfirmed;

        /// DWM_FRAME_COUNT->ULONGLONG->unsigned __int64
        public ulong cRefreshConfirmed;

        /// UINT->unsigned int
        public uint cDXRefreshConfirmed;

        /// DWM_FRAME_COUNT->ULONGLONG->unsigned __int64
        public ulong cFramesLate;

        /// UINT->unsigned int
        public uint cFramesOutstanding;

        /// DWM_FRAME_COUNT->ULONGLONG->unsigned __int64
        public ulong cFrameDisplayed;

        /// QPC_TIME->ULONGLONG->unsigned __int64
        public ulong qpcFrameDisplayed;

        /// DWM_FRAME_COUNT->ULONGLONG->unsigned __int64
        public ulong cRefreshFrameDisplayed;

        /// DWM_FRAME_COUNT->ULONGLONG->unsigned __int64
        public ulong cFrameComplete;

        /// QPC_TIME->ULONGLONG->unsigned __int64
        public ulong qpcFrameComplete;

        /// DWM_FRAME_COUNT->ULONGLONG->unsigned __int64
        public ulong cFramePending;

        /// QPC_TIME->ULONGLONG->unsigned __int64
        public ulong qpcFramePending;

        /// DWM_FRAME_COUNT->ULONGLONG->unsigned __int64
        public ulong cFramesDisplayed;

        /// DWM_FRAME_COUNT->ULONGLONG->unsigned __int64
        public ulong cFramesComplete;

        /// DWM_FRAME_COUNT->ULONGLONG->unsigned __int64
        public ulong cFramesPending;

        /// DWM_FRAME_COUNT->ULONGLONG->unsigned __int64
        public ulong cFramesAvailable;

        /// DWM_FRAME_COUNT->ULONGLONG->unsigned __int64
        public ulong cFramesDropped;

        /// DWM_FRAME_COUNT->ULONGLONG->unsigned __int64
        public ulong cFramesMissed;

        /// DWM_FRAME_COUNT->ULONGLONG->unsigned __int64
        public ulong cRefreshNextDisplayed;

        /// DWM_FRAME_COUNT->ULONGLONG->unsigned __int64
        public ulong cRefreshNextPresented;

        /// DWM_FRAME_COUNT->ULONGLONG->unsigned __int64
        public ulong cRefreshesDisplayed;

        /// DWM_FRAME_COUNT->ULONGLONG->unsigned __int64
        public ulong cRefreshesPresented;

        /// DWM_FRAME_COUNT->ULONGLONG->unsigned __int64
        public ulong cRefreshStarted;

        /// ULONGLONG->unsigned __int64
        public ulong cPixelsReceived;

        /// ULONGLONG->unsigned __int64
        public ulong cPixelsDrawn;

        /// DWM_FRAME_COUNT->ULONGLONG->unsigned __int64
        public ulong cBuffersEmpty;
    }
}