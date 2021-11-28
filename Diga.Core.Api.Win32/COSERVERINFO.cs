using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{

#pragma warning disable 0649
    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
    public class COSERVERINFO_X64 : IDisposable
    {
        public COSERVERINFO_X64(string srvname, IntPtr authinf)
        {
            servername = srvname;
            authinfo = authinf;
        }
 

        public int reserved1;
        public int padding1;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string servername;
        public IntPtr authinfo;                // COAUTHINFO*
        public int reserved2;
        public int padding2;
        void IDisposable.Dispose()
        {
            authinfo = IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
        ~COSERVERINFO_X64()
        {
        }
    }


    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
    public class COSERVERINFO : IDisposable
    {
        public COSERVERINFO(string srvname, IntPtr authinf) {
            servername = srvname;
            authinfo = authinf;
        }
 
        public int reserved1;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string servername;
        public IntPtr authinfo;                // COAUTHINFO*
        public int reserved2;
        void IDisposable.Dispose()
        {
            authinfo = IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
        ~COSERVERINFO()
        {
        }
    }

#pragma warning restore 0649

}