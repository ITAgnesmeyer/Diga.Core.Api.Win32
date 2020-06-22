using Diga.Core.Api.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurfaceTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isWindow = User32.IsWindow(this.Handle);
            MessageBox.Show("IsWindow:" + isWindow);
            isWindow = User32.IsWindow(button1.Handle);
            MessageBox.Show("IsWindow:" + isWindow);
            TestOpenFolder of = new TestOpenFolder(User32.GetActiveWindow());
            var retValue = of.ShowBrowseForFolder();
            if(retValue == DialogResult.OK)
            {
                this.Text = of.Path;
            }
        }
    }

    class TestOpenFolder
    {
        private string _InitalPath;
        private IntPtr _HWnd;
        public string Path { get; set; }
        public TestOpenFolder(IntPtr parentHwned, string initPath="")
        {
            this._HWnd = parentHwned;
            this._InitalPath = initPath;
        }
        public DialogResult ShowBrowseForFolder()
        {
            DialogResult resultValue = DialogResult.Cancel;
            InitCommonControlsEx cc = new InitCommonControlsEx(CommonControls.ICC_UNDEFINED);
            ComCtl32.InitCommonControlsEx(ref cc);
            int cs = Marshal.SystemDefaultCharSize;
            if (cs == 2)
                Debug.Print("unicode");
            else
                Debug.Print("Ansi");


            BrowseInfo bf = new BrowseInfo();
            bf.hwndOwner = this._HWnd;
            bf.pidlRoot = IntPtr.Zero;
            bf.lpszTitle = "TEST";
            bf.ulFlags = BrowseForFolderConst.BIF_NEWDIALOGSTYLE | BrowseForFolderConst.BIF_SHAREABLE;
            bf.lpfn = new BrowseCallBackProc(OnBffCallByck);
            bf.lParam = IntPtr.Zero;
            bf.iImage = 0;
            IntPtr pidl = IntPtr.Zero;
            try
            {
                StringBuilder sb = new StringBuilder(256);
                pidl = Shell32.SHBrowseForFolder(ref bf);
                
                bool retVal = Shell32.SHGetPathFromIDList(pidl, sb);
                if (retVal)
                {
                    Debug.Print(sb.ToString());
                    this.Path = sb.ToString();
                    resultValue = DialogResult.OK;
                }
                else
                {
                    resultValue = DialogResult.Cancel;
                }
            }
            finally
            {
                if (pidl != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(pidl);

            }
            return resultValue;
        }

        private int OnBffCallByck(IntPtr hwnd, uint msg, IntPtr lp, IntPtr wp)
        {
            switch (msg)
            {
                case BrowseForFolderConst.BFFM_INITIALIZED:
                    User32.SendMessage(hwnd, (int)BrowseForFolderConst.BFFM_SETSELECTIONW, 1, _InitalPath);
                    break;
                case BrowseForFolderConst.BFFM_SELCHANGED:
                    StringBuilder sb = new StringBuilder(256);
                    if (Shell32.SHGetPathFromIDList(lp, sb))
                    {
                        User32.SendMessage(hwnd, (int)BrowseForFolderConst.BFFM_SETSTATUSTEXTW, 0, sb);
                    }
                    break;
            }
            return 0;
        }
    }




}
