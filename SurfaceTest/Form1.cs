using Diga.Core.Api.Win32;
using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using System.Xml.XPath;
using Diga.Core.Api.Win32.Com;

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

        private void button3_Click(object sender, EventArgs e)
        {
            ComCallingInfo info = new ComCallingInfo();
            info.DllPath = "C:\\Windows\\System32\\VBSCRIPT.DLL";

            Guid clsId = new Guid("B54F3741-5B07-11CF-A4B0-00AA004A55E8");
            Guid iid = new Guid("BB1A2AE1-A4F9-11cf-8F20-00805F2CD064");


            Ole32.CoCreateInstance(ref clsId , IntPtr.Zero,
                (int)CLSCTX.CLSCTX_INPROC_SERVER, ref iid, out object scriptObject);

            //object scriptObject = ComLoader.GetObject(info, new Guid("B54F3741-5B07-11CF-A4B0-00AA004A55E8"),
            //    new Guid("BB1A2AE1-A4F9-11cf-8F20-00805F2CD064"));

            IActiveScript ac = (IActiveScript)scriptObject;
            IActiveScriptParse32 ap = (IActiveScriptParse32)scriptObject;
            DefaultScriptSite site = new DefaultScriptSite(this.Handle);
            ScriptObj so = new ScriptObj();
            site.RefObj = so;
            ac.SetScriptSite(site);
            ac.AddNamedItem("MyObject",
                ((uint)SCRIPTITEMFLAGS.SCRIPTITEM_ISVISIBLE | (uint)SCRIPTITEMFLAGS.SCRIPTITEM_ISSOURCE));
            
            
            ap.InitNew();
            try
            {
                EXCEPINFO[] infoArr = new EXCEPINFO[10];
                string str = this.textBox1.Text;
                ap.ParseScriptText(str, "MyObject", so, "\r\n", 0, 0,
                    (uint)SCRIPTTEXT.SCRIPTTEXT_ISVISIBLE, out var result, infoArr);
                if (result != null)
                {
                    Debug.Print(result.ToString());
                }

            }
            catch (COMException exception)
            {
                Console.WriteLine(exception.Message);
                MessageBox.Show(exception.Message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            
            //ac.SetScriptState(SCRIPTSTATE.SCRIPTSTATE_CONNECTED);



        }
    }
}
