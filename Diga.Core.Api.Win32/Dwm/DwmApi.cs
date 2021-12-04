using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Dwm
{
    public static class DwmApi
    {

        private const string DWMAPIDLL = "dwmapi.dll";
     
        [DllImport(DWMAPIDLL, EntryPoint = "DwmDefWindowProc", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DwmDefWindowProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam, ref int plResult);


       
        [DllImport(DWMAPIDLL, EntryPoint = "DwmEnableBlurBehindWindow", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmEnableBlurBehindWindow(IntPtr hWnd, ref DWM_BLURBEHIND pBlurBehind);


       
        [DllImport(DWMAPIDLL, EntryPoint = "DwmEnableComposition", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmEnableComposition(uint uCompositionAction);


       
        [DllImport(DWMAPIDLL, EntryPoint = "DwmEnableMMCSS", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmEnableMMCSS([MarshalAs(UnmanagedType.Bool)] bool fEnableMMCSS);


       
        [DllImport(DWMAPIDLL, EntryPoint = "DwmExtendFrameIntoClientArea", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margins pMarInset);


       
        [DllImport(DWMAPIDLL, EntryPoint = "DwmGetColorizationColor", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmGetColorizationColor(ref uint pcrColorization, ref int pfOpaqueBlend);


       
        [DllImport(DWMAPIDLL, EntryPoint = "DwmGetCompositionTimingInfo", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmGetCompositionTimingInfo(IntPtr hwnd, ref DWM_TIMING_INFO pTimingInfo);


        [DllImport(DWMAPIDLL, EntryPoint = "DwmGetWindowAttribute", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmGetWindowAttribute(IntPtr hwnd, uint dwAttribute, IntPtr pvAttribute, uint cbAttribute);


       
        [DllImport(DWMAPIDLL, EntryPoint = "DwmIsCompositionEnabled", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);


       
        [DllImport(DWMAPIDLL, EntryPoint = "DwmModifyPreviousDxFrameDuration", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmModifyPreviousDxFrameDuration(IntPtr hwnd, int cRefreshes, [MarshalAs(UnmanagedType.Bool)] bool fRelative);


       
        [DllImport(DWMAPIDLL, EntryPoint = "DwmQueryThumbnailSourceSize", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmQueryThumbnailSourceSize(IntPtr hThumbnail, ref Size pSize);


      
        [DllImport(DWMAPIDLL, EntryPoint = "DwmRegisterThumbnail", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmRegisterThumbnail(IntPtr hwndDestination, IntPtr hwndSource, ref IntPtr phThumbnailId);


       
        [DllImport(DWMAPIDLL, EntryPoint = "DwmSetDxFrameDuration", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmSetDxFrameDuration(IntPtr hwnd, int cRefreshes);

        [DllImport(DWMAPIDLL, EntryPoint = "DwmSetPresentParameters", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmSetPresentParameters(IntPtr hwnd, ref DWM_PRESENT_PARAMETERS pPresentParams);


        [DllImport(DWMAPIDLL, EntryPoint = "DwmSetWindowAttribute", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, uint dwAttribute, IntPtr pvAttribute, uint cbAttribute);


        [DllImport(DWMAPIDLL, EntryPoint = "DwmUnregisterThumbnail", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmUnregisterThumbnail(IntPtr hThumbnailId);


        [DllImport(DWMAPIDLL, EntryPoint = "DwmUpdateThumbnailProperties", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmUpdateThumbnailProperties(IntPtr hThumbnailId, ref DWM_THUMBNAIL_PROPERTIES ptnProperties);


        [DllImport(DWMAPIDLL, EntryPoint = "DwmSetIconicThumbnail", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmSetIconicThumbnail(IntPtr hwnd, IntPtr hbmp, uint dwSITFlags);


        [DllImport(DWMAPIDLL, EntryPoint = "DwmSetIconicLivePreviewBitmap", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmSetIconicLivePreviewBitmap(IntPtr hwnd, IntPtr hbmp, ref Point pptClient, uint dwSITFlags);


        [DllImport(DWMAPIDLL, EntryPoint = "DwmInvalidateIconicBitmaps", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmInvalidateIconicBitmaps(IntPtr hwnd);


        [DllImport(DWMAPIDLL, EntryPoint = "DwmAttachMilContent", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmAttachMilContent(IntPtr hwnd);


        [DllImport(DWMAPIDLL, EntryPoint = "DwmDetachMilContent", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmDetachMilContent(IntPtr hwnd);


        [DllImport(DWMAPIDLL, EntryPoint = "DwmFlush", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmFlush();


        [DllImport(DWMAPIDLL, EntryPoint = "DwmGetGraphicsStreamTransformHint", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmGetGraphicsStreamTransformHint(uint uIndex, ref MilMatrix3x2D pTransform);


        [DllImport(DWMAPIDLL, EntryPoint = "DwmGetGraphicsStreamClient", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmGetGraphicsStreamClient(uint uIndex, ref Guid pClientUuid);


        [DllImport(DWMAPIDLL, EntryPoint = "DwmGetTransportAttributes", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmGetTransportAttributes(ref int pfIsRemoting, ref int pfIsConnected, ref uint pDwGeneration);


        [DllImport(DWMAPIDLL, EntryPoint = "DwmTransitionOwnedWindow", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmTransitionOwnedWindow(IntPtr hwnd, DWMTRANSITION_OWNEDWINDOW_TARGET target);


        [DllImport(DWMAPIDLL, EntryPoint = "DwmRenderGesture", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmRenderGesture(GESTURE_TYPE gt, uint cContacts, ref uint pdwPointerID, ref Point pPoints);


        [DllImport(DWMAPIDLL, EntryPoint = "DwmTetherContact", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmTetherContact(uint dwPointerID, [MarshalAs(UnmanagedType.Bool)] bool fEnable, Point ptTether);


        [DllImport(DWMAPIDLL, EntryPoint = "DwmShowContact", CallingConvention = CallingConvention.StdCall)]
        public static extern int DwmShowContact(uint dwPointerID, DWM_SHOWCONTACT eShowContact);


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
