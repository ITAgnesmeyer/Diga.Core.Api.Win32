using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Diga.Core.Api.Win32.Com.ActiveScript
{

    public interface IScriptProcudure
    {
        string Name { get; set; }
        string Namespace { get; set; }
        string Prams { get; set; }
        string ScriptText { get; set; }

        bool Parse();
    }

    public class ScriptProcedure : IScriptProcudure
    {
        private ActiveScriptParseProcedure32 _Proc32;
        private ActiveScriptParseProcedure64 _Proc64;
        private bool Is64 = IntPtr.Size == 8;

        internal ScriptProcedure(object engine)
        {
            if (this.Is64)
            {
                this._Proc64 = new ActiveScriptParseProcedure64();
            }
            else
            {
                this._Proc32 = new ActiveScriptParseProcedure32(engine);
            }
        }


        public string Name { get; set; }
        public string Namespace { get; set; }
        public string Prams { get; set; }
        public string ScriptText { get; set; }
        public bool Parse()
        {
            CheckParams();
            int returnValue = 0;
            object o;
            if (this.Is64)
            {
                returnValue = this._Proc64.ParseProcedureText(this.ScriptText, this.Prams, this.Name, null, null, null, 0, 0,
                    (uint)( SCRIPTPROC.SCRIPTPROC_ISEXPRESSION), out object obj);
            }
            else
            {
                returnValue = this._Proc32.ParseProcedureText(this.ScriptText, this.Prams, this.Name, null, null, null, 0, 0,
                    (uint)(SCRIPTPROC.SCRIPTPROC_ISEXPRESSION), out object obj);
                o = obj;
            }

            if (returnValue == HRESULT.S_OK)
            {
                return true;
            }

            return false;
        }


        private void CheckParams()
        {
            if(string.IsNullOrEmpty(this.Name)) 
                throw new ArgumentNullException("name");
            if (string.IsNullOrEmpty(this.Prams))
                throw new ArgumentNullException("Prams");
            if (string.IsNullOrWhiteSpace(this.Namespace))
                throw new ArgumentNullException("Namespace");
            if (string.IsNullOrEmpty(this.ScriptText))
                throw new ArgumentNullException("ScriptText");
        }
    }
    public class ActiveScriptParseProcedure64 : IActiveScriptParseProcedure2_64
    {
        private IActiveScriptParseProcedure2_64 GetInterface2()
        {
            return this;
        }


        public int ParseProcedureText([In, MarshalAs(UnmanagedType.LPWStr)] string pstrCode, [In, MarshalAs(UnmanagedType.LPWStr)] string pstrFormalParams, [In, MarshalAs(UnmanagedType.LPWStr)] string pstrProcedureName, [In, MarshalAs(UnmanagedType.LPWStr)] string pstrItemName, [In, MarshalAs(UnmanagedType.IUnknown)] object punkContext, [In, MarshalAs(UnmanagedType.LPWStr)] string pstrDelimiter, [In] ulong dwSourceContextCookie, [In] uint ulStartingLineNumber, [In] uint dwFlags, [MarshalAs(UnmanagedType.IDispatch)] out object ppdisp)
        {
            return this.GetInterface2().ParseProcedureText(pstrCode, pstrFormalParams, pstrProcedureName, pstrItemName,
                punkContext, pstrDelimiter, dwSourceContextCookie, ulStartingLineNumber, dwFlags, out ppdisp);
        }
    }
    public class ActiveScriptParseProcedure32
    {
        private object _Holder; 
        private IActiveScriptParseProcedure2_32 GetInterface2()
        {
            return (IActiveScriptParseProcedure2_32)this._Holder;
        }

        internal ActiveScriptParseProcedure32(object engine)
        {
            IActiveScriptParseProcedure2_32 ob = (IActiveScriptParseProcedure2_32)engine;
            this._Holder = ob;
        }
        public int ParseProcedureText(string pstrCode, string pstrFormalParams, string pstrProcedureName, string pstrItemName,
            object punkContext, string pstrDelimiter, uint dwSourceContextCookie, uint ulStartingLineNumber, uint dwFlags,
            out object ppdisp)
        {
            return this.GetInterface2().ParseProcedureText(pstrCode, pstrFormalParams, pstrProcedureName, pstrItemName,
                punkContext, pstrDelimiter, dwSourceContextCookie, ulStartingLineNumber, dwFlags, out ppdisp);
        }
    }
    public interface IScriptSite : IActiveScriptSite, IActiveScriptSiteWindow
    {
        Dictionary<string, object> RefObj { get; }
    }
}