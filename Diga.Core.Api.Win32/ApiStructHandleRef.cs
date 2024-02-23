using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    public class ApiClassHandleRef<T> : ApiHandleRef where T : class
    {
        public ApiClassHandleRef(object wrapper) : base(wrapper, Allocate())
        {

        }

        public ApiClassHandleRef(object wrapper, T item) : base(wrapper, Allocate(item))
        {

        }

        public ApiClassHandleRef(T item) : base(Allocate(item))
        {

        }
        private static IntPtr Allocate(T item)
        {
            IntPtr ptr = Allocate();
            Marshal.StructureToPtr(item, ptr, false);
            return ptr;
        }
        private static IntPtr Allocate()
        {
            IntPtr hItem = Marshal.AllocHGlobal(Marshal.SizeOf<T>());

            return hItem;
        }
        public ApiClassHandleRef() : base(Allocate())
        {
        }
        public T GetClass()
        {
#pragma warning disable IL2091
            return Marshal.PtrToStructure< T >(this.Handle);
#pragma warning restore IL2091
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
            Marshal.StructureToPtr(item, ptr, false);
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
        public T GetStruct()
        {
#pragma warning disable IL2091
            return Marshal.PtrToStructure<T>(this.Handle);
#pragma warning restore IL2091
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