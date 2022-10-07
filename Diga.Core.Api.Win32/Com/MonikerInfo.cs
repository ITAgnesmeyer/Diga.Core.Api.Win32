using System;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;

namespace Diga.Core.Api.Win32.Com
{
    public class MonikerInfo
    {
        private object _Moniker;
        private object _Context;
        public MonikerInfo(IBindCtx context, IMoniker moniker)
        {
            this._Context = context;
            this._Moniker = moniker;
                
            
        }

        public IBindCtx Context { get=>(IBindCtx)this._Context; }
        public IMoniker Moniker { get=>(IMoniker)this._Moniker; }

        public Guid ClassId
        {
            get
            {
                this.Moniker.GetClassID(out Guid clsId);
                return clsId;
            }
        }

        public string GetDisplayName
        {
            get
            {
                try
                {
                    this.Moniker.GetDisplayName(this.Context,null, out string displayName );
                    return displayName;

                }
                catch (UnauthorizedAccessException)
                {
                    return null;
                }
            }
        }
        public long StreamSizeNeeded
        {
            get
            {
                this.Moniker.GetSizeMax(out long size);
                return size;
            }
        }

        public bool IsRunning
        {
            get
            {
                HRESULT result = this.Moniker.IsRunning(this.Context, null, this.Moniker);
                return result == HRESULT.S_OK;
            }
        }

        public bool IsDirty
        {
            get
            {
                HRESULT result = this.Moniker.IsDirty();
                return result == HRESULT.S_OK;

            }
        }

        public bool IsSystemMoniker
        {
            get
            {
                HRESULT result = this.Moniker.IsSystemMoniker(out int mKSys);
                if (result == HRESULT.S_OK)
                {
                    Debug.Print(((MKSYS)mKSys).ToString());
                    return mKSys != (int)MKSYS.MKSYS_NONE;
                }

                return false;
            }
        }
#if NETCOREAPP

        public DateTime TimeOfLastChange
        {
            get
            {
                this.Moniker.GetTimeOfLastChange(this.Context,this.Moniker, out var fTime);
                FileTime ft = fTime;
                Kernel32.FileTimeToSystemTime(ref ft, out SystemTime sysTime);
                return sysTime;
            }
        }
#endif

        public bool IsEqual(IMoniker moniker)
        {
            HRESULT result = this.Moniker.IsEqual(moniker);
            return result == HRESULT.S_OK;
        }
    }
}