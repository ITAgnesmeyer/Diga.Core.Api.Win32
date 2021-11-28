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

        [DllImport(OLE32, EntryPoint = "CLSIDFromProgID", CallingConvention = CallingConvention.StdCall)]
        public static extern int CLSIDFromProgID([In][MarshalAs(UnmanagedType.LPWStr)] string lpszProgID, out Guid lpclsid);


        [DllImport(OLE32, EntryPoint = "CLSIDFromProgIDEx", CallingConvention = CallingConvention.StdCall)]
        public static extern int CLSIDFromProgIDEx([In][MarshalAs(UnmanagedType.LPWStr)] string lpszProgID, out Guid lpclsid);

        [DllImport(OLE32, EntryPoint = "CLSIDFromString", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int CLSIDFromString(string lpsz, out Guid pclsid);


        [DllImport(OLE32, CharSet = CharSet.Unicode, ExactSpelling = true, PreserveSig = false)]
        [return: MarshalAs(UnmanagedType.LPWStr)]
        public static extern string StringFromCLSID([MarshalAs(UnmanagedType.LPStruct)] Guid rclsid);

        [DllImport(OLE32, CharSet = CharSet.Unicode)]
        internal static extern int CoSetProxyBlanket(IntPtr pProxy, RpcAuthent authent, RpcAuthor author,
            string serverprinc, RpcLevel level, RpcImpers
                impers,
            IntPtr ciptr, int dwCapabilities);

        [DllImport(OLE32, PreserveSig=false)] 
        public static extern void CoCreateInstance(
            [In] ref Guid clsid,
            IntPtr pUnkOuter,
            int context,
            [In] ref Guid iid,
            [MarshalAs(UnmanagedType.IUnknown)] out Object o );

        [DllImport(OLE32, CharSet = CharSet.Unicode, ExactSpelling = true, PreserveSig = false)]
        public static extern void CoCreateInstanceEx(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid rclsid,
            [MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter,
            CLSCTX dwClsCtx,
            IntPtr pServerInfo,
            uint cmq,
            [In, Out] MULTI_QI[] pResults);

        [DllImport(OLE32, CharSet = CharSet.Unicode)]
        internal static extern int CoCreateInstanceEx(ref Guid clsid, IntPtr pUnkOuter,
            int dwClsContext, [In, Out] COSERVERINFO_X64 srv,
            int num, [In, Out] MULTI_QI_X64[] amqi);

        [DllImport(OLE32, CharSet = CharSet.Unicode)]
        public static extern int CoCreateInstanceEx(ref Guid clsid, IntPtr pUnkOuter,
            int dwClsContext, [In, Out] COSERVERINFO srv,
            int num, [In, Out] MULTI_QI[] amqi);

        public static object CreateRemoteObject(Type remoteObjectType, Type remoteObjectInterfaceType, string server,
            string username, string domain, string password)
        {
            if (IntPtr.Size == 8)
            {
                return CreateRemoteObjectX64(remoteObjectType.GUID, remoteObjectInterfaceType.GUID, server, username, domain,
                    password);
            }
           
            return CreateRemoteObjectX32(remoteObjectType.GUID, remoteObjectInterfaceType.GUID, server, username, domain,
                password);

        }

        public static object CreateRemoteObjectX64(Guid remoteObjectGuid, Guid remoteObjectInterfaceGuid, string server,
            string username, string domain, string password)
        {
            MULTI_QI_X64[]      amqi            = new MULTI_QI_X64[1];
            IntPtr              guidbuf         = IntPtr.Zero;
            COAUTHINFO_X64      ca              = null;
            IntPtr              captr           = IntPtr.Zero;
            COSERVERINFO_X64    cs              = null;
            Guid                clsid           = remoteObjectGuid;
            int                 hr              = 0;
            COAUTHIDENTITY_X64  ci              = null;
            IntPtr              ciptr           = IntPtr.Zero;
             try {
                guidbuf = Marshal.AllocCoTaskMem(16);
                Marshal.StructureToPtr(remoteObjectInterfaceGuid, guidbuf, false);
                amqi[0] = new MULTI_QI_X64(guidbuf);
 
                ci = new COAUTHIDENTITY_X64(username, domain, password);
                ciptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(ci));
                Marshal.StructureToPtr(ci, ciptr, false);
 
                ca = new COAUTHINFO_X64(RpcAuthent.WinNT, RpcAuthor.None, null, RpcLevel.Default, RpcImpers.Impersonate, ciptr);
                captr = Marshal.AllocCoTaskMem(Marshal.SizeOf(ca));
                Marshal.StructureToPtr(ca, captr, false);
 
                cs = new COSERVERINFO_X64(server, captr);
                hr = CoCreateInstanceEx(ref clsid, IntPtr.Zero, (int)ClsCtx.RemoteServer, cs, 1, amqi);
                if ((uint)hr == 0x80040154)
                    throw new Exception("Make sure remote server is enabled for config access");
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);
                if (amqi[0].hr < 0)
                    Marshal.ThrowExceptionForHR(amqi[0].hr);
                hr =CoSetProxyBlanket(amqi[0].pItf, RpcAuthent.WinNT, RpcAuthor.None, null, RpcLevel.Default, RpcImpers.Impersonate, ciptr, 0);
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);
                return Marshal.GetObjectForIUnknown(amqi[0].pItf);
            } finally {
                if (amqi[0].pItf != IntPtr.Zero) {
                    Marshal.Release(amqi[0].pItf);
                    amqi[0].pItf = IntPtr.Zero;
                }
                amqi[0].piid = IntPtr.Zero;
                if (captr != IntPtr.Zero) {
                    Marshal.DestroyStructure(captr, typeof(COAUTHINFO_X64));
                    Marshal.FreeCoTaskMem(captr);
                }
                if (ciptr != IntPtr.Zero) {
                    Marshal.DestroyStructure(ciptr, typeof(COAUTHIDENTITY_X64));
                    Marshal.FreeCoTaskMem(ciptr);
                }
                if (guidbuf != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(guidbuf);
            }
        }

        public static object CreateRemoteObjectX32(Guid remoteObjectGuid, Guid remoteObjectInterfaceGuid,string server, string username, string domain,
            string password)
        {
            MULTI_QI []     amqi            = new MULTI_QI[1];
            IntPtr          guidbuf         = IntPtr.Zero;
            COAUTHINFO      ca              = null;
            IntPtr          captr           = IntPtr.Zero;
            COSERVERINFO    cs              = null;
            Guid clsid = remoteObjectGuid;
            int             hr              = 0;
            COAUTHIDENTITY  ci              = null;
            IntPtr          ciptr           = IntPtr.Zero;

            try
            {
                guidbuf = Marshal.AllocCoTaskMem(16);
                Marshal.StructureToPtr(remoteObjectInterfaceGuid, guidbuf, false);
                amqi[0] = new MULTI_QI(guidbuf);
 
                ci = new COAUTHIDENTITY(username, domain, password);
                ciptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(ci));
                Marshal.StructureToPtr(ci, ciptr, false);
 
                ca = new COAUTHINFO(RpcAuthent.WinNT, RpcAuthor.None, null, RpcLevel.Default, RpcImpers.Impersonate, ciptr);
                captr = Marshal.AllocCoTaskMem(Marshal.SizeOf(ca));
                Marshal.StructureToPtr(ca, captr, false);
 
                cs = new COSERVERINFO(server, captr);
                hr = CoCreateInstanceEx(ref clsid, IntPtr.Zero, (int)ClsCtx.RemoteServer, cs, 1, amqi);
                if ((uint)hr == 0x80040154)
                    throw new Exception("Make sure remote server is enabled for config access");
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);
                if (amqi[0].hr < 0)
                    Marshal.ThrowExceptionForHR(amqi[0].hr);
                hr =CoSetProxyBlanket(amqi[0].pItf, RpcAuthent.WinNT, RpcAuthor.None, null, RpcLevel.Default, RpcImpers.Impersonate, ciptr, 0);
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);
                return Marshal.GetObjectForIUnknown(amqi[0].pItf);
            }
            finally
            {
                if (amqi[0].pItf != IntPtr.Zero)
                {
                    Marshal.Release(amqi[0].pItf);
                    amqi[0].pItf = IntPtr.Zero;
                }
                amqi[0].piid = IntPtr.Zero;
                if (captr != IntPtr.Zero) {
                    Marshal.DestroyStructure(captr, typeof(COAUTHINFO));
                    Marshal.FreeCoTaskMem(captr);
                }
                if (ciptr != IntPtr.Zero) {
                    Marshal.DestroyStructure(ciptr, typeof(COAUTHIDENTITY));
                    Marshal.FreeCoTaskMem(ciptr);
                }
                if (guidbuf != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(guidbuf);
            }

        }
        
    }
}