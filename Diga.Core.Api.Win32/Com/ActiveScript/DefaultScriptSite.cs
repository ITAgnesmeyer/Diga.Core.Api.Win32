using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using EXCEPINFO = System.Runtime.InteropServices.ComTypes.EXCEPINFO;

namespace Diga.Core.Api.Win32.Com.ActiveScript
{
    public class DefaultScriptSite : IScriptSite
    {
        public  Dictionary<string,object> RefObj { get; }

        private readonly IntPtr _Handle;
        public event EventHandler<ScriptExceptionEventArgs> ScriptError;
        public event EventHandler<ScriptTerminateEventArgs> ScriptTerminate;
        public event EventHandler EnterScript;
        public event EventHandler LeaveScript;
        public DefaultScriptSite() : this(IntPtr.Zero)
        {

        }
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
            EXCEPINFO firstExInfo = new EXCEPINFO();
            if (pexcepinfo.Length > 0)
            {
                firstExInfo = pexcepinfo[0];
            }

            ScriptTerminateEventArgs eventArgs = new ScriptTerminateEventArgs(pvarResult, firstExInfo);
            OnScriptTerminateInvoke(eventArgs);
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
                        ScriptExceptionEventArgs exArgs = new ScriptExceptionEventArgs(info,e);
                       
                        OnScriptErrorInvoke(exArgs);
                    }
                }

                return HRESULT.S_OK;
            }

            return HRESULT.S_FALSE;
        }

        public int OnEnterScript()
        {
            //OnEnterScript
            OnEnterScriptInvoke();
            return HRESULT.S_OK;
        }

        public int OnLeaveScript()
        {
            //OnLeaveScript
            OnLeaveScriptInvoke();
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

        protected virtual void OnScriptErrorInvoke(ScriptExceptionEventArgs e)
        {
            ScriptError?.Invoke(this, e);
        }

        protected virtual void OnScriptTerminateInvoke(ScriptTerminateEventArgs e)
        {
            ScriptTerminate?.Invoke(this, e);
        }

        protected virtual void OnEnterScriptInvoke()
        {
            EnterScript?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnLeaveScriptInvoke()
        {
            LeaveScript?.Invoke(this, EventArgs.Empty);
        }
    }
}