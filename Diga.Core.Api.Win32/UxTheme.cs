using Diga.Core.Api.Win32.GDI;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Diga.Core.Api.Win32
{
    public static class UxTheme
    {
        private const string UXTHEME = "UxTheme.dll";
        /// Return Type: void
        ///dwFlags: DWORD->unsigned int
        [DllImport(UXTHEME, EntryPoint = "SetThemeAppProperties")]
        public static extern void SetThemeAppProperties(uint dwFlags);

         [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern bool IsAppThemed();
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern int GetThemeAppProperties();
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern void SetThemeAppProperties(int Flags);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern IntPtr OpenThemeData(IntPtr hwnd, [MarshalAs(UnmanagedType.LPWStr)] string pszClassList);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern int CloseThemeData(IntPtr hTheme);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern int GetCurrentThemeName(StringBuilder pszThemeFileName, int dwMaxNameChars, StringBuilder pszColorBuff, int dwMaxColorChars, StringBuilder pszSizeBuff, int cchMaxSizeChars);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern bool IsThemePartDefined(IntPtr hTheme, int iPartId, int iStateId);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern int DrawThemeBackground(IntPtr hTheme, IntPtr hdc, int partId, int stateId, [In] Rect pRect, [In] Rect pClipRect);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern int DrawThemeEdge(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, [In] Rect pDestRect, int uEdge, int uFlags, [Out] Rect pContentRect);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern int DrawThemeParentBackground(IntPtr hwnd, IntPtr hdc, [In] Rect prc);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern int DrawThemeText(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, [MarshalAs(UnmanagedType.LPWStr)] string pszText, int iCharCount, int dwTextFlags, int dwTextFlags2, [In] Rect pRect);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern int GetThemeBackgroundContentRect(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, [In] Rect pBoundingRect, [Out] Rect pContentRect);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern int GetThemeBackgroundExtent(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, [In] Rect pContentRect, [Out] Rect pExtentRect);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern int GetThemeBackgroundRegion(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, [In] Rect pRect, ref IntPtr pRegion);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern int GetThemeBool(IntPtr hTheme, int iPartId, int iStateId, int iPropId, ref bool pfVal);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern int GetThemeColor(IntPtr hTheme, int iPartId, int iStateId, int iPropId, ref int pColor);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern int GetThemeEnumValue(IntPtr hTheme, int iPartId, int iStateId, int iPropId, ref int piVal);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern int GetThemeFilename(IntPtr hTheme, int iPartId, int iStateId, int iPropId, StringBuilder pszThemeFilename, int cchMaxBuffChars);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern int GetThemeFont(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, int iPropId, LogFont pFont);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern int GetThemeInt(IntPtr hTheme, int iPartId, int iStateId, int iPropId, ref int piVal);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern int GetThemePartSize(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, [In] Rect prc, ThemeSizeType eSize, [Out] Size psz);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern int GetThemePosition(IntPtr hTheme, int iPartId, int iStateId, int iPropId, [Out] Point pPoint);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern int GetThemeMargins(IntPtr hTheme, IntPtr hDC, int iPartId, int iStateId, int iPropId, ref Margins margins);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern int GetThemeString(IntPtr hTheme, int iPartId, int iStateId, int iPropId, StringBuilder pszBuff, int cchMaxBuffChars);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern int GetThemeDocumentationProperty([MarshalAs(UnmanagedType.LPWStr)] string pszThemeName, [MarshalAs(UnmanagedType.LPWStr)] string pszPropertyName, StringBuilder pszValueBuff, int cchMaxValChars);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern int GetThemeTextExtent(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, [MarshalAs(UnmanagedType.LPWStr)] string pszText, int iCharCount, int dwTextFlags, [In] Rect pBoundingRect, [Out] Rect pExtentRect);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern int GetThemeTextMetrics(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref TextMetric ptm);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
       public static extern int HitTestThemeBackground(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId,
           int dwOptions, [In] Rect pRect, IntPtr hrgn, [In] Point ptTest, ref int pwHitTestCode);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern bool IsThemeBackgroundPartiallyTransparent(IntPtr hTheme, int iPartId, int iStateId);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
        public static extern bool GetThemeSysBool(IntPtr hTheme, int iBoolId);
        [DllImport(UXTHEME, CharSet=CharSet.Auto)]
       
        public static extern int GetThemeSysInt(IntPtr hTheme, int iIntId, ref int piValue);


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