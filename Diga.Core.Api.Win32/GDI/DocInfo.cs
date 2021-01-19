using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.GDI
{
    [StructLayout(LayoutKind.Sequential,CharSet = CharSet.Auto)]
    public struct DocInfo
    {

        /// int
        public int cbSize;

        /// LPCWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszDocName;

        /// LPCWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszOutput;

        /// LPCWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszDatatype;

        /// DWORD->unsigned int
        public uint fwType;
    }
}