        using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Diga.Core.Api.Win32
{
    public static class Shell32
    {

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SHBrowseForFolder(ref BrowseInfo lpbi);

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern bool SHGetPathFromIDList(IntPtr pidl, StringBuilder pszPath);


    }
}