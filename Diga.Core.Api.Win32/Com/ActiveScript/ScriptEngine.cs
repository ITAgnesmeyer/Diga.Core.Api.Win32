using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Com.ActiveScript
{
    public class ScriptEngine:IDisposable
    {
        private readonly ScriptEngineType _EngineType;
        private readonly IScriptSite _ActiveScriptSite;
        private IActiveScript _ActiveScript;
        private object _ScriptObject;
        private bool disposedValue;

        public ScriptEngine(ScriptEngineType type , IScriptSite site)
        {
            this._EngineType = type;
            this._ActiveScriptSite = site;
            this.InitEngine();
        }

        private void InitEngine()
        {
            var clsId = this._EngineType == ScriptEngineType.VBScript ? ActiveScriptIIDs.IID_VBScript : ActiveScriptIIDs.IID_JScript;

            Guid iid = typeof(IActiveScript).GUID;

            Ole32.CoCreateInstance(ref clsId, IntPtr.Zero, (int)CLSCTX.CLSCTX_INPROC_SERVER, ref iid, out object scriptObject);
            this._ScriptObject = scriptObject ?? throw new COMException("Cannot create IActiveScript object", HRESULT.E_FAIL);

            this._ActiveScript = (IActiveScript)this._ScriptObject;

            this._ActiveScript.SetScriptSite(this._ActiveScriptSite);

            foreach (string key in this._ActiveScriptSite.RefObj.Keys)
            {
                this._ActiveScript.AddNamedItem(key,
                    (uint)SCRIPTITEMFLAGS.SCRIPTITEM_ISVISIBLE | (uint)SCRIPTITEMFLAGS.SCRIPTITEM_ISSOURCE);

            }



        }

        public object Run(string scriptText)
        {
            if (IntPtr.Size == 8)
            {
                return Run64(scriptText);
            }
            else
            {
                return Run32(scriptText);
            }
        }

        private object Run64(string scriptText)
        {
            IActiveScriptParse64 activeScriptParse = (IActiveScriptParse64)this._ScriptObject;

            activeScriptParse.InitNew();
            try
            {
                System.Runtime.InteropServices.ComTypes.EXCEPINFO[] infoArr = new System.Runtime.InteropServices.ComTypes.EXCEPINFO[10];
                activeScriptParse.ParseScriptText(scriptText, null, null, null, 0, 0,
                    (uint)SCRIPTTEXT.SCRIPTTEXT_ISVISIBLE, out var retVal, infoArr);
                return retVal;
            }
            catch (Exception)
            {
                throw;
            }


        }
        private object Run32(string scriptText)
        {
            IActiveScriptParse32 activeScriptParse = (IActiveScriptParse32)this._ScriptObject;

            activeScriptParse.InitNew();
            try
            {
                System.Runtime.InteropServices.ComTypes.EXCEPINFO[] infoArr = new System.Runtime.InteropServices.ComTypes.EXCEPINFO[10];
                activeScriptParse.ParseScriptText(scriptText, null, null, null, 0, 0,
                    (uint)SCRIPTTEXT.SCRIPTTEXT_ISVISIBLE, out var retVal, infoArr);
                
                return retVal;
                
            }
            catch (Exception)
            {
                throw;
            }

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this._ActiveScript?.Close();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}