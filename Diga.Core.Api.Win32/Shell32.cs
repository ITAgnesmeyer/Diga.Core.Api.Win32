using System;
using System.Runtime.InteropServices;
using System.Text;
using Diga.Core.Api.Win32.Com;

namespace Diga.Core.Api.Win32
{
    public static class Shell32
    {

        public const int MAX_PATH = 260;
        public const int MAX_UNICODESTRING_LEN = short.MaxValue;



        private const string SHELL32 = "shell32.dll";
        private const CharSet CHARSET = CharSet.Auto;

        [DllImport(SHELL32, CharSet = CHARSET)]
        public static extern IntPtr SHBrowseForFolder(ref BrowseInfo lpbi);

        [DllImport(SHELL32, CharSet = CHARSET)]
        public static extern bool SHGetPathFromIDList(IntPtr pidl, StringBuilder pszPath);

        [DllImport(SHELL32)]
        public static extern int SHGetSpecialFolderLocation(IntPtr hwnd, int csidl, ref IntPtr ppidl);

        [DllImport(SHELL32, CharSet = CharSet.Auto)]
        private static extern bool SHGetPathFromIDListEx(IntPtr pidl, IntPtr pszPath, int cchPath, int flags);

        public static bool SHGetPathFromIDListLongPath(IntPtr pidl, ref IntPtr pszPath)
        {
            int iterator = 1;
            int length = MAX_PATH;
            bool result;

            while ((result = SHGetPathFromIDListEx(pidl, pszPath, length, 0)) == false && length < MAX_UNICODESTRING_LEN)
            {
                string path = Marshal.PtrToStringAuto(pszPath);

                // ReSharper disable once PossibleNullReferenceException
                if (path.Length != 0 && path.Length < length)
                    break;

                iterator += 2;
                if (iterator * length >= MAX_UNICODESTRING_LEN)
                {
                    length = MAX_UNICODESTRING_LEN;
                }
                else
                {
                    length = iterator * length;
                }

                pszPath = Marshal.ReAllocHGlobal(pszPath, (IntPtr)((length + 1) * Marshal.SystemDefaultCharSize));
            }

            return result;
        }

        [DllImport(SHELL32)]
        public static extern int SHGetMalloc([Out, MarshalAs(UnmanagedType.LPArray)] IMalloc[] ppMalloc);


        [DllImport(SHELL32, PreserveSig = true)]

        private static extern int SHGetKnownFolderPath(ref Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr pszPath);

        public static int SHGetFolderPathEx(ref Guid rfid, uint dwFlags, IntPtr hToken, StringBuilder pszPath)
        {
            int result = -1;
            if ((result = SHGetKnownFolderPath(ref rfid, dwFlags, hToken, out var path)) == HRESULT.S_OK)
            {
                pszPath.Append(Marshal.PtrToStringAuto(path));
                Marshal.FreeCoTaskMem(path);
            }
            return result;

        }
        [DllImport(SHELL32, PreserveSig = true)]
        public static extern int SHCreateShellItem(IntPtr pidlParent, IntPtr psfParent, IntPtr pidl, out IShellItem ppsi);

        [DllImport(SHELL32, PreserveSig = true)]
        public static extern int SHILCreateFromPath([MarshalAs(UnmanagedType.LPWStr)]string pszPath, out IntPtr ppIdl, ref uint rgflnOut);
    }
}