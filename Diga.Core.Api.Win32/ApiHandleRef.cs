using System;

namespace Diga.Core.Api.Win32
{
    public class ApiHandleRef : IDisposable
    {
        private object _Wrapper;
        private  IntPtr _Handle;
        private bool _DisposedValue;



        public ApiHandleRef(object wrapper, IntPtr handel)
        {
            if (wrapper == null)
                this._Wrapper = this;
            else
                this._Wrapper = wrapper;

            this._Handle = handel;
        }
        public ApiHandleRef(IntPtr handle) : this(null, handle)
        {
        }

        public bool IsValid => this._Handle != IntPtr.Zero;
        public object Wrapper => this._Wrapper;
        public IntPtr Handle => this._Handle;

        public static implicit operator IntPtr(ApiHandleRef input)
        {
            return input.Handle;
        }

        public static implicit operator ApiHandleRef(IntPtr input)
        {
            return new ApiHandleRef(input);
        }

        public static bool operator ==(ApiHandleRef left, ApiHandleRef right)
        {
            if (((object)left) == null) return false;
            if (((object)right) == null) return false;
            return left.Handle == right.Handle;
        }

        public static bool operator !=(ApiHandleRef left, ApiHandleRef right)
        {
            if (((object)left) == null) return false;
            if (((object)right) == null) return false;
            return left.Handle != right.Handle;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ApiHandleRef)) return false;
            ApiHandleRef right = (ApiHandleRef)obj;
            return this == right;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._DisposedValue)
            {
                if (disposing)
                {
                    this._Handle = IntPtr.Zero;
                    this._Wrapper = null;
                }

            
                this._DisposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}