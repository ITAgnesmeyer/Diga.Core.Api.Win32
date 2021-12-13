using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using EXCEPINFO = System.Runtime.InteropServices.ComTypes.EXCEPINFO;

namespace Diga.Core.Api.Win32.Com.ActiveScript
{
    public class DefaultScriptSite : IActiveScriptSite, IActiveScriptSiteWindow
    {
        public  Dictionary<string,object> RefObj { get; }

        private readonly IntPtr _Handle;

        public DefaultScriptSite(IntPtr handle)
        {
            this._Handle = handle;
            this.RefObj = new Dictionary<string, object>();
        }

        public int GetItemInfo(string pstrName, uint dwReturnMask, out object ppiunkItem, ITypeInfo ppti)
        {

            ppiunkItem = default(object);
            ppti = null;
            if (this.RefObj.ContainsKey(pstrName))
            {
                ppiunkItem = this.RefObj[pstrName];
               
                return HRESULT.S_OK;
            }

            return HRESULT.S_FALSE;
        }

        public int GetDocVersionString(out string v)
        {
            v = default(string);
            return HRESULT.S_FALSE;
        }

        public int OnScriptTerminate(ref object pvarResult, EXCEPINFO[] pexcepinfo)
        {
            if (pvarResult != null)
                Debug.Print(pvarResult.ToString());
            if (pexcepinfo != null)
            {
                foreach (var info in pexcepinfo)
                {
                    Debug.Print(info.bstrDescription);
                }
            }


            return HRESULT.S_OK;


        }



        public int GetLCID(out uint id)
        {


            id = default(uint);
            return HRESULT.S_FALSE;
        }

        public int OnScriptError(IActiveScriptError pscripterror)
        {
            IActiveScriptError e = pscripterror;
            if (e != null)
            {
                EXCEPINFO[] errors = new EXCEPINFO[10];

                e.GetExceptionInfo(errors);

                foreach (var info in errors)
                {
                    if (info.bstrDescription != null)
                    {
                        Debug.Print(info.bstrDescription);
                        Debug.Print(info.scode.ToString());
                        e.GetSourcePosition(out uint sourceContext, out uint lineNumber, out int charPos);
                        Debug.Print($"SourceContext={sourceContext}, line={lineNumber}, col={charPos}");
                        Debug.Print(info.bstrSource);
                        try
                        {
                            e.GetSourceLineText(out string errorLineText);
                            Debug.Print(errorLineText);

                        }
                        catch (Exception)
                        {
                        }


                    }
                }


                return HRESULT.S_OK;
            }

            return HRESULT.S_FALSE;
        }

        public int OnEnterScript()
        {
            //OnEnterScript
            Debug.Print("OnEnterScript");
            return HRESULT.S_OK;
        }

        public int OnLeaveScript()
        {
            //OnLeaveScript
            Debug.Print("OnLeaveScript");
            return HRESULT.S_OK;
        }




        public int OnStateChange(SCRIPTSTATE state)
        {
            Debug.Print("STate Change:" + state);
            return HRESULT.S_OK;
        }

        public int GetWindow(out IntPtr phwnd)
        {

            phwnd = this._Handle;
            if (phwnd == IntPtr.Zero)
            {
                return HRESULT.S_FALSE;
            }
            return HRESULT.S_OK;
        }

        public int EnableModeless([In] int fEnable)
        {
            return HRESULT.S_FALSE;
        }
    }
}