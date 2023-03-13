using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Diga.Core.Api.Win32.Com;

namespace SurfaceTest
{








    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class ScriptObj
    {
        private object _FuncObject;
        private string _FuncName;

        public void InvokeFunc(string name)
        {
            if (this._FuncName == "OnLog" && this._FuncObject != null)
            {
                DispatchObjectWrapper w = new DispatchObjectWrapper(this._FuncObject);
                w.InvokeAction("OnLog");
                var x = w.InvokeGet("Herbert");
            }
        }
        public void RetisterFuncObj(ref object obj, string name)
        {
            this._FuncObject = obj;
            this._FuncName = name;
        }
        public void Log(ref object value)
        {

            DispatchObjectWrapper wrapper = new DispatchObjectWrapper(value);

            bool continas = wrapper.Members.Count == 0;

            dynamic v = value;

            try
            {
                string name = v.GetName();

            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }

            Type t = value.GetType();
            Type t2 = v.GetType();

            if (!continas)
            {


                object o = wrapper.InvokeFunction("GetName");

                wrapper.InvokeAction("SetName", "hallo");

                object result = wrapper.InvokeGet("Name");

                wrapper.InvokePut("Name", "hallooXyz");
            }
            else
            {
                try
                {
                    wrapper.InvokeAction("OnLog");
                }
                catch (Exception e)
                {
                    Debug.Print(e.Message);
                }
                
            }
        }
    }





}



