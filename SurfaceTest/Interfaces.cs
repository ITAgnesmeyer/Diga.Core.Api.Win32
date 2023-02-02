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
        public void Log(ref object value)
        {

            DispatchObjectWrapper wrapper = new DispatchObjectWrapper(value);

            bool continas = wrapper.Members.Count == 0;


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



