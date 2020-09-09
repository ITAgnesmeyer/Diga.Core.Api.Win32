using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Diga.Core.Api.Win32
{
    public static partial class User32
    {
        private const string USER32 = "user32.dll";
        private const CharSet CHARSET = CharSet.Auto;

        [DllImport(USER32, EntryPoint = "SetTimer")]
        public static extern UIntPtr SetTimer([In] IntPtr hWnd, UIntPtr nIdEvent, uint uElapse,
            TimerProc lpTimerFunc);

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


        [DllImport(USER32, EntryPoint = "AppendMenu", CharSet = CHARSET)]
        private static extern bool AppendMenu(IntPtr hMenu, MenuFlags uFlags, uint uIdNewItem, string lpNewItem);


        [DllImport(USER32, EntryPoint = "CreateWindowEx", CharSet = CHARSET, SetLastError = true)]
        public static extern IntPtr CreateWindowEx(uint dwExStyle, [In] string lpClassName, [In] string lpWindowName,
            uint dwStyle, int X, int Y, int nWidth, int nHeight, [In] IntPtr hWndParent, [In] IntPtr hMenu,
            [In] IntPtr hInstance, [In] IntPtr lpParam);


        [DllImport(USER32, EntryPoint = "CreateWindowEx", SetLastError = true, CharSet = CHARSET)]
        public static extern IntPtr CreateWindowEx(
            int dwExStyle,
            string lpClassName,
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

        [DllImport(USER32, EntryPoint = "CreateDialogIndirectParam", CharSet = CHARSET,SetLastError = true)]
        public static extern IntPtr CreateDialogIndirectParamEx([In] IntPtr hInstance, [In] IntPtr lpTemplate,
            [In] IntPtr hWndParent, DlgProc lpDialogFunc, IntPtr dwInitParam);

        public static IntPtr CreateDialogIndirect(IntPtr hInstance, ref DlgTemplate lpTemplate, IntPtr hWndParent,
            DlgProc dlgFunc)
        {
            return CreateDialogIndirectParam(hInstance, ref lpTemplate, hWndParent, dlgFunc, 0);
        }

        public static IntPtr CreateDialogIndirectEx(IntPtr hInstance, DlgTemplateEx lpTemplate, IntPtr hWndParent,
            DlgProc dlgFunc)
        {
            using (ApiStructHandleRef<DialogTemplate> pt = new ApiStructHandleRef<DialogTemplate>(lpTemplate))
            {
                return CreateDialogIndirectParamEx(hInstance,  pt, hWndParent, dlgFunc, IntPtr.Zero);
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





        [DllImport(USER32, EntryPoint = "GetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos([Out] out Point lpPoint);

        [DllImport(USER32,EntryPoint = "SetCursorPos", SetLastError = true)]
        public static extern bool SetCursorPos(int x, int y);


        [DllImport(USER32,EntryPoint = "SendInput", SetLastError = true)]
        public static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);
        
        [DllImport(USER32,EntryPoint = "GetDoubleClickTime", SetLastError = true)]
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

        [DllImport(USER32, EntryPoint = "SetParent")]
        public static extern IntPtr SetParent([In] IntPtr hWndChild, [In] IntPtr hWndNewParent);

        [DllImport(USER32,EntryPoint = "SetForegroundWindow",  SetLastError = true)]
        public static extern bool SetForegroundWindow(IntPtr windowHandle);

        [DllImport(USER32, EntryPoint = "SetFocus", SetLastError = true)]
        public static extern IntPtr SetFocus(IntPtr hWnd);

        [DllImport(USER32, EntryPoint = "IsWindow")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindow([In] IntPtr hWnd);

        [DllImport(USER32, EntryPoint = "IsWindowEnabled")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowEnabled([In] IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint="IsWindowUnicode")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern  bool IsWindowUnicode([In] IntPtr hWnd) ;


        [DllImport(USER32, EntryPoint = "IsWindowVisible")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowVisible([In] IntPtr hWnd);

        [DllImport(USER32, EntryPoint = "EnableWindow")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnableWindow([In] IntPtr hWnd, [MarshalAs(UnmanagedType.Bool)] bool bEnable);


        [DllImport(USER32, EntryPoint = "TranslateMessage")]
        public static extern bool TranslateMessage([In] ref MSG lpMsg);

        [DllImport(USER32, EntryPoint = "DispatchMessage", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr DispatchMessage([In] ref MSG lpmsg);


        [DllImport(USER32, EntryPoint = "CallWindowProc", CharSet = CHARSET)]
        public static extern IntPtr CallWindowProc(
            IntPtr wndProc,
            IntPtr hWnd,
            int msg,
            IntPtr wParam,
            IntPtr lParam);


        [DllImport(USER32, SetLastError = true, CharSet = CHARSET)]
        public static extern bool SetWindowTextO(IntPtr hwnd, String lpString);


        [DllImport(USER32, EntryPoint = "SetWindowText", CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowText([In] IntPtr hWnd,
            [In] string lpString);


        [DllImport(USER32, EntryPoint = "MessageBoxEx", CharSet = CHARSET)]
        public static extern int MessageBoxEx(IntPtr hWnd, string lpText, string lpCaption,
            uint uType, ushort wLanguageId);

        [DllImport(USER32, EntryPoint = "MessageBox", SetLastError = true, CharSet = CHARSET)]
        public static extern uint MessageBox(IntPtr hwnd,
            string text,
            string title,
            uint type);


        [DllImport(USER32, EntryPoint = "CreateMenu")]
        public static extern IntPtr CreateMenu();


        [DllImport(USER32, EntryPoint = "AppendMenu", CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AppendMenu([In] IntPtr hMenu, uint uFlags, uint uIdNewItem,
            [In] string lpNewItem);

        [DllImport(USER32, EntryPoint = "AppendMenu", CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AppendMenu([In] IntPtr hMenu, IntPtr uFlags, uint uIdNewItem,
            [In] string lpNewItem);


        [DllImport(USER32, EntryPoint = "InsertMenu", CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InsertMenu([In] IntPtr hMenu, uint uPosition, uint uFlags, uint uIdNewItem,
            [In] string lpNewItem);


        [DllImport(USER32, EntryPoint = "LoadMenuIndirect", CharSet = CHARSET)]
        public static extern IntPtr LoadMenuIndirect([In] IntPtr lpMenuTemplate);


        [DllImport(USER32, EntryPoint = "GetSubMenu")]
        public static extern IntPtr GetSubMenu([In] IntPtr hMenu, int nPos);


        [DllImport(USER32, EntryPoint = "GetMenuItemID")]
        public static extern uint GetMenuItemID([In] IntPtr hMenu, int nPos);


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


        [DllImport(USER32)]
        public static extern IntPtr GetActiveWindow();


        [DllImport(USER32, SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, [Out] out uint lpdwProcessId);


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


        [DllImport("user32.dll", EntryPoint = "GetWindowPlacement")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowPlacement([In()] IntPtr hWnd, ref WindowPlacement lpwndpl);



        [DllImport(USER32, EntryPoint = "SetWindowLong", CharSet = CHARSET)]
        public static extern int SetWindowLongPrt32([In] IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport(USER32, EntryPoint = "SetWindowLongPtr", CharSet = CHARSET)]
        private static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        public static IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
        {
            if (IntPtr.Size == 8)
                return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);

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
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy,
            SetWindowPosFlags uFlags);

        [DllImport(USER32,EntryPoint = "SetLayeredWindowAttributes",  SetLastError = true)]
        public static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);


        [DllImport(USER32,EntryPoint = "GetMessageExtraInfo", SetLastError = true)]
        public static extern IntPtr GetMessageExtraInfo();

        [DllImport(USER32, EntryPoint = "SendMessageTimeout", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessageTimeout(IntPtr hWnd, uint msg, UIntPtr wParam, IntPtr lParam, uint fuFlags, uint uTimeout, out UIntPtr lpdwResult);


        [DllImport(USER32)]
        public static extern int GetSystemMetrics(SystemMetric smIndex);

        [DllImport(USER32)]
        public static extern int GetSystemMetrics(int smIndex);


        [DllImport(USER32)]
        public static extern IntPtr BeginPaint(IntPtr hwnd, out PaintStruct lpPaint);

        [DllImport(USER32)]
        public static extern bool EndPaint(IntPtr hWnd, [In] ref PaintStruct lpPaint);

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
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, int wParam, out SystemTime lParam);


        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendDlgItemMessage(IntPtr hDlg, int dlgItemId, int msg, IntPtr wParam, StringBuilder lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendDlgItemMessage(IntPtr hDlg, int dlgItemId, int msg, int wParam, StringBuilder lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendDlgItemMessage(IntPtr hDlg, int dlgItemId, int msg, IntPtr wParam, string lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendDlgItemMessage(IntPtr hDlg, int dlgItemId, int msg, int wParam, string lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendDlgItemMessage(IntPtr hDlg, int dlgItemId, int msg, int wParam, ref IntPtr lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendDlgItemMessage(IntPtr hDlg, int dlgItemId, int msg, int wParam, IntPtr lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendDlgItemMessage(IntPtr hDlg, int dlgItemId, int msg, int wParam, int lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendDlgItemMessage(IntPtr hDlg, int dlgItemId, uint msg, uint wParam = 0, uint lParam = 0);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendDlgItemMessage(IntPtr hDlg, int dlgItemId, int msg, int wParam, out HighLow lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendDlgItemMessage(IntPtr hDlg, int dlgItemId, int msg, int wParam, HighLow lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendDlgItemMessage(IntPtr hDlg, int dlgItemId, uint msg, IntPtr wParam, int lParam);

        [DllImport(USER32, CharSet = CHARSET)]
        public static extern IntPtr SendDlgItemMessage(IntPtr hDlg, int dlgItemId, uint msg, IntPtr wParam, IntPtr lParam);

        



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
        public static extern int DialogBoxParam([In] IntPtr hInstance, [In] string lpTemplateName, [In] IntPtr hWndParent, DlgProc lpDialogFunc, IntPtr dwInitParam);

        [DllImport(USER32, EntryPoint = "DialogBoxParam", CharSet = CHARSET)]
        public static extern int DialogBoxParam([In] IntPtr hInstance, [In] IntPtr lpTemplateName, [In] IntPtr hWndParent, DlgProc lpDialogFunc, IntPtr dwInitParam);


        public static int DialogBox(IntPtr hInstance, string templateName, IntPtr hWndParent, DlgProc lpDialogFunc)
        {
            return DialogBoxParam(hInstance, templateName, hWndParent, lpDialogFunc, IntPtr.Zero);
        }

        public static int DialogBox(IntPtr hInstance, int templateId, IntPtr hWndParent, DlgProc lpDialogFunc)
        {

            return DialogBoxParam(hInstance, Win32Api.MakeInterSource(templateId), hWndParent, lpDialogFunc, IntPtr.Zero);
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
            string dir = System.Reflection.Assembly.GetExecutingAssembly().Location;

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
                wndclassex.cbSize = (int)wnd.cbSize;
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


        [DllImport(USER32, EntryPoint = "GetGuiResources")]
        public static extern uint GetGuiResources([In] IntPtr hProcess, uint uiFlags);


        [DllImport(USER32, EntryPoint = "RedrawWindow")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RedrawWindow([In] IntPtr hWnd, [In] IntPtr lprcUpdate, [In] IntPtr hrgnUpdate,
            uint flags);


        [DllImport(USER32,EntryPoint = "VkKeyScan", CharSet = CHARSET, SetLastError = true)]
        public static extern short VkKeyScan(char ch);

        [DllImport(USER32,EntryPoint ="GetKeyState", CharSet = CHARSET, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);


    }
}