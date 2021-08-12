using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Dwm
{
    public static class DwmApi
    {

        private const string DWMAPIDLL = "dwmapi.dll";
        /// Return Type: BOOL->int
        ///hWnd: HWND->HWND__*
        ///msg: UINT->unsigned int
        ///wParam: WPARAM->UINT_PTR->unsigned int
        ///lParam: LPARAM->LONG_PTR->int
        ///plResult: LRESULT*
        [DllImport(DWMAPIDLL, EntryPoint = "DwmDefWindowProc", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DwmDefWindowProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam, ref int plResult);


        /// Return Type: HRESULT->LONG->int
        ///hWnd: HWND->HWND__*
        ///pBlurBehind: DWM_BLURBEHIND*
        [DllImport(DWMAPIDLL, EntryPoint = "DwmEnableBlurBehindWindow", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmEnableBlurBehindWindow(IntPtr hWnd, ref DWM_BLURBEHIND pBlurBehind);


        /// Return Type: HRESULT->LONG->int
        ///uCompositionAction: UINT->unsigned int
        [DllImport(DWMAPIDLL, EntryPoint = "DwmEnableComposition", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmEnableComposition(uint uCompositionAction);


        /// Return Type: HRESULT->LONG->int
        ///fEnableMMCSS: BOOL->int
        [DllImport(DWMAPIDLL, EntryPoint = "DwmEnableMMCSS", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmEnableMMCSS([MarshalAs(UnmanagedType.Bool)] bool fEnableMMCSS);


        /// Return Type: HRESULT->LONG->int
        ///hWnd: HWND->HWND__*
        ///pMarInset: MARGINS*
        [DllImport(DWMAPIDLL, EntryPoint = "DwmExtendFrameIntoClientArea", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margins pMarInset);


        /// Return Type: HRESULT->LONG->int
        ///pcrColorization: DWORD*
        ///pfOpaqueBlend: BOOL*
        [DllImport(DWMAPIDLL, EntryPoint = "DwmGetColorizationColor", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmGetColorizationColor(ref uint pcrColorization, ref int pfOpaqueBlend);


        /// Return Type: HRESULT->LONG->int
        ///hwnd: HWND->HWND__*
        ///pTimingInfo: DWM_TIMING_INFO*
        [DllImport(DWMAPIDLL, EntryPoint = "DwmGetCompositionTimingInfo", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmGetCompositionTimingInfo(IntPtr hwnd, ref DWM_TIMING_INFO pTimingInfo);


        /// Return Type: HRESULT->LONG->int
        ///hwnd: HWND->HWND__*
        ///dwAttribute: DWORD->unsigned int
        ///pvAttribute: PVOID->void*
        ///cbAttribute: DWORD->unsigned int
        [DllImport(DWMAPIDLL, EntryPoint = "DwmGetWindowAttribute", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmGetWindowAttribute(IntPtr hwnd, uint dwAttribute, IntPtr pvAttribute, uint cbAttribute);


        /// Return Type: HRESULT->LONG->int
        ///pfEnabled: BOOL*
        [DllImport(DWMAPIDLL, EntryPoint = "DwmIsCompositionEnabled", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);


        /// Return Type: HRESULT->LONG->int
        ///hwnd: HWND->HWND__*
        ///cRefreshes: INT->int
        ///fRelative: BOOL->int
        [DllImport(DWMAPIDLL, EntryPoint = "DwmModifyPreviousDxFrameDuration", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmModifyPreviousDxFrameDuration(IntPtr hwnd, int cRefreshes, [MarshalAs(UnmanagedType.Bool)] bool fRelative);


        /// Return Type: HRESULT->LONG->int
        ///hThumbnail: HTHUMBNAIL->HANDLE->void*
        ///pSize: PSIZE->tagSIZE*
        [DllImport(DWMAPIDLL, EntryPoint = "DwmQueryThumbnailSourceSize", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmQueryThumbnailSourceSize(IntPtr hThumbnail, ref Size pSize);


        /// Return Type: HRESULT->LONG->int
        ///hwndDestination: HWND->HWND__*
        ///hwndSource: HWND->HWND__*
        ///phThumbnailId: PHTHUMBNAIL->HTHUMBNAIL*
        [DllImport(DWMAPIDLL, EntryPoint = "DwmRegisterThumbnail", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmRegisterThumbnail(IntPtr hwndDestination, IntPtr hwndSource, ref IntPtr phThumbnailId);


        /// Return Type: HRESULT->LONG->int
        ///hwnd: HWND->HWND__*
        ///cRefreshes: INT->int
        [DllImport(DWMAPIDLL, EntryPoint = "DwmSetDxFrameDuration", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmSetDxFrameDuration(IntPtr hwnd, int cRefreshes);


        /// Return Type: HRESULT->LONG->int
        ///hwnd: HWND->HWND__*
        ///pPresentParams: DWM_PRESENT_PARAMETERS*
        [DllImport(DWMAPIDLL, EntryPoint = "DwmSetPresentParameters", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmSetPresentParameters(IntPtr hwnd, ref DWM_PRESENT_PARAMETERS pPresentParams);


        /// Return Type: HRESULT->LONG->int
        ///hwnd: HWND->HWND__*
        ///dwAttribute: DWORD->unsigned int
        ///pvAttribute: LPCVOID->void*
        ///cbAttribute: DWORD->unsigned int
        [DllImport(DWMAPIDLL, EntryPoint = "DwmSetWindowAttribute", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, uint dwAttribute, IntPtr pvAttribute, uint cbAttribute);


        /// Return Type: HRESULT->LONG->int
        ///hThumbnailId: HTHUMBNAIL->HANDLE->void*
        [DllImport(DWMAPIDLL, EntryPoint = "DwmUnregisterThumbnail", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmUnregisterThumbnail(IntPtr hThumbnailId);


        /// Return Type: HRESULT->LONG->int
        ///hThumbnailId: HTHUMBNAIL->HANDLE->void*
        ///ptnProperties: DWM_THUMBNAIL_PROPERTIES*
        [DllImport(DWMAPIDLL, EntryPoint = "DwmUpdateThumbnailProperties", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmUpdateThumbnailProperties(IntPtr hThumbnailId, ref DWM_THUMBNAIL_PROPERTIES ptnProperties);


        /// Return Type: HRESULT->LONG->int
        ///hwnd: HWND->HWND__*
        ///hbmp: HBITMAP->HBITMAP__*
        ///dwSITFlags: DWORD->unsigned int
        [DllImport(DWMAPIDLL, EntryPoint = "DwmSetIconicThumbnail", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmSetIconicThumbnail(IntPtr hwnd, IntPtr hbmp, uint dwSITFlags);


        /// Return Type: HRESULT->LONG->int
        ///hwnd: HWND->HWND__*
        ///hbmp: HBITMAP->HBITMAP__*
        ///pptClient: POINT*
        ///dwSITFlags: DWORD->unsigned int
        [DllImport(DWMAPIDLL, EntryPoint = "DwmSetIconicLivePreviewBitmap", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmSetIconicLivePreviewBitmap(IntPtr hwnd, IntPtr hbmp, ref Point pptClient, uint dwSITFlags);


        /// Return Type: HRESULT->LONG->int
        ///hwnd: HWND->HWND__*
        [DllImport(DWMAPIDLL, EntryPoint = "DwmInvalidateIconicBitmaps", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmInvalidateIconicBitmaps(IntPtr hwnd);


        /// Return Type: HRESULT->LONG->int
        ///hwnd: HWND->HWND__*
        [DllImport(DWMAPIDLL, EntryPoint = "DwmAttachMilContent", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmAttachMilContent(IntPtr hwnd);


        /// Return Type: HRESULT->LONG->int
        ///hwnd: HWND->HWND__*
        [DllImport(DWMAPIDLL, EntryPoint = "DwmDetachMilContent", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmDetachMilContent(IntPtr hwnd);


        /// Return Type: HRESULT->LONG->int
        [DllImport(DWMAPIDLL, EntryPoint = "DwmFlush", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmFlush();


        /// Return Type: HRESULT->LONG->int
        ///uIndex: UINT->unsigned int
        ///pTransform: MilMatrix3x2D*
        [DllImport(DWMAPIDLL, EntryPoint = "DwmGetGraphicsStreamTransformHint", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmGetGraphicsStreamTransformHint(uint uIndex, ref MilMatrix3x2D pTransform);


        /// Return Type: HRESULT->LONG->int
        ///uIndex: UINT->unsigned int
        ///pClientUuid: UUID*
        [DllImport(DWMAPIDLL, EntryPoint = "DwmGetGraphicsStreamClient", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmGetGraphicsStreamClient(uint uIndex, ref Guid pClientUuid);


        /// Return Type: HRESULT->LONG->int
        ///pfIsRemoting: BOOL*
        ///pfIsConnected: BOOL*
        ///pDwGeneration: DWORD*
        [DllImport(DWMAPIDLL, EntryPoint = "DwmGetTransportAttributes", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmGetTransportAttributes(ref int pfIsRemoting, ref int pfIsConnected, ref uint pDwGeneration);


        /// Return Type: HRESULT->LONG->int
        ///hwnd: HWND->HWND__*
        ///target: DWMTRANSITION_OWNEDWINDOW_TARGET
        [DllImport(DWMAPIDLL, EntryPoint = "DwmTransitionOwnedWindow", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmTransitionOwnedWindow(IntPtr hwnd, DWMTRANSITION_OWNEDWINDOW_TARGET target);


        /// Return Type: HRESULT->LONG->int
        ///gt: GESTURE_TYPE
        ///cContacts: UINT->unsigned int
        ///pdwPointerID: DWORD*
        ///pPoints: POINT*
        [DllImport(DWMAPIDLL, EntryPoint = "DwmRenderGesture", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmRenderGesture(GESTURE_TYPE gt, uint cContacts, ref uint pdwPointerID, ref Point pPoints);


        /// Return Type: HRESULT->LONG->int
        ///dwPointerID: DWORD->unsigned int
        ///fEnable: BOOL->int
        ///ptTether: POINT->tagPOINT
        [DllImport(DWMAPIDLL, EntryPoint = "DwmTetherContact", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmTetherContact(uint dwPointerID, [MarshalAs(UnmanagedType.Bool)] bool fEnable, Point ptTether);


        /// Return Type: HRESULT->LONG->int
        ///dwPointerID: DWORD->unsigned int
        ///eShowContact: DWM_SHOWCONTACT
        [DllImport(DWMAPIDLL, EntryPoint = "DwmShowContact", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmShowContact(uint dwPointerID, DWM_SHOWCONTACT eShowContact);


        /// Return Type: HRESULT->LONG->int
        ///appWindow: HWND->HWND__*
        ///value: DWM_TAB_WINDOW_REQUIREMENTS*
        [DllImport(DWMAPIDLL, EntryPoint = "DwmGetUnmetTabRequirements", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmGetUnmetTabRequirements(IntPtr appWindow, ref DWM_TAB_WINDOW_REQUIREMENTS value);

        public static IntPtr HitTestNCA(IntPtr hWnd, IntPtr wParam, IntPtr lParam, Margins frameMargins)
        {
            HighLow lParamHighLow = Win32Api.MakeHiLo(lParam);
            Point mousePoint = new Point(lParamHighLow.iLow, lParamHighLow.iHigh);

            User32.GetWindowRect(hWnd, out Rect windowRect);
            Rect frameRect = new Rect(0, 0, 0, 0);
            User32.AdjustWindowRectEx(ref frameRect,
                WindowStylesConst.WS_OVERLAPPEDWINDOW & ~WindowStylesConst.WS_CAPTION, false, 0);
            ushort row = 1;
            ushort col = 1;
            bool onResizeBorder = false;

            if (mousePoint.Y > windowRect.Top && mousePoint.Y < windowRect.Top + frameMargins.cyTopHeight)
            {
                onResizeBorder = (mousePoint.Y < (windowRect.Top - frameRect.Top));
                row = 0;
            }
            else if (mousePoint.Y < windowRect.Bottom &&
                     mousePoint.Y >= windowRect.Bottom - frameMargins.cyBottomHeight)
            {
                row = 2;
            }

            if (mousePoint.X >= windowRect.Left && mousePoint.X < windowRect.Left + frameMargins.cxLeftWidth)
            {
                col = 0;
            }
            else if (mousePoint.X < windowRect.Right && mousePoint.X >= windowRect.Right - frameMargins.cxRightWidth)
            {
                col = 2;
            }

            int[,] hitTest =
            {
                {DwmApiConstants.HTTOPLEFT, onResizeBorder ? DwmApiConstants.HTTOP: DwmApiConstants.HTCAPTION, DwmApiConstants.HTTOPRIGHT},
                {DwmApiConstants.HTLEFT, DwmApiConstants.HTNOWHERE, DwmApiConstants.HTRIGHT},
                {DwmApiConstants.HTBOTTOMLEFT, DwmApiConstants.HTBOTTOM, DwmApiConstants.HTBOTTOMRIGHT}
            };

            return (IntPtr) hitTest[row, col];
        }
    }

}
