using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Mem
{
    public class SharedMem:IDisposable
    {
        private IntPtr _FileHandle;
        private IntPtr _FileMap;

        public IntPtr RootHandle => this._FileMap;


        public T ToStruct<T>() where T:struct
        {
            T t = Marshal.PtrToStructure<T>(this.RootHandle);
            return t;
        }
        public SharedMem(string name, bool existing, uint sizeInBytes)
        {
            if (existing)
            {
                this._FileHandle = Kernel32.OpenFileMapping(FileRights.ReadWrite, false, name);
            }
            else
            {
                this._FileHandle = Kernel32.CreateFileMapping(Kernel32.NoFileHandle, 0,
                    FileProtection.ReadWrite,
                    0, sizeInBytes, name);
            }

            if (this._FileHandle == IntPtr.Zero)
            {
                throw new Exception
                    ("Open/create error: " + Marshal.GetLastWin32Error());
            }

            // Obtain a read/write map for the entire file
            this._FileMap = Kernel32.MapViewOfFile(this._FileHandle, (uint)FileRights.ReadWrite, 0, 0, 0);

            if (this._FileMap == IntPtr.Zero)
            {
                throw new Exception
                    ("MapViewOfFile error: " + Marshal.GetLastWin32Error());
            }
        }

        public void Dispose()
        {
            if (this._FileMap != IntPtr.Zero)
            {
                Kernel32.UnmapViewOfFile(this._FileMap);
            }

            if (this._FileHandle != IntPtr.Zero)
            {
                Kernel32.CloseHandle(this._FileHandle);
            }

            this._FileMap = this._FileHandle = IntPtr.Zero;
        }
    }
}
