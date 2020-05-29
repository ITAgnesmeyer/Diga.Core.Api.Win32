using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    public static class Gid32
    {
        private const string GDI32 = "gdi32.dll";
        
        [DllImport(GDI32)]
        public static extern IntPtr GetStockObject(StockObjects fnObject);
        [DllImport(GDI32, EntryPoint = "CreateSolidBrush", SetLastError = true)]
        public static extern IntPtr CreateSolidBrush(int crColor);


        [DllImport(GDI32, EntryPoint = "SetBkColor", SetLastError = true)]
        public static extern uint SetBkColor(IntPtr hdc, int crColor);

        [DllImport(GDI32)]
        public static extern uint SetTextColor(IntPtr hdc, int crColor);

        
        /// Return Type: int
        ///hdc: HDC->HDC__*
        ///index: int
        [DllImport(GDI32, EntryPoint = "GetDeviceCaps")]
        public static extern int GetDeviceCaps([In] IntPtr hdc, int index);

        /// Return Type: HFONT->HFONT__*
        ///lplf: LOGFONTW*
        [DllImport(GDI32, EntryPoint = "CreateFontIndirectW")]
        public static extern IntPtr CreateFontIndirect([In] ref LogFontW lplf);


        [DllImport(GDI32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetObject(IntPtr hObject, int nSize, [In, Out] LogFontW lf);

        
        public static int GetObject(IntPtr hObject, LogFontW lp)
        {
            return GetObject(hObject, Marshal.SizeOf(typeof(LogFontW)), lp);
        }


        public static int RGB(int r, int g, int b) => checked(checked(checked(b * 65536) + checked(g * 256)) + r);
    }
}