using System;
using System.Runtime.InteropServices.ComTypes;

namespace Diga.Core.Api.Win32.Com.ActiveScript
{
    public class ScriptTerminateEventArgs : EventArgs
    {

        public object Result { get; }

        public ScriptExceptionEventArgs Error { get; }

        internal ScriptTerminateEventArgs(object result, EXCEPINFO exInof)
        {
            this.Error = new ScriptExceptionEventArgs(exInof);
            this.Result = result;

        }
        
    }
}