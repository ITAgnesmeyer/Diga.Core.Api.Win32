using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Diga.Core.Api.Win32
{
    public static class User32
    {
        // ReSharper disable InconsistentNaming
        private const string USER32 = "user32.dll";
        // ReSharper restore InconsistentNaming

        // Return Type: void
        //hWinEventHook: HWINEVENTHOOK->HWINEVENTHOOK__*
        //event: DWORD->unsigned int
        //hwnd: HWND->HWND__*
        //idObject: LONG->int
        //idChild: LONG->int
        //idEventThread: DWORD->unsigned int
        //dwmsEventTime: DWORD->unsigned int
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void WinEventProc(IntPtr hWinEventHook, uint @event, IntPtr hwnd, int idObject, int idChild, uint idEventThread, uint dwmsEventTime);


        // Return Type: void
        //param0: HWND->HWND__*
        //param1: UINT->unsigned int
        //param2: UINT_PTR->unsigned int
        //param3: DWORD->unsigned int
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void Timerproc(IntPtr param0, uint param1, IntPtr param2, uint param3);
        // Return Type: UINT_PTR->unsigned int
        //hWnd: HWND->HWND__*
        //nIDEvent: UINT_PTR->unsigned int
        //uElapse: UINT->unsigned int
        //lpTimerFunc: TIMERPROC
        [DllImport(USER32, EntryPoint = "SetTimer")]
        public static extern UIntPtr SetTimer([In] IntPtr hWnd, UIntPtr nIdEvent, uint uElapse,
            Timerproc lpTimerFunc);
        // Return Type: BOOL->int
        //hWnd: HWND->HWND__*
        //uIDEvent: UINT_PTR->unsigned int
        [DllImport(USER32, EntryPoint = "KillTimer")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool KillTimer([In] IntPtr hWnd, UIntPtr uIdEvent);


        [DllImport(USER32)]
        public static extern bool UpdateWindow(IntPtr hWnd);

        [DllImport(USER32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport(USER32, SetLastError = true)]
        public static extern bool DestroyWindow(IntPtr hWnd);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern bool AppendMenu(IntPtr hMenu, MenuFlags uFlags, uint uIdNewItem, string lpNewItem);

        [DllImport(USER32, SetLastError=true, CharSet= CharSet.Ansi)]
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


        // Return Type: HWND->HWND__*
        //dwExStyle: DWORD->unsigned int
        //lpClassName: LPCSTR->CHAR*
        //lpWindowName: LPCSTR->CHAR*
        //dwStyle: DWORD->unsigned int
        //X: int
        //Y: int
        //nWidth: int
        //nHeight: int
        //hWndParent: HWND->HWND__*
        //hMenu: HMENU->HMENU__*
        //hInstance: HINSTANCE->HINSTANCE__*
        //lpParam: LPVOID->void*
        //[DllImport(USER32, EntryPoint = "CreateWindowExA")]
        //public static extern IntPtr CreateWindowExA(uint dwExStyle,
        //    [In, MarshalAs(UnmanagedType.LPStr)] 
        //    string lpClassName, [In, MarshalAs(UnmanagedType.LPStr)]  string lpWindowName, uint dwStyle, int X, int Y, int nWidth, int nHeight, [In] IntPtr hWndParent,
        //    [In] IntPtr hMenu, [In] IntPtr hInstance, [In] IntPtr lpParam);


        // Return Type: HWND->HWND__*
        //dwExStyle: DWORD->unsigned int
        //lpClassName: LPCWSTR->WCHAR*
        //lpWindowName: LPCWSTR->WCHAR*
        //dwStyle: DWORD->unsigned int
        //X: int
        //Y: int
        //nWidth: int
        //nHeight: int
        //hWndParent: HWND->HWND__*
        //hMenu: HMENU->HMENU__*
        //hInstance: HINSTANCE->HINSTANCE__*
        //lpParam: LPVOID->void*
        //[DllImport(USER32,SetLastError = true, EntryPoint="CreateWindowExW")]
        //public static extern IntPtr CreateWindowExW(uint dwExStyle,
        //    [In, MarshalAs(UnmanagedType.LPWStr)]
        //    string lpClassName, [In, MarshalAs(UnmanagedType.LPWStr)]  string lpWindowName, uint dwStyle, int X, int Y, int nWidth, int nHeight, [In] IntPtr hWndParent,
        //    [In] IntPtr hMenu, [In] IntPtr hInstance, [In] IntPtr lpParam);



        // Return Type: ATOM->WORD->unsigned short
        //param0: WNDCLASSEXA*
        [DllImport(USER32, CharSet = CharSet.Ansi)]
        public static extern  ushort RegisterClassEx([In()] ref WndClassEx param0) ;


        //public static ushort RegisterClassEx([In] ref Wndclassex lpWndClass)
        //{
        //    return RegisterClassExA(ref lpWndClass);
        //}

        //// Return Type: ATOM->WORD->unsigned short
        ////param0: WNDCLASSEXW*
        //[DllImport(USER32, EntryPoint="RegisterClassExW")]
        //public static extern  ushort RegisterClassExW([In] ref Wndclassex param0) ;



        [DllImport(USER32)]
        public static extern bool UnregisterClass(string lpClassName, IntPtr hInstance);

       
        [DllImport(USER32)]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

        [DllImport(USER32)]
        public static extern void PostQuitMessage(int nExitCode);

        [DllImport(USER32)]
        public static extern sbyte GetMessage(out Msg lpMsg, IntPtr hWnd, uint wMsgFilterMin,
            uint wMsgFilterMax);

        
       
        [DllImport(USER32, EntryPoint="GetClassName", CharSet= CharSet.Ansi)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder buf, int nMaxCount);


        // Return Type: int
        //hWnd: HWND->HWND__*
        //lpClassName: LPSTR->CHAR*
        //nMaxCount: int
        //[DllImport(USER32, EntryPoint = "GetClassNameA")]
        //public static extern int GetClassNameA([In] IntPtr hWnd,
        //    [Out, MarshalAs(UnmanagedType.LPStr)]  StringBuilder lpClassName, int nMaxCount);


        public static string GetClassName(IntPtr hWnd)
        {
            StringBuilder sb = new StringBuilder(256);
            GetClassName(hWnd, sb, sb.Length);
            return sb.ToString();
        }


        // Return Type: BOOL->int
        //hInstance: HINSTANCE->HINSTANCE__*
        //lpszClass: LPCSTR->CHAR*
        //lpwcx: LPWNDCLASSEXA->tagWNDCLASSEXA*
        //[System.Runtime.InteropServices.DllImportAttribute(USER32, EntryPoint="GetClassInfoExA")]
        //[return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        //public static extern  bool GetClassInfoExA([System.Runtime.InteropServices.InAttribute()] System.IntPtr hInstance, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string lpszClass, ref WndclassexA lpwcx) ;

        // Return Type: BOOL->int
        //hInstance: HINSTANCE->HINSTANCE__*
        //lpszClass: LPCWSTR->WCHAR*
        //lpwcx: LPWNDCLASSEXW->tagWNDCLASSEXW*
        [DllImport(USER32, EntryPoint="GetClassInfoEx", CharSet= CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern  bool GetClassInfoExW([In] IntPtr hInstance, [In] string lpszClass,  ref WndClassEx lpwcx) ;

        
       

        [DllImport(USER32)]
        public static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

        // Return Type: HANDLE->void*
        //hInst: HINSTANCE->HINSTANCE__*
        //name: LPCWSTR->WCHAR*
        //type: UINT->unsigned int
        //cx: int
        //cy: int
        //fuLoad: UINT->unsigned int
        [DllImport(USER32, EntryPoint = "LoadImageW")]
        public static extern IntPtr LoadImage([In] IntPtr hInst, [In, MarshalAs(UnmanagedType.LPWStr)]  string name, uint type, int cx, int cy, uint fuLoad);

        // Return Type: BOOL->int
        //hWnd: HWND->HWND__*
        //X: int
        //Y: int
        //nWidth: int
        //nHeight: int
        //bRepaint: BOOL->int
        [DllImport(USER32, EntryPoint = "MoveWindow")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MoveWindow([In] IntPtr hWnd, int x, int y, int nWidth, int nHeight,
            [MarshalAs(UnmanagedType.Bool)] bool bRepaint);

        

        // Return Type: HWND->HWND__*
        //hWndChild: HWND->HWND__*
        //hWndNewParent: HWND->HWND__*
        [DllImport(USER32, EntryPoint="SetParent")]
        public static extern IntPtr SetParent([In] IntPtr hWndChild, [In] IntPtr hWndNewParent);

        
        // Return Type: BOOL->int
        //hWnd: HWND->HWND__*
        [DllImport(USER32, EntryPoint="IsWindowEnabled")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern  bool IsWindowEnabled([In] IntPtr hWnd) ;


        // Return Type: BOOL->int
        //hWnd: HWND->HWND__*
        //bEnable: BOOL->int
        [DllImport(USER32, EntryPoint = "EnableWindow")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnableWindow([In] IntPtr hWnd, [MarshalAs(UnmanagedType.Bool)] bool bEnable);


        [DllImport(USER32)]
        public static extern bool TranslateMessage([In] ref Msg lpMsg);

        [DllImport(USER32,SetLastError =true)]
        public static extern IntPtr DispatchMessage([In] ref Msg lpmsg);

        //[DllImport(USER32, CharSet = CharSet.Auto)]
        //public static extern IntPtr DefWindowProc(
        //    IntPtr hWnd,
        //    int msg,
        //    IntPtr wParam,
        //    IntPtr lParam);


        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr CallWindowProc(
            IntPtr wndProc,
            IntPtr hWnd,
            int msg,
            IntPtr wParam,
            IntPtr lParam);


        [DllImport(USER32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetWindowTextO(IntPtr hwnd, String lpString);

        
        // Return Type: BOOL->int
        //hWnd: HWND->HWND__*
        //lpString: LPCWSTR->WCHAR*
        [DllImport(USER32, EntryPoint="SetWindowText", CharSet= CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowText([In] IntPtr hWnd,
            [In]  string lpString);


        [DllImport(USER32)]
        public static extern int MessageBoxEx(IntPtr hWnd, string lpText, string lpCaption,
            uint uType, ushort wLanguageId);

        [DllImport(USER32, SetLastError = true)]
        public static extern uint MessageBox(IntPtr hwnd,
            string text,
            string title,
            uint type);
        // Return Type: HMENU->HMENU__*
        [DllImport(USER32, EntryPoint="CreateMenu")]
        public static extern  IntPtr CreateMenu() ;

        // Return Type: BOOL->int
        //hMenu: HMENU->HMENU__*
        //uFlags: UINT->unsigned int
        //uIDNewItem: UINT_PTR->unsigned int
        //lpNewItem: LPCWSTR->WCHAR*
        [DllImport(USER32, EntryPoint="AppendMenu", CharSet= CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern  bool AppendMenu([In] IntPtr hMenu, uint uFlags, uint uIdNewItem,
            [In]  string lpNewItem) ;

        [DllImport(USER32, EntryPoint="AppendMenu", CharSet= CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern  bool AppendMenu([In] IntPtr hMenu, IntPtr uFlags, uint uIdNewItem,
            [In]  string lpNewItem) ;

        // Return Type: BOOL->int
        //hMenu: HMENU->HMENU__*
        //uPosition: UINT->unsigned int
        //uFlags: UINT->unsigned int
        //uIDNewItem: UINT_PTR->unsigned int
        //lpNewItem: LPCWSTR->WCHAR*
        [DllImport(USER32, EntryPoint="InsertMenuW")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern  bool InsertMenu([In] IntPtr hMenu, uint uPosition, uint uFlags, uint uIdNewItem,
            [In, MarshalAs(UnmanagedType.LPWStr)]  string lpNewItem) ;

        // Return Type: HMENU->HMENU__*
        //lpMenuTemplate: MENUTEMPLATEW*
        [DllImport(USER32, EntryPoint="LoadMenuIndirectW")]
        public static extern  IntPtr LoadMenuIndirectW([In] IntPtr lpMenuTemplate) ;

        // Return Type: HMENU->HMENU__*
        //hMenu: HMENU->HMENU__*
        //nPos: int
        [DllImport(USER32, EntryPoint="GetSubMenu")]
        public static extern  IntPtr GetSubMenu([In] IntPtr hMenu, int nPos) ;

        // Return Type: UINT->unsigned int
        //hMenu: HMENU->HMENU__*
        //nPos: int
        [DllImport(USER32, EntryPoint="GetMenuItemID")]
        public static extern  uint GetMenuItemID([In] IntPtr hMenu, int nPos) ;

        
        // Return Type: HMENU->HMENU__*
        [DllImport(USER32, EntryPoint="CreatePopupMenu")]
        public static extern  IntPtr CreatePopupMenu() ;

        
        // Return Type: BOOL->int
        //uiAction: UINT->unsigned int
        //uiParam: UINT->unsigned int
        //pvParam: PVOID->void*
        //fWinIni: UINT->unsigned int
        [DllImport(USER32, EntryPoint = "SystemParametersInfo", CharSet= CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SystemParametersInfoW(uint uiAction, uint uiParam, IntPtr pvParam, uint fWinIni);

        [DllImport(USER32, EntryPoint = "SystemParametersInfo", CharSet= CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SystemParametersInfo(uint uiAction, int uiParam, ref LogFontW logFont, int fWinIni);

        public static bool GetDefaultLogFont(out LogFontW logFont)
        {
            LogFontW lFont = new LogFontW();

            int size = Marshal.SizeOf(typeof(LogFontW));
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

        //[DllImport(dllName:USER32, EntryPoint = "MessageBoxW", SetLastError=true, CharSet = CharSet.Unicode)]
        //public static extern int MessageBox(IntPtr hWnd, [MarshalAs(UnmanagedType.LPTStr)] string text, [MarshalAs(UnmanagedType.LPTStr)] string caption, uint options);

        [DllImport(USER32, CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetActiveWindow();

       

        [DllImport(USER32, SetLastError=true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, [Out] out uint lpdwProcessId);

       


        [DllImport(USER32, EntryPoint="GetWindowLong", CharSet= CharSet.Ansi)]
        private static extern IntPtr GetWindowLongPtr32(IntPtr hWnd, int nIndex);

        [DllImport(USER32, EntryPoint="GetWindowLongPtr", CharSet= CharSet.Ansi)]
        private static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);



        public static IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex)
        {
            return IntPtr.Size == 8 ? 
                GetWindowLongPtr64(hWnd, nIndex) : 
                GetWindowLongPtr32(hWnd, nIndex);
        }

        public static IntPtr GetWindowLongPtr(IntPtr hWnd, Gwl gwl)
        {
            int index = (int) gwl;
            return GetWindowLongPtr(hWnd, index);
        }

       
        [DllImport(USER32, EntryPoint="SetWindowLong", CharSet= CharSet.Ansi)]
        public static extern  int SetWindowLongPrt32([In] IntPtr hWnd, int nIndex, int dwNewLong) ;

        [DllImport(USER32, EntryPoint="SetWindowLongPtr", CharSet= CharSet.Ansi)]
        private static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        public static IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
        {
            if (IntPtr.Size == 8)
                return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
           
            return new IntPtr(SetWindowLongPrt32(hWnd, nIndex, dwNewLong.ToInt32()));
        }

        public static IntPtr SetWindowLongPtr(IntPtr hWnd, Gwl gwl, IntPtr dwNewLong)
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


        [DllImport(USER32)]
        public static extern int GetSystemMetrics(SystemMetric smIndex);

        [DllImport(USER32)]
        public static extern int GetSystemMetrics(int smIndex);


        [DllImport(USER32)]
        public static extern IntPtr BeginPaint(IntPtr hwnd, out Paintstruct lpPaint);

        [DllImport(USER32)]
        public static extern bool EndPaint(IntPtr hWnd, [In] ref Paintstruct lpPaint);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, StringBuilder lParam);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, StringBuilder lParam);


        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam,
            [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam,
            [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, ref IntPtr lParam);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);


        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, uint wParam = 0, uint lParam = 0);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, out HighLow lParam);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, HighLow lParam);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, int lParam);

        [DllImport(USER32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr  lParam);


        // Return Type: BOOL->int
        //hWnd: HWND->HWND__*
        //hMenu: HMENU->HMENU__*
        [DllImport(USER32, EntryPoint="SetMenu")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern  bool SetMenu([In] IntPtr hWnd, [In] IntPtr hMenu) ;


        // Return Type: UINT->unsigned int
        //hDlg: HWND->HWND__*
        //nIDButton: int
        [DllImport(USER32, EntryPoint = "IsDlgButtonChecked")]
        public static extern uint IsDlgButtonChecked([In] IntPtr hDlg, int nIdButton);


        // Return Type: BOOL->int
        //hWnd: HWND->HWND__*
        //lpRect: LPRECT->tagRECT*
        [DllImport(USER32, EntryPoint="GetClientRect")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern  bool GetClientRect([In] IntPtr hWnd, [Out] out Rect lpRect) ;


        // Return Type: BOOL->int
        //hDlg: HWND->HWND__*
        //nIDButton: int
        //uCheck: UINT->unsigned int
        [DllImport(USER32, EntryPoint = "CheckDlgButton")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CheckDlgButton([In] IntPtr hDlg, int nIdButton, uint uCheck);

        public static void SetWindowTextsRaw(IntPtr hWnd, string text)
        {
            IntPtr txt = Marshal.StringToCoTaskMemUni(text);
            SendMessage(hWnd, (int) WindowsMessages.WM_SETTEXT, (int) IntPtr.Zero, txt);
            Marshal.FreeCoTaskMem(txt);
        }

        public static string GetWindowTextRaw(IntPtr hwnd)
        {
            // Allocate correct string length first
            int length = (int) SendMessage(hwnd, (int) WindowsMessages.WM_GETTEXTLENGTH, (int) IntPtr.Zero,
                IntPtr.Zero);
            StringBuilder sb = new StringBuilder(length + 1);
            SendMessage(hwnd, (int) WindowsMessages.WM_GETTEXT, (IntPtr) sb.Capacity, sb);
            return sb.ToString();
        }

        // Return Type: BOOL->int
        //hwndCombo: HWND->HWND__*
        //pcbi: PCOMBOBOXINFO->tagCOMBOBOXINFO*
        [DllImport(USER32, EntryPoint="GetComboBoxInfo")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern  bool GetComboBoxInfo([In] IntPtr hwndCombo, ref ComboBoxInfo pcbi) ;


        // Return Type: INT_PTR->int
        //hInstance: HINSTANCE->HINSTANCE__*
        //hDialogTemplate: LPCDLGTEMPLATEW->DLGTEMPLATE*
        //hWndParent: HWND->HWND__*
        //lpDialogFunc: DLGPROC
        //dwInitParam: LPARAM->LONG_PTR->int
        [DllImport(USER32, EntryPoint="DialogBoxIndirectParamW")]
        public static extern  int DialogBoxIndirectParam([In] IntPtr hInstance, [In] ref DialogTemplate hDialogTemplate, [In] IntPtr hWndParent, Dlgproc lpDialogFunc, [MarshalAs(UnmanagedType.SysInt)] int dwInitParam) ;

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
        // Return Type: INT_PTR->int
        //param0: HWND->HWND__*
        //param1: UINT->unsigned int
        //param2: WPARAM->UINT_PTR->unsigned int
        //param3: LPARAM->LONG_PTR->int
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int Dlgproc(IntPtr hWnd, uint param1, IntPtr wParam, IntPtr lParam);


        // Return Type: HWINEVENTHOOK->HWINEVENTHOOK__*
        //eventMin: DWORD->unsigned int
        //eventMax: DWORD->unsigned int
        //hmodWinEventProc: HMODULE->HINSTANCE->HINSTANCE__*
        //pfnWinEventProc: WINEVENTPROC
        //idProcess: DWORD->unsigned int
        //idThread: DWORD->unsigned int
        //dwFlags: DWORD->unsigned int
        [DllImport(USER32, EntryPoint="SetWinEventHook")]
        public static extern  IntPtr SetWinEventHook(uint eventMin, uint eventMax, [In] IntPtr hmodWinEventProc, WinEventProc pfnWinEventProc, uint idProcess, uint idThread, uint dwFlags) ;

        public static IntPtr HookWindowEvent( WinEventProc pfnWinEventProc, uint processId, uint threadId)
        {
            return SetWinEventHook(EVENT_MIN, EVENT_MAX, IntPtr.Zero, pfnWinEventProc, processId, threadId,
                WINEVENT_OUTOFCONTEXT | WINEVENT_SKIPOWNPROCESS);
        }

        // Return Type: BOOL->int
        //hWinEventHook: HWINEVENTHOOK->HWINEVENTHOOK__*
        [DllImport(USER32, EntryPoint="UnhookWinEvent")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern  bool UnhookWinEvent([In] IntPtr hWinEventHook) ;


        // ReSharper disable InconsistentNaming
        private const uint EVENT_MIN = 0x00000001;
       
        private const uint EVENT_MAX = 0x7FFFFFFF;

        
        // WINEVENT_SKIPOWNPROCESS -> 0x0002
        private const uint WINEVENT_SKIPOWNPROCESS = 0x0002;
    
        // WINEVENT_SKIPOWNTHREAD -> 0x0001
        private const uint WINEVENT_SKIPOWNTHREAD = 0x0001;
    
        // WINEVENT_OUTOFCONTEXT -> 0x0000
        private const uint WINEVENT_OUTOFCONTEXT = 0x0000;
    
        // WINEVENT_INCONTEXT -> 0x0004
        private const uint WINEVENT_INCONTEXT = 0x0004;
        // ReSharper restore InconsistentNaming
        public static bool GetClassInfoEx(IntPtr instanceHandle, string className, out WndClassEx wndclassex)
        {
            WndClassEx wnd = WndClassEx.Build();

            bool val = GetClassInfoExW(instanceHandle, className, ref wnd);
            wndclassex = new WndClassEx();
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
                wndclassex.lpfnWndProc = Marshal.GetFunctionPointerForDelegate( wnd.lpfnWndProc);
                wndclassex.lpszClassName = wnd.lpszClassName;
                wndclassex.lpszMenuName = wnd.lpszMenuName;
                wndclassex.style = wnd.style;

            }
            

            return val;
        }

    }
}