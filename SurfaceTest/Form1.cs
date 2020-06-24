using Diga.Core.Api.Win32;
using System;
using System.Runtime.InteropServices;
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

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                using (LoadLibraryHandler handler = new LoadLibraryHandler("user32.dll"))
                {
                    handler.Load();
                    handler.LoadAddress("MessageBoxW");
                    handler.LoadAddress("MessageBoxA");

                    MyMessageBoxW mW = handler.GetDelegate<MyMessageBoxW>("MessageBoxW");

                    mW(this.Handle, "TEST", "TEST", MessageBoxOptionsConst.OkOnly);
                    MyMessageBoxA mA = handler.GetDelegate<MyMessageBoxA>("MessageBoxA");
                    mA(this.Handle, "TEST", "TEST", MessageBoxOptionsConst.OkOnly);
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show("Error:" + exception.Message);
            }
            
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private delegate int MyMessageBoxW(IntPtr hWnd,  string lpText, string lpCaption, uint uType);
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        private delegate int MyMessageBoxA(IntPtr hWnd,  string lpText, string lpCaption, uint uType);

    }
}
