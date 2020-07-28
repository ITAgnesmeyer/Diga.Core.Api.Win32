using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    public class ApiStructHandleRef<T> : ApiHandleRef where T:struct
    {
        public ApiStructHandleRef(object wrapper) : base(wrapper, Allocate())
        {

        }

        public ApiStructHandleRef(object wrapper, T item):base(wrapper , Allocate(item))
        {
            
        }

        public ApiStructHandleRef(T item):base(Allocate(item))
        {
            
        }
        private static IntPtr Allocate(T item)
        {
            IntPtr ptr = Allocate();
            Marshal.StructureToPtr<T>(item, ptr, true);
            return ptr;
        }
        private static IntPtr Allocate()
        {
            IntPtr hItem = Marshal.AllocHGlobal(Marshal.SizeOf<T>());
            
            return hItem;
        }
        public ApiStructHandleRef() : base(Allocate())
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Marshal.FreeHGlobal(this.Handle);
            }
            base.Dispose(disposing);
        }
    }
}