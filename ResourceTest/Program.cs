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

namespace ResourceTest
{

    public class Program
    {
        private static IntPtr _hDlg = IntPtr.Zero;
        private static IntPtr _hInsance;
        private static bool IsUnicode = false;
        private static IntPtr _oldLvProc = IntPtr.Zero;
        private static IntPtr _oldEditProc = IntPtr.Zero;
        private static IntPtr _EditControl = IntPtr.Zero;
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {

            _hInsance = Kernel32.GetModuleHandle(null);
            InitCommonControlsEx cex = new InitCommonControlsEx(CommonControls.ICC_WIN95_CLASSES);
            ComCtl32.InitCommonControlsEx(ref cex);


            ResourceLoader resLoader = new ResourceLoader(_hInsance);

            var loader = new DlgTemplateLoader(resLoader);

            loader.LoadTemplates(101);
            DlgTemplateAll t = loader.Head;
            List<DlgItemTemplateAll> items = loader.Items;
            foreach (DlgItemTemplateAll itemTemplateAll in items)
            {
                Debug.Print("ClassID:0x" + itemTemplateAll.ClassID.ToString("x4"));
                Debug.Print("ClassName:" + itemTemplateAll.ClassName);

            }



            //User32.LoadString(_hInsance, 101, buff,5000);

            string v = resLoader.LoadString(101);
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



            User32.ShowWindow(_hDlg, (int)ShowWindowCommands.ShowDefault);

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
        /*
    long _stdcall ListViewProc(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)
           {
               switch(message){
                   case WM_LBUTTONDOWN:
                   {
                       if (hEdit != NULL){SendMessage(hEdit,WM_KILLFOCUS,0,0);};
                       LVHITTESTINFO itemclicked;
                       long x, y;
                       x = (long)LOWORD(lParam);
                       y = (long)HIWORD(lParam);
                       itemclicked.pt.x = x;
                       itemclicked.pt.y = y;
                       int lResult = ListView_SubItemHitTest(hwnd,&itemclicked);
                       if (lResult!=-1){
                           RECT subitemrect;
                           ListView_GetSubItemRect(hwnd,itemclicado.iItem,itemclicado.iSubItem,LVIR_BOUNDS,&subitemrect);
                           int altura = subitemrect.bottom - subitemrect.top;
                           int largura = subitemrect.right - subitemrect.left;
                           if (itemclicado.iSubItem==0){largura=largura/4;};
                           hEdit = CreateWindowEx(WS_EX_CLIENTEDGE, "EDIT", "", 
                           WS_CHILD|WS_VISIBLE|ES_WANTRETURN, 
                           subitemrect.left, subitemrect.top, largura, 1.5*altura, hwnd, 0, GetModuleHandle(NULL), NULL);
                           if(hEdit == NULL)
                           MessageBox(hwnd, "Could not create edit box.", "Error", MB_OK | MB_ICONERROR);
                           SetFocus(hEdit);
                           EOldProc = (WNDPROC)SetWindowLong(hEdit, GWL_WNDPROC, (LONG)EditProc);
                           iItem = itemclicked.iItem;
                           iSubItem = itemclicked.iSubItem;
                       }
                       return 0;
                       break;
                   }
               }
               return CallWindowProc(LVOldProc, hwnd, message, wParam, lParam);
           }
long _stdcall EditProc(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)
           {
               switch(message){
                   case WM_KILLFOCUS:
                   {
                       LV_DISPINFO lvDispinfo;
                       ZeroMemory(&lvDispinfo,sizeof(LV_DISPINFO));
                       lvDispinfo.hdr.hwndFrom = hwnd;
                       lvDispinfo.hdr.idFrom = GetDlgCtrlID(hwnd);
                       lvDispinfo.hdr.code = LVN_ENDLABELEDIT;
                       lvDispinfo.item.mask = LVIF_TEXT;
                       lvDispinfo.item.iItem = iItem;
                       lvDispinfo.item.iSubItem = iSubItem;
                       lvDispinfo.item.pszText = NULL;
                       char szEditText[10];
                       GetWindowText(hwnd,szEditText,10);
                       lvDispinfo.item.pszText = szEditText;
                       lvDispinfo.item.cchTextMax = lstrlen(szEditText);
                       SendMessage(GetParent(GetDlgItem(b,MATRIZ)),WM_NOTIFY,(WPARAM)MATRIZ,(LPARAM)&lvDispinfo); //the LV ID and the LVs Parent window's HWND
                       DestroyWindow(hwnd);
                       break;
                   }
               }
            
               return CallWindowProc(EOldProc, hwnd, message, wParam, lParam);
           }

case WM_NOTIFY:
           {
               if(((LPNMHDR)z)->code == LVN_ENDLABELEDIT){
                   LVITEM LvItem;
                   LV_DISPINFO* dispinfo = (LV_DISPINFO*)z;
                   char text[10]="";
                   LvItem.iItem = dispinfo->item.iItem;
                   LvItem.iSubItem = dispinfo->item.iSubItem;
                   LvItem.pszText = dispinfo->item.pszText;
                   SendDlgItemMessage(w,MATRIZ,LVM_SETITEMTEXT,(WPARAM)LvItem.iItem,(LPARAM)&LvItem); // put new text
               }
               break;
           }

        */
        /// <returns></returns>
        /// 


        private static int Last_iItem = 0;
        private static int Last_iSubItem = 0;
        private static IntPtr EditProc(IntPtr hwnd, uint msg, IntPtr wparam, IntPtr lparam)
        {
            switch (msg)
            {
                case WindowsMessages.WM_CHAR: 
                    int keyCode = wparam.ToInt32();
                    if(keyCode == 13 || keyCode == 10)
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
                        if (_EditControl == null)
                        {
                            User32.MessageBox(hwnd, "Could not create edit box.", "Error", MessageBoxOptionsConst.OkOnly | MessageBoxOptionsConst.IconError);

                        }
                        User32.SetWindowText(_EditControl, txt);
                        User32.SetFocus(_EditControl);
                        User32.SendMessage(_EditControl, EditBoxMessages.EM_SETSEL, 0, -1);
                        _oldEditProc = User32.SetWindowLongPtr(_EditControl, GWL.GWL_WNDPROC, Marshal.GetFunctionPointerForDelegate((WndProc)EditProc));
                        Last_iItem = itemClicked.iItem;
                        Last_iSubItem = itemClicked.iSubItem;
                    }
                    return new IntPtr(0);
                    break;
            }
            return User32.CallWindowProc(_oldLvProc, hwnd, (int)msg, wparam, lparam);
        }

        private static bool LVWasCreated = false;
        private static int DProc(IntPtr hwnd, uint msg, IntPtr wparam, IntPtr lparam)
        {
            switch (msg)
            {

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
                case WindowsMessages.WM_CREATE:

                    break;
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
