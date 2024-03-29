﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Diga.Core.Api.Win32.GDI;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MENUITEMINFOW
    {

        /// UINT->unsigned int
        public uint cbSize;

        /// UINT->unsigned int
        public uint fMask;

        /// UINT->unsigned int
        public uint fType;

        /// UINT->unsigned int
        public uint fState;

        /// UINT->unsigned int
        public uint wID;

        /// HMENU->HMENU__*
        public IntPtr hSubMenu;

        /// HBITMAP->HBITMAP__*
        public IntPtr hbmpChecked;

        /// HBITMAP->HBITMAP__*
        public IntPtr hbmpUnchecked;

        /// ULONG_PTR->unsigned int
        public uint dwItemData;

        /// LPWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string dwTypeData;

        /// UINT->unsigned int
        public uint cch;

        /// HBITMAP->HBITMAP__*
        public IntPtr hbmpItem;
    }


    public class TrackPopupMenuConst
    {

        public const uint TPM_LEFTBUTTON = 0x0000U;
        public const uint TPM_RIGHTBUTTON = 0x0002U;
        public const uint TPM_LEFTALIGN = 0x0000U;
        public const uint TPM_CENTERALIGN = 0x0004U;
        public const uint TPM_RIGHTALIGN = 0x0008U;
        public const uint TPM_TOPALIGN = 0x0000U;
        public const uint TPM_VCENTERALIGN = 0x0010U;
        public const uint TPM_BOTTOMALIGN = 0x0020U;
        public const uint TPM_HORIZONTAL = 0x0000U     /* Horz alignment matters more */;
        public const uint TPM_VERTICAL = 0x0040U     /* Vert alignment matters more */;
        public const uint TPM_NONOTIFY = 0x0080U     /* Don't send any notification msgs */;
        public const uint TPM_RETURNCMD = 0x0100U;
        public const uint TPM_RECURSE = 0x0001U;
        public const uint TPM_HORPOSANIMATION = 0x0400U;
        public const uint TPM_HORNEGANIMATION = 0x0800U;
        public const uint TPM_VERPOSANIMATION = 0x1000U;
        public const uint TPM_VERNEGANIMATION = 0x2000U;
        public const uint TPM_NOANIMATION = 0x4000U;
        public const uint TPM_LAYOUTRTL = 0x8000U;
        public const uint TPM_WORKAREA = 0x10000U;
    }

    public static partial class User32
    {
        private const string USER32 = "user32.dll";
        private const CharSet CHARSET = CharSet.Auto;

        [DllImport(USER32, EntryPoint = "AdjustWindowRectEx")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AdjustWindowRectEx(ref Rect lpRect, uint dwStyle, [MarshalAs(UnmanagedType.Bool)] bool bMenu, uint dwExStyle);



        [DllImport(USER32, EntryPoint = "SetTimer")]
        public static extern UIntPtr SetTimer([In] IntPtr hWnd, UIntPtr nIdEvent, uint uElapse, TimerProc lpTimerFunc);

        [DllImport(USER32, EntryPoint = "KillTimer")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool KillTimer([In] IntPtr hWnd, UIntPtr uIdEvent);

        [DllImport(USER32, EntryPoint = "UpdateWindow")]
        public static extern bool UpdateWindow(IntPtr hWnd);

        [DllImport(USER32, EntryPoint = "ShowWindow")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport(USER32, EntryPoint = "DestroyWindow", SetLastError = true)]
        public static extern bool DestroyWindow(IntPtr hWnd);

        [DllImport(USER32, EntryPoint = "DestroyMenu")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DestroyMenu([In] IntPtr hMenu);

        /// Return Type: BOOL->int
        ///hMenu: HMENU->HMENU__*
        ///uPosition: UINT->unsigned int
        ///uFlags: UINT->unsigned int
        [DllImport("user32.dll", EntryPoint = "DeleteMenu")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteMenu([In] IntPtr hMenu, uint uPosition, uint uFlags);


        [DllImport(USER32, EntryPoint = "AppendMenu", CharSet = CHARSET)]
        private static extern bool AppendMenu(IntPtr hMenu, MenuFlags uFlags, uint uIdNewItem, string lpNewItem);

        [DllImport(USER32, EntryPoint = "CreateWindowEx", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr CreateWindowEx(uint dwExStyle, [In] string lpClassName, [In] string lpWindowName,
            uint dwStyle, int X, int Y, int nWidth, int nHeight, [In] IntPtr hWndParent, [In] IntPtr hMenu,
            [In] IntPtr hInstance, [In] IntPtr lpParam);

        [DllImport(USER32, EntryPoint = "CreateWindowEx", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr CreateWindowEx(
            int dwExStyle,
            uint lpClassName,
            string lpWindowName,
            uint dwStyle,
            int x,
            int y,
            int nWidth,
            int nHeight,
            IntPtr hWndParent,
            IntPtr hMenu,
            IntPtr hInstance,
            IntPtr lpParam);

        [DllImport(USER32, EntryPoint = "CreateWindowEx", SetLastError = true, CharSet = CHARSET)]
        public static extern IntPtr CreateWindowEx(int dwExStyle, string lpClassName, string lpWindowName, uint dwStyle,
            int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

        [DllImport(USER32, EntryPoint = "CreateDialogParam", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr CreateDialogParam([In] IntPtr hInstance, [In] string lpTemplateName,
            [In] IntPtr hWndParent, DlgProc lpDialogFunc, IntPtr dwInitParam);

        [DllImport(USER32, EntryPoint = "CreateDialogParam", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr CreateDialogParam([In] IntPtr hInstance, [In] IntPtr lpTemplateName,
            [In] IntPtr hWndParent, DlgProc lpDialogFunc, IntPtr dwInitParam);

        public static IntPtr CreateDialog(IntPtr hInstance, string templateName, IntPtr hWndParent, DlgProc dlgFunc)
        {
            return CreateDialogParam(hInstance, templateName, hWndParent, dlgFunc, IntPtr.Zero);
        }

        public static IntPtr CreateDialog(IntPtr hInstance, int templateId, IntPtr hWndParent, DlgProc dlgFunc)
        {
            return CreateDialogParam(hInstance, Win32Api.MakeInterSource(templateId), hWndParent, dlgFunc, IntPtr.Zero);
        }

        [DllImport(USER32, EntryPoint = "CreateDialogIndirectParam", CharSet = CHARSET)]
        public static extern IntPtr CreateDialogIndirectParam([In] IntPtr hInstance, [In] ref DlgTemplate lpTemplate,
            [In] IntPtr hWndParent, DlgProc lpDialogFunc, [MarshalAs(UnmanagedType.SysInt)] int dwInitParam);

        [DllImport(USER32, EntryPoint = "CreateDialogIndirectParam", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr CreateDialogIndirectParamEx([In] IntPtr hInstance, [In] IntPtr lpTemplate,
            [In] IntPtr hWndParent, DlgProc lpDialogFunc, IntPtr dwInitParam);

        public static IntPtr CreateDialogIndirect(IntPtr hInstance, ref DlgTemplate lpTemplate, IntPtr hWndParent,
            DlgProc dlgFunc)
        {
            return CreateDialogIndirectParam(hInstance, ref lpTemplate, hWndParent, dlgFunc, 0);
        }
        [Obsolete("do not use this function anymore")]
        public static IntPtr CreateDialogIndirectEx(IntPtr hInstance, DlgTemplateExOld lpTemplate, IntPtr hWndParent,
            DlgProc dlgFunc)
        {
            using (ApiStructHandleRef<DialogTemplate> pt = new ApiStructHandleRef<DialogTemplate>(lpTemplate))
            {
                return CreateDialogIndirectParamEx(hInstance, pt, hWndParent, dlgFunc, IntPtr.Zero);
            }
        }

        [DllImport(USER32, EntryPoint = "RegisterClassEx", SetLastError = true, CharSet = CHARSET)]
        public static extern ushort RegisterClassEx([In] ref WndclassEx param0);

        [DllImport(USER32, EntryPoint = "UnregisterClass", CharSet = CHARSET)]
        public static extern bool UnregisterClass(string lpClassName, IntPtr hInstance);

        [DllImport(USER32, EntryPoint = "DefWindowProc", CharSet = CHARSET)]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

        [DllImport(USER32, EntryPoint = "PostQuitMessage")]
        public static extern void PostQuitMessage(int nExitCode);

        [DllImport(USER32, EntryPoint = "PostMessage", CharSet = CHARSET, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PostMessage([In] IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);


        [DllImport(USER32, EntryPoint = "PeekMessage", CharSet = CHARSET, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PeekMessage([Out] out MSG lpMsg, [In] IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);


        [DllImport(USER32, EntryPoint = "GetMessage", CharSet = CHARSET)]
        public static extern sbyte GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

        [DllImport(USER32, EntryPoint = "GetClassName", CharSet = CHARSET)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder buf, int nMaxCount);

        public static string GetClassName(IntPtr hWnd)
        {
            StringBuilder sb = new StringBuilder(256);
            int retValue = GetClassName(hWnd, sb, 256);
            return sb.ToString();
        }

        [DllImport(USER32, EntryPoint = "GetClassInfoEx", CallingConvention = CallingConvention.StdCall,
            CharSet = CHARSET, SetLastError = true, ThrowOnUnmappableChar = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetClassInfoExIntern([In] IntPtr hInstance, [In] string lpszClass,
            ref WndclassEx lpwcx);

        [DllImport(USER32, EntryPoint = "LoadCursor", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

        [DllImport(USER32, EntryPoint = "LoadCursor", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr LoadCursor(IntPtr hInstance, IntPtr lpCursorName);

        [DllImport(USER32, EntryPoint = "LoadCursor", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr LoadCursor(IntPtr hInstance, string lpCursorName);

        [DllImport(USER32, EntryPoint = "LoadCursorFromFile", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr LoadCursorFromFile([In] string fileName);

        [DllImport(USER32, EntryPoint = "LoadImage", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr LoadImage([In] IntPtr hInst, [In] string name, uint type, int cx, int cy,
            uint fuLoad);

        [DllImport(USER32, EntryPoint = "LoadImage", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr LoadImage([In] IntPtr hInst, [In] IntPtr name, uint type, int cx, int cy,
            uint fuLoad);

        [DllImport(USER32, EntryPoint = "LoadBitmap", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr LoadBitmap(IntPtr hInstance, string lpCursorName);

        [DllImport(USER32, EntryPoint = "LoadBitmap", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr LoadBitmap(IntPtr hInstance, IntPtr lpCursorName);

        [DllImport(USER32, EntryPoint = "LoadIcon", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr LoadIcon([In] IntPtr hInst, [In] IntPtr name);

        [DllImport(USER32, EntryPoint = "LoadIcon", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr LoadIcon([In] IntPtr hInst, [In] string name);

        [DllImport(USER32, EntryPoint = "LoadAccelerators", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr LoadAccelerators([In] IntPtr hInst, [In] IntPtr tableName);

        [DllImport(USER32, EntryPoint = "LoadAccelerators", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr LoadAccelerators([In] IntPtr hInst, [In] string tableName);

        [DllImport(USER32, EntryPoint = "LoadMenu", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr LoadMenu([In] IntPtr hInst, [In] IntPtr name);

        [DllImport(USER32, EntryPoint = "LoadMenu", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr LoadMenu([In] IntPtr hInst, [In] string name);

        [DllImport(USER32, EntryPoint = "LoadString", CharSet = CHARSET, SetLastError = true)]
        public static extern int LoadString([In] IntPtr hInst, [In] int id, StringBuilder buffer, int buffLen);

        [DllImport(USER32, EntryPoint = "LoadString", CharSet = CHARSET, SetLastError = true)]
        public static extern int LoadString([In] IntPtr hInst, [In] int id, IntPtr buffer, int buffLen = 0);

        public static IntPtr SetClassLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
        {
            if (IntPtr.Size == 4)
            {
                return SetClassLongPtr32(hWnd, nIndex, dwNewLong);
            }

            return SetClassLongPtr64(hWnd, nIndex, dwNewLong);
        }

        [DllImport(USER32, CharSet = CharSet.Auto, EntryPoint = "SetClassLong")]
        public static extern IntPtr SetClassLongPtr32(IntPtr hwnd, int nIndex, IntPtr dwNewLong);

        [DllImport(USER32, CharSet = CharSet.Auto, EntryPoint = "SetClassLongPtr")]
        public static extern IntPtr SetClassLongPtr64(IntPtr hwnd, int nIndex, IntPtr dwNewLong);

        [DllImport(USER32, EntryPoint = "GetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos([Out] out Point lpPoint);

        [DllImport(USER32, EntryPoint = "SetCursorPos", SetLastError = true)]
        public static extern bool SetCursorPos(int x, int y);

        [DllImport(USER32, EntryPoint = "SendInput", SetLastError = true)]
        public static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs,
            int cbSize);

        [DllImport(USER32, EntryPoint = "GetDoubleClickTime", SetLastError = true)]
        public static extern uint GetDoubleClickTime();

        [DllImport(USER32, EntryPoint = "MonitorFromPoint")]
        public static extern IntPtr MonitorFromPoint(Point pt, uint dwFlags);

        [DllImport(USER32, EntryPoint = "MonitorFromWindow")]
        public static extern IntPtr MonitorFromWindow([In] IntPtr hwnd, uint dwFlags);

        [DllImport(USER32, EntryPoint = "MoveWindow")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MoveWindow([In] IntPtr hWnd, int X, int y, int nWidth, int nHeight,
            [MarshalAs(UnmanagedType.Bool)] bool bRepaint);

        [DllImport(USER32, EntryPoint = "MonitorFromRect")]
        public static extern IntPtr MonitorFromRect([In] ref Rect lprc, uint dwFlags);


        [DllImport(USER32, EntryPoint = "MsgWaitForMultipleObjects", SetLastError = true)]
        public static extern uint MsgWaitForMultipleObjects(uint nCount, ref IntPtr pHandles, [MarshalAs(UnmanagedType.Bool)] bool fWaitAll, uint dwMilliseconds, uint dwWakeMask);


        [DllImport(USER32, EntryPoint = "MsgWaitForMultipleObjectsEx", SetLastError = true)]
        public static extern uint MsgWaitForMultipleObjectsEx(uint nCount, ref IntPtr pHandles, uint dwMilliseconds, uint dwWakeMask, uint dwFlags);



        [DllImport(USER32, EntryPoint = "SetParent")]
        public static extern IntPtr SetParent([In] IntPtr hWndChild, [In] IntPtr hWndNewParent);

        [DllImport(USER32, EntryPoint = "SetForegroundWindow", SetLastError = true)]
        public static extern bool SetForegroundWindow(IntPtr windowHandle);

        [DllImport(USER32, EntryPoint = "SetFocus", SetLastError = true)]
        public static extern IntPtr SetFocus(IntPtr hWnd);

        [DllImport(USER32, EntryPoint = "IsWindow")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindow([In] IntPtr hWnd);

        [DllImport(USER32, EntryPoint = "IsWindowEnabled")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowEnabled([In] IntPtr hWnd);

        [DllImport(USER32, EntryPoint = "IsWindowUnicode")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowUnicode([In] IntPtr hWnd);

        [DllImport(USER32, EntryPoint = "IsWindowVisible")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowVisible([In] IntPtr hWnd);

        [DllImport(USER32, EntryPoint = "IsGUIThread")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsGUIThread([MarshalAs(UnmanagedType.Bool)] bool bConvert);

        [DllImport(USER32, EntryPoint = "IsZoomed")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsZoomed([In] IntPtr hWnd);

        [DllImport(USER32, EntryPoint = "EnableWindow")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnableWindow([In] IntPtr hWnd, [MarshalAs(UnmanagedType.Bool)] bool bEnable);

        [DllImport(USER32, EntryPoint = "TranslateMessage")]
        public static extern bool TranslateMessage([In] ref MSG lpMsg);

        /// Return Type: int
        ///hWnd: HWND->HWND__*
        ///hAccTable: HACCEL->HACCEL__*
        ///lpMsg: LPMSG->tagMSG*
        [DllImport(USER32, EntryPoint = "TranslateAccelerator", CharSet = CHARSET, SetLastError = true)]
        public static extern int TranslateAccelerator([In] IntPtr hWnd, [In] IntPtr hAccTable, [In] ref MSG lpMsg);



        /// Return Type: BOOL->int
        ///hMenu: HMENU->HMENU__*
        ///uFlags: UINT->unsigned int
        ///x: int
        ///y: int
        ///nReserved: int
        ///hWnd: HWND->HWND__*
        ///prcRect: RECT*
        [DllImport(USER32, EntryPoint = "TrackPopupMenu")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool TrackPopupMenu([In] IntPtr hMenu, uint uFlags, int x, int y, int nReserved, [In] IntPtr hWnd, [In] IntPtr prcRect);

        [DllImport(USER32, EntryPoint = "TrackPopupMenu")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool TrackPopupMenu([In] IntPtr hMenu, uint uFlags, int x, int y, int nReserved, [In] IntPtr hWnd, [In] Rect prcRect);

        /// Return Type: BOOL->int
        ///param0: HMENU->HMENU__*
        ///param1: UINT->unsigned int
        ///param2: int
        ///param3: int
        ///param4: HWND->HWND__*
        ///param5: LPTPMPARAMS->TPMPARAMS*
        [DllImport(USER32, EntryPoint = "TrackPopupMenuEx")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool TrackPopupMenuEx([In] IntPtr hMenu, uint uFlags, int x, int y, [In] IntPtr hWnd, [In] IntPtr lptpm);

        /// Return Type: BOOL->int
        ///param0: HMENU->HMENU__*
        ///param1: UINT->unsigned int
        ///param2: int
        ///param3: int
        ///param4: HWND->HWND__*
        ///param5: LPTPMPARAMS->TPMPARAMS*
        [DllImport(USER32, EntryPoint = "TrackPopupMenuEx")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool TrackPopupMenuEx([In] IntPtr hMenu, uint uFlags, int x, int y, [In] IntPtr hWnd, [In] TPMPARAMS lptpm);


        [DllImport(USER32, EntryPoint = "DispatchMessage", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr DispatchMessage([In] ref MSG lpmsg);


        /// Return Type: BOOL->int
        ///hWnd: HWND->HWND__*
        [DllImport(USER32, EntryPoint = "DrawMenuBar")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DrawMenuBar([In] IntPtr hWnd);


        [DllImport(USER32, EntryPoint = "CallWindowProc", CharSet = CHARSET)]
        public static extern IntPtr CallWindowProc(IntPtr wndProc, IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport(USER32, SetLastError = true, CharSet = CHARSET)]
        public static extern bool SetWindowTextO(IntPtr hwnd, string lpString);

        [DllImport(USER32, EntryPoint = "SetWindowText", CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowText([In] IntPtr hWnd, [In] string lpString);

        [DllImport(USER32, EntryPoint = "MessageBoxEx", CharSet = CHARSET)]
        public static extern int MessageBoxEx(IntPtr hWnd, string lpText, string lpCaption, uint uType,
            ushort wLanguageId);

        [DllImport(USER32, EntryPoint = "MessageBox", SetLastError = true, CharSet = CHARSET)]
        public static extern uint MessageBox(IntPtr hwnd, string text, string title, uint type);

        [DllImport(USER32, EntryPoint = "CreateMenu")]
        public static extern IntPtr CreateMenu();

        [DllImport(USER32, EntryPoint = "AppendMenu", CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AppendMenu([In] IntPtr hMenu, uint uFlags, uint uIdNewItem, [In] string lpNewItem);

        [DllImport(USER32, EntryPoint = "AppendMenu", CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AppendMenu([In] IntPtr hMenu, IntPtr uFlags, uint uIdNewItem, [In] string lpNewItem);

        [DllImport(USER32, EntryPoint = "InsertMenu", CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InsertMenu([In] IntPtr hMenu, uint uPosition, uint uFlags, uint uIdNewItem,
            [In] string lpNewItem);

        /// Return Type: BOOL->int
        ///hmenu: HMENU->HMENU__*
        ///item: UINT->unsigned int
        ///fByPosition: BOOL->int
        ///lpmi: LPCMENUITEMINFOW->MENUITEMINFOW*
        [DllImport(USER32, EntryPoint = "InsertMenuItemW")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InsertMenuItemW([In()] IntPtr hmenu, uint item, [MarshalAs(UnmanagedType.Bool)] bool fByPosition, [In()] ref MENUITEMINFOW lpmi);


        [DllImport(USER32, EntryPoint = "LoadMenuIndirect", CharSet = CHARSET)]
        public static extern IntPtr LoadMenuIndirect([In] IntPtr lpMenuTemplate);

        [DllImport(USER32, EntryPoint = "GetSubMenu")]
        public static extern IntPtr GetSubMenu([In] IntPtr hMenu, int nPos);

        [DllImport(USER32, EntryPoint = "GetShellWindow")]
        public static extern IntPtr GetShellWindow();

        [DllImport(USER32, EntryPoint = "GetMenuItemID")]
        public static extern uint GetMenuItemID([In] IntPtr hMenu, int nPos);

        [DllImport(USER32, EntryPoint = "GetWindowInfo")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowInfo([In] IntPtr hWnd, ref WindowInfo pwi);


        [DllImport(USER32, EntryPoint = "CreatePopupMenu")]
        public static extern IntPtr CreatePopupMenu();

        [DllImport(USER32, EntryPoint = "SystemParametersInfo", CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SystemParametersInfoW(uint uiAction, uint uiParam, IntPtr pvParam, uint fWinIni);

        [DllImport(USER32, EntryPoint = "SystemParametersInfo", CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SystemParametersInfo(uint uiAction, int uiParam, ref LogFont logFont, int fWinIni);

        [DllImport(USER32, EntryPoint = "GetDesktopWindow")]
        public static extern IntPtr GetDesktopWindow();

        public static bool GetDefaultLogFont(out LogFont logFont)
        {
            LogFont lFont = new LogFont();

            int size = Marshal.SizeOf(typeof(LogFont));
            bool retVal = SystemParametersInfo(SpiConst.SPI_GETICONTITLELOGFONT, size, ref lFont, 0);
            logFont = lFont;
            return retVal;
        }

        [DllImport(USER32, EntryPoint = "GetDC", SetLastError = true)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        /// Return Type: HDC->HDC__*
        ///hWnd: HWND->HWND__*
        ///hrgnClip: HRGN->HRGN__*
        ///flags: DWORD->unsigned int
        [DllImport(USER32, EntryPoint = "GetDCEx")]
        public static extern IntPtr GetDCEx([In()] IntPtr hWnd, [In()] IntPtr hrgnClip, uint flags);


        [DllImport(USER32, EntryPoint = "ReleaseDC", SetLastError = true)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDc);

        [DllImport(USER32)]
        public static extern int GetDlgCtrlID(IntPtr hwndCtl);

        [DllImport(USER32, EntryPoint = "GetDlgItem")]
        public static extern IntPtr GetDlgItem([In] IntPtr hDlg, int dlgItemId);

        [DllImport(USER32, EntryPoint = "GetDlgItemInt")]
        public static extern uint GetDlgItemInt([In] IntPtr hDlg, int dlgItemId, IntPtr lpTranslated,
            [MarshalAs(UnmanagedType.Bool)] bool bSigned);

        [DllImport(USER32, EntryPoint = "GetDlgItemText", CharSet = CHARSET)]
        public static extern uint GetDlgItemText([In] IntPtr hDlg, int dlgItemId, [Out] StringBuilder lpString,
            int cchMax);

        [DllImport(USER32, EntryPoint = "SetDlgItemInt")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetDlgItemInt([In] IntPtr hDlg, int dlgItemId, uint uValue,
            [MarshalAs(UnmanagedType.Bool)] bool bSigned);



        [DllImport(USER32, EntryPoint = "SetDlgItemText", CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetDlgItemText([In] IntPtr hDlg, int dlgItemId, [In] string lpString);

        public static void SetWindowTextsRaw(IntPtr hWnd, string text)
        {
            IntPtr txt = Marshal.StringToCoTaskMemUni(text);
            SendMessage(hWnd, (int)WindowsMessages.WM_SETTEXT, (int)IntPtr.Zero, txt);
            Marshal.FreeCoTaskMem(txt);
        }

        public static string GetWindowTextRaw(IntPtr hwnd)
        {
            // Allocate correct string length first
            int length = (int)SendMessage(hwnd, (int)WindowsMessages.WM_GETTEXTLENGTH, (int)IntPtr.Zero,
                IntPtr.Zero);
            StringBuilder sb = new StringBuilder(length + 1);
            SendMessage(hwnd, (int)WindowsMessages.WM_GETTEXT, (IntPtr)sb.Capacity, sb);
            return sb.ToString();
        }

        [DllImport(USER32, EntryPoint = "GetWindowModuleFileName", CharSet = CHARSET)]
        public static extern uint GetWindowModuleFileName([In] IntPtr hwnd, [Out] StringBuilder pszFileName,
            uint cchFileNameMax);

        [DllImport(USER32)]
        public static extern IntPtr GetActiveWindow();

        [DllImport(USER32, SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, [Out] out uint lpdwProcessId);


        [DllImport(USER32, EntryPoint = "GetWindowThreadProcessId", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId([In] IntPtr hWnd, IntPtr lpdwProcessId);


        [DllImport(USER32, EntryPoint = "GetWindowLong", CharSet = CHARSET)]
        private static extern IntPtr GetWindowLongPtr32(IntPtr hWnd, int nIndex);

        [DllImport(USER32, EntryPoint = "GetWindowLongPtr", CharSet = CHARSET)]
        private static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);

        [DllImport(USER32, EntryPoint = "GetWindowLong", CharSet = CHARSET)]
        public static extern int GetWindowLong([In] IntPtr hWnd, int nIndex);

        public static IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex)
        {
            bool is64 = IntPtr.Size == 8;

            if (is64)
                return GetWindowLongPtr64(hWnd, nIndex);
            else
                return GetWindowLongPtr32(hWnd, nIndex);
        }

        public static IntPtr GetWindowLongPtr(IntPtr hWnd, GWL gwl)
        {
            int index = (int)gwl;
            return GetWindowLongPtr(hWnd, index);
        }

        [DllImport(USER32, EntryPoint = "GetWindowPlacement")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowPlacement([In] IntPtr hWnd, ref WindowPlacement lpwndpl);


        [DllImport(USER32, EntryPoint = "SetWindowPlacement")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPlacement([In] IntPtr hWnd, [In] ref WindowPlacement lpwndpl);


        [DllImport(USER32, EntryPoint = "GetWindow")]
        public static extern IntPtr GetWindow([In] IntPtr hWnd, GetWindowFlag uCmd);


        [DllImport(USER32, EntryPoint = "GetMonitorInfo", CharSet = CHARSET, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetMonitorInfo([In] IntPtr hMonitor, ref MonitorInfo lpmi);

        [DllImport(USER32, EntryPoint = "GetParent", SetLastError = true)]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport(USER32, EntryPoint = "GetMonitorInfo", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr GetAncestor(IntPtr hWnd, uint gwFlags);

        [DllImport(USER32, EntryPoint = "SetWindowLong", CharSet = CHARSET)]
        public static extern int SetWindowLongPrt32([In] IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport(USER32, EntryPoint = "SetWindowLongPtr", CharSet = CHARSET)]
        private static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        public static IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
        {
            if (IntPtr.Size == 8) return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);

            return new IntPtr(SetWindowLongPrt32(hWnd, nIndex, dwNewLong.ToInt32()));
        }

        public static IntPtr SetWindowLongPtr(IntPtr hWnd, GWL gwl, IntPtr dwNewLong)
        {
            int index = (int)gwl;
            return SetWindowLongPtr(hWnd, index, dwNewLong);
        }

        [DllImport(USER32, SetLastError = true)]
        public static extern bool GetWindowRect(IntPtr hwnd, out Rect lpRect);

        [DllImport(USER32)]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [DllImport(USER32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy,
            uint uFlags);

        [DllImport(USER32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy,
            SetWindowPosFlags uFlags);

        [DllImport(USER32, EntryPoint = "SetLayeredWindowAttributes", SetLastError = true)]
        public static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        [DllImport(USER32, EntryPoint = "GetMessageExtraInfo", SetLastError = true)]
        public static extern IntPtr GetMessageExtraInfo();

        [DllImport(USER32, EntryPoint = "SendMessageTimeout", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessageTimeout(IntPtr hWnd, uint msg, UIntPtr wParam, IntPtr lParam,
            uint fuFlags, uint uTimeout, out UIntPtr lpdwResult);

        [DllImport(USER32)]
        public static extern int GetSystemMetrics(SystemMetric smIndex);

        [DllImport(USER32)]
        public static extern int GetSystemMetrics(int smIndex);

        [DllImport(USER32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetSystemMetricsForDpi(int nIndex, uint dpi);

        [DllImport(USER32)]
        public static extern IntPtr BeginPaint(IntPtr hwnd, out PaintStruct lpPaint);

        //[DllImport(USER32)]
        //public static extern IntPtr BeginPaintRef(IntPtr hwnd, ref PaintStruct lpPaint);
        [DllImport(USER32)]
        public static extern IntPtr BeginPaint(IntPtr hWnd, IntPtr lpPaintPtr);


        [DllImport(USER32)]
        public static extern bool EndPaint(IntPtr hWnd, [In] ref PaintStruct lpPaint);
        [DllImport(USER32)]
        public static extern bool EndPaint(IntPtr hWnd, IntPtr lpPaint);

        [DllImport(USER32, EntryPoint = "EnumThreadWindows", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumThreadWindows(uint dwThreadId, WndEumProc lpfn, [MarshalAs(UnmanagedType.SysInt)] int lParam);

        [DllImport(USER32, EntryPoint = "EnumThreadWindows", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumThreadWindows(uint dwThreadId, WndEumProc lpfn, IntPtr lParam);

        [DllImport(USER32, EntryPoint = "EnumChildWindows", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows([In] IntPtr hWndParent, WndEumProc lpEnumFunc, [MarshalAs(UnmanagedType.SysInt)] int lParam);

        [DllImport(USER32, EntryPoint = "EnumChildWindows", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows([In] IntPtr hWndParent, WndEumProc lpEnumFunc, IntPtr lParam);


        [DllImport(USER32, EntryPoint = "EnumDesktopWindows", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumDesktopWindows([In] IntPtr hDesktop, WndEumProc lpfn, [MarshalAs(UnmanagedType.SysInt)] int lParam);

        [DllImport(USER32, EntryPoint = "EnumDesktopWindows", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumDesktopWindows([In] IntPtr hDesktop, WndEumProc lpfn, IntPtr lParam);



        [DllImport(USER32, EntryPoint = "EnumWindows", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumWindows(WndEumProc lpEnumFunc, [MarshalAs(UnmanagedType.SysInt)] int lParam);

        [DllImport(USER32, EntryPoint = "EnumWindows", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumWindows(WndEumProc lpEnumFunc, IntPtr lParam);


        [DllImport(USER32, EntryPoint = "FindWindow", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr FindWindow([In] string lpClassName, [In] string lpWindowName);


        [DllImport(USER32, EntryPoint = "FindWindowEx", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr FindWindowEx([In] IntPtr hWndParent, [In] IntPtr hWndChildAfter, [In] string lpszClass, [In] string lpszWindow);

        /// Return Type: int
        ///hDC: HDC->HDC__*
        ///lprc: RECT*
        ///hbr: HBRUSH->HBRUSH__*
        [DllImport(USER32, EntryPoint = "FillRect")]
        public static extern int FillRect([In] IntPtr hDC, [In] ref Rect lprc, [In] IntPtr hbr);



        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, StringBuilder lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, StringBuilder lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, ref IntPtr lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, uint wParam = 0, uint lParam = 0);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, out HighLow lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, HighLow lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, int lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, int wParam, SystemTime lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static unsafe extern IntPtr SendMessage(IntPtr hWnd, uint msg, uint wParam, void* lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, int wParam, out SystemTime lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendDlgItemMessage(IntPtr hDlg, int dlgItemId, int msg, IntPtr wParam,
            StringBuilder lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendDlgItemMessage(IntPtr hDlg, int dlgItemId, int msg, int wParam,
            StringBuilder lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendDlgItemMessage(IntPtr hDlg, int dlgItemId, int msg, IntPtr wParam,
            string lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendDlgItemMessage(IntPtr hDlg, int dlgItemId, int msg, int wParam, string lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendDlgItemMessage(IntPtr hDlg, int dlgItemId, int msg, int wParam,
            ref IntPtr lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendDlgItemMessage(IntPtr hDlg, int dlgItemId, int msg, int wParam, IntPtr lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendDlgItemMessage(IntPtr hDlg, int dlgItemId, int msg, int wParam, int lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendDlgItemMessage(IntPtr hDlg, int dlgItemId, uint msg, uint wParam = 0,
            uint lParam = 0);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendDlgItemMessage(IntPtr hDlg, int dlgItemId, int msg, int wParam,
            out HighLow lParam);


        /// Return Type: BOOL->int
        ///hWnd: HWND->HWND__*
        ///lpPoint: LPPOINT->tagPOINT*
        [DllImport(USER32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ScreenToClient([In] IntPtr hWnd, ref Point lpPoint);

        [DllImport(USER32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ClientToScreen([In] IntPtr hWnd, ref Point lpPoint);

        [DllImport(USER32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool OffsetRect(ref Rect rect, int dx, int dy);

        [DllImport(USER32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PtInRect(Rect rect, Point pt);


        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendDlgItemMessage(IntPtr hDlg, int dlgItemId, int msg, int wParam, HighLow lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendDlgItemMessage(IntPtr hDlg, int dlgItemId, uint msg, IntPtr wParam, int lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendDlgItemMessage(IntPtr hDlg, int dlgItemId, uint msg, IntPtr wParam,
            IntPtr lParam);

        [DllImport(USER32, EntryPoint = "SetMenu")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetMenu([In] IntPtr hWnd, [In] IntPtr hMenu);

        [DllImport(USER32, EntryPoint = "IsDlgButtonChecked")]
        public static extern uint IsDlgButtonChecked([In] IntPtr hDlg, int nIdButton);

        [DllImport(USER32, EntryPoint = "IsDialogMessage", CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsDialogMessage([In] IntPtr hDlg, [In] ref MSG lpMsg);

        [DllImport(USER32, EntryPoint = "IsIconic")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsIconic([In] IntPtr hWnd);

        [DllImport(USER32, EntryPoint = "GetClientRect")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetClientRect([In] IntPtr hWnd, [Out] out Rect lpRect);

        [DllImport(USER32, EntryPoint = "CheckDlgButton")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CheckDlgButton([In] IntPtr hDlg, int nIdButton, uint uCheck);

        [DllImport(USER32, EntryPoint = "GetComboBoxInfo")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetComboBoxInfo([In] IntPtr hwndCombo, ref ComboboxInfo pcbi);

        [DllImport(USER32, EntryPoint = "DialogBoxIndirectParam", CharSet = CHARSET)]
        public static extern int DialogBoxIndirectParam([In] IntPtr hInstance, [In] ref DialogTemplate hDialogTemplate,
            [In] IntPtr hWndParent, DlgProc lpDialogFunc, [MarshalAs(UnmanagedType.SysInt)] int dwInitParam);

        [DllImport(USER32, EntryPoint = "EndDialog")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EndDialog([In] IntPtr hDlg, int nResult);

        [DllImport(USER32, EntryPoint = "DialogBoxParam", CharSet = CHARSET)]
        public static extern int DialogBoxParam([In] IntPtr hInstance, [In] string lpTemplateName,
            [In] IntPtr hWndParent, DlgProc lpDialogFunc, IntPtr dwInitParam);

        [DllImport(USER32, EntryPoint = "DialogBoxParam", CharSet = CHARSET)]
        public static extern int DialogBoxParam([In] IntPtr hInstance, [In] IntPtr lpTemplateName,
            [In] IntPtr hWndParent, DlgProc lpDialogFunc, IntPtr dwInitParam);

        public static int DialogBox(IntPtr hInstance, string templateName, IntPtr hWndParent, DlgProc lpDialogFunc)
        {
            return DialogBoxParam(hInstance, templateName, hWndParent, lpDialogFunc, IntPtr.Zero);
        }

        public static int DialogBox(IntPtr hInstance, int templateId, IntPtr hWndParent, DlgProc lpDialogFunc)
        {
            return DialogBoxParam(hInstance, Win32Api.MakeInterSource(templateId), hWndParent, lpDialogFunc,
                IntPtr.Zero);
        }

        public static void AddTbButton(IntPtr tbHandle, string name, int idCommand)
        {
            int btnStuctSiez = Marshal.SizeOf(typeof(TbButton));
            SendMessage(tbHandle, 0x41E, new IntPtr(btnStuctSiez), IntPtr.Zero);
            TbButton btnStruct = new TbButton();
            btnStruct.fsState = 0x4;
            btnStruct.idCommand = idCommand;
            btnStruct.iString = SendMessage(tbHandle, 0x44D, 0, name + '\0');
            //btnStruct.fsStyle = 0x2;
            IntPtr btnStructState = IntPtr.Zero;
            try
            {
                btnStructState = Marshal.AllocHGlobal(btnStuctSiez);
                Marshal.StructureToPtr(btnStruct, btnStructState, true);
                SendMessage(tbHandle, 0x444, new IntPtr(1), btnStructState);
            }
            finally
            {
                if (btnStructState != IntPtr.Zero) Marshal.FreeHGlobal(btnStructState);
            }
        }

        public static uint EnableVisualStyles()
        {
            string dir = Kernel32.GetCurrentDirectory();

            ActCtx actCtx = new ActCtx()
            {
                cbSize = Marshal.SizeOf(typeof(ActCtx)),
                dwFlags = ActCtxFlags.ACTCTX_FLAG_RESOURCE_NAME_VALID,
                lpSource = dir,

                wLangId = 0,
                lpResourceName = new IntPtr(101)
            };

            IntPtr hActCtx = Kernel32.CreateActCtx(ref actCtx);
            bool contextCreationSucceeded = hActCtx != new IntPtr(-1);

            if (!contextCreationSucceeded)
            {
                actCtx.lpResourceName = (IntPtr)ActCtxFlags.ISOLATIONAWARE_NOSTATICIMPORT_MANIFEST_RESOURCE_ID;
                hActCtx = Kernel32.CreateActCtx(ref actCtx);
                contextCreationSucceeded = hActCtx != new IntPtr(-1);
            }

            if (!contextCreationSucceeded)
            {
                actCtx.lpResourceName = (IntPtr)ActCtxFlags.CREATEPROCESS_MANIFEST_RESOURCE_ID;
                hActCtx = Kernel32.CreateActCtx(ref actCtx);
                contextCreationSucceeded = hActCtx != new IntPtr(-1);
            }

            Kernel32.ActivateActCtx(hActCtx, out var ulpActivationCookie);
            return ulpActivationCookie;
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void WinEventProc(IntPtr hWinEventHook, uint @event, IntPtr hwnd, int idObject, int idChild,
            uint idEventThread, uint dwmsEventTime);

        [DllImport(USER32, EntryPoint = "SetWinEventHook")]
        public static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, [In] IntPtr hmodWinEventProc,
            WinEventProc pfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

        public static IntPtr HookWindowEvent(WinEventProc pfnWinEventProc, uint processId, uint threadId)
        {
            return SetWinEventHook(EVENT_MIN, EVENT_MAX, IntPtr.Zero, pfnWinEventProc, processId, threadId,
                WINEVENT_OUTOFCONTEXT | WINEVENT_SKIPOWNPROCESS);
        }

        [DllImport(USER32, EntryPoint = "UnhookWinEvent")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWinEvent([In] IntPtr hWinEventHook);

        private const uint EVENT_MIN = 0x00000001;
        private const uint EVENT_MAX = 0x7FFFFFFF;

        private const uint WINEVENT_SKIPOWNPROCESS = 0x0002;

        private const uint WINEVENT_SKIPOWNTHREAD = 0x0001;

        private const uint WINEVENT_OUTOFCONTEXT = 0x0000;

        private const uint WINEVENT_INCONTEXT = 0x0004;

        public static bool GetClassInfoEx(IntPtr instanceHandle, string className, out WndclassEx wndclassex)
        {
            WndclassEx wnd = new WndclassEx();
            wnd.cbSize = Marshal.SizeOf(typeof(WndclassEx));
            bool val = false;
            try
            {
                val = GetClassInfoExIntern(instanceHandle, className, ref wnd);
                if (!val)
                {
                    int error = Marshal.GetLastWin32Error();
                    Win32Exception ex = new Win32Exception(error);
                    Debug.Print(ex.Message);
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }

            wndclassex = new WndclassEx();
            if (val)
            {
                wndclassex.cbClsExtra = wnd.cbClsExtra;
                wndclassex.cbSize = wnd.cbSize;
                wndclassex.cbWndExtra = wnd.cbWndExtra;
                wndclassex.hbrBackground = wnd.hbrBackground;
                wndclassex.hCursor = wnd.hCursor;
                wndclassex.hIcon = wnd.hIcon;
                wndclassex.hIconSm = wnd.hIconSm;
                wndclassex.hInstance = wnd.hInstance;
                wndclassex.lpfnWndProc = wnd.lpfnWndProc;
                wndclassex.lpszClassName = wnd.lpszClassName;
                wndclassex.lpszMenuName = wnd.lpszMenuName;
                wndclassex.style = wnd.style;
            }

            return val;
        }

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern bool GetClassInfo(IntPtr hInst, string lpszClass, [In, Out] WindowClass wc);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern bool GetClassInfo(IntPtr hInst, string lpszClass, IntPtr wc);

        [DllImport(USER32, EntryPoint = "GetGuiResources")]
        public static extern uint GetGuiResources([In] IntPtr hProcess, uint uiFlags);

        [DllImport(USER32, EntryPoint = "RedrawWindow")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RedrawWindow([In] IntPtr hWnd, [In] IntPtr lprcUpdate, [In] IntPtr hrgnUpdate,
            uint flags);

        [DllImport(USER32, EntryPoint = "VkKeyScan", CharSet = CHARSET, SetLastError = true)]
        public static extern short VkKeyScan(char ch);

        [DllImport(USER32, EntryPoint = "GetKeyState", CharSet = CHARSET, ExactSpelling = true,
            CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);

        [DllImport(USER32, EntryPoint = "WindowFromPoint", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr WindowFromPoint(Point point);
    }
}