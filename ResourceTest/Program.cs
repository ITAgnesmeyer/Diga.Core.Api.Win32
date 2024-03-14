using Diga.Core.Api.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Diga.Core.Api.Win32.Com;
using Diga.Core.Api.Win32.GDI;
using System.Runtime.CompilerServices;
using System.Reflection.PortableExecutable;

namespace ResourceTest
{

    public class Program
    {
        private static IntPtr _hDlg = IntPtr.Zero;
        private static IntPtr _hInsance;
        private static bool IsUnicode = false;
        private static IntPtr _oldLvProc = IntPtr.Zero;
        private static IntPtr _oldEditProc = IntPtr.Zero;
        private static IntPtr _oldHeaderProc = IntPtr.Zero;
        private static IntPtr _EditControl = IntPtr.Zero;
        private static IntPtr _IimageList = IntPtr.Zero;
       
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
           


            _hInsance = Kernel32.GetModuleHandle(null);
            IntPtr hp = Kernel32.GetCurrentProcess();
            InitCommonControlsEx cex = new InitCommonControlsEx(CommonControls.ICC_WIN95_CLASSES);
            ComCtl32.InitCommonControlsEx(ref cex);


            
            

            ResourceLoader resLoader = new ResourceLoader(_hInsance);
            byte[] arr = resLoader.LoadRTData(101);
            string val = Encoding.UTF8.GetString(arr);
            _IimageList = ComCtl32.ImageList_Create(16, 16, ImageListConst.ILC_COLOR32, 3, 3);
            IntPtr ico0 = resLoader.LoadIcon(103);
            ComCtl32.ImageList_AddIcon(_IimageList, ico0);
            IntPtr ico1 = resLoader.LoadIcon(106);
            ComCtl32.ImageList_AddIcon(_IimageList, ico1 );
            IntPtr ico2 = resLoader.LoadIcon(108);
            ComCtl32.ImageList_AddIcon(_IimageList, ico2 );

            //var loader = new DlgTemplateLoader(resLoader);

            //loader.LoadTemplates(101);
            //DlgTemplateAll t = loader.Head;
            //List<DlgItemTemplateAll> items = loader.Items;
            //foreach (DlgItemTemplateAll itemTemplateAll in items)
            //{
            //    Debug.Print("ClassID:0x" + itemTemplateAll.ClassID.ToString("x4"));
            //    Debug.Print("ClassName:" + itemTemplateAll.ClassName);

            //}



            //User32.LoadString(_hInsance, 101, buff,5000);

            //string v = resLoader.LoadString(101);
            IntPtr hAccel = resLoader.LoadAccelerator(101);
            //bool isRes = Win32Api.IsIntResource(Win32Api.MakeInterSource(1023));
            _hDlg = User32.CreateDialog(_hInsance, 101, IntPtr.Zero, DProc);
            if (_hDlg == IntPtr.Zero)
            {
                Win32Exception ex = new Win32Exception(Marshal.GetLastWin32Error());
                Debug.Print(ex.Message);
            }
            
            //foreach (DlgItemTemplateAll dlgItemTemplateAll in items)
            //{
            //    IntPtr hCtrl = User32.GetDlgItem(_hDlg, (int)dlgItemTemplateAll.Id);
            //    string name = User32.GetClassName(hCtrl);
            //    Debug.Print($"Class name(0x{dlgItemTemplateAll.ClassID.ToString("x4")}):{name}");
            //}

            IntPtr cLv = User32.GetDlgItem(_hDlg, 1003);
            _oldLvProc = User32.SetWindowLongPtr(cLv, GWL.GWL_WNDPROC,
                Marshal.GetFunctionPointerForDelegate((WndProc)LVProc));
            IsUnicode = User32.IsWindowUnicode(_hDlg);

            IntPtr cTab = User32.GetDlgItem(_hDlg, 1016);
            TCITEMW tcit = new TCITEMW();
            tcit.pszText = "Test";
            tcit.cchTextMax = tcit.pszText.Length;
            tcit.mask = TabControlConst.TCIF_TEXT;

            TabControlMacros.TabCtrl_InsertItem(cTab, 0,tcit);
            tcit.pszText = "Test2";
            tcit.cchTextMax = tcit.pszText.Length;
            
            TabControlMacros.TabCtrl_InsertItem(cTab, 0, tcit);
            var itm = TabControlMacros.TabCtrl_GetItem(cTab, 0, out TCITEMW tcci);

            IntPtr htv = User32.GetDlgItem(_hDlg, 1014);
            TreeViewMacros.TreeView_SetImageList(htv, _IimageList);

            User32.ShowWindow(_hDlg, (int)ShowWindowCommands.ShowDefault);
            User32.UpdateWindow(_hDlg);
            
            int ret;
            while ((ret = User32.GetMessage(out MSG msg, IntPtr.Zero, 0, 0)) > 0)
            {
                if (ret == -1)
                {
                    //return;
                }
                else
                {


                    if (User32.TranslateAccelerator(_hDlg, hAccel, ref msg) == 0)
                    {
                        User32.TranslateMessage(ref msg);
                        User32.DispatchMessage(ref msg);
                    }
                }
            }

            ComCtl32.ImageList_Destroy(_IimageList);
        }


        private static int DProcMessage(IntPtr hwnd, uint msg, IntPtr wparam, IntPtr lparam)
        {
            switch (msg)
            {
                case WindowsMessages.WM_CLOSE:
                    int result = 0;
                    User32.EndDialog(hwnd, result);

                    return 1;
            }

            return 0;
        }


        private unsafe  static IntPtr HeaderProc(IntPtr hwnd, uint msg, IntPtr wparam, IntPtr lparam)
        {
            if(msg == HeaderMessageConst.HDM_LAYOUT)
            {
                LPHDLAYOUT* hdl = (LPHDLAYOUT*)lparam;
                Rect* pRect = (Rect*)hdl->prc;
                WINDOWPOS* pWPos = (WINDOWPOS*)hdl->pwpos;
                pWPos->cy = 50;
                pRect->Top = 50;
            }
            if(msg == WindowsMessages.WM_ERASEBKGND )
            {
                IntPtr hDc = wparam;
                int bgColor = Gdi32.RGB(0, 255, 250);
                Gdi32.SetBkColor(hDc, bgColor);
                
                return Gdi32.CreateSolidBrush(bgColor);
            }
            if(msg == WindowsMessages.WM_NCPAINT)
            {

            }
            if(msg == WindowsMessages.WM_PAINT)
            {
                IntPtr hdc = User32.BeginPaint(hwnd, out PaintStruct lpPaint);
                IntPtr br = Gdi32.CreateSolidBrush(Gdi32.RGB(0, 255, 255));
                Rect r = new Rect(lpPaint.rcPaint_left, lpPaint.rcPaint_top, lpPaint.rcPaint_right, lpPaint.rcPaint_bottom);
                User32.FillRect(hdc, ref r, br);
                Gdi32.DeleteObject(br);


                User32.EndPaint(hwnd,ref  lpPaint);
                return 0;
            }
            return User32.CallWindowProc(_oldHeaderProc, hwnd, (int)msg, wparam, lparam);
        }
        private static int Last_iItem = 0;
        private static int Last_iSubItem = 0;
        private static IntPtr EditProc(IntPtr hwnd, uint msg, IntPtr wparam, IntPtr lparam)
        {
            switch (msg)
            {
                case WindowsMessages.WM_CHAR:
                    int keyCode = wparam.ToInt32();
                    if (keyCode == 13 || keyCode == 10)
                    {
                        IntPtr hWndLV = User32.GetDlgItem(_hDlg, 1003);
                        User32.SetFocus(hWndLV);
                    }
                    break;
                case WindowsMessages.WM_KILLFOCUS:
                    if (wparam != IntPtr.Zero)
                    {
                        tagLVDISPINFOW dispInfo = new tagLVDISPINFOW();
                        dispInfo.hdr.hwndFrom = User32.GetDlgItem(_hDlg, 1003);
                        dispInfo.hdr.idFrom = (uint)User32.GetDlgCtrlID(dispInfo.hdr.hwndFrom);
                        dispInfo.hdr.code = new IntPtr(ListViewNotifyConst.LVN_ENDLABELEDITW);
                        dispInfo.item.mask = ListViewItemMemberValidInfoConst.LVIF_TEXT;
                        dispInfo.item.iItem = Last_iItem;
                        dispInfo.item.iSubItem = Last_iSubItem;
                        string txt = User32.GetWindowTextRaw(hwnd);
                        dispInfo.item.pszText = txt;
                        dispInfo.item.cchTextMax = txt.Length;
                        using (var p = new ApiClassHandleRef<tagLVDISPINFOW>(dispInfo))
                        {
                            IntPtr hww = User32.GetParent(User32.GetDlgItem(_hDlg, 1003));
                            User32.SendMessage(hww, (int)WindowsMessages.WM_NOTIFY, 1003, p);
                        }

                        User32.DestroyWindow(hwnd);

                        return IntPtr.Zero;

                    }
                    break;
            }
            return User32.CallWindowProc(_oldEditProc, hwnd, (int)msg, wparam, lparam);
        }
        private static IntPtr LVProc(IntPtr hwnd, uint msg, IntPtr wparam, IntPtr lparam)
        {
            Debug.Print("LVProc:0x" + msg.ToString("x4"));
            switch (msg)
            {
                case WindowsMessages.WM_CANCELMODE:
                    return new IntPtr((ApiBool)false);
                case WindowsMessages.WM_LBUTTONDBLCLK:
                    if (_EditControl != IntPtr.Zero)
                    {
                        User32.SendMessage(_EditControl, WindowsMessages.WM_KILLFOCUS, 0, 0);
                    }
                    tagLVHITTESTINFO itemClicked = new tagLVHITTESTINFO();
                    var hiLo = Win32Api.MakeHiLo(lparam);
                    itemClicked.pt.X = hiLo.iLow;
                    itemClicked.pt.Y = hiLo.iHigh;
                    int lRect = ListViewMacros.ListView_SubItemHitTest(hwnd, ref itemClicked);
                    if (lRect != -1)
                    {
                        ListViewMacros.ListView_GetSubItemRect(hwnd, itemClicked.iItem, itemClicked.iSubItem, ListViewItemRectConst.LVIR_BOUNDS, out Rect sutItemRect);
                        int height = sutItemRect.Height;
                        int width = sutItemRect.Width;
                        if (itemClicked.iSubItem == 0)
                        {
                            width = width / 4;

                        }
                        ListViewMacros.ListView_GetItemTextW(hwnd, itemClicked.iItem, itemClicked.iSubItem, out string txt);

                        _EditControl = User32.CreateWindowEx(0, "Edit", "", (uint)WindowStyles.WS_CHILD | (uint)WindowStyles.WS_VISIBLE | (uint)EditBoxStyles.ES_WANTRETURN, sutItemRect.Left, sutItemRect.Top, width, height, hwnd, IntPtr.Zero, _hInsance, IntPtr.Zero);
                        //if (_EditControl == null)
                        //{
                        //    User32.MessageBox(hwnd, "Could not create edit box.", "Error", MessageBoxOptionsConst.OkOnly | MessageBoxOptionsConst.IconError);

                        //}
                        User32.SetWindowText(_EditControl, txt);
                        User32.SetFocus(_EditControl);
                        User32.SendMessage(_EditControl, EditBoxMessages.EM_SETSEL, 0, -1);
                        _oldEditProc = User32.SetWindowLongPtr(_EditControl, GWL.GWL_WNDPROC, Marshal.GetFunctionPointerForDelegate((WndProc)EditProc));
                        Last_iItem = itemClicked.iItem;
                        Last_iSubItem = itemClicked.iSubItem;
                    }
                    return new IntPtr(0);
                    //break;
            }
            return User32.CallWindowProc(_oldLvProc, hwnd, (int)msg, wparam, lparam);
        }

        private static bool LVWasCreated = false;

        private static IntPtr hPrev = TreeViewConst.TVI_FIRST;
        private static IntPtr hPrevRootItem = IntPtr.Zero;
        private static IntPtr hPrevLevel2Item = IntPtr.Zero;
        private static IntPtr AddTreeItem(IntPtr hTreeView, string text, IntPtr parent)
        {
            TVITEMEXW tvi = new TVITEMEXW();
            TVINSERTSTRUCTEXW tvins = new TVINSERTSTRUCTEXW();
            tvi.mask = TreeViewConst.TVIF_TEXT|TreeViewConst.TVIF_IMAGE|TreeViewConst.TVIF_EXPANDEDIMAGE|TreeViewConst.TVIF_SELECTEDIMAGE;//| TreeViewConst.TVIF_PARAM;
            tvi.pszText = text;
            tvi.cchTextMax = text.Length;
            tvi.iImage = 2;
            tvi.iSelectedImage = 1;
            tvi.iExpandedImage = 0;
            tvins.item = tvi;
            tvins.hParent = parent;
            tvins.hInsertAfter = parent;
            return TreeViewMacros.TreeView_InsertItem(hTreeView, tvins);
        }
        private static IntPtr AddItemToTree(IntPtr hwndTV, string lpszItem, int nlevel)
        {
            TVITEMW tvi = new TVITEMW();
            TVINSERTSTRUCTW tvins = new TVINSERTSTRUCTW();
            IntPtr hti;
            tvi.mask = TreeViewConst.TVIF_TEXT | TreeViewConst.TVIF_PARAM;
            tvi.pszText = lpszItem;
            tvi.cchTextMax = lpszItem.Length;
            tvi.iImage = 0;
            tvi.iSelectedImage = 0;
            tvi.lParam = new IntPtr(nlevel);
            //tvins.u = new TVINSERTSTRUCTW_U();
            tvins.item = tvi;
            tvins.hInsertAfter = hPrev;

            if (nlevel == 1)
            {
                tvins.hParent = TreeViewConst.TVI_ROOT;
            }
            else if (nlevel == 2)
            {
                tvins.hParent = hPrevRootItem;
            }
            else
            {
                tvins.hParent = hPrevLevel2Item;
            }

            hPrev = TreeViewMacros.TreeView_InsertItem(hwndTV, tvins);
            if (hPrev == IntPtr.Zero)
                return IntPtr.Zero;

            if (nlevel == 1)
            {
                hPrevRootItem = hPrev;
            }
            else if (nlevel == 2)
            {
                hPrevLevel2Item = hPrev;
            }

            if (nlevel > 1)
            {
                hti = TreeViewMacros.TreeView_GetParentPtr(hwndTV, hPrev);
                tvi.mask = TreeViewConst.TVIF_IMAGE | TreeViewConst.TVIF_SELECTEDIMAGE;
                tvi.hItem = hti;
                tvi.iImage = 0;
                tvi.iSelectedImage = 0;
                TreeViewMacros.TreeView_SetItem(hwndTV, tvi);
            }
            return hPrev;
        }
        private static int DProc(IntPtr hwnd, uint msg, IntPtr wparam, IntPtr lparam)
        {
            switch (msg)
            {
                case WindowsMessages.WM_PAINT:
                    using (var p = new ApiStructHandleRef<PaintStruct>())
                    {
                        IntPtr hdc = User32.BeginPaint(hwnd, p);
                        PaintStruct ps = p.GetStruct();
                        User32.EndPaint(hwnd, p);
                        User32.ReleaseDC(hwnd, hdc);

                    }
                    break;

                case WindowsMessages.WM_NOTIFY:
                    NmHdr hdr = null;
                    try
                    {
                        hdr = Marshal.PtrToStructure<NmHdr>(lparam);
                    }
                    catch (Exception e)
                    {
                        Debug.Print(e.Message);
                    }


                    if (hdr != null)
                    {
                        uint cNotify = Win32Api.GetIntPtrUInt(hdr.code);
                        if (IsUnicode)
                        {
                            switch (cNotify)
                            {
                                //case ListViewNotifyConst.LVN_ITEMACTIVATE:
                                //    tagNMITEMACTIVATE nmActivate = default;
                                //    try
                                //    {
                                //        nmActivate = Marshal.PtrToStructure<tagNMITEMACTIVATE>(lparam);

                                //    }
                                //    catch (Exception e)
                                //    {
                                //        Debug.Print(e.Message);
                                //    }

                                //    if (nmActivate.iItem > -1)
                                //    {

                                //    }

                                //    break;
                                //case ListViewNotifyConst.LVN_COLUMNCLICK:

                                //    break;
                                case ListViewNotifyConst.LVN_BEGINLABELEDITW:
                                    ListViewMacros.ListView_CancelEditLabel(hdr.hwndFrom);
                                    return 0;
                                //    /*break*/
                                //    ;
                                case ListViewNotifyConst.LVN_ENDLABELEDITW:
                                    tagLVDISPINFOW dispInfo = default;
                                    try
                                    {
                                        dispInfo = Marshal.PtrToStructure<tagLVDISPINFOW>(lparam);
                                    }
                                    catch (Exception e)
                                    {
                                        Debug.Print(e.Message);
                                    }

                                    if (dispInfo != null)
                                    {
                                        if (dispInfo.item.pszText != null)
                                        {

                                            ListViewMacros.ListView_SetItemTextW(dispInfo.hdr.hwndFrom, dispInfo.item.iItem,
                                                dispInfo.item.iSubItem, dispInfo.item.pszText);
                                            return (ApiBool)true;
                                        }
                                        else
                                        {
                                            return (ApiBool)false;
                                        }
                                    }

                                    break;
                            }

                        }
                        else
                        {

                        }
                    }
                    break;
                //case WindowsMessages.WM_CREATE:

                //    break;
                case WindowsMessages.WM_INITDIALOG:
                    //IntPtr hIcon = User32.LoadIcon(_hInsance, Win32Api.MakeInterSource(102));
                    IntPtr hIcon = User32.LoadImage(_hInsance, Win32Api.MakeInterSource(102), ImageTypeConst.IMAGE_ICON,
                        User32.GetSystemMetrics(SystemMetric.SM_CXSMICON),
                        User32.GetSystemMetrics(SystemMetric.SM_CYSMICON), 0);
                    //IntPtr hIcon = User32.LoadIcon(IntPtr.Zero,Win32Api.MakeInterSourceString(ResourceTypes.IDI_APPLICATION_ID));
                    if (hIcon != IntPtr.Zero)
                    {
                        User32.SendMessage(hwnd, WindowsMessages.WM_SETICON, new IntPtr(0), hIcon);
                    }

                    //Do not Use default COM in AOT!!!
                    //--------------------------------
/*
                    NativeFileOpenDialogClass dlg = new NativeFileOpenDialogClass();
                    dlg.SetOptions(FOS.FOS_PICKFOLDERS);
                    dlg.SetOkButtonLabel("Annehmen");
                    HRESULT hr = dlg.Show(hwnd);
                    if (hr.Succeeded)
                    {
                        dlg.GetResult(out IShellItem ppsi);
                        if (ppsi != null)
                        {
                            ppsi.GetDisplayName(SIGDN.SIGDN_FILESYSPATH, out string pName);
                            if (pName != null)
                            {
                                User32.MessageBox(hwnd, pName, "File Path", MessageBoxOptionsConst.OkOnly);
                            }
                        }
                    }
*/
                    break;
                case WindowsMessages.WM_COMMAND:
                    int id = Win32Api.LoWord(wparam.ToInt32());
                    int cmdInt = Win32Api.HiWord(wparam.ToInt32());
                    switch (id)
                    {

                        case 1:
                            if (cmdInt == ButtonMessages.BN_CLICKED)
                            {
                                User32.SendMessage(_hDlg, WindowsMessages.WM_CLOSE);
                                return 1;
                            }

                            break;
                        case 2:
                            if (cmdInt == ButtonMessages.BN_CLICKED)
                            {
                                User32.DialogBox(_hInsance, 102, _hDlg, DProcMessage);
                            }

                            break;
                        case 1002:
                            IntPtr lv = User32.GetDlgItem(hwnd, 1003);
                            //ListViewMacros.ListView_DeleteAllItems(lv);
                            if (IsUnicode)
                            {
                                if (!LVWasCreated)
                                {
                                    ListViewMacros.ListView_SetExtendedListViewStyle(lv,
                                        ((uint)ListViewStylesEx.LVS_EX_FULLROWSELECT |
                                               (uint)ListViewStylesEx.LVS_EX_DOUBLEBUFFER |
                                               (uint)ListViewStylesEx.LVS_EX_GRIDLINES));

                                    tagLVCOLUMNW col = new tagLVCOLUMNW
                                    {
                                        mask = ListViewColumnMemberValidInfoConst.LVCF_FMT |
                                               ListViewColumnMemberValidInfoConst.LVCF_WIDTH |
                                               ListViewColumnMemberValidInfoConst.LVCF_TEXT //|
                                                                                            //ListViewColumnMemberValidInfoConst.LVCF_SUBITEM
                                    };

                                    for (int i = 0; i < 5; i++)
                                    {
                                        col.iSubItem = i;
                                        col.pszText = "column" + i;
                                        col.cx = 250;
                                        if (i < 2)
                                        {
                                            col.fmt = ListViewColumnHeaderAlignConst.LVCFMT_LEFT;
                                        }
                                        else
                                        {
                                            col.fmt = ListViewColumnHeaderAlignConst.LVCFMT_RIGHT;
                                        }

                                        ListViewMacros.ListView_InsertColumnW(lv, i, col);

                                    }

                                    LVWasCreated = true;

                                    IntPtr hHeader = ListViewMacros.ListView_GetHeader(lv);
                                    LogFont logFont = new LogFont();
                                    IntPtr hFont = User32.SendMessage(hHeader, WindowsMessages.WM_GETFONT);
                                    Gdi32.GetObject(hFont, ref logFont);
                                    logFont.lfWeight = FontWeight.FW_BOLD;
                                    hFont = Gdi32.CreateFontIndirect(ref logFont);
                                    User32.SendMessage(hHeader, WindowsMessages.WM_SETFONT, hFont, 0);
                                    _oldHeaderProc = User32.SetWindowLongPtr(hHeader, GWL.GWL_WNDPROC, Marshal.GetFunctionPointerForDelegate((WndProc)HeaderProc));
                                }
                                else 
                                {
                                    //IntPtr hHeader = ListViewMacros.ListView_GetHeader(lv);
                                    //HDLAYOUT hdLo;
                                    //using (var hdl = new ApiStructHandleRef<HDLAYOUT>())
                                    //{
                                    //    IntPtr result = User32.SendMessage(hHeader, HeaderMessageConst.HDM_LAYOUT, 0, hdl);
                                    //    hdLo = hdl.GetStruct();
                                    //}

                                    //User32.SetWindowPos(hHeader, 0, hdLo.pwpos.x, hdLo.pwpos.y, hdLo.pwpos.cx, hdLo.pwpos.cy + 20, SetWindowPosFlags.DoNotChangeOwnerZOrder);

                                }

                                int anz = ListViewMacros.ListView_GeItemCount(lv);
                                tagLVITEMW itemo = new tagLVITEMW
                                {
                                    mask = ListViewItemMemberValidInfoConst.LVIF_TEXT,
                                    iItem = anz,
                                    pszText = "WErt",
                                    iSubItem = 0
                                };
                                int index = ListViewMacros.ListView_InsertItemW(lv, itemo);
                                //ListViewMacros.ListView_GetItemW(lv, out tagLVITEMW item);

                                ListViewMacros.ListView_SetItemTextW(lv, index, 1, "hallo" + 0);
                                ListViewMacros.ListView_SetItemTextW(lv, index, 2, "hallo" + 1);
                                ListViewMacros.ListView_SetItemTextW(lv, index, 3, "hallo" + 2);
                                ListViewMacros.ListView_SetItemTextW(lv, index, 4, "hallo" + 3);

                            }
                            else
                            {

                            }
                            break;
                        case 1003:

                            break;
                        case 1015:
                            IntPtr hWndTreeView = User32.GetDlgItem(hwnd, 1014);
                            if (hWndTreeView != IntPtr.Zero)
                            {
                                //IntPtr hti = AddItemToTree(hWndTreeView, "First", 1);
                                //if (hti == IntPtr.Zero)
                                //    break;

                                //hti = AddItemToTree(hWndTreeView, "Second", 2);
                                //if (hti == IntPtr.Zero)
                                //    break;
                                //hti = AddItemToTree(hWndTreeView, "Value", 3);
                                //if (hti == IntPtr.Zero)
                                //    break;
                                //hti = AddItemToTree(hWndTreeView, "Valuea", 2);
                                //if (hti == IntPtr.Zero)
                                //    break;
                                //var root = TreeViewMacros.TreeView_GetRoot(hWndTreeView);

                                //TVITEMW? item = TreeViewMacros.TreeView_GetFirstVisible(hWndTreeView,root.Value);
                                //if(item != null)
                                //{
                                //    TreeViewMacros.TreeView_Expand(hWndTreeView, item.Value,TreeViewConst.TVE_TOGGLE);
                                //}

                                IntPtr root = AddTreeItem(hWndTreeView, "Root", TreeViewConst.TVI_ROOT);
                                IntPtr FirstSub = AddTreeItem(hWndTreeView, "First", root);
                                IntPtr SecondSub = AddTreeItem(hWndTreeView, "Second", root);
                                TreeViewMacros.TreeView_ExpandPtr(hWndTreeView, root, TreeViewConst.TVE_EXPAND);

                            }
                            break;
                        case 40001:
                            User32.SendMessage(_hDlg, WindowsMessages.WM_CLOSE);
                            return 1;
                        case 40002:
                            User32.MessageBox(_hDlg, "Dies ist ein Text", "Dies ist ein Titel",
                                MessageBoxOptionsConst.OkOnly | MessageBoxOptionsConst.IconInformation);
                            break;

                        case 1005:
                            StringBuilder sb = new StringBuilder(255);
                            User32.GetDlgItemText(hwnd, 1004, sb, sb.Capacity);
                            User32.SetDlgItemText(hwnd, 1000, sb.ToString());
                            break;
                        case 1006:
                            IntPtr h = User32.GetDlgItem(hwnd, 1004);
                            DateTimePickerMessages.DateTime_GetDateTimePickerInfo(h, out DateTimePickerInfo info);
                            Debug.Print(info.rcButton.Width.ToString());

                            DateTimePickerMessages.DateTime_GetIdealSize(h, out Size sz);
                            Debug.Print(sz.cx.ToString());
                            uint bg = DateTimePickerMessages.DateTime_GetMonthCalColor(h, MonthCalenderMessages.MCSC_TITLETEXT);
                            byte r = Gdi32.GetRValue(bg);
                            byte g = Gdi32.GetGValue(bg);
                            byte b = Gdi32.GetBValue(bg);

                            Debug.Print($"R:{r},G:{g},B:{b}");
                            SystemTimeRange range = DateTimePickerMessages.DateTime_GetRange(h);
                            DateTime min = range.RangeStart;
                            DateTime max = range.RangeEnd;
                            Debug.Print("start:" + min.ToString("f"));
                            Debug.Print("end:" + max.ToString("f"));
                            int retVal = DateTimePickerMessages.DateTime_GetSystemtime(h, out SystemTime t);
                            if (retVal == 0)
                            {
                                DateTime dt = t;
                                Debug.Print("Valud=>" + dt.ToString("f"));
                            }
                            else
                            {
                                if (retVal == -1)
                                {
                                    Debug.Print("Error");
                                }
                                else
                                {
                                    Debug.Print("None");
                                }
                            }

                            SystemTime tToSet = DateTime.Now;
                            DateTimePickerMessages.DateTime_SetSystemtime(h, tToSet);
                            break;
                    }

                    break;

                case WindowsMessages.WM_CLOSE:
                    User32.DestroyWindow(hwnd);

                    return 1;

                case WindowsMessages.WM_DESTROY:
                    User32.PostQuitMessage(0);
                    return 1;
            }

            return 0;
        }
    }
}
