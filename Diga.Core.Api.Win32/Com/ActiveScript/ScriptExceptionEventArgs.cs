using System;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;

namespace Diga.Core.Api.Win32.Com.ActiveScript
{
    public class ScriptExceptionEventArgs : EventArgs
    {
        internal ScriptExceptionEventArgs(EXCEPINFO exInfo)
        {
            this.Description = exInfo.bstrDescription;
            this.SCode = exInfo.scode;
            this.Source = exInfo.bstrSource;
            this.ErrorCode = exInfo.wCode;
        }

        internal ScriptExceptionEventArgs(EXCEPINFO exInfo, IActiveScriptError error)
        {
            this.Description = exInfo.bstrDescription;
            this.SCode = exInfo.scode;
            this.ErrorCode = exInfo.scode - unchecked((int)0x800A0000);
            this.Source = exInfo.bstrSource ;
            try
            {
                error.GetSourceLineText(out string sourceLine);
                Debug.Print(sourceLine);
                this.LineText = sourceLine;
            }
            catch (Exception)
            {
                // ignored
            }
            error.GetSourcePosition(out uint sourceContext, out uint lineNumber, out int charPos);
            this.SourceContext = (int)sourceContext;
            this.Line = (int)lineNumber;
            this.Column = (int)charPos;
            

        }

        internal ScriptExceptionEventArgs(int sCode,int line, int column, 
            int sourceContext, string description, string source, string lineText, int errorCode)
        {
            this.Line = line;
            this.SCode = sCode;
            this.Column = column;
            this.SourceContext = sourceContext;
            this.Description = description;
            this.Source = source;
            this.LineText = lineText;
            this.ErrorCode = errorCode;
        }
        public int SCode { get; }
        public int Line { get; }
        public int Column { get; }
        public int SourceContext { get; }
        public string Description { get; }
        public string Source { get; }
        public string LineText { get; }

        public int ErrorCode { get; }

        public override string ToString()
        {
            return
                $"Source:{this.Source}\nDescription:{this.Description}\nLine:{this.Line}\nColumn:{this.Column}\nLineText:{LineText}\nErrorCode:{this.ErrorCode}\nScode:{this.SCode}";
        }
    }
}