        using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Diga.Core.Api.Win32
{
    public static class Shell32
    {
        private const string SHELL32 = "shell32.dll";
        private const CharSet CHARSET = CharSet.Auto;

        [DllImport(SHELL32, CharSet = CHARSET)]
        public static extern IntPtr SHBrowseForFolder(ref BrowseInfo lpbi);

        [DllImport(SHELL32, CharSet = CHARSET)]
        public static extern bool SHGetPathFromIDList(IntPtr pidl, StringBuilder pszPath);


    }
}