using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
#pragma warning disable 0649

    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
    public class COAUTHIDENTITY_X64
    {
        public COAUTHIDENTITY_X64(string usr, string dom, string pwd)
        {
            user = usr;
            userlen = (user == null) ? 0 : user.Length;
            domain = dom;
            domainlen = (domain == null) ? 0 : domain.Length;
            password = pwd;
            passwordlen = (password == null) ? 0 : password.Length;
        }
 
        [MarshalAs(UnmanagedType.LPWStr)]
        public string user = null;
        public int userlen = 0;

        public int padding1;

 
        [MarshalAs(UnmanagedType.LPWStr)]
        public string domain = null;
        public int domainlen = 0;
        public int padding2;
 
        [MarshalAs(UnmanagedType.LPWStr)]
        public string password = null;
        public int passwordlen = 0;
        public int flags = 2;        // SEC_WINNT_AUTH_IDENTITY_UNICODE
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
    public class COAUTHIDENTITY
    {
        public COAUTHIDENTITY(string usr, string dom, string pwd) {
            user = usr;
            userlen = (user==null) ? 0 : user.Length;
            domain = dom;
            domainlen = (domain==null) ? 0 : domain.Length;
            password = pwd;
            passwordlen = (password==null) ? 0 : password.Length;
        }
 
        [MarshalAs(UnmanagedType.LPWStr)]
        public string user = null;
        public int userlen = 0;
 
        [MarshalAs(UnmanagedType.LPWStr)]
        public string domain = null;
        public int domainlen = 0;
 
        [MarshalAs(UnmanagedType.LPWStr)]
        public string password = null;
        public int passwordlen = 0;
        public int flags = 2;        // SEC_WINNT_AUTH_IDENTITY_UNICODE
    }

#pragma warning restore 0649
}