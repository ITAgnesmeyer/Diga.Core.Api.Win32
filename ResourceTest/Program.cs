using Diga.Core.Api.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace ResourceTest
{
  
    public class Program
    {
        private static IntPtr _hDlg = IntPtr.Zero;
        private static IntPtr _hInsance;

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

            DlgTemplateEx dlgTemplateEx =  DlgTemplateExLoader.LoadDialog(_hInsance, 101);
            Debug.Print(dlgTemplateEx.IsDialogEx().ToString());
            foreach (DlgItemTemplateEx dlgItemTemplateEx in dlgTemplateEx.Items)
            {
                Debug.Print(dlgItemTemplateEx.Id.ToString());
            }


            _hDlg = User32.CreateDialog(_hInsance, 101, IntPtr.Zero, DProc);
            if (_hDlg == IntPtr.Zero)
            {
                Win32Exception ex = new Win32Exception(Marshal.GetLastWin32Error());
                Debug.Print(ex.Message);
            }

            User32.ShowWindow(_hDlg, (int)ShowWindowCommands.ShowDefault);

            int ret;
            while ((ret = User32.GetMessage(out MSG msg, IntPtr.Zero, 0, 0)) != 0)
            {
                if (ret == -1)
                {
                    return;
                }

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



        private static int DProc(IntPtr hwnd, uint msg, IntPtr wparam, IntPtr lparam)
        {
            switch (msg)
            {
                case WindowsMessages.WM_INITDIALOG:
                    IntPtr hIcon = User32.LoadImage(_hInsance, Win32Api.MakeInterSource(102), ImageTypeConst.IMAGE_ICON,
                        User32.GetSystemMetrics(SystemMetric.SM_CXSMICON),
                        User32.GetSystemMetrics(SystemMetric.SM_CYSMICON), 0);
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
                        case 40001:
                            User32.SendMessage(_hDlg, WindowsMessages.WM_CLOSE);
                            return 1;

                        case 1005:
                            StringBuilder sb = new StringBuilder(255);
                            User32.GetDlgItemText(hwnd, 1004, sb, sb.Capacity);
                            User32.SetDlgItemText(hwnd, 1000, sb.ToString());
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
