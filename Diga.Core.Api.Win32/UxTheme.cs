using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    public static class UxTheme
    {
        private const string UXTHEME = "UxTheme.dll";
        /// Return Type: void
        ///dwFlags: DWORD->unsigned int
        [DllImport(UXTHEME, EntryPoint = "SetThemeAppProperties")]
        public static extern void SetThemeAppProperties(uint dwFlags);

        [DllImport(UXTHEME, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

        public const int STAP_ALLOW_NONCLIENT = (1 << 0);
        public const int STAP_ALLOW_CONTROLS = (1 << 1);
        public const int STAP_ALLOW_WEBCONTENT = (1 << 2);

        public static void EnableTheme()
        {
            UxTheme.SetThemeAppProperties(STAP_ALLOW_NONCLIENT | STAP_ALLOW_CONTROLS | STAP_ALLOW_WEBCONTENT);
        }
    }
}