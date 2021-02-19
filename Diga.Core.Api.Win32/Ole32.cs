using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    public static class Ole32
    {
        private const string OLE32 = "ole32.dll";
        ///pvReserved: LPVOID->void*
        [DllImport(OLE32, EntryPoint = "OleInitialize", CallingConvention = CallingConvention.StdCall)]
        public static extern int OleInitialize(IntPtr pvReserved);

        /// Return Type: void
        [DllImport(OLE32, EntryPoint = "OleUninitialize", CallingConvention = CallingConvention.StdCall)]
        public static extern void OleUninitialize();

        [DllImport(OLE32, EntryPoint = "CoLockObjectExternal", CallingConvention = CallingConvention.StdCall, PreserveSig = true)]
        public static extern int CoLockObjectExternal([MarshalAs(UnmanagedType.IUnknown)] object pUnk, [MarshalAs(UnmanagedType.Bool)] bool fLock, [MarshalAs(UnmanagedType.Bool)] bool fLastUnlockReleases);

        [DllImport(OLE32, EntryPoint = "CoLockObjectExternal", CallingConvention = CallingConvention.StdCall, PreserveSig = true)]
        public static extern int CoLockObjectExternal(IntPtr pUnk, [MarshalAs(UnmanagedType.Bool)] bool fLock, [MarshalAs(UnmanagedType.Bool)] bool fLastUnlockReleases);

        [DllImport(OLE32, SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = true)]
        public extern static void CoTaskMemFree(IntPtr pv);
    }
}