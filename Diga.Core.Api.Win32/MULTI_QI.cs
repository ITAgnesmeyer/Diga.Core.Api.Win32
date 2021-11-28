using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct MULTI_QI_X64 : IDisposable
    {
        public MULTI_QI_X64(IntPtr pid)
        {
            piid = pid;
            pItf = IntPtr.Zero;
            hr = 0;
            padding = 0;
        }
 
        public IntPtr piid;        // 'Guid' can't be marshaled to GUID* here? use IntPtr buffer trick instead
        public IntPtr pItf;
        public int hr;
#pragma warning disable 0649
        public int padding;
#pragma warning restore 0649
 
        void IDisposable.Dispose()
        {
            if (pItf != IntPtr.Zero) {
                Marshal.Release(pItf);
                pItf = IntPtr.Zero;
            }
            if (piid != IntPtr.Zero) {
                Marshal.FreeCoTaskMem(piid);
                piid = IntPtr.Zero;
            }
            GC.SuppressFinalize(this);
 
        }
    }


    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct MULTI_QI : IDisposable
    {
        public MULTI_QI(IntPtr pid) {
            piid = pid;
            pItf = IntPtr.Zero;
            hr = 0;
        }
 
        public IntPtr piid;        // 'Guid' can't be marshaled to GUID* here? use IntPtr buffer trick instead
        public IntPtr pItf;
        public int hr;
 
        void IDisposable.Dispose()
        {
            if (pItf != IntPtr.Zero)
            {
                Marshal.Release(pItf);
                pItf = IntPtr.Zero;
            }
            if (piid != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(piid);
                piid = IntPtr.Zero;
            }
            GC.SuppressFinalize(this);
 
        }
    }
}