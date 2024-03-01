using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Local

namespace Diga.Core.Api.Win32
{
    public static class AdvApi32
    {
        private const string ADVAPI32 = "advapi32.dll";
        private const CharSet CHARSET = CharSet.Auto;

        /// Return Type: BOOL->int
        ///lpBuffer: LPWSTR->WCHAR*
        ///pcbBuffer: LPDWORD->DWORD*
        [DllImport("advapi32.dll", EntryPoint = "GetUserNameW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetUserNameW(IntPtr lpBuffer, ref uint pcbBuffer);
        /// Return Type: BOOL->int
        ///lpszUsername: LPCWSTR->WCHAR*
        ///lpszDomain: LPCWSTR->WCHAR*
        ///lpszPassword: LPCWSTR->WCHAR*
        ///dwLogonType: DWORD->unsigned int
        ///dwLogonProvider: DWORD->unsigned int
        ///phToken: PHANDLE->HANDLE*
        [DllImport(ADVAPI32, EntryPoint = "LogonUserW")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LogonUserW([In()][MarshalAs(UnmanagedType.LPWStr)] string lpszUsername, [In()][MarshalAs(UnmanagedType.LPWStr)] string lpszDomain, [In()][MarshalAs(UnmanagedType.LPWStr)] string lpszPassword, uint dwLogonType, uint dwLogonProvider, out IntPtr phToken);
        public static string WhoAmI()
        {
            uint buffLen = 255;
            IntPtr pUserString = Marshal.AllocCoTaskMem((int)buffLen);
            bool r = GetUserNameW(pUserString, ref buffLen);
            int error = Marshal.GetLastWin32Error();
            string res = Marshal.PtrToStringUni(pUserString);
            Marshal.FreeCoTaskMem(pUserString);
            if(!r)
            {
                throw new Win32Exception(error);
            }
            return res;
        }


    }
}


