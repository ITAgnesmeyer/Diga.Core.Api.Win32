using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    public class LoadLibraryHandler:IDisposable
    {
        private ApiHandleRef _Handle;
        private string _LibPath;
        public string LastError{get;set;}
        private Dictionary<string, Delegate> DelegateList;
        private Dictionary<string, ApiHandleRef> ProdAddresses;
       
        public LoadLibraryHandler(string libPath)
        {
            this._LibPath = libPath;
            this.DelegateList = new Dictionary<string, Delegate>();
            this.ProdAddresses = new Dictionary<string, ApiHandleRef>();
        }

        public bool IsValid
        {
            get
            {
                if(this._Handle == null ) return false;
                return this._Handle.IsValid;

            }
        }

        public bool LoadAddress(string procName)
        {

            if(this.ProdAddresses.ContainsKey(procName)) return true;

            if (string.IsNullOrEmpty(procName))
            {
                throw new ArgumentException("The procName - Parameter is empty");
            }
            if (!this.IsValid)
                throw new InvalidOperationException("The Library is not loaded");
            IntPtr ptr = Kernel32.GetProcAddress(this.Handle, procName);
            if (ptr == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());;
            }

            this.ProdAddresses.Add(procName, new ApiHandleRef(this, ptr));
            return true;
        }
        public T GetDelegate<T>(string procName) where T : Delegate
        {
            
            if (!LoadAddress(procName))
            {
                throw new Exception("could not load ProcAddress");
            }

            if (this.DelegateList.ContainsKey(procName))
            {
                return (T) this.DelegateList[procName];
            }

            ApiHandleRef ptr = this.ProdAddresses[procName];
            
            T del = null;
            try
            {
                del = Marshal.GetDelegateForFunctionPointer<T>(ptr);
                this.DelegateList.Add(procName, del);
            }
            catch (Exception e)
            {
                this.LastError = e.Message;
            }

            return del;
        }

        

        public bool Load()
        {
           this._Handle = Kernel32.LoadLibrary(this._LibPath);
           if (!this.IsValid)
           {
               Win32Exception ex = new Win32Exception(Marshal.GetLastWin32Error());
               this.LastError = ex.Message;
           }
           return this.IsValid;
        }

        public IntPtr Handle => this._Handle.Handle;
        private void SafeFreeLib()
        {
            if (!this.IsValid) return;
            Kernel32.FreeLibrary(this._Handle);
        }


        public void Dispose()
        {
            this.DelegateList.Clear();
            this.ProdAddresses.Clear();
            SafeFreeLib();
            this._Handle?.Dispose();
        }
    }
}