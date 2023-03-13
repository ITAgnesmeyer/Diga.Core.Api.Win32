using Diga.Core.Api.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using System.Xml.XPath;
using Diga.Core.Api.Win32.Com;
using Diga.Core.Api.Win32.Com.ActiveScript;

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

                    mW(this.Handle, "TEST", "TEST", MessageBoxOptionsConst.OkOnly | MessageBoxOptionsConst.IconError);
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

        private ScriptEngine _ScriptEngine;
        private ScriptObj _ScriptObj;
        private void button3_Click(object sender, EventArgs e)
        {

            string str = this.textBox1.Text;
            this._ScriptObj = new ScriptObj();
            DefaultScriptSite site = new DefaultScriptSite(this.Handle);
            site.ScriptError += (o, xe) =>
            {
                MessageBox.Show(this, xe.ToString(), "Script Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            site.RefObj.Add("MyObject", this._ScriptObj);


           

            

            try
            {
                this._ScriptEngine = new ScriptEngine(ScriptEngineType.VBScript, site);
                ScriptProcedure s = this._ScriptEngine.GetProcdure();
                s.Name = "Test";
                s.ScriptText = "1+2";
                s.Namespace = "Global";
                s.Prams = "arg";
                this._ScriptEngine.AddProcedure(s);

                object obj = this._ScriptEngine.Run(str);
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

        private void button4_Click(object sender, EventArgs e)
        {
            IBindCtx context = RunningObjectTableUtility.GetBindContext();
            IRunningObjectTable rotTable = RunningObjectTableUtility.GetRunningObjectTable(context);
            IEnumMoniker enumerator = RunningObjectTableUtility.GetMonikerEnumerator(rotTable);
            List<MonikerInfo> infos = RunningObjectTableUtility.GetMonikerInfos(context, enumerator);
            foreach (MonikerInfo monikerInfo in infos)
            {
                Debug.Print($"DisplayName:{monikerInfo.GetDisplayName}");
                Debug.Print($"ClassID:{monikerInfo.ClassId}");
                Debug.Print($"IsSystem:{monikerInfo.IsSystemMoniker}");

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            object obj =
                RunningObjectTableUtility.GetRotObject("VisualStudio.DTE.17.0:", RotDisplayNameSearchType.Contains);

            DispatchObjectWrapper dispatch = new DispatchObjectWrapper(obj);
            var mem = dispatch.Members;
            foreach (DispatchMemberInfo dispatchMemberInfo in mem)
            {
                if (dispatchMemberInfo.FunctionDescription.invkind == INVOKEKIND.INVOKE_PROPERTYGET)
                {
                    Debug.Print(dispatchMemberInfo.Name);
                }
                
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this._ScriptObj == null) return;
            if (this._ScriptEngine == null) return;
            this._ScriptObj.InvokeFunc("OnLog");
        }
    }
}
