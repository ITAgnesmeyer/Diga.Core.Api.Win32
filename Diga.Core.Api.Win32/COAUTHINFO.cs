using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{

    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
    public class COAUTHINFO_X64 : IDisposable
    {
        public COAUTHINFO_X64(RpcAuthent authent, RpcAuthor author, string serverprinc, RpcLevel level, RpcImpers impers, IntPtr ciptr)
        {
            authnsvc = authent;
            authzsvc = author;
            serverprincname = serverprinc;
            authnlevel = level;
            impersonationlevel = impers;
            authidentitydata = ciptr;
        }
 
        public RpcAuthent authnsvc;
        public RpcAuthor authzsvc;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string serverprincname;
        public RpcLevel authnlevel;
        public RpcImpers impersonationlevel;
        public IntPtr authidentitydata;        // COAUTHIDENTITY*
        public int capabilities = 0;        // EOAC_NONE
#pragma warning disable 0649
        public int padding;
#pragma warning restore 0649
 
        void IDisposable.Dispose()
        {
            authidentitydata = IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
        ~COAUTHINFO_X64()
        {
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
    public class COAUTHINFO : IDisposable
    {
        public COAUTHINFO(RpcAuthent authent, RpcAuthor author, string serverprinc, RpcLevel level, RpcImpers impers, IntPtr ciptr) {
            authnsvc = authent;
            authzsvc = author;
            serverprincname = serverprinc;
            authnlevel = level;
            impersonationlevel = impers;
            authidentitydata = ciptr;
        }
 
        public RpcAuthent authnsvc;
        public RpcAuthor authzsvc;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string serverprincname;
        public RpcLevel authnlevel;
        public RpcImpers impersonationlevel;
        public IntPtr authidentitydata;        // COAUTHIDENTITY*
        public int capabilities = 0;        // EOAC_NONE
 
        void IDisposable.Dispose()
        {
            authidentitydata = IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
        ~COAUTHINFO()
        {
        }
    }
}