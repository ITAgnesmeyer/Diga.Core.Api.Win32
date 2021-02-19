using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Diga.Core.Api.Win32
{
    public static class ComCtl32
    {
        private const string COMCTL32 = "comctl32.dll";

        [DllImport(COMCTL32)]
        public static extern void InitCommonControls();

        [DllImport(COMCTL32, EntryPoint = "InitCommonControlsEx", CallingConvention = CallingConvention.StdCall)]
        public static extern bool InitCommonControlsEx(ref InitCommonControlsEx iccex);


        [DllImport(COMCTL32, EntryPoint = "ImageList_Create")]
        public static extern IntPtr ImageList_Create(int cx, int cy, int flags, int cInitial, int cGrow);

        //[DllImport(COMCTL32, EntryPoint = "ImageList_Add", CallingConvention = CallingConvention.StdCall)]
        //public static extern int ImageList_Add(IntPtr hIml, IntPtr hbmImage, IntPtr hbmMask);

        [DllImport(COMCTL32, EntryPoint = "ImageList_Destroy")]
        public static extern int ImageList_Destroy(IntPtr hIml);

        [DllImport(COMCTL32)]
        public static extern int ImageList_GetImageCount(IntPtr hIml);

        [DllImport(COMCTL32)]
        public static extern int ImageList_Add(IntPtr hIml, IntPtr hbmImage, IntPtr hbmMask);

        [DllImport(COMCTL32)]
        public static extern int ImageList_ReplaceIcon(IntPtr hIml, int index, IntPtr hicon);

        [DllImport(COMCTL32)]
        public static extern int ImageList_SetBkColor(IntPtr hIml, int clrBk);

        [DllImport(COMCTL32)]
        public static extern bool ImageList_Draw(IntPtr hIml, int i, IntPtr hdcDst, int x, int y, int fStyle);

        [DllImport(COMCTL32)]
        public static extern bool ImageList_Replace(IntPtr hIml, int i, IntPtr hbmImage, IntPtr hbmMask);

        [DllImport(COMCTL32)]
        public static extern bool ImageList_DrawEx(IntPtr hIml, int i, IntPtr hdcDst, int x, int y, int dx, int dy,
            int rgbBk, int rgbFg, int fStyle);

        [DllImport(COMCTL32)]
        public static extern bool ImageList_GetIconSize(IntPtr hIml, out int x, out int y);

        [DllImport(COMCTL32)]
        public static extern IntPtr ImageList_Duplicate(IntPtr hIml);


        [DllImport(COMCTL32)]
        public static extern bool ImageList_Remove(IntPtr hIml, int i);
        [DllImport(COMCTL32)]
        public static extern bool ImageList_GetImageInfo(IntPtr hIml, int i, ImageInfo pImageInfo);

        [DllImport(COMCTL32)]
        public static extern bool ImageList_Write(IntPtr hIml, IStream pstm);

        [DllImport(COMCTL32)]
        public static extern int ImageList_WriteEx(HandleRef hIml, int dwFlags, IStream pstm);


    }
}