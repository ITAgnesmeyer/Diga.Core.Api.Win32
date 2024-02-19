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
        public static extern IntPtr ImageList_Create( [In] int cx,
            [In] int cy,
            [In] uint flags,
            [In] int cInitial,
            [In] int cGrow);

        //[DllImport(COMCTL32, EntryPoint = "ImageList_Add", CallingConvention = CallingConvention.StdCall)]
        //public static extern int ImageList_Add(IntPtr hIml, IntPtr hbmImage, IntPtr hbmMask);

        [DllImport(COMCTL32, EntryPoint = "ImageList_Destroy")]
        public static extern int ImageList_Destroy([In] IntPtr hIml);

        [DllImport(COMCTL32)]
        public static extern int ImageList_GetImageCount([In] IntPtr hIml);

        [DllImport(COMCTL32)]
        public static extern int ImageList_SetImageCount([In] IntPtr hIml, [In] uint uNewCount);


        [DllImport(COMCTL32)]
        public static extern int ImageList_Add([In] IntPtr hIml, [In] IntPtr hbmImage, [In, Optional] IntPtr hbmMask);

        [DllImport(COMCTL32)]
        public static extern int ImageList_ReplaceIcon([In] IntPtr hIml, [In] int index, [In] IntPtr hicon);

        [DllImport(COMCTL32)]
        public static extern uint ImageList_SetBkColor([In] IntPtr hIml, [In] uint clrBk);
        
        [DllImport(COMCTL32)]
        public static extern uint ImageList_GetBkColor([In] IntPtr hIml);
        
        [DllImport(COMCTL32)]
        public static extern int ImageList_SetOverlayImage([In] IntPtr hIml, [In] int imageIndex, [In] int OverlayIndex);

        public static int ImageList_AddIcon(IntPtr hIml, IntPtr hIcon)
        {
            return ImageList_ReplaceIcon(hIml, -1, hIcon);
        }

        [DllImport(COMCTL32)]
        public static extern bool ImageList_Draw([In] IntPtr hIml, [In] int i, [In] IntPtr hdcDst, [In] int x, [In] int y, int fStyle);

        [DllImport(COMCTL32)]
        public static extern bool ImageList_Replace(IntPtr hIml, int i, IntPtr hbmImage, IntPtr hbmMask);

        [DllImport(COMCTL32)]
        public static extern int ImageList_AddMasked(IntPtr hIml, IntPtr hbmImage, int crMask);

        [DllImport(COMCTL32)]
        public static extern bool ImageList_DrawEx(IntPtr hIml, int i, IntPtr hdcDst, int x, int y, int dx, int dy,
            int rgbBk, int rgbFg, int fStyle);

        [DllImport(COMCTL32)]
        public static extern bool ImageList_DrawIndirect([MarshalAs(UnmanagedType.Struct)] IMAGELISTDRAWPARAMS pImLdp);

        [DllImport(COMCTL32)]
        public static extern bool ImageList_Remove(IntPtr hIml, int i);

        [DllImport(COMCTL32)]
        public static extern IntPtr ImageList_GetIcon(IntPtr hIml, int i, uint flags);

        [DllImport(COMCTL32)]
        public static extern IntPtr ImageList_LoadImageA(IntPtr hInstance, [MarshalAs(UnmanagedType.LPStr)] string lpBmp, int cx, int cGrow, int crMask, uint uType, uint uFlags);

        [DllImport(COMCTL32)]
        public static extern IntPtr ImageList_LoadImageW(IntPtr hInstance, [MarshalAs(UnmanagedType.LPWStr)] string lpBmp, int cx, int cGrow, int crMask, uint uType, uint uFlags);

        [DllImport(COMCTL32)]
        public static extern bool ImageList_Copy(IntPtr himlDst, int iDst, IntPtr himlSrc, int iSrc, uint uFalgs);

        [DllImport(COMCTL32)]
        public static extern bool ImageList_BeginDrag(IntPtr himlTrack, int iTrack, int dxHotspot, int dyHotspot);

        [DllImport(COMCTL32)]
        public static extern void ImageList_EndDrag();

        [DllImport(COMCTL32)]
        public static extern bool ImageList_DragEnter(IntPtr hwndLock, int x, int y);

        [DllImport(COMCTL32)]
        public static extern bool ImageList_DragLeave(IntPtr hwndLock);

        [DllImport(COMCTL32)]
        public static extern bool ImageList_DragMove(int x , int y);

        [DllImport(COMCTL32)]
        public static extern bool ImageList_SetDragCursorImage(IntPtr himlDrag, int iDrag, int dxHotspot, int dyHotspot);

        [DllImport(COMCTL32)]
        public static extern bool ImageList_DragShowNolock(bool fShow);

        [DllImport(COMCTL32)]
        public static extern IntPtr ImageList_GetDragImage(out Point ppt, out Point pptHotspot);

        public static bool ImageList_RemoveAll(IntPtr hIml)
        {
            return ImageList_Remove(hIml, -1);
        }

        public static IntPtr ImageList_ExtractIcon(IntPtr hInstance, IntPtr hIml, int i)
        {
            return ImageList_GetIcon(hIml, i, 0);
        }

        public static IntPtr ImageList_LoadBitmapW(IntPtr hInstance, string lpbmp, int cx, int cGrow,int crMask)
        {
            return ImageList_LoadImageW(hInstance, lpbmp, cx, cGrow, crMask, ImageTypeConst.IMAGE_BITMAP,0);
        }
        public static IntPtr ImageList_LoadBitmapA(IntPtr hInstance, string lpbmp, int cx, int cGrow, int crMask)
        {
            return ImageList_LoadImageA(hInstance, lpbmp, cx, cGrow, crMask, ImageTypeConst.IMAGE_BITMAP, 0);
        }

        [DllImport(COMCTL32)]
        public static extern IntPtr ImageList_Read([MarshalAs(UnmanagedType.LPStruct)]IStream stream);

        [DllImport(COMCTL32)]
        public static extern bool ImageList_Write(IntPtr himl, [MarshalAs(UnmanagedType.LPStruct)] IStream pStr);

        [DllImport(COMCTL32)]
        public static extern int ImageList_ReadEx(uint dwFlags, IStream pstm, ref Guid riid, out object ppv);

        [DllImport(COMCTL32)]
        public static extern int ImageList_WriteEx(IntPtr hIml, int dwFlags, [MarshalAs(UnmanagedType.LPStruct)] IStream pstm);




        [DllImport(COMCTL32)]
        public static extern bool ImageList_GetIconSize(IntPtr hIml, out int x, out int y);

        [DllImport(COMCTL32)]
        public static extern bool ImageList_SetIconSize(IntPtr hIml, int cx, int cy);


        [DllImport(COMCTL32)]
        public static extern bool ImageList_GetImageInfo(IntPtr hIml, int i,out ImageInfo pImageInfo);


        [DllImport(COMCTL32)]
        public static extern IntPtr ImageList_Duplicate(IntPtr hIml);


 
      

        //[DllImport(COMCTL32)]
        //public static extern bool ImageList_Write(IntPtr hIml, IStream pstm);



    }
}