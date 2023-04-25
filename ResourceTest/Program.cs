using Diga.Core.Api.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Diga.Core.Api.Win32.GDI;

namespace ResourceTest
{

    public class Program
    {
        private static IntPtr _hDlg = IntPtr.Zero;
        private static IntPtr _hInsance;
        private static bool IsUnicode = false;
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Module mod = typeof(Program).Module;
            _hInsance = Marshal.GetHINSTANCE(mod);
            InitCommonControlsEx cex = new InitCommonControlsEx(CommonControls.ICC_WIN95_CLASSES);
            ComCtl32.InitCommonControlsEx(ref cex);

            DlgTemplateEx dlgTemplateEx = DlgTemplateExLoader.LoadDialog(_hInsance, 101);
            Debug.Print(dlgTemplateEx.IsDialogEx().ToString());
            int count = 0;
            foreach (DlgItemTemplateEx dlgItemTemplateEx in dlgTemplateEx.Items)
            {
                count += 1;
                Debug.Print(dlgItemTemplateEx.Id.ToString());
                int u = (int)0x40 + count;
                Debug.Print("id=>" + u);
            }


            _hDlg = User32.CreateDialog(_hInsance, 101, IntPtr.Zero, DProc);

            IsUnicode = User32.IsWindowUnicode(_hDlg);

            if (_hDlg == IntPtr.Zero)
            {
                Win32Exception ex = new Win32Exception(Marshal.GetLastWin32Error());
                Debug.Print(ex.Message);
            }


            User32.ShowWindow(_hDlg, (int)ShowWindowCommands.ShowDefault);
            foreach (DlgItemTemplateEx dlgItemTemplateEx in dlgTemplateEx.Items)
            {
                IntPtr hwnd = User32.GetDlgItem(_hDlg, (int)dlgItemTemplateEx.Id);

                dlgItemTemplateEx.WindowClass = User32.GetClassName(hwnd);
                Debug.Print("ID=" + dlgItemTemplateEx.Id + ",WindClass=" + dlgItemTemplateEx.WindowClass +
                            ", WindowClassId=" + dlgItemTemplateEx.WindowClassId);
            }
            int ret;
            while ((ret = User32.GetMessage(out MSG msg, IntPtr.Zero, 0, 0)) > 0)
            {
                //if (ret == -1)
                //{
                //    return;
                //}

                if (!User32.IsDialogMessage(_hDlg, ref msg))
                {
                    User32.TranslateMessage(ref msg);
                    User32.DispatchMessage(ref msg);
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
                                case ListViewNotfiyConst.LVN_BEGINLABELEDITW:
                                    return (ApiBool)false;
                                    break;
                                case ListViewNotfiyConst.LVN_ENDLABELEDITW:
                                    tagLVDISPINFOW dispInfo = null;
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

                    IntPtr hIcon = User32.LoadImage(_hInsance, Win32Api.MakeInterSource(102), ImageTypeConst.IMAGE_ICON,
                        User32.GetSystemMetrics(SystemMetric.SM_CXSMICON),
                        User32.GetSystemMetrics(SystemMetric.SM_CYSMICON), 0);
                    //IntPtr hIcon = User32.LoadIcon(IntPtr.Zero,Win32Api.MakeInterSourceString(ResourceTypes.IDI_APPLICATION_ID));
                    if (hIcon != IntPtr.Zero)
                    {
                        User32.SendMessage(hwnd, WindowsMessages.WM_SETICON, new IntPtr(0), hIcon);
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


                                    tagLVCOLUMNW col = new tagLVCOLUMNW
                                    {
                                        mask = ListViewColumnMemeberValidInfoConst.LVCF_FMT |
                                               ListViewColumnMemeberValidInfoConst.LVCF_WIDTH |
                                               ListViewColumnMemeberValidInfoConst.LVCF_TEXT |
                                               ListViewColumnMemeberValidInfoConst.LVCF_SUBITEM
                                    };

                                    for (int i = 0; i < 5; i++)
                                    {
                                        col.iSubItem = i;
                                        col.pszText = "column" + i;
                                        col.cx = 100;
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

                                tagLVITEMW itemo = new tagLVITEMW
                                {
                                    mask = ListViewItemMemberValidInfoConst.LVIF_TEXT,
                                    pszText = "WErt",
                                    iSubItem = 0
                                };
                                int index = ListViewMacros.ListView_InsertItemW(lv, itemo);
                                ListViewMacros.ListView_GetItemW(lv, out tagLVITEMW item);

                                ListViewMacros.ListView_SetItemTextW(lv, index, 1, "hallo"+index);
                                ListViewMacros.ListView_SetItemTextW(lv, index, 2, "hallo" + index);

                            }
                            else
                            {

                            }
                            break;
                        case 40001:
                            User32.SendMessage(_hDlg, WindowsMessages.WM_CLOSE);
                            return 1;

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
