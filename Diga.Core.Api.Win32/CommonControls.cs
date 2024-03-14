// ReSharper disable InconsistentNaming

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Diga.Core.Api.Win32
{

    public class ImageListConst
    {
        public const uint CLR_NONE = unchecked((uint)0xFFFFFFFFL);
        public const uint CLR_DEFAULT = unchecked((uint)0xFF000000L);

        public const uint ILC_MASK = 0x00000001;
        public const uint ILC_COLOR = 0x00000000;
        public const uint ILC_COLORDDB = 0x000000FE;
        public const uint ILC_COLOR4 = 0x00000004;
        public const uint ILC_COLOR8 = 0x00000008;
        public const uint ILC_COLOR16 = 0x00000010;
        public const uint ILC_COLOR24 = 0x00000018;
        public const uint ILC_COLOR32 = 0x00000020;
        public const uint ILC_PALETTE = 0x00000800;// (not implemented)
        public const uint ILC_MIRROR = 0x00002000;// Mirror the icons contained, if the process is mirrored
        public const uint ILC_PERITEMMIRROR = 0x00008000;// Causes the mirroring code to mirror each item when inserting a set of images, verses the whole strip
        public const uint ILC_ORIGINALSIZE = 0x00010000;// Imagelist should accept smaller than set images and apply OriginalSize based on image added
        public const uint ILC_HIGHQUALITYSCALE = 0x00020000;// Imagelist should enable use of the high quality scaler.

        public const uint ILD_NORMAL = 0x00000000;
        public const uint ILD_TRANSPARENT = 0x00000001;
        public const uint ILD_MASK = 0x00000010;
        public const uint ILD_IMAGE = 0x00000020;
        public const uint ILD_ROP = 0x00000040;
        public const uint ILD_BLEND25 = 0x00000002;
        public const uint ILD_BLEND50 = 0x00000004;
        public const uint ILD_OVERLAYMASK = 0x00000F00;

        public const uint ILD_PRESERVEALPHA = 0x00001000;// This preserves the alpha channel in dest
        public const uint ILD_SCALE = 0x00002000;// Causes the image to be scaled to cx, cy instead of clipped
        public const uint ILD_DPISCALE = 0x00004000;
        public const uint ILD_ASYNC = 0x00008000;
        public const uint ILD_SELECTED = ILD_BLEND50;
        public const uint ILD_FOCUS = ILD_BLEND25;
        public const uint ILD_BLEND = ILD_BLEND50;
        public const uint CLR_HILIGHT = CLR_DEFAULT;
        public const uint ILS_NORMAL = 0x00000000;
        public const uint ILS_GLOW = 0x00000001;
        public const uint ILS_SHADOW = 0x00000002;
        public const uint ILS_SATURATE = 0x00000004;
        public const uint ILS_ALPHA = 0x00000008;
        public const uint ILGT_NORMAL = 0x00000000;
        public const uint ILGT_ASYNC = 0x00000001;
        //public const uint HBITMAP_CALLBACK = ((HBITMAP) - 1);// only for SparseImageList
        //public const uint ImageList_LoadImage = ImageList_LoadImageW;
        //public const uint ImageList_LoadImage = ImageList_LoadImageA;
        public const uint ILCF_MOVE = (0x00000000);
        public const uint ILCF_SWAP = (0x00000001);
        //public const uint ImageList_RemoveAll(himl)=ImageList_Remove(himl, -1);
        //public const uint ImageList_ExtractIcon(hi,= himl, i) ImageList_GetIcon(himl, i, 0);
        //public const uint ImageList_LoadBitmap(hi,= lpbmp, cx, cGrow, crMask) ImageList_LoadImage(hi, lpbmp, cx, cGrow, crMask, IMAGE_BITMAP, 0);
        public const uint ILP_NORMAL = 0;// Writes or reads the stream using new sematics for this version of comctl32
        public const uint ILP_DOWNLEVEL = 1;// Write or reads the stream using downlevel sematics.
        //public const uint IImageListToHIMAGELIST(himl)=((HIMAGELIST)(himl));
    }


    //[StructLayout(LayoutKind.Sequential)]
    //public struct IMAGELISTDRAWPARAMS
    //{
    //    public uint cbSize;
    //    public IntPtr himl;
    //    public int i;
    //    public IntPtr hdcDst;
    //    public int x;
    //    public int y;
    //    public int cx;
    //    public int cy;
    //    public int xBitmap;
    //    public int yBitmap;
    //    public uint rgbBk;
    //    public uint rgbFg;
    //    public uint fStyle;
    //    public uint dwRop;
    //    public uint fState;
    //    public uint Frame;
    //    public uint crEffect;
    //}

    //[StructLayout(LayoutKind.Sequential)]
    //public struct IMAGEINFO
    //{
    //    public IntPtr hbmImage;
    //    public IntPtr hbmMask;
    //    public int Unused1;
    //    public int Unused2;
    //    public Rect rcImage;
    //}

    [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall)]
    public delegate int PFNTVCOMPARE(IntPtr lParam1, IntPtr lParam2, IntPtr lParamSort);

    //[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall)]
    //public delegate int FuncCompare(IntPtr lParam1, IntPtr lParam2, IntPtr lParamSort);


    [StructLayout(LayoutKind.Sequential)]
    public struct NMCUSTOMDRAW
    {
        public NmHdr hdr;
        public uint dwDrawStage;
        public IntPtr hdc;
        public Rect rc;
        public UIntPtr dwItemSpec;
        public uint uItemState;
        public IntPtr lItemlParam;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct TVINSERTSTRUCTA_U
    {
        public TVITEMEXA itemex;
        public TVITEMA item;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TVINSERTSTRUCTA
    {
        public IntPtr hParent;
        public IntPtr hInsertAfter;
        public TVINSERTSTRUCTA_U u;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TVINSERTSTRUCTW_U
    {
        public TVITEMEXW itemex;
        public TVITEMW item;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TVINSERTSTRUCTW
    {
        public IntPtr hParent;
        public IntPtr hInsertAfter;
        //public TVINSERTSTRUCTW_U u;
        public TVITEMW item;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TVINSERTSTRUCTEXW
    {
        public IntPtr hParent;
        public IntPtr hInsertAfter;
        //public TVINSERTSTRUCTW_U u;
        public TVITEMEXW item;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct IMAGELISTDRAWPARAMS
    {
        public uint cbSize;
        public IntPtr himl;
        public int i;
        public IntPtr hdcDst;
        public int x;
        public int y;
        public int cx;
        public int cy;
        public int xBitmap;
        public int yBitmap;
        public uint rgbBk;
        public uint rgbFg;
        public uint fStyle;
        public uint dwRop;
        public uint fState;
        public uint Frame;
        public uint crEffect;
    }
    public class TabControlConst
    {
        public const uint TCM_FIRST = 0x1300;// Tab control messages
        public const uint TCS_SCROLLOPPOSITE = 0x0001;// assumes multiline tab
        public const uint TCS_BOTTOM = 0x0002;
        public const uint TCS_RIGHT = 0x0002;
        public const uint TCS_MULTISELECT = 0x0004;// allow multi-select in button mode
        public const uint TCS_FLATBUTTONS = 0x0008;
        public const uint TCS_FORCEICONLEFT = 0x0010;
        public const uint TCS_FORCELABELLEFT = 0x0020;
        public const uint TCS_HOTTRACK = 0x0040;
        public const uint TCS_VERTICAL = 0x0080;
        public const uint TCS_TABS = 0x0000;
        public const uint TCS_BUTTONS = 0x0100;
        public const uint TCS_SINGLELINE = 0x0000;
        public const uint TCS_MULTILINE = 0x0200;
        public const uint TCS_RIGHTJUSTIFY = 0x0000;
        public const uint TCS_FIXEDWIDTH = 0x0400;
        public const uint TCS_RAGGEDRIGHT = 0x0800;
        public const uint TCS_FOCUSONBUTTONDOWN = 0x1000;
        public const uint TCS_OWNERDRAWFIXED = 0x2000;
        public const uint TCS_TOOLTIPS = 0x4000;
        public const uint TCS_FOCUSNEVER = 0x8000;
        public const uint TCS_EX_FLATSEPARATORS = 0x00000001;
        public const uint TCS_EX_REGISTERDROP = 0x00000002;
        public const uint TCM_GETIMAGELIST = (TCM_FIRST + 2);
        //public const uint TabCtrl_GetImageList(hwnd)=\;
        public const uint TCM_SETIMAGELIST = (TCM_FIRST + 3);
        //public const uint TabCtrl_SetImageList(hwnd,= himl) \;
        public const uint TCM_GETITEMCOUNT = (TCM_FIRST + 4);
        //public const uint TabCtrl_GetItemCount(hwnd)=\;
        public const uint TCIF_TEXT = 0x0001;
        public const uint TCIF_IMAGE = 0x0002;
        public const uint TCIF_RTLREADING = 0x0004;
        public const uint TCIF_PARAM = 0x0008;
        public const uint TCIF_STATE = 0x0010;
        public const uint TCIS_BUTTONPRESSED = 0x0001;
        public const uint TCIS_HIGHLIGHTED = 0x0002;
        //public const uint TC_ITEMHEADERA = TCITEMHEADERA;
        //public const uint TC_ITEMHEADERW = TCITEMHEADERW;
        //public const uint TC_ITEMHEADER = TCITEMHEADER;
        //public const uint TCITEMHEADER = TCITEMHEADERW;
        //public const uint LPTCITEMHEADER = LPTCITEMHEADERW;
        //public const uint TCITEMHEADER = TCITEMHEADERA;
        //public const uint LPTCITEMHEADER = LPTCITEMHEADERA;
        //public const uint TC_ITEMA = TCITEMA;
        //public const uint TC_ITEMW = TCITEMW;
        //public const uint TC_ITEM = TCITEM;
        //public const uint TCITEM = TCITEMW;
        //public const uint LPTCITEM = LPTCITEMW;
        //public const uint TCITEM = TCITEMA;
        //public const uint LPTCITEM = LPTCITEMA;
        public const uint TCM_GETITEMA = (TCM_FIRST + 5);
        public const uint TCM_GETITEMW = (TCM_FIRST + 60);
        //public const uint TCM_GETITEM = TCM_GETITEMW;
        //public const uint TCM_GETITEM = TCM_GETITEMA;
        //public const uint TabCtrl_GetItem(hwnd,= iItem, pitem) \;
        public const uint TCM_SETITEMA = (TCM_FIRST + 6);
        public const uint TCM_SETITEMW = (TCM_FIRST + 61);
        //public const uint TCM_SETITEM = TCM_SETITEMW;
        //public const uint TCM_SETITEM = TCM_SETITEMA;
        //public const uint TabCtrl_SetItem(hwnd,= iItem, pitem) \;
        public const uint TCM_INSERTITEMA = (TCM_FIRST + 7);
        public const uint TCM_INSERTITEMW = (TCM_FIRST + 62);
        //public const uint TCM_INSERTITEM = TCM_INSERTITEMW;
        //public const uint TCM_INSERTITEM = TCM_INSERTITEMA;
        //public const uint TabCtrl_InsertItem(hwnd,= iItem, pitem)   \;
        public const uint TCM_DELETEITEM = (TCM_FIRST + 8);
        //public const uint TabCtrl_DeleteItem(hwnd,= i) \;
        public const uint TCM_DELETEALLITEMS = (TCM_FIRST + 9);
        //public const uint TabCtrl_DeleteAllItems(hwnd)=\;
        public const uint TCM_GETITEMRECT = (TCM_FIRST + 10);
        //public const uint TabCtrl_GetItemRect(hwnd,= i, prc) \;
        public const uint TCM_GETCURSEL = (TCM_FIRST + 11);
        //public const uint TabCtrl_GetCurSel(hwnd)=\;
        public const uint TCM_SETCURSEL = (TCM_FIRST + 12);
        //public const uint TabCtrl_SetCurSel(hwnd,= i) \;
        public const uint TCHT_NOWHERE = 0x0001;
        public const uint TCHT_ONITEMICON = 0x0002;
        public const uint TCHT_ONITEMLABEL = 0x0004;
        public const uint TCHT_ONITEM = (TCHT_ONITEMICON | TCHT_ONITEMLABEL);
        //public const uint LPTC_HITTESTINFO = LPTCHITTESTINFO;
        //public const uint TC_HITTESTINFO = TCHITTESTINFO;
        public const uint TCM_HITTEST = (TCM_FIRST + 13);
        //public const uint TabCtrl_HitTest(hwndTC,= pinfo) \;
        public const uint TCM_SETITEMEXTRA = (TCM_FIRST + 14);
        //public const uint TabCtrl_SetItemExtra(hwndTC,= cb) \;
        public const uint TCM_ADJUSTRECT = (TCM_FIRST + 40);
        //public const uint TabCtrl_AdjustRect(hwnd,= bLarger, prc) \;
        public const uint TCM_SETITEMSIZE = (TCM_FIRST + 41);
        //public const uint TabCtrl_SetItemSize(hwnd,= x, y) \;
        public const uint TCM_REMOVEIMAGE = (TCM_FIRST + 42);
        //public const uint TabCtrl_RemoveImage(hwnd,= i) \;
        public const uint TCM_SETPADDING = (TCM_FIRST + 43);
        //public const uint TabCtrl_SetPadding(hwnd,= cx, cy) \;
        public const uint TCM_GETROWCOUNT = (TCM_FIRST + 44);
        //public const uint TabCtrl_GetRowCount(hwnd)=\;
        public const uint TCM_GETTOOLTIPS = (TCM_FIRST + 45);
        //public const uint TabCtrl_GetToolTips(hwnd)=\;
        public const uint TCM_SETTOOLTIPS = (TCM_FIRST + 46);
        //public const uint TabCtrl_SetToolTips(hwnd,= hwndTT) \;
        public const uint TCM_GETCURFOCUS = (TCM_FIRST + 47);
        //public const uint TabCtrl_GetCurFocus(hwnd)=\;
        public const uint TCM_SETCURFOCUS = (TCM_FIRST + 48);
        //public const uint TabCtrl_SetCurFocus(hwnd,= i) \;
        public const uint TCM_SETMINTABWIDTH = (TCM_FIRST + 49);
        //public const uint TabCtrl_SetMinTabWidth(hwnd,= x) \;
        public const uint TCM_DESELECTALL = (TCM_FIRST + 50);
        //public const uint TabCtrl_DeselectAll(hwnd,= fExcludeFocus)\;
        public const uint TCM_HIGHLIGHTITEM = (TCM_FIRST + 51);
        //public const uint TabCtrl_HighlightItem(hwnd,= i, fHighlight) \;
        public const uint TCM_SETEXTENDEDSTYLE = (TCM_FIRST + 52);// optional wParam == mask
        //public const uint TabCtrl_SetExtendedStyle(hwnd,= dw)\;
        public const uint TCM_GETEXTENDEDSTYLE = (TCM_FIRST + 53);
        public const uint TCM_SETUNICODEFORMAT = CommonControlsMessageConst.CCM_SETUNICODEFORMAT;
        //public const uint TabCtrl_SetUnicodeFormat(hwnd,= fUnicode)  \;
        public const uint TCM_GETUNICODEFORMAT = CommonControlsMessageConst.CCM_SETUNICODEFORMAT;
        //public const uint TabCtrl_GetUnicodeFormat(hwnd)= \;
        public const uint TCN_FIRST = 0xfffffdda;
        public const uint TCN_KEYDOWN = (TCN_FIRST - 0);
        //public const uint TC_KEYDOWN = NMTCKEYDOWN;
        public const uint TCN_SELCHANGE = (TCN_FIRST - 1);
        public const uint TCN_SELCHANGING = (TCN_FIRST - 2);
        public const uint TCN_GETOBJECT = (TCN_FIRST - 3);
        public const uint TCN_FOCUSCHANGE = (TCN_FIRST - 4);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TCITEMHEADERA
    {
        public uint mask;
        public uint lpReserved1;
        public uint lpReserved2;
        [MarshalAs(UnmanagedType.LPStr)]
        public string pszText;
        public int cchTextMax;
        public int iImage;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TCITEMHEADERW
    {
        public uint mask;
        public uint lpReserved1;
        public uint lpReserved2;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszText;
        public int cchTextMax;
        public int iImage;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TCITEMA
    {
        public uint mask;
        public uint dwState;
        public uint dwStateMask;
        [MarshalAs(UnmanagedType.LPStr)]
        public string pszText;
        public int cchTextMax;
        public int iImage;
        public IntPtr lParam;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TCITEMW
    {
        public uint mask;
        public uint dwState;
        public uint dwStateMask;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszText;
        public int cchTextMax;
        public int iImage;
        public IntPtr lParam;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TCHITTESTINFO
    {
        public Point pt;
        public uint flags;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NMTCKEYDOWN
    {
        public NmHdr hdr;
        public ushort wVKey;
        public uint flags;
    }

    public static class TabControlMacros
    {
        public static IntPtr TabCtrl_GetImageList(IntPtr hWnd)
        {
            return User32.SendMessage(hWnd, TabControlConst.TCM_GETIMAGELIST);

        }
        public static IntPtr TabCtrl_SetImageList(IntPtr hWnd, IntPtr hIml)
        {
            return User32.SendMessage(hWnd, TabControlConst.TCM_SETIMAGELIST, IntPtr.Zero, hIml);


        }
        public static int TabCtrl_GetItemCount(IntPtr hWnd)
        {
            IntPtr result = User32.SendMessage(hWnd, TabControlConst.TCM_GETITEMCOUNT);
            return result.ToInt32();
        }


        public static bool  TabCtrl_GetItem(IntPtr hWnd,int iItem, out TCITEMW pItem)
        {
            using(var p = new ApiStructHandleRef<TCITEMW>())
            {
                IntPtr result = User32.SendMessage(hWnd, (int)TabControlConst.TCM_GETITEMW, iItem, p);
                ApiBool ok = result.ToInt32();
                if(ok)
                {
                    pItem = p.GetStruct();
                }
                else
                {
                    pItem = new TCITEMW();
                }
                return ok;
            }
        }

        public static bool TabCtrl_SetItem(IntPtr hWnd, int iItem, TCITEMW pitem)
        {
            using(var p = new ApiStructHandleRef<TCITEMW>(pitem))
            {
                IntPtr result = User32.SendMessage(hWnd, (int)TabControlConst.TCM_SETITEMW, iItem, p);
                return (ApiBool)result.ToInt32();
            }
        }

        public static int TabCtrl_InsertItem(IntPtr hwnd,int iItem, TCITEMW pitem)
        {
            using(var p = new ApiStructHandleRef<TCITEMW>(pitem))
            {
                IntPtr result = User32.SendMessage(hwnd, (int)TabControlConst.TCM_INSERTITEMW, iItem, p);
                return result.ToInt32();
            }
        }
        public static bool TabCtrl_DeleteItem(IntPtr hwnd,int i)
        {
            IntPtr result = User32.SendMessage(hwnd, TabControlConst.TCM_DELETEITEM, (uint)i);
            return (ApiBool)result.ToInt32();
        }

        
        public static bool TabCtrl_DeleteAllItems(IntPtr hwnd)
        {
            IntPtr result = User32.SendMessage(hwnd, TabControlConst.TCM_DELETEALLITEMS);
            return (ApiBool)result.ToInt32();
        }
        public static bool TabCtrl_GetItemRect(IntPtr hwnd,int i,out Rect prc)
        {
            using(var p = new ApiStructHandleRef<Rect>())
            {
                IntPtr result = User32.SendMessage(hwnd, (int)TabControlConst.TCM_GETITEMRECT, i, p);
                ApiBool ok = result.ToInt32();
                if(ok)
                {
                    prc = p.GetStruct();
                }
                else
                {
                    prc = new Rect();
                }
                return ok;
            }
        }
        public static int TabCtrl_GetCurSel(IntPtr hwnd)
        {
            IntPtr result = User32.SendMessage(hwnd, TabControlConst.TCM_GETCURSEL);
            return result.ToInt32();
        }
        public static int TabCtrl_SetCurSel(IntPtr hwnd,int i)
        {
            IntPtr result = User32.SendMessage(hwnd, TabControlConst.TCM_SETCURSEL, (uint)i);
            return result.ToInt32();
        }
        public static int TabCtrl_HitTest(IntPtr hWnd, TCHITTESTINFO pinfo)
        { 
            using(var p = new ApiStructHandleRef<TCHITTESTINFO>(pinfo))
            {
                IntPtr result = User32.SendMessage(hWnd , TabControlConst.TCM_HITTEST, IntPtr.Zero, p);
                return result.ToInt32();    
            }
        }

        public static bool TabCtrl_SetItemExtra(IntPtr hwndTC,int cb)
        {
            IntPtr result = User32.SendMessage(hwndTC, TabControlConst.TCM_SETITEMEXTRA, (uint)cb, 0);
            return (ApiBool)result.ToInt32();
        }

        public static void TabCtrl_AdjustRect(IntPtr hwnd,bool bLarger, ref Rect prc)
        {
            using(var p = new ApiStructHandleRef<Rect>(prc))
            {
                User32.SendMessage(hwnd, (int)TabControlConst.TCM_ADJUSTRECT, (ApiBool)bLarger, p);
                prc = p.GetStruct();
            }
        }

        public static HighLow TabCtrl_SetItemSize(IntPtr hwnd,int width,int  height)
        {
            HighLow hl = new HighLow();
            hl.iLow = width;
            hl.iHigh = height;
            IntPtr result = User32.SendMessage(hwnd, TabControlConst.TCM_SETITEMSIZE, IntPtr.Zero, Win32Api.HiLoToLParam(hl));
            HighLow hlResult = Win32Api.MakeHiLo(result);
            return hlResult;

        }
        public static void TabCtrl_RemoveImage(IntPtr hwnd,int i)
        {
            User32.SendMessage(hwnd, TabControlConst.TCM_REMOVEIMAGE, (uint)i);

        }

        public static void TabCtrl_SetPadding(IntPtr hwnd,int cx, int cy)
        {
            HighLow hl = new HighLow();
            hl.iLow = cx;
            hl.iHigh = cy;
            User32.SendMessage(hwnd, TabControlConst.TCM_SETPADDING, IntPtr.Zero , Win32Api.HiLoToLParam(hl));
        }

        public static int TabCtrl_GetRowCount(IntPtr hwnd)
        {
            IntPtr result = User32.SendMessage(hwnd, TabControlConst.TCM_GETROWCOUNT);
            return result.ToInt32();
        }
        public static IntPtr TabCtrl_GetToolTips(IntPtr hwnd)
        {
            return User32.SendMessage(hwnd , TabControlConst.TCM_GETTOOLTIPS);
        }
        public static void TabCtrl_SetToolTips(IntPtr hwnd,IntPtr hwndTT)
        {
            User32.SendMessage(hwnd , TabControlConst.TCM_SETTOOLTIPS, hwndTT, IntPtr.Zero); 
        }
        public static int TabCtrl_GetCurFocus(IntPtr hwnd)
        {
            IntPtr result = User32.SendMessage(hwnd , TabControlConst.TCM_GETCURFOCUS);
            return result.ToInt32();
        }
        public static void TabCtrl_SetCurFocus(IntPtr hwnd,int i)
        {
            User32.SendMessage(hwnd, TabControlConst.TCM_SETCURFOCUS, (uint)i);
        }
        public static int TabCtrl_SetMinTabWidth(IntPtr hwnd,int x)
        {
            IntPtr result = User32.SendMessage(hwnd , (int)TabControlConst.TCM_SETMINTABWIDTH,0, x);
            return result.ToInt32();
        }


        public static void TabCtrl_DeselectAll(IntPtr hwnd,bool fExcludeFocus)
        {
            User32.SendMessage(hwnd , TabControlConst.TCM_DESELECTALL , (uint)((int)(ApiBool)fExcludeFocus));

        }
        public static bool TabCtrl_HighlightItem(IntPtr hwnd,int i, bool fHighlight)
        {
            HighLow hl = new HighLow();
            hl.iLow = (ApiBool)fHighlight;
            hl.iLow = 0;
            IntPtr result = User32.SendMessage(hwnd, (int)TabControlConst.TCM_HIGHLIGHTITEM, i, Win32Api.HiLoToLParam(hl));
            if (result.ToInt32() != 0)
                return true;
            return false;
        }
        public static void TabCtrl_SetExtendedStyle(IntPtr hwnd,uint dw)
        {
            User32.SendMessage(hwnd, TabControlConst.TCM_SETEXTENDEDSTYLE, 0, dw);
        }

        public static uint TabCtrl_GetExtendedStyle(IntPtr hWnd )
        {
            IntPtr result = User32.SendMessage(hWnd, TabControlConst.TCM_GETEXTENDEDSTYLE);
            return (uint)result.ToInt64();
        }
        public static bool TabCtrl_SetUnicodeFormat(IntPtr hwnd,bool fUnicode)
        {
            IntPtr result = User32.SendMessage(hwnd, TabControlConst.TCM_SETUNICODEFORMAT, (uint)(int)(ApiBool)fUnicode);
            return (ApiBool )result.ToInt32();
        }
        public static bool TabCtrl_GetUnicodeFormat(IntPtr hwnd)
        {
            IntPtr result = User32.SendMessage(hwnd, TabControlConst.TCM_GETUNICODEFORMAT);
            return (ApiBool )result.ToInt32();
        }

    }

    public class TreeViewConst
    {
        public const uint TVN_FIRST = 0xfffffe70;
        public const uint TV_FIRST = 0x1100;// TreeView messages
        public const uint TVS_HASBUTTONS = 0x0001;
        public const uint TVS_HASLINES = 0x0002;
        public const uint TVS_LINESATROOT = 0x0004;
        public const uint TVS_EDITLABELS = 0x0008;
        public const uint TVS_DISABLEDRAGDROP = 0x0010;
        public const uint TVS_SHOWSELALWAYS = 0x0020;
        public const uint TVS_RTLREADING = 0x0040;
        public const uint TVS_NOTOOLTIPS = 0x0080;
        public const uint TVS_CHECKBOXES = 0x0100;
        public const uint TVS_TRACKSELECT = 0x0200;
        public const uint TVS_SINGLEEXPAND = 0x0400;
        public const uint TVS_INFOTIP = 0x0800;
        public const uint TVS_FULLROWSELECT = 0x1000;
        public const uint TVS_NOSCROLL = 0x2000;
        public const uint TVS_NONEVENHEIGHT = 0x4000;
        public const uint TVS_NOHSCROLL = 0x8000;// TVS_NOSCROLL overrides this
        public const uint TVS_EX_NOSINGLECOLLAPSE = 0x0001;
        public const uint TVS_EX_MULTISELECT = 0x0002;
        public const uint TVS_EX_DOUBLEBUFFER = 0x0004;
        public const uint TVS_EX_NOINDENTSTATE = 0x0008;
        public const uint TVS_EX_RICHTOOLTIP = 0x0010;
        public const uint TVS_EX_AUTOHSCROLL = 0x0020;
        public const uint TVS_EX_FADEINOUTEXPANDOS = 0x0040;
        public const uint TVS_EX_PARTIALCHECKBOXES = 0x0080;
        public const uint TVS_EX_EXCLUSIONCHECKBOXES = 0x0100;
        public const uint TVS_EX_DIMMEDCHECKBOXES = 0x0200;
        public const uint TVS_EX_DRAWIMAGEASYNC = 0x0400;
        public const uint TVIF_TEXT = 0x0001;
        public const uint TVIF_IMAGE = 0x0002;
        public const uint TVIF_PARAM = 0x0004;
        public const uint TVIF_STATE = 0x0008;
        public const uint TVIF_HANDLE = 0x0010;
        public const uint TVIF_SELECTEDIMAGE = 0x0020;
        public const uint TVIF_CHILDREN = 0x0040;
        public const uint TVIF_INTEGRAL = 0x0080;
        public const uint TVIF_STATEEX = 0x0100;
        public const uint TVIF_EXPANDEDIMAGE = 0x0200;
        public const uint TVIS_SELECTED = 0x0002;
        public const uint TVIS_CUT = 0x0004;
        public const uint TVIS_DROPHILITED = 0x0008;
        public const uint TVIS_BOLD = 0x0010;
        public const uint TVIS_EXPANDED = 0x0020;
        public const uint TVIS_EXPANDEDONCE = 0x0040;
        public const uint TVIS_EXPANDPARTIAL = 0x0080;
        public const uint TVIS_OVERLAYMASK = 0x0F00;
        public const uint TVIS_STATEIMAGEMASK = 0xF000;
        public const uint TVIS_USERMASK = 0xF000;
        public const uint TVIS_EX_FLAT = 0x0001;
        public const uint TVIS_EX_DISABLED = 0x0002;
        public const uint TVIS_EX_ALL = 0x0002;
        public static IntPtr TVI_ROOT = new IntPtr(0 - 0x10000);
        public static IntPtr TVI_FIRST = new IntPtr(0 - 0x0FFFF);
        public static IntPtr TVI_LAST = new IntPtr(0 - 0x0FFFE);
        public static IntPtr TVI_SORT = new IntPtr(0 - 0x0FFFD);
        public const uint TVM_INSERTITEMA = (TV_FIRST + 0);
        public const uint TVM_INSERTITEMW = (TV_FIRST + 50);
        public const uint TVM_DELETEITEM = (TV_FIRST + 1);
        public const uint TVM_EXPAND = (TV_FIRST + 2);
        public const uint TVE_COLLAPSE = 0x0001;
        public const uint TVE_EXPAND = 0x0002;
        public const uint TVE_TOGGLE = 0x0003;
        public const uint TVE_EXPANDPARTIAL = 0x4000;
        public const uint TVE_COLLAPSERESET = 0x8000;
        public const uint TVM_GETITEMRECT = (TV_FIRST + 4);
        public const uint TVM_GETCOUNT = (TV_FIRST + 5);
        public const uint TVM_GETINDENT = (TV_FIRST + 6);
        public const uint TVM_SETINDENT = (TV_FIRST + 7);
        public const uint TVM_GETIMAGELIST = (TV_FIRST + 8);
        public const uint TVSIL_NORMAL = 0;
        public const uint TVSIL_STATE = 2;
        public const uint TVM_SETIMAGELIST = (TV_FIRST + 9);
        public const uint TVM_GETNEXTITEM = (TV_FIRST + 10);
        public const uint TVGN_ROOT = 0x0000;
        public const uint TVGN_NEXT = 0x0001;
        public const uint TVGN_PREVIOUS = 0x0002;
        public const uint TVGN_PARENT = 0x0003;
        public const uint TVGN_CHILD = 0x0004;
        public const uint TVGN_FIRSTVISIBLE = 0x0005;
        public const uint TVGN_NEXTVISIBLE = 0x0006;
        public const uint TVGN_PREVIOUSVISIBLE = 0x0007;
        public const uint TVGN_DROPHILITE = 0x0008;
        public const uint TVGN_CARET = 0x0009;
        public const uint TVGN_LASTVISIBLE = 0x000A;
        public const uint TVGN_NEXTSELECTED = 0x000B;
        public const uint TVSI_NOSINGLEEXPAND = 0x8000;// Should not conflict with TVGN flags.
        public const uint TVM_SELECTITEM = (TV_FIRST + 11);
        public const uint TVM_GETITEMA = (TV_FIRST + 12);
        public const uint TVM_GETITEMW = (TV_FIRST + 62);
        public const uint TVM_SETITEMA = (TV_FIRST + 13);
        public const uint TVM_SETITEMW = (TV_FIRST + 63);
        public const uint TVM_EDITLABELA = (TV_FIRST + 14);
        public const uint TVM_EDITLABELW = (TV_FIRST + 65);
        public const uint TVM_GETEDITCONTROL = (TV_FIRST + 15);
        public const uint TVM_GETVISIBLECOUNT = (TV_FIRST + 16);
        public const uint TVM_HITTEST = (TV_FIRST + 17);
        public const uint TVHT_NOWHERE = 0x0001;
        public const uint TVHT_ONITEMICON = 0x0002;
        public const uint TVHT_ONITEMLABEL = 0x0004;
        public const uint TVHT_ONITEM = (TVHT_ONITEMICON | TVHT_ONITEMLABEL | TVHT_ONITEMSTATEICON);
        public const uint TVHT_ONITEMINDENT = 0x0008;
        public const uint TVHT_ONITEMBUTTON = 0x0010;
        public const uint TVHT_ONITEMRIGHT = 0x0020;
        public const uint TVHT_ONITEMSTATEICON = 0x0040;
        public const uint TVHT_ABOVE = 0x0100;
        public const uint TVHT_BELOW = 0x0200;
        public const uint TVHT_TORIGHT = 0x0400;
        public const uint TVHT_TOLEFT = 0x0800;
        public const uint TVM_CREATEDRAGIMAGE = (TV_FIRST + 18);

        public const uint TVM_SORTCHILDREN = (TV_FIRST + 19);
        public const uint TVM_ENSUREVISIBLE = (TV_FIRST + 20);
        public const uint TVM_SORTCHILDRENCB = (TV_FIRST + 21);
        public const uint TVM_ENDEDITLABELNOW = (TV_FIRST + 22);
        public const uint TVM_GETISEARCHSTRINGA = (TV_FIRST + 23);
        public const uint TVM_GETISEARCHSTRINGW = (TV_FIRST + 64);
        public const uint TVM_SETTOOLTIPS = (TV_FIRST + 24);
        public const uint TVM_GETTOOLTIPS = (TV_FIRST + 25);
        public const uint TVM_SETINSERTMARK = (TV_FIRST + 26);
        public const uint TVM_SETUNICODEFORMAT = CommonControlsMessageConst.CCM_SETUNICODEFORMAT;
        public const uint TVM_GETUNICODEFORMAT = CommonControlsMessageConst.CCM_GETUNICODEFORMAT;
        public const uint TVM_SETITEMHEIGHT = (TV_FIRST + 27);
        public const uint TVM_GETITEMHEIGHT = (TV_FIRST + 28);
        public const uint TVM_SETBKCOLOR = (TV_FIRST + 29);
        public const uint TVM_SETTEXTCOLOR = (TV_FIRST + 30);
        public const uint TVM_GETBKCOLOR = (TV_FIRST + 31);
        public const uint TVM_GETTEXTCOLOR = (TV_FIRST + 32);
        public const uint TVM_SETSCROLLTIME = (TV_FIRST + 33);
        public const uint TVM_GETSCROLLTIME = (TV_FIRST + 34);
        public const uint TVM_SETINSERTMARKCOLOR = (TV_FIRST + 37);
        public const uint TVM_GETINSERTMARKCOLOR = (TV_FIRST + 38);
        public const uint TVM_SETBORDER = (TV_FIRST + 35);
        public const uint TVSBF_XBORDER = 0x00000001;
        public const uint TVSBF_YBORDER = 0x00000002;

        public const uint TVM_GETITEMSTATE = (TV_FIRST + 39);
        public const uint TVM_SETLINECOLOR = (TV_FIRST + 40);
        public const uint TVM_GETLINECOLOR = (TV_FIRST + 41);
        public const uint TVM_MAPACCIDTOHTREEITEM = (TV_FIRST + 42);
        public const uint TVM_MAPHTREEITEMTOACCID = (TV_FIRST + 43);
        public const uint TVM_SETEXTENDEDSTYLE = (TV_FIRST + 44);
        public const uint TVM_GETEXTENDEDSTYLE = (TV_FIRST + 45);
        public const uint TVM_SETAUTOSCROLLINFO = (TV_FIRST + 59);
        public const uint TVM_SETHOT = (TV_FIRST + 58);
        public const uint TVM_GETSELECTEDCOUNT = (TV_FIRST + 70);
        public const uint TVM_SHOWINFOTIP = (TV_FIRST + 71);
        public const uint TVM_GETITEMPARTRECT = (TV_FIRST + 72);
        public const uint TVN_SELCHANGINGA = (TVN_FIRST - 1);
        public const uint TVN_SELCHANGINGW = (TVN_FIRST - 50);
        public const uint TVN_SELCHANGEDA = (TVN_FIRST - 2);
        public const uint TVN_SELCHANGEDW = (TVN_FIRST - 51);
        public const uint TVC_UNKNOWN = 0x0000;
        public const uint TVC_BYMOUSE = 0x0001;
        public const uint TVC_BYKEYBOARD = 0x0002;
        public const uint TVN_GETDISPINFOA = (TVN_FIRST - 3);
        public const uint TVN_GETDISPINFOW = (TVN_FIRST - 52);
        public const uint TVN_SETDISPINFOA = (TVN_FIRST - 4);
        public const uint TVN_SETDISPINFOW = (TVN_FIRST - 53);
        public const uint TVIF_DI_SETITEM = 0x1000;
        public const uint TVN_ITEMEXPANDINGA = (TVN_FIRST - 5);
        public const uint TVN_ITEMEXPANDINGW = (TVN_FIRST - 54);
        public const uint TVN_ITEMEXPANDEDA = (TVN_FIRST - 6);
        public const uint TVN_ITEMEXPANDEDW = (TVN_FIRST - 55);
        public const uint TVN_BEGINDRAGA = (TVN_FIRST - 7);
        public const uint TVN_BEGINDRAGW = (TVN_FIRST - 56);
        public const uint TVN_BEGINRDRAGA = (TVN_FIRST - 8);
        public const uint TVN_BEGINRDRAGW = (TVN_FIRST - 57);
        public const uint TVN_DELETEITEMA = (TVN_FIRST - 9);
        public const uint TVN_DELETEITEMW = (TVN_FIRST - 58);
        public const uint TVN_BEGINLABELEDITA = (TVN_FIRST - 10);
        public const uint TVN_BEGINLABELEDITW = (TVN_FIRST - 59);
        public const uint TVN_ENDLABELEDITA = (TVN_FIRST - 11);
        public const uint TVN_ENDLABELEDITW = (TVN_FIRST - 60);
        public const uint TVN_KEYDOWN = (TVN_FIRST - 12);
        public const uint TVN_GETINFOTIPA = (TVN_FIRST - 13);
        public const uint TVN_GETINFOTIPW = (TVN_FIRST - 14);
        public const uint TVN_SINGLEEXPAND = (TVN_FIRST - 15);
        public const uint TVNRET_DEFAULT = 0;
        public const uint TVNRET_SKIPOLD = 1;
        public const uint TVNRET_SKIPNEW = 2;
        public const uint TVN_ITEMCHANGINGA = (TVN_FIRST - 16);
        public const uint TVN_ITEMCHANGINGW = (TVN_FIRST - 17);
        public const uint TVN_ITEMCHANGEDA = (TVN_FIRST - 18);
        public const uint TVN_ITEMCHANGEDW = (TVN_FIRST - 19);
        public const uint TVN_ASYNCDRAW = (TVN_FIRST - 20);
        public const uint TVN_SELCHANGING = TVN_SELCHANGINGW;
        public const uint TVN_SELCHANGED = TVN_SELCHANGEDW;
        public const uint TVN_GETDISPINFO = TVN_GETDISPINFOW;
        public const uint TVN_SETDISPINFO = TVN_SETDISPINFOW;
        public const uint TVN_ITEMEXPANDING = TVN_ITEMEXPANDINGW;
        public const uint TVN_ITEMEXPANDED = TVN_ITEMEXPANDEDW;
        public const uint TVN_BEGINDRAG = TVN_BEGINDRAGW;
        public const uint TVN_BEGINRDRAG = TVN_BEGINRDRAGW;
        public const uint TVN_DELETEITEM = TVN_DELETEITEMW;
        public const uint TVN_BEGINLABELEDIT = TVN_BEGINLABELEDITW;
        public const uint TVN_ENDLABELEDIT = TVN_ENDLABELEDITW;
        public const uint TVN_GETINFOTIP = TVN_GETINFOTIPW;
        public const uint TVCDRF_NOIMAGES = 0x00010000;
        public const uint TVN_ITEMCHANGING = TVN_ITEMCHANGINGW;
        public const uint TVN_ITEMCHANGED = TVN_ITEMCHANGEDW;


    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NMTVSTATEIMAGECHANGING
    {
        public NmHdr hdr;
        public IntPtr hti;
        public int iOldStateImageIndex;
        public int iNewStateImageIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TVITEMA
    {
        public uint mask;
        public IntPtr hItem;
        public uint state;
        public uint stateMask;
        [MarshalAs(UnmanagedType.LPStr)]
        public string pszText;
        public int cchTextMax;
        public int iImage;
        public int iSelectedImage;
        public int cChildren;
        public IntPtr lParam;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TVITEMW
    {
        public uint mask;
        public IntPtr hItem;
        public uint state;
        public uint stateMask;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszText;
        public int cchTextMax;
        public int iImage;
        public int iSelectedImage;
        public int cChildren;
        public IntPtr lParam;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TVITEMEXA
    {
        public uint mask;
        public IntPtr hItem;
        public uint state;
        public uint stateMask;
        [MarshalAs(UnmanagedType.LPStr)]
        public string pszText;
        public int cchTextMax;
        public int iImage;
        public int iSelectedImage;
        public int cChildren;
        public IntPtr lParam;
        public int iIntegral;
        public uint uStateEx;
        public IntPtr hwnd;
        public int iExpandedImage;
        public int iReserved;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TVITEMEXW
    {
        public uint mask;
        public IntPtr hItem;
        public uint state;
        public uint stateMask;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszText;
        public int cchTextMax;
        public int iImage;
        public int iSelectedImage;
        public int cChildren;
        public IntPtr lParam;
        public int iIntegral;
        public uint uStateEx;
        public IntPtr hwnd;
        public int iExpandedImage;
        public int iReserved;
    }
    [Flags]
    public enum TVITEMPART : uint
    {
        TVGIPR_BUTTON = 0x0001,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TVHITTESTINFO
    {
        public Point pt;
        public uint flags;
        public IntPtr hItem;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct TVGETITEMPARTRECTINFO
    {
        public IntPtr hti;
        [MarshalAs(UnmanagedType.LPStruct)]
        public Rect prc;
        public uint partID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TVSORTCB
    {
        public IntPtr hParent;
        public PFNTVCOMPARE lpfnCompare;
        public IntPtr lParam;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NMTREEVIEWA
    {
        public NmHdr hdr;
        public uint action;
        public TVITEMA itemOld;
        public TVITEMA itemNew;
        public Point ptDrag;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct NMTREEVIEWW
    {
        public NmHdr hdr;
        public uint action;
        public TVITEMW itemOld;
        public TVITEMW itemNew;
        public Point ptDrag;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NMTVDISPINFOA
    {
        public NmHdr hdr;
        public TVITEMA item;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LPHDLAYOUT
    {
        public IntPtr prc;
        public IntPtr pwpos;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HDLAYOUT
    {
        public Rect prc;
        //[MarshalAs(UnmanagedType.LPStruct)]
        public WINDOWPOS pwpos;

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NMTVDISPINFOW
    {
        public NmHdr hdr;
        public TVITEMW item;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NMTVDISPINFOEXA
    {
        public NmHdr hdr;
        public TVITEMEXA item;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NMTVDISPINFOEXW
    {
        public NmHdr hdr;
        public TVITEMEXW item;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NMTVKEYDOWN
    {
        public NmHdr hdr;
        public ushort wVKey;
        public uint flags;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct NMTVCUSTOMDRAW
    {
        public NMCUSTOMDRAW nmcd;
        public uint clrText;
        public uint clrTextBk;
        public int iLevel;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct NMTVGETINFOTIPA
    {
        public NmHdr hdr;
        [MarshalAs(UnmanagedType.LPStr)]
        public string pszText;
        public int cchTextMax;
        public IntPtr hItem;
        public IntPtr lParam;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NMTVGETINFOTIPW
    {
        public NmHdr hdr;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszText;
        public int cchTextMax;
        public IntPtr hItem;
        public IntPtr lParam;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NMTVITEMCHANGE
    {
        public NmHdr hdr;
        public uint uChanged;
        public IntPtr hItem;
        public uint uStateNew;
        public uint uStateOld;
        public IntPtr lParam;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NMTVASYNCDRAW
    {
        public NmHdr hdr;
        [MarshalAs(UnmanagedType.LPStruct)]
        public IMAGELISTDRAWPARAMS pimldp;
        public int hr;
        public IntPtr hItem;
        public IntPtr lParam;
        public uint dwRetFlags;
        public int iRetImageIndex;
    }


    public static class HeaderImageListType
    {
        public const int HDSIL_NORMAL = 0;
        public const int HDSIL_STATE = 1;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct HDITEMA
    {
        public uint mask;
        public int cxy;
        [MarshalAs(UnmanagedType.LPStr)]
        public string pszText;
        public IntPtr hbm;
        public int ccTextMax;
        public int fmt;
        public IntPtr lParam;
        public int iImage;
        public int iOrder;
        public uint type;
        public IntPtr pvFilter;
        public uint state;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct HDITEMW
    {
        public uint mask;
        public int cxy;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszText;
        public IntPtr hbm;
        public int ccTextMax;
        public int fmt;
        public IntPtr lParam;
        public int iImage;
        public int iOrder;
        public uint type;
        public IntPtr pvFilter;
        public uint state;
    }

    public class HeaderItemMaskConst
    {
        public const uint HDI_WIDTH = 0x0001;
        public const uint HDI_HEIGHT = HDI_WIDTH;
        public const uint HDI_TEXT = 0x0002;
        public const uint HDI_FORMAT = 0x0004;
        public const uint HDI_LPARAM = 0x0008;
        public const uint HDI_BITMAP = 0x0010;
        public const uint HDI_IMAGE = 0x0020;
        public const uint HDI_DI_SETITEM = 0x0040;
        public const uint HDI_ORDER = 0x0080;
        public const uint HDI_FILTER = 0x0100;
        public const uint HDI_STATE = 0x0200;
    }

    public class HeaderStylesConst
    {

        public const uint HDS_HORZ = 0x0000;
        public const uint HDS_BUTTONS = 0x0002;
        public const uint HDS_HOTTRACK = 0x0004;
        public const uint HDS_HIDDEN = 0x0008;
        public const uint HDS_DRAGDROP = 0x0040;
        public const uint HDS_FULLDRAG = 0x0080;
        public const uint HDS_FILTERBAR = 0x0100;
        public const uint HDS_FLAT = 0x0200;
        public const uint HDS_CHECKBOXES = 0x0400;
        public const uint HDS_NOSIZING = 0x0800;
        public const uint HDS_OVERFLOW = 0x1000;
    }
    public class HeaderMessageConst
    {
        public const uint HDM_FIRST = 0x1200;      // Header messages
        public const uint HDM_GETITEMCOUNT = (HDM_FIRST + 0);
        public const uint HDM_INSERTITEMA = (HDM_FIRST + 1);
        public const uint HDM_INSERTITEMW = (HDM_FIRST + 10);
        public const uint HDM_DELETEITEM = (HDM_FIRST + 2);
        public const uint HDM_GETITEMA = (HDM_FIRST + 3);
        public const uint HDM_GETITEMW = (HDM_FIRST + 11);
        public const uint HDM_SETITEMA = (HDM_FIRST + 4);
        public const uint HDM_SETITEMW = (HDM_FIRST + 12);
        public const uint HDM_LAYOUT = (HDM_FIRST + 5);
        public const uint HDM_HITTEST = (HDM_FIRST + 6);
        public const uint HDM_GETITEMRECT = (HDM_FIRST + 7);
        public const uint HDM_SETIMAGELIST = (HDM_FIRST + 8);
        public const uint HDM_GETIMAGELIST = (HDM_FIRST + 9);
        public const uint HDM_ORDERTOINDEX = (HDM_FIRST + 15);
        public const uint HDM_CREATEDRAGIMAGE = (HDM_FIRST + 16);  // wparam = which item (by index)
        public const uint HDM_GETORDERARRAY = (HDM_FIRST + 17);
        public const uint HDM_SETORDERARRAY = (HDM_FIRST + 18);
        public const uint HDM_SETHOTDIVIDER = (HDM_FIRST + 19);
        public const uint HDM_SETBITMAPMARGIN = (HDM_FIRST + 20);
        public const uint HDM_GETBITMAPMARGIN = (HDM_FIRST + 21);
        public const uint HDM_SETUNICODEFORMAT = CommonControlsMessageConst.CCM_SETUNICODEFORMAT;
        public const uint HDM_GETUNICODEFORMAT = CommonControlsMessageConst.CCM_GETUNICODEFORMAT;
        public const uint HDM_SETFILTERCHANGETIMEOUT = (HDM_FIRST + 22);
        public const uint HDM_EDITFILTER = (HDM_FIRST + 23);
        public const uint HDM_CLEARFILTER = (HDM_FIRST + 24);
        //public static uint HDM_TRANSLATEACCELERATOR = CommonControlsMessage.CCM_TRANSLATEACCELERATOR;
        public const uint HDM_GETITEMDROPDOWNRECT = (HDM_FIRST + 25);  // rect of item's drop down button
        public const uint HDM_GETOVERFLOWRECT = (HDM_FIRST + 26);  // rect of overflow button
        public const uint HDM_GETFOCUSEDITEM = (HDM_FIRST + 27);
        public const uint HDM_SETFOCUSEDITEM = (HDM_FIRST + 28);
    }
    public class ListViewItemRectConst
    {
        public const int LVIR_BOUNDS = 0;
        public const int LVIR_ICON = 1;
        public const int LVIR_LABEL = 2;
        public const int LVIR_SELECTBOUNDS = 3;
    }
    public class ListViewNotifyConst
    {
        /// LVN_FIRST -> (0U-100U)
        public const uint LVN_FIRST = (unchecked(0U - 100U));

        /// LVN_LAST -> (0U-199U)
        public const uint LVN_LAST = (unchecked(0U - 199U));

        /// LVN_ITEMCHANGING -> (LVN_FIRST-0)
        public const uint LVN_ITEMCHANGING = (LVN_FIRST - 0);

        /// LVN_ITEMCHANGED -> (LVN_FIRST-1)
        public const uint LVN_ITEMCHANGED = (LVN_FIRST - 1);

        /// LVN_INSERTITEM -> (LVN_FIRST-2)
        public const uint LVN_INSERTITEM = (LVN_FIRST - 2);

        /// LVN_DELETEITEM -> (LVN_FIRST-3)
        public const uint LVN_DELETEITEM = (LVN_FIRST - 3);

        /// LVN_DELETEALLITEMS -> (LVN_FIRST-4)
        public const uint LVN_DELETEALLITEMS = (LVN_FIRST - 4);

        /// LVN_BEGINLABELEDITA -> (LVN_FIRST-5)
        public const uint LVN_BEGINLABELEDITA = (LVN_FIRST - 5);

        /// LVN_ENDLABELEDITA -> (LVN_FIRST-6)
        public const uint LVN_ENDLABELEDITA = (LVN_FIRST - 6);

        /// LVN_COLUMNCLICK -> (LVN_FIRST-8)
        public const uint LVN_COLUMNCLICK = (LVN_FIRST - 8);

        /// LVN_BEGINDRAG -> (LVN_FIRST-9)
        public const uint LVN_BEGINDRAG = (LVN_FIRST - 9);

        /// LVN_BEGINRDRAG -> (LVN_FIRST-11)
        public const uint LVN_BEGINRDRAG = (LVN_FIRST - 11);

        /// LVN_ODCACHEHINT -> (LVN_FIRST-13)
        public const uint LVN_ODCACHEHINT = (LVN_FIRST - 13);

        /// LVN_ITEMACTIVATE -> (LVN_FIRST-14)
        public const uint LVN_ITEMACTIVATE = (LVN_FIRST - 14);

        /// LVN_ODSTATECHANGED -> (LVN_FIRST-15)
        public const uint LVN_ODSTATECHANGED = (LVN_FIRST - 15);


        /// LVN_HOTTRACK -> (LVN_FIRST-21)
        public const uint LVN_HOTTRACK = (LVN_FIRST - 21);


        /// LVN_BEGINLABELEDITW -> (LVN_FIRST-75)
        public const uint LVN_BEGINLABELEDITW = (LVN_FIRST - 75);

        /// LVN_ENDLABELEDITW -> (LVN_FIRST-76)
        public const uint LVN_ENDLABELEDITW = (LVN_FIRST - 76);

        /// LVN_ODFINDITEMA -> (LVN_FIRST-52)
        public const uint LVN_ODFINDITEMA = (LVN_FIRST - 52);

        /// LVN_ODFINDITEMW -> (LVN_FIRST-79)
        public const uint LVN_ODFINDITEMW = (LVN_FIRST - 79);

        /// LVN_GETDISPINFOA -> (LVN_FIRST-50)
        public const uint LVN_GETDISPINFOA = (LVN_FIRST - 50);

        /// LVN_GETDISPINFOW -> (LVN_FIRST-77)
        public const uint LVN_GETDISPINFOW = (LVN_FIRST - 77);

        /// LVN_SETDISPINFOA -> (LVN_FIRST-51)
        public const uint LVN_SETDISPINFOA = (LVN_FIRST - 51);

        public const uint LVN_KEYDOWN = (LVN_FIRST - 55);
        public const uint LVN_MARQUEEBEGIN = (LVN_FIRST - 56);
        public const uint LVN_GETINFOTIPA = (LVN_FIRST - 57);
        public const uint LVN_GETINFOTIPW = (LVN_FIRST - 58);
        public const uint LVN_INCREMENTALSEARCHA = (LVN_FIRST - 62);
        public const uint LVN_INCREMENTALSEARCHW = (LVN_FIRST - 63);
        public const uint LVN_COLUMNDROPDOWN = (LVN_FIRST - 64);
        public const uint LVN_COLUMNOVERFLOWCLICK = (LVN_FIRST - 66);
        public const uint LVN_BEGINSCROLL = (LVN_FIRST - 80);
        public const uint LVN_ENDSCROLL = (LVN_FIRST - 81);
        public const uint LVN_LINKCLICK = (LVN_FIRST - 84);
        public const uint LVN_GETEMPTYMARKUP = (LVN_FIRST - 87);

    }
    public class ListViewViewConst
    {

        /// LV_VIEW_ICON -> 0x0000
        public const int LV_VIEW_ICON = 0;

        /// LV_VIEW_DETAILS -> 0x0001
        public const int LV_VIEW_DETAILS = 1;

        /// LV_VIEW_SMALLICON -> 0x0002
        public const int LV_VIEW_SMALLICON = 2;

        /// LV_VIEW_LIST -> 0x0003
        public const int LV_VIEW_LIST = 3;

        /// LV_VIEW_TILE -> 0x0004
        public const int LV_VIEW_TILE = 4;

        /// LV_VIEW_MAX -> 0x0004
        public const int LV_VIEW_MAX = 4;

    }
    public class HeaderFlagsConst
    {
        public const uint HDF_LEFT = 0x0000;// Same as LVCFMT_LEFT
        public const uint HDF_RIGHT = 0x0001;// Same as LVCFMT_RIGHT
        public const uint HDF_CENTER = 0x0002;// Same as LVCFMT_CENTER
        public const uint HDF_JUSTIFYMASK = 0x0003;// Same as LVCFMT_JUSTIFYMASK
        public const uint HDF_RTLREADING = 0x0004;// Same as LVCFMT_LEFT
        public const uint HDF_BITMAP = 0x2000;
        public const uint HDF_STRING = 0x4000;
        public const uint HDF_OWNERDRAW = 0x8000;// Same as LVCFMT_COL_HAS_IMAGES
        public const uint HDF_IMAGE = 0x0800;// Same as LVCFMT_IMAGE
        public const uint HDF_BITMAP_ON_RIGHT = 0x1000;// Same as LVCFMT_BITMAP_ON_RIGHT
        public const uint HDF_SORTUP = 0x0400;
        public const uint HDF_SORTDOWN = 0x0200;
        public const uint HDF_CHECKBOX = 0x0040;
        public const uint HDF_CHECKED = 0x0080;
        public const uint HDF_FIXEDWIDTH = 0x0100;// Can't resize the column; same as LVCFMT_FIXED_WIDTH
        public const uint HDF_SPLITBUTTON = 0x1000000;// Column is a split button; same as LVCFMT_SPLITBUTTON
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HD_TEXTFILTERA
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string pszText;
        public int cchTextMax;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HD_TEXTFILTERW
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszText;
        public int cchTextMax;
    }

    public static class HeaderHitTestInfoFlags
    {
        public static uint HHT_NOWHERE = 0x0001;
        public static uint HHT_ONHEADER = 0x0002;
        public static uint HHT_ONDIVIDER = 0x0004;
        public static uint HHT_ONDIVOPEN = 0x0008;
        public static uint HHT_ONFILTER = 0x0010;
        public static uint HHT_ONFILTERBUTTON = 0x0020;
        public static uint HHT_ABOVE = 0x0100;
        public static uint HHT_BELOW = 0x0200;
        public static uint HHT_TORIGHT = 0x0400;
        public static uint HHT_TOLEFT = 0x0800;
        public static uint HHT_ONITEMSTATEICON = 0x1000;
        public static uint HHT_ONDROPDOWN = 0x2000;
        public static uint HHT_ONOVERFLOW = 0x4000;

    }
    [StructLayout(LayoutKind.Sequential)]
    public struct HDHITTESTINFO
    {
        public Point pt;
        public uint flags;
        public int iItem;
    }
    public class ListViewColumnHeaderAlignConst
    {
        /// LVCFMT_LEFT -> 0x0000
        public const int LVCFMT_LEFT = 0;

        /// LVCFMT_RIGHT -> 0x0001
        public const int LVCFMT_RIGHT = 1;

        /// LVCFMT_CENTER -> 0x0002
        public const int LVCFMT_CENTER = 2;

        /// LVCFMT_JUSTIFYMASK -> 0x0003
        public const int LVCFMT_JUSTIFYMASK = 3;

        /// LVCFMT_IMAGE -> 0x0800
        public const int LVCFMT_IMAGE = 2048;

        /// LVCFMT_BITMAP_ON_RIGHT -> 0x1000
        public const int LVCFMT_BITMAP_ON_RIGHT = 4096;

        /// LVCFMT_COL_HAS_IMAGES -> 0x8000
        public const int LVCFMT_COL_HAS_IMAGES = 32768;

        /// LVCFMT_FIXED_WIDTH -> 0x00100
        public const int LVCFMT_FIXED_WIDTH = 256;

        /// LVCFMT_NO_DPI_SCALE -> 0x40000
        public const int LVCFMT_NO_DPI_SCALE = 262144;

        /// LVCFMT_FIXED_RATIO -> 0x80000
        public const int LVCFMT_FIXED_RATIO = 524288;

        /// LVCFMT_LINE_BREAK -> 0x100000
        public const int LVCFMT_LINE_BREAK = 1048576;

        /// LVCFMT_FILL -> 0x200000
        public const int LVCFMT_FILL = 2097152;

        /// LVCFMT_WRAP -> 0x400000
        public const int LVCFMT_WRAP = 4194304;

        /// LVCFMT_NO_TITLE -> 0x800000
        public const int LVCFMT_NO_TITLE = 8388608;

        /// LVCFMT_TILE_PLACEMENTMASK -> (LVCFMT_LINE_BREAK | LVCFMT_FILL)
        public const int LVCFMT_TILE_PLACEMENTMASK = (LVCFMT_LINE_BREAK | LVCFMT_FILL);

        /// LVCFMT_SPLITBUTTON -> 0x1000000
        public const int LVCFMT_SPLITBUTTON = 16777216;
    }

    public class ListViewItemMemberValidInfoConst
    {

        /// LVIF_TEXT -> 0x00000001
        public const int LVIF_TEXT = 1;

        /// LVIF_IMAGE -> 0x00000002
        public const int LVIF_IMAGE = 2;

        /// LVIF_PARAM -> 0x00000004
        public const int LVIF_PARAM = 4;

        /// LVIF_STATE -> 0x00000008
        public const int LVIF_STATE = 8;

        /// LVIF_INDENT -> 0x00000010
        public const int LVIF_INDENT = 16;

        /// LVIF_NORECOMPUTE -> 0x00000800
        public const int LVIF_NORECOMPUTE = 2048;

        /// LVIF_GROUPID -> 0x00000100
        public const int LVIF_GROUPID = 256;

        /// LVIF_COLUMNS -> 0x00000200
        public const int LVIF_COLUMNS = 512;

        /// LVIF_COLFMT -> 0x00010000
        public const int LVIF_COLFMT = 65536;

    }
    public class ListViewColumnMemberValidInfoConst
    {

        /// LVCF_FMT -> 0x0001
        public const int LVCF_FMT = 1;

        /// LVCF_WIDTH -> 0x0002
        public const int LVCF_WIDTH = 2;

        /// LVCF_TEXT -> 0x0004
        public const int LVCF_TEXT = 4;

        /// LVCF_SUBITEM -> 0x0008
        public const int LVCF_SUBITEM = 8;

        /// LVCF_IMAGE -> 0x0010
        public const int LVCF_IMAGE = 16;

        /// LVCF_ORDER -> 0x0020
        public const int LVCF_ORDER = 32;

        /// LVCF_MINWIDTH -> 0x0040
        public const int LVCF_MINWIDTH = 64;

        /// LVCF_DEFAULTWIDTH -> 0x0080
        public const int LVCF_DEFAULTWIDTH = 128;

        /// LVCF_IDEALWIDTH -> 0x0100
        public const int LVCF_IDEALWIDTH = 256;






    }



    [StructLayout(LayoutKind.Sequential)]
    public struct tagLVCOLUMNA
    {

        /// UINT->unsigned int
        public uint mask;

        /// int
        public int fmt;

        /// int
        public int cx;

        /// LPSTR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string pszText;

        /// int
        public int cchTextMax;

        /// int
        public int iSubItem;

        /// int
        public int iImage;

        /// int
        public int iOrder;

        /// int
        public int cxMin;

        /// int
        public int cxDefault;

        /// int
        public int cxIdeal;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct tagLVCOLUMNW
    {

        /// UINT->unsigned int
        public uint mask;

        /// int
        public int fmt;

        /// int
        public int cx;

        /// LPWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszText;

        /// int
        public int cchTextMax;

        /// int
        public int iSubItem;

        /// int
        public int iImage;

        /// int
        public int iOrder;

        /// int
        public int cxMin;

        /// int
        public int cxDefault;

        /// int
        public int cxIdeal;
    }



    [StructLayout(LayoutKind.Sequential)]
    public struct tagLVITEMINDEX
    {

        /// int
        public int iItem;

        /// int
        public int iGroup;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct tagLVITEMW
    {

        /// UINT->unsigned int
        public uint mask;

        /// int
        public int iItem;

        /// int
        public int iSubItem;

        /// UINT->unsigned int
        public uint state;

        /// UINT->unsigned int
        public uint stateMask;

        /// LPWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszText;

        /// int
        public int cchTextMax;

        /// int
        public int iImage;

        /// LPARAM->LONG_PTR->int
        public IntPtr lParam;

        /// int
        public int iIndent;

        /// int
        public int iGroupId;

        /// UINT->unsigned int
        public uint cColumns;

        /// PUINT->unsigned int*
        public IntPtr puColumns;

        /// int*
        public IntPtr piColFmt;

        /// int
        public int iGroup;
    }



    [StructLayout(LayoutKind.Sequential)]
    public struct tagLVITEMA
    {

        /// UINT->unsigned int
        public uint mask;

        /// int
        public int iItem;

        /// int
        public int iSubItem;

        /// UINT->unsigned int
        public uint state;

        /// UINT->unsigned int
        public uint stateMask;

        /// LPSTR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string pszText;

        /// int
        public int cchTextMax;

        /// int
        public int iImage;

        /// LPARAM->LONG_PTR->int
        public int lParam;

        /// int
        public int iIndent;

        /// int
        public int iGroupId;

        /// UINT->unsigned int
        public uint cColumns;

        /// PUINT->unsigned int*
        public IntPtr puColumns;

        /// int*
        public IntPtr piColFmt;

        /// int
        public int iGroup;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class tagLVDISPINFOW
    {

        /// NMHDR->tagNMHDR
        public NmHdr hdr = new NmHdr();

        /// NMHDR->tagNMHDR
        public tagLVITEMW item = new tagLVITEMW();
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct tagLVDISPINFOA
    {

        /// NMHDR->tagNMHDR
        public NmHdr hdr;

        /// NMHDR->tagNMHDR
        public tagLVITEMA item;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct tagLVHITTESTINFO
    {
        public Point pt;
        public uint flags;
        public int iItem;
        public int iSubItem;
        public int iGroup;

    }
    [StructLayout(LayoutKind.Sequential)]
    public struct tagNMLISTVIEW
    {
        public NmHdr hdr;
        public int iItem;
        public int iSubItem;
        public uint uNewState;
        public uint uOldState;
        public uint uChanged;
        public Point ptAction;
        public IntPtr lParam;

    }
    [StructLayout(LayoutKind.Sequential)]
    public struct tagNMITEMACTIVATE
    {
        public NmHdr hdr;
        public int iItem;
        public int iSubItem;
        public uint uNewState;
        public uint uOldState;
        public uint uChanged;
        public Point ptAction;
        public IntPtr lParam;
        public uint uKeyFlags;
    }

    public class ListViewItemState
    {
        public const uint LVIS_FOCUSED = 0x0001;
        public const uint LVIS_SELECTED = 0x0002;
        public const uint LVIS_CUT = 0x0004;
        public const uint LVIS_DROPHILITED = 0x0008;
        public const uint LVIS_GLOW = 0x0010;
        public const uint LVIS_ACTIVATING = 0x0020;
        public const uint LVIS_OVERLAYMASK = 0x0F00;
        public const uint LVIS_STATEIMAGEMASK = 0xF000;

        public static bool IsListViewState(uint state, uint stateToFind)
        {
            return (state & stateToFind) == stateToFind;
        }

    }

    [Flags]
    public enum CommonControlsMessage : uint
    {
        CCM_FIRST = 0x2000,// Common control shared messages
        CCM_LAST = (CCM_FIRST + 0x200),
        CCM_SETBKCOLOR = (CCM_FIRST + 1),// lParam is bkColor
        CCM_SETCOLORSCHEME = (CCM_FIRST + 2),// lParam is color scheme
        CCM_GETCOLORSCHEME = (CCM_FIRST + 3),// fills in COLORSCHEME pointed to by lParam
        CCM_GETDROPTARGET = (CCM_FIRST + 4),
        CCM_SETUNICODEFORMAT = (CCM_FIRST + 5),
        CCM_GETUNICODEFORMAT = (CCM_FIRST + 6),
        CCM_SETVERSION = (CCM_FIRST + 0x7),
        CCM_GETVERSION = (CCM_FIRST + 0x8),
        CCM_SETNOTIFYWINDOW = (CCM_FIRST + 0x9),// wParam == hwndParent.
        CCM_SETWINDOWTHEME = (CCM_FIRST + 0xb),
        CCM_DPISCALE = (CCM_FIRST + 0xc),// wParam == Awareness
    }

    [Flags]
    public enum ListViewKeyFlags : uint
    {
        LVKF_ALT = 0x0001,
        LVKF_CONTROL = 0x0002,
        LVKF_SHIFT = 0x0004
    }

    [Flags]
    public enum ListViewStyles : uint
    {
        LVS_ICON = 0x0000,
        LVS_REPORT = 0x0001,
        LVS_SMALLICON = 0x0002,
        LVS_LIST = 0x0003,
        LVS_TYPEMASK = 0x0003,
        LVS_SINGLESEL = 0x0004,
        LVS_SHOWSELALWAYS = 0x0008,
        LVS_SORTASCENDING = 0x0010,
        LVS_SORTDESCENDING = 0x0020,
        LVS_SHAREIMAGELISTS = 0x0040,
        LVS_NOLABELWRAP = 0x0080,
        LVS_AUTOARRANGE = 0x0100,
        LVS_EDITLABELS = 0x0200,
        LVS_OWNERDATA = 0x1000,
        LVS_NOSCROLL = 0x2000,
        LVS_TYPESTYLEMASK = 0xfc00,
        LVS_ALIGNTOP = 0x0000,
        LVS_ALIGNLEFT = 0x0800,
        LVS_ALIGNMASK = 0x0c00,
        LVS_OWNERDRAWFIXED = 0x0400,
        LVS_NOCOLUMNHEADER = 0x4000,
        LVS_NOSORTHEADER = 0x8000
    }
    [Flags]
    public enum ListViewStylesEx : uint
    {
        LVS_EX_GRIDLINES = 0x00000001,
        LVS_EX_SUBITEMIMAGES = 0x00000002,
        LVS_EX_CHECKBOXES = 0x00000004,
        LVS_EX_TRACKSELECT = 0x00000008,
        LVS_EX_HEADERDRAGDROP = 0x00000010,
        LVS_EX_FULLROWSELECT = 0x00000020,// applies to report mode only
        LVS_EX_ONECLICKACTIVATE = 0x00000040,
        LVS_EX_TWOCLICKACTIVATE = 0x00000080,
        LVS_EX_FLATSB = 0x00000100,
        LVS_EX_REGIONAL = 0x00000200,
        LVS_EX_INFOTIP = 0x00000400,// listview does InfoTips for you
        LVS_EX_UNDERLINEHOT = 0x00000800,
        LVS_EX_UNDERLINECOLD = 0x00001000,
        LVS_EX_MULTIWORKAREAS = 0x00002000,
        LVS_EX_LABELTIP = 0x00004000,// listview unfolds partly hidden labels if it does not have infotip text
        LVS_EX_BORDERSELECT = 0x00008000,// border selection style instead of highlight

        LVS_EX_DOUBLEBUFFER = 0x00010000,
        LVS_EX_HIDELABELS = 0x00020000,
        LVS_EX_SINGLEROW = 0x00040000,
        LVS_EX_SNAPTOGRID = 0x00080000,// Icons automatically snap to grid.
        LVS_EX_SIMPLESELECT = 0x00100000,// Also changes overlay rendering to top right for icon mode=.,


        LVS_EX_JUSTIFYCOLUMNS = 0x00200000, // Icons are lined up in columns that use up the whole view area.
        LVS_EX_TRANSPARENTBKGND = 0x00400000, // Background is painted by the parent via WM_PRINTCLIENT
        LVS_EX_TRANSPARENTSHADOWTEXT = 0x00800000,  // Enable shadow text on transparent backgrounds only (useful with bitmaps)
        LVS_EX_AUTOAUTOARRANGE = 0x01000000,  // Icons automatically arrange if no icon positions have been set
        LVS_EX_HEADERINALLVIEWS = 0x02000000, // Display column header in all view modes
        LVS_EX_AUTOCHECKSELECT = 0x08000000,
        LVS_EX_AUTOSIZECOLUMNS = 0x10000000,
        LVS_EX_COLUMNSNAPPOINTS = 0x40000000,
        LVS_EX_COLUMNOVERFLOW = 0x80000000
    }

    [Flags]
    public enum ListViewMessage : uint
    {
        LVM_FIRST = 0x1000,// ListView messages
        LVM_SETUNICODEFORMAT = CommonControlsMessage.CCM_SETUNICODEFORMAT,
        LVM_GETUNICODEFORMAT = CommonControlsMessage.CCM_GETUNICODEFORMAT,
        LVM_GETBKCOLOR = (LVM_FIRST + 0),
        LVM_SETBKCOLOR = (LVM_FIRST + 1),
        LVM_GETIMAGELIST = (LVM_FIRST + 2),
        LVM_SETIMAGELIST = (LVM_FIRST + 3),
        LVM_GETITEMCOUNT = (LVM_FIRST + 4),
        LVM_GETITEMA = (LVM_FIRST + 5),
        LVM_GETITEMW = (LVM_FIRST + 75),
        //LVM_GETITEM = LVM_GETITEMW,
        //LVM_GETITEM = LVM_GETITEMA,
        LVM_SETITEMA = (LVM_FIRST + 6),
        LVM_SETITEMW = (LVM_FIRST + 76),
        //LVM_SETITEM = LVM_SETITEMW,
        //LVM_SETITEM = LVM_SETITEMA,
        LVM_INSERTITEMA = (LVM_FIRST + 7),
        LVM_INSERTITEMW = (LVM_FIRST + 77),
        //LVM_INSERTITEM = LVM_INSERTITEMW,
        //LVM_INSERTITEM = LVM_INSERTITEMA,
        LVM_DELETEITEM = (LVM_FIRST + 8),
        LVM_DELETEALLITEMS = (LVM_FIRST + 9),
        LVM_GETCALLBACKMASK = (LVM_FIRST + 10),
        LVM_SETCALLBACKMASK = (LVM_FIRST + 11),
        LVM_GETNEXTITEM = (LVM_FIRST + 12),
        LVM_FINDITEMA = (LVM_FIRST + 13),
        LVM_FINDITEMW = (LVM_FIRST + 83),
        LVM_GETITEMRECT = (LVM_FIRST + 14),
        LVM_SETITEMPOSITION = (LVM_FIRST + 15),
        LVM_GETITEMPOSITION = (LVM_FIRST + 16),
        LVM_GETSTRINGWIDTHA = (LVM_FIRST + 17),
        LVM_GETSTRINGWIDTHW = (LVM_FIRST + 87),
        LVM_HITTEST = (LVM_FIRST + 18),
        LVM_ENSUREVISIBLE = (LVM_FIRST + 19),
        LVM_SCROLL = (LVM_FIRST + 20),
        LVM_REDRAWITEMS = (LVM_FIRST + 21),
        LVM_ARRANGE = (LVM_FIRST + 22),
        LVM_EDITLABELA = (LVM_FIRST + 23),
        LVM_EDITLABELW = (LVM_FIRST + 118),
        //LVM_EDITLABEL = LVM_EDITLABELW,
        //LVM_EDITLABEL = LVM_EDITLABELA,
        LVM_GETEDITCONTROL = (LVM_FIRST + 24),
        LVM_GETCOLUMNA = (LVM_FIRST + 25),
        LVM_GETCOLUMNW = (LVM_FIRST + 95),
        LVM_SETCOLUMNA = (LVM_FIRST + 26),
        LVM_SETCOLUMNW = (LVM_FIRST + 96),
        LVM_INSERTCOLUMNA = (LVM_FIRST + 27),
        LVM_INSERTCOLUMNW = (LVM_FIRST + 97),
        LVM_DELETECOLUMN = (LVM_FIRST + 28),
        LVM_GETCOLUMNWIDTH = (LVM_FIRST + 29),
        LVM_SETCOLUMNWIDTH = (LVM_FIRST + 30),
        LVM_GETHEADER = (LVM_FIRST + 31),
        LVM_CREATEDRAGIMAGE = (LVM_FIRST + 33),
        LVM_GETVIEWRECT = (LVM_FIRST + 34),
        LVM_GETTEXTCOLOR = (LVM_FIRST + 35),
        LVM_SETTEXTCOLOR = (LVM_FIRST + 36),
        LVM_GETTEXTBKCOLOR = (LVM_FIRST + 37),
        LVM_SETTEXTBKCOLOR = (LVM_FIRST + 38),
        LVM_GETTOPINDEX = (LVM_FIRST + 39),
        LVM_GETCOUNTPERPAGE = (LVM_FIRST + 40),
        LVM_GETORIGIN = (LVM_FIRST + 41),
        LVM_UPDATE = (LVM_FIRST + 42),
        LVM_SETITEMSTATE = (LVM_FIRST + 43),
        LVM_GETITEMSTATE = (LVM_FIRST + 44),
        LVM_GETITEMTEXTA = (LVM_FIRST + 45),
        LVM_GETITEMTEXTW = (LVM_FIRST + 115),
        LVM_SETITEMTEXTA = (LVM_FIRST + 46),
        LVM_SETITEMTEXTW = (LVM_FIRST + 116),
        LVM_SETITEMCOUNT = (LVM_FIRST + 47),
        LVM_SORTITEMS = (LVM_FIRST + 48),
        LVM_SETITEMPOSITION32 = (LVM_FIRST + 49),
        LVM_GETSELECTEDCOUNT = (LVM_FIRST + 50),
        LVM_GETITEMSPACING = (LVM_FIRST + 51),
        LVM_GETISEARCHSTRINGA = (LVM_FIRST + 52),
        LVM_GETISEARCHSTRINGW = (LVM_FIRST + 117),
        //LVM_GETISEARCHSTRING = LVM_GETISEARCHSTRINGW,
        //LVM_GETISEARCHSTRING = LVM_GETISEARCHSTRINGA,
        LVM_SETICONSPACING = (LVM_FIRST + 53),
        LVM_SETEXTENDEDLISTVIEWSTYLE = (LVM_FIRST + 54),// optional wParam == mask
        LVM_GETEXTENDEDLISTVIEWSTYLE = (LVM_FIRST + 55),
        LVM_GETSUBITEMRECT = (LVM_FIRST + 56),
        LVM_SUBITEMHITTEST = (LVM_FIRST + 57),
        LVM_SETCOLUMNORDERARRAY = (LVM_FIRST + 58),
        LVM_GETCOLUMNORDERARRAY = (LVM_FIRST + 59),
        LVM_SETHOTITEM = (LVM_FIRST + 60),
        LVM_GETHOTITEM = (LVM_FIRST + 61),
        LVM_SETHOTCURSOR = (LVM_FIRST + 62),
        LVM_GETHOTCURSOR = (LVM_FIRST + 63),
        LVM_APPROXIMATEVIEWRECT = (LVM_FIRST + 64),
        LVM_SETWORKAREAS = (LVM_FIRST + 65),
        LVM_GETWORKAREAS = (LVM_FIRST + 70),
        LVM_GETNUMBEROFWORKAREAS = (LVM_FIRST + 73),
        LVM_GETSELECTIONMARK = (LVM_FIRST + 66),
        LVM_SETSELECTIONMARK = (LVM_FIRST + 67),
        LVM_SETHOVERTIME = (LVM_FIRST + 71),
        LVM_GETHOVERTIME = (LVM_FIRST + 72),
        LVM_SETTOOLTIPS = (LVM_FIRST + 74),
        LVM_GETTOOLTIPS = (LVM_FIRST + 78),
        LVM_SORTITEMSEX = (LVM_FIRST + 81),
        LVM_SETBKIMAGEA = (LVM_FIRST + 68),
        LVM_SETBKIMAGEW = (LVM_FIRST + 138),
        LVM_GETBKIMAGEA = (LVM_FIRST + 69),
        LVM_GETBKIMAGEW = (LVM_FIRST + 139),
        LVM_SETSELECTEDCOLUMN = (LVM_FIRST + 140),
        LVM_SETVIEW = (LVM_FIRST + 142),
        LVM_GETVIEW = (LVM_FIRST + 143),
        LVM_INSERTGROUP = (LVM_FIRST + 145),
        LVM_SETGROUPINFO = (LVM_FIRST + 147),
        LVM_GETGROUPINFO = (LVM_FIRST + 149),
        LVM_REMOVEGROUP = (LVM_FIRST + 150),
        LVM_MOVEGROUP = (LVM_FIRST + 151),
        LVM_GETGROUPCOUNT = (LVM_FIRST + 152),
        LVM_GETGROUPINFOBYINDEX = (LVM_FIRST + 153),
        LVM_MOVEITEMTOGROUP = (LVM_FIRST + 154),
        LVM_GETGROUPRECT = (LVM_FIRST + 98),
        LVM_SETGROUPMETRICS = (LVM_FIRST + 155),
        LVM_GETGROUPMETRICS = (LVM_FIRST + 156),
        LVM_ENABLEGROUPVIEW = (LVM_FIRST + 157),
        LVM_SORTGROUPS = (LVM_FIRST + 158),
        LVM_INSERTGROUPSORTED = (LVM_FIRST + 159),
        LVM_REMOVEALLGROUPS = (LVM_FIRST + 160),
        LVM_HASGROUP = (LVM_FIRST + 161),
        LVM_GETGROUPSTATE = (LVM_FIRST + 92),
        LVM_GETFOCUSEDGROUP = (LVM_FIRST + 93),
        LVM_SETTILEVIEWINFO = (LVM_FIRST + 162),
        LVM_GETTILEVIEWINFO = (LVM_FIRST + 163),
        LVM_SETTILEINFO = (LVM_FIRST + 164),
        LVM_GETTILEINFO = (LVM_FIRST + 165),
        LVM_SETINSERTMARK = (LVM_FIRST + 166),
        LVM_GETINSERTMARK = (LVM_FIRST + 167),
        LVM_INSERTMARKHITTEST = (LVM_FIRST + 168),
        LVM_GETINSERTMARKRECT = (LVM_FIRST + 169),
        LVM_SETINSERTMARKCOLOR = (LVM_FIRST + 170),
        LVM_GETINSERTMARKCOLOR = (LVM_FIRST + 171),
        LVM_GETSELECTEDCOLUMN = (LVM_FIRST + 174),
        LVM_ISGROUPVIEWENABLED = (LVM_FIRST + 175),
        LVM_GETOUTLINECOLOR = (LVM_FIRST + 176),
        LVM_SETOUTLINECOLOR = (LVM_FIRST + 177),
        LVM_CANCELEDITLABEL = (LVM_FIRST + 179),
        LVM_MAPINDEXTOID = (LVM_FIRST + 180),
        LVM_MAPIDTOINDEX = (LVM_FIRST + 181),
        LVM_ISITEMVISIBLE = (LVM_FIRST + 182),
        LVM_GETEMPTYTEXT = (LVM_FIRST + 204),
        LVM_GETFOOTERRECT = (LVM_FIRST + 205),
        LVM_GETFOOTERINFO = (LVM_FIRST + 206),
        LVM_GETFOOTERITEMRECT = (LVM_FIRST + 207),
        LVM_GETFOOTERITEM = (LVM_FIRST + 208),
        LVM_GETITEMINDEXRECT = (LVM_FIRST + 209),
        LVM_SETITEMINDEXSTATE = (LVM_FIRST + 210),
        LVM_GETNEXTITEMINDEX = (LVM_FIRST + 211),
        //LVM_SETBKIMAGE = LVM_SETBKIMAGEW,
        //LVM_GETBKIMAGE = LVM_GETBKIMAGEW,
        //LVM_SETBKIMAGE = LVM_SETBKIMAGEA,
        //LVM_GETBKIMAGE = LVM_GETBKIMAGEA,
    }
    public static class ListViewMessageConst
    {
        public const uint LVM_FIRST = 0x1000;// ListView messages
        public const uint LVM_SETUNICODEFORMAT = CommonControlsMessageConst.CCM_SETUNICODEFORMAT;
        public const uint LVM_GETUNICODEFORMAT = CommonControlsMessageConst.CCM_GETUNICODEFORMAT;
        public const uint LVM_GETBKCOLOR = (LVM_FIRST + 0);
        public const uint LVM_SETBKCOLOR = (LVM_FIRST + 1);
        public const uint LVM_GETIMAGELIST = (LVM_FIRST + 2);
        public const uint LVM_SETIMAGELIST = (LVM_FIRST + 3);
        public const uint LVM_GETITEMCOUNT = (LVM_FIRST + 4);
        public const uint LVM_GETITEMA = (LVM_FIRST + 5);
        public const uint LVM_GETITEMW = (LVM_FIRST + 75);

        public const uint LVM_SETITEMA = (LVM_FIRST + 6);
        public const uint LVM_SETITEMW = (LVM_FIRST + 76);

        public const uint LVM_INSERTITEMA = (LVM_FIRST + 7);
        public const uint LVM_INSERTITEMW = (LVM_FIRST + 77);

        public const uint LVM_DELETEITEM = (LVM_FIRST + 8);
        public const uint LVM_DELETEALLITEMS = (LVM_FIRST + 9);
        public const uint LVM_GETCALLBACKMASK = (LVM_FIRST + 10);
        public const uint LVM_SETCALLBACKMASK = (LVM_FIRST + 11);
        public const uint LVM_GETNEXTITEM = (LVM_FIRST + 12);
        public const uint LVM_FINDITEMA = (LVM_FIRST + 13);
        public const uint LVM_FINDITEMW = (LVM_FIRST + 83);
        public const uint LVM_GETITEMRECT = (LVM_FIRST + 14);
        public const uint LVM_SETITEMPOSITION = (LVM_FIRST + 15);
        public const uint LVM_GETITEMPOSITION = (LVM_FIRST + 16);
        public const uint LVM_GETSTRINGWIDTHA = (LVM_FIRST + 17);
        public const uint LVM_GETSTRINGWIDTHW = (LVM_FIRST + 87);
        public const uint LVM_HITTEST = (LVM_FIRST + 18);
        public const uint LVM_ENSUREVISIBLE = (LVM_FIRST + 19);
        public const uint LVM_SCROLL = (LVM_FIRST + 20);
        public const uint LVM_REDRAWITEMS = (LVM_FIRST + 21);
        public const uint LVM_ARRANGE = (LVM_FIRST + 22);
        public const uint LVM_EDITLABELA = (LVM_FIRST + 23);
        public const uint LVM_EDITLABELW = (LVM_FIRST + 118);
        public const uint LVM_GETEDITCONTROL = (LVM_FIRST + 24);
        public const uint LVM_GETCOLUMNA = (LVM_FIRST + 25);
        public const uint LVM_GETCOLUMNW = (LVM_FIRST + 95);
        public const uint LVM_SETCOLUMNA = (LVM_FIRST + 26);
        public const uint LVM_SETCOLUMNW = (LVM_FIRST + 96);
        public const uint LVM_INSERTCOLUMNA = (LVM_FIRST + 27);
        public const uint LVM_INSERTCOLUMNW = (LVM_FIRST + 97);
        public const uint LVM_DELETECOLUMN = (LVM_FIRST + 28);
        public const uint LVM_GETCOLUMNWIDTH = (LVM_FIRST + 29);
        public const uint LVM_SETCOLUMNWIDTH = (LVM_FIRST + 30);
        public const uint LVM_GETHEADER = (LVM_FIRST + 31);
        public const uint LVM_CREATEDRAGIMAGE = (LVM_FIRST + 33);
        public const uint LVM_GETVIEWRECT = (LVM_FIRST + 34);
        public const uint LVM_GETTEXTCOLOR = (LVM_FIRST + 35);
        public const uint LVM_SETTEXTCOLOR = (LVM_FIRST + 36);
        public const uint LVM_GETTEXTBKCOLOR = (LVM_FIRST + 37);
        public const uint LVM_SETTEXTBKCOLOR = (LVM_FIRST + 38);
        public const uint LVM_GETTOPINDEX = (LVM_FIRST + 39);
        public const uint LVM_GETCOUNTPERPAGE = (LVM_FIRST + 40);
        public const uint LVM_GETORIGIN = (LVM_FIRST + 41);
        public const uint LVM_UPDATE = (LVM_FIRST + 42);
        public const uint LVM_SETITEMSTATE = (LVM_FIRST + 43);
        public const uint LVM_GETITEMSTATE = (LVM_FIRST + 44);
        public const uint LVM_GETITEMTEXTA = (LVM_FIRST + 45);
        public const uint LVM_GETITEMTEXTW = (LVM_FIRST + 115);
        public const uint LVM_SETITEMTEXTA = (LVM_FIRST + 46);
        public const uint LVM_SETITEMTEXTW = (LVM_FIRST + 116);
        public const uint LVM_SETITEMCOUNT = (LVM_FIRST + 47);
        public const uint LVM_SORTITEMS = (LVM_FIRST + 48);
        public const uint LVM_SETITEMPOSITION32 = (LVM_FIRST + 49);
        public const uint LVM_GETSELECTEDCOUNT = (LVM_FIRST + 50);
        public const uint LVM_GETITEMSPACING = (LVM_FIRST + 51);
        public const uint LVM_GETISEARCHSTRINGA = (LVM_FIRST + 52);
        public const uint LVM_GETISEARCHSTRINGW = (LVM_FIRST + 117);

        public const uint LVM_SETICONSPACING = (LVM_FIRST + 53);
        public const uint LVM_SETEXTENDEDLISTVIEWSTYLE = (LVM_FIRST + 54);// optional wParam == mask
        public const uint LVM_GETEXTENDEDLISTVIEWSTYLE = (LVM_FIRST + 55);
        public const uint LVM_GETSUBITEMRECT = (LVM_FIRST + 56);
        public const uint LVM_SUBITEMHITTEST = (LVM_FIRST + 57);
        public const uint LVM_SETCOLUMNORDERARRAY = (LVM_FIRST + 58);
        public const uint LVM_GETCOLUMNORDERARRAY = (LVM_FIRST + 59);
        public const uint LVM_SETHOTITEM = (LVM_FIRST + 60);
        public const uint LVM_GETHOTITEM = (LVM_FIRST + 61);
        public const uint LVM_SETHOTCURSOR = (LVM_FIRST + 62);
        public const uint LVM_GETHOTCURSOR = (LVM_FIRST + 63);
        public const uint LVM_APPROXIMATEVIEWRECT = (LVM_FIRST + 64);
        public const uint LVM_SETWORKAREAS = (LVM_FIRST + 65);
        public const uint LVM_GETWORKAREAS = (LVM_FIRST + 70);
        public const uint LVM_GETNUMBEROFWORKAREAS = (LVM_FIRST + 73);
        public const uint LVM_GETSELECTIONMARK = (LVM_FIRST + 66);
        public const uint LVM_SETSELECTIONMARK = (LVM_FIRST + 67);
        public const uint LVM_SETHOVERTIME = (LVM_FIRST + 71);
        public const uint LVM_GETHOVERTIME = (LVM_FIRST + 72);
        public const uint LVM_SETTOOLTIPS = (LVM_FIRST + 74);
        public const uint LVM_GETTOOLTIPS = (LVM_FIRST + 78);
        public const uint LVM_SORTITEMSEX = (LVM_FIRST + 81);
        public const uint LVM_SETBKIMAGEA = (LVM_FIRST + 68);
        public const uint LVM_SETBKIMAGEW = (LVM_FIRST + 138);
        public const uint LVM_GETBKIMAGEA = (LVM_FIRST + 69);
        public const uint LVM_GETBKIMAGEW = (LVM_FIRST + 139);
        public const uint LVM_SETSELECTEDCOLUMN = (LVM_FIRST + 140);
        public const uint LVM_SETVIEW = (LVM_FIRST + 142);
        public const uint LVM_GETVIEW = (LVM_FIRST + 143);
        public const uint LVM_INSERTGROUP = (LVM_FIRST + 145);
        public const uint LVM_SETGROUPINFO = (LVM_FIRST + 147);
        public const uint LVM_GETGROUPINFO = (LVM_FIRST + 149);
        public const uint LVM_REMOVEGROUP = (LVM_FIRST + 150);
        public const uint LVM_MOVEGROUP = (LVM_FIRST + 151);
        public const uint LVM_GETGROUPCOUNT = (LVM_FIRST + 152);
        public const uint LVM_GETGROUPINFOBYINDEX = (LVM_FIRST + 153);
        public const uint LVM_MOVEITEMTOGROUP = (LVM_FIRST + 154);
        public const uint LVM_GETGROUPRECT = (LVM_FIRST + 98);
        public const uint LVM_SETGROUPMETRICS = (LVM_FIRST + 155);
        public const uint LVM_GETGROUPMETRICS = (LVM_FIRST + 156);
        public const uint LVM_ENABLEGROUPVIEW = (LVM_FIRST + 157);
        public const uint LVM_SORTGROUPS = (LVM_FIRST + 158);
        public const uint LVM_INSERTGROUPSORTED = (LVM_FIRST + 159);
        public const uint LVM_REMOVEALLGROUPS = (LVM_FIRST + 160);
        public const uint LVM_HASGROUP = (LVM_FIRST + 161);
        public const uint LVM_GETGROUPSTATE = (LVM_FIRST + 92);
        public const uint LVM_GETFOCUSEDGROUP = (LVM_FIRST + 93);
        public const uint LVM_SETTILEVIEWINFO = (LVM_FIRST + 162);
        public const uint LVM_GETTILEVIEWINFO = (LVM_FIRST + 163);
        public const uint LVM_SETTILEINFO = (LVM_FIRST + 164);
        public const uint LVM_GETTILEINFO = (LVM_FIRST + 165);
        public const uint LVM_SETINSERTMARK = (LVM_FIRST + 166);
        public const uint LVM_GETINSERTMARK = (LVM_FIRST + 167);
        public const uint LVM_INSERTMARKHITTEST = (LVM_FIRST + 168);
        public const uint LVM_GETINSERTMARKRECT = (LVM_FIRST + 169);
        public const uint LVM_SETINSERTMARKCOLOR = (LVM_FIRST + 170);
        public const uint LVM_GETINSERTMARKCOLOR = (LVM_FIRST + 171);
        public const uint LVM_GETSELECTEDCOLUMN = (LVM_FIRST + 174);
        public const uint LVM_ISGROUPVIEWENABLED = (LVM_FIRST + 175);
        public const uint LVM_GETOUTLINECOLOR = (LVM_FIRST + 176);
        public const uint LVM_SETOUTLINECOLOR = (LVM_FIRST + 177);
        public const uint LVM_CANCELEDITLABEL = (LVM_FIRST + 179);
        public const uint LVM_MAPINDEXTOID = (LVM_FIRST + 180);
        public const uint LVM_MAPIDTOINDEX = (LVM_FIRST + 181);
        public const uint LVM_ISITEMVISIBLE = (LVM_FIRST + 182);
        public const uint LVM_GETEMPTYTEXT = (LVM_FIRST + 204);
        public const uint LVM_GETFOOTERRECT = (LVM_FIRST + 205);
        public const uint LVM_GETFOOTERINFO = (LVM_FIRST + 206);
        public const uint LVM_GETFOOTERITEMRECT = (LVM_FIRST + 207);
        public const uint LVM_GETFOOTERITEM = (LVM_FIRST + 208);
        public const uint LVM_GETITEMINDEXRECT = (LVM_FIRST + 209);
        public const uint LVM_SETITEMINDEXSTATE = (LVM_FIRST + 210);
        public const uint LVM_GETNEXTITEMINDEX = (LVM_FIRST + 211);
        //public const uint LVM_SETBKIMAGE = LVM_SETBKIMAGEW;
        //public const uint LVM_GETBKIMAGE = LVM_GETBKIMAGEW;
        //public const uint LVM_SETBKIMAGE = LVM_SETBKIMAGEA;
        //public const uint LVM_GETBKIMAGE = LVM_GETBKIMAGEA;
    }

    public static class CommonControlsMessageConst
    {
        public const uint CCM_FIRST = 0x2000;// Common control shared messages
        public const uint CCM_LAST = (CCM_FIRST + 0x200);
        public const uint CCM_SETBKCOLOR = (CCM_FIRST + 1);// lParam is bkColor
        public const uint CCM_SETCOLORSCHEME = (CCM_FIRST + 2);// lParam is color scheme
        public const uint CCM_GETCOLORSCHEME = (CCM_FIRST + 3);// fills in COLORSCHEME pointed to by lParam
        public const uint CCM_GETDROPTARGET = (CCM_FIRST + 4);
        public const uint CCM_SETUNICODEFORMAT = (CCM_FIRST + 5);
        public const uint CCM_GETUNICODEFORMAT = (CCM_FIRST + 6);
        public const uint CCM_SETVERSION = (CCM_FIRST + 0x7);
        public const uint CCM_GETVERSION = (CCM_FIRST + 0x8);
        public const uint CCM_SETNOTIFYWINDOW = (CCM_FIRST + 0x9);// wParam == hwndParent.
        public const uint CCM_SETWINDOWTHEME = (CCM_FIRST + 0xb);
        public const uint CCM_DPISCALE = (CCM_FIRST + 0xc);// wParam == Awareness
    }
    [Flags]
    public enum ListViewNextItem : uint
    {

        LVNI_ALL = 0x0000,
        LVNI_FOCUSED = 0x0001,
        LVNI_SELECTED = 0x0002,
        LVNI_CUT = 0x0004,
        LVNI_DROPHILITED = 0x0008,
        LVNI_STATEMASK = (LVNI_FOCUSED | LVNI_SELECTED | LVNI_CUT | LVNI_DROPHILITED),
        LVNI_VISIBLEORDER = 0x0010,
        LVNI_PREVIOUS = 0x0020,
        LVNI_VISIBLEONLY = 0x0040,
        LVNI_SAMEGROUPONLY = 0x0080,
        LVNI_ABOVE = 0x0100,
        LVNI_BELOW = 0x0200,
        LVNI_TOLEFT = 0x0400,
        LVNI_TORIGHT = 0x0800,
        LVNI_DIRECTIONMASK = (LVNI_ABOVE | LVNI_BELOW | LVNI_TOLEFT | LVNI_TORIGHT),
    }
    public static class ListViewNextItemConst
    {
        public const uint LVNI_ALL = 0x0000;
        public const uint LVNI_FOCUSED = 0x0001;
        public const uint LVNI_SELECTED = 0x0002;
        public const uint LVNI_CUT = 0x0004;
        public const uint LVNI_DROPHILITED = 0x0008;
        public const uint LVNI_STATEMASK = (LVNI_FOCUSED | LVNI_SELECTED | LVNI_CUT | LVNI_DROPHILITED);
        public const uint LVNI_VISIBLEORDER = 0x0010;
        public const uint LVNI_PREVIOUS = 0x0020;
        public const uint LVNI_VISIBLEONLY = 0x0040;
        public const uint LVNI_SAMEGROUPONLY = 0x0080;
        public const uint LVNI_ABOVE = 0x0100;
        public const uint LVNI_BELOW = 0x0200;
        public const uint LVNI_TOLEFT = 0x0400;
        public const uint LVNI_TORIGHT = 0x0800;
        public const uint LVNI_DIRECTIONMASK = (LVNI_ABOVE | LVNI_BELOW | LVNI_TOLEFT | LVNI_TORIGHT);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct tagLVFINDINFOA
    {

        /// UINT->unsigned int
        public uint flags;

        /// LPCSTR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string psz;

        /// LPARAM->LONG_PTR->int
        public int lParam;

        /// POINT->tagPOINT
        public Point pt;

        /// UINT->unsigned int
        public uint vkDirection;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct tagLVFINDINFOW
    {

        /// UINT->unsigned int
        public uint flags;

        /// LPCWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string psz;

        /// LPARAM->LONG_PTR->int
        public int lParam;

        /// POINT->tagPOINT
        public Point pt;

        /// UINT->unsigned int
        public uint vkDirection;
    }

    public static class TreeViewMacros
    {
        public static IntPtr TreeView_InsertItem(IntPtr hWnd, TVINSERTSTRUCTW item)
        {
            using (var p = new ApiStructHandleRef<TVINSERTSTRUCTW>(item))
            {
                IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_INSERTITEMW, IntPtr.Zero, p);
                return result;
            }
        }

        public static IntPtr TreeView_InsertItem(IntPtr hWnd, TVINSERTSTRUCTEXW item)
        {
            using (var p = new ApiStructHandleRef<TVINSERTSTRUCTEXW>(item))
            {
                IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_INSERTITEMW, IntPtr.Zero, p);
                return result;
            }
        }

        public static bool TreeView_DeleteItem(IntPtr hWnd, TVITEMW hTreeItem)
        {
            using (var p = new ApiStructHandleRef<TVITEMW>(hTreeItem))
            {
                IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_DELETEITEM, IntPtr.Zero, p);
                return (ApiBool)result.ToInt32();
            }

        }

        public static bool TreeView_DeleteAllItems(IntPtr hWnd)
        {
            IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_DELETEITEM, IntPtr.Zero, TreeViewConst.TVI_ROOT);
            return (ApiBool)result.ToInt32();
        }

        public static bool TreeView_ExpandPtr(IntPtr hWnd, IntPtr hItem, uint code)
        {
            IntPtr result = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_EXPAND, (int)code, hItem);
            return (ApiBool)result.ToInt32();
        }
        public static bool TreeView_Expand(IntPtr hWnd, TVITEMW hItem, uint code)
        {
            using (var p = new ApiStructHandleRef<TVITEMW>(hItem))
            {
                IntPtr result = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_EXPAND, (int)code, p);
                return (ApiBool)result.ToInt32();

            }
        }

        public static bool TreeView_GetItemRect(IntPtr hWnd, TVITEMEXW item, ApiBool onlyText, out Rect rect)
        {
            using (var p = new ApiStructHandleRef<TVITEMEXW>(item))
            {
                IntPtr result = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_GETITEMRECT, onlyText, p);
                ApiBool ok = (ApiBool)result.ToInt32();
                if (ok)
                {
                    rect = Marshal.PtrToStructure<Rect>(p);
                    return true;
                }
                rect = new Rect();
                return false;
            }
        }
        public static int TreeView_GetCount(IntPtr hWnd)
        {
            IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_GETCOUNT, IntPtr.Zero, IntPtr.Zero);
            return result.ToInt32();
        }
        public static int TreeView_GetIndent(IntPtr hWnd)
        {
            IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_GETINDENT, IntPtr.Zero, IntPtr.Zero);
            return result.ToInt32();
        }

        public static bool TreeView_SetIndent(IntPtr hWnd, int indent)
        {
            IntPtr result = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_SETINDENT, indent, 0);
            return (ApiBool)result.ToInt32();
        }
        public static IntPtr TreeView_GetImageList(IntPtr hWnd, int type = (int)TreeViewConst.TVSIL_NORMAL)
        {
            IntPtr result = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_GETIMAGELIST, type, 0);
            return result;
        }

        public static IntPtr TreeView_SetImageList(IntPtr hWnd, IntPtr hIList, int type = (int)TreeViewConst.TVSIL_NORMAL)
        {
            IntPtr result = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_SETIMAGELIST, type, hIList);
            return result;
        }

        public static TVITEMW? TreeView_GetNextItem(IntPtr hWnd, uint flag, TVITEMW? item)
        {
            if (item == null)
            {
                return TreeView_GetNextItem(hWnd, flag);
            }
            else
            {
                return TreeView_GetNextItem(hWnd, flag, item);
            }
        }
        public static TVITEMW? TreeView_GetNextItem(IntPtr hWnd, uint flag, TVITEMW item)
        {
            using (var p = new ApiStructHandleRef<TVITEMW>(item))
            {
                IntPtr nItem = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_GETNEXTITEM, (int)flag, p);
                if (nItem != IntPtr.Zero)
                {
                    return Marshal.PtrToStructure<TVITEMW>(nItem);
                }
                else
                {
                    return null;
                }

            }
        }

        public static IntPtr TreeView_GetNextItemPtr(IntPtr hWnd, uint flag, IntPtr item)
        {
            return User32.SendMessage(hWnd, (int)TreeViewConst.TVM_GETNEXTITEM, (int)flag, item);
        }

        public static TVITEMW? TreeView_GetNextItem(IntPtr hWnd, uint flag)
        {
            IntPtr nItem = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_GETNEXTITEM, (int)flag, IntPtr.Zero);
            if (nItem != IntPtr.Zero)
            {
                return Marshal.PtrToStructure<TVITEMW>(nItem);
            }
            else
            {
                return null;
            }
        }

        public static IntPtr TreeView_GetChildPtr(IntPtr hWnd, IntPtr item)
        {
            return TreeView_GetNextItemPtr(hWnd, TreeViewConst.TVGN_CHILD, item);
        }
        public static TVITEMW? TreeView_GetChild(IntPtr hWnd, TVITEMW item)
        {
            return TreeView_GetNextItem(hWnd, TreeViewConst.TVGN_CHILD, item);
        }

        public static IntPtr TreeView_GetNextSiblingPtr(IntPtr hWnd, IntPtr item)
        {
            return TreeView_GetNextItemPtr(hWnd, TreeViewConst.TVGN_NEXT, item);
        }
        public static TVITEMW? TreeView_GetNextSibling(IntPtr hWnd, TVITEMW item)
        {
            return TreeView_GetNextItem(hWnd, TreeViewConst.TVGN_NEXT, item);
        }

        public static IntPtr TreeView_GetPrevSiblingPtr(IntPtr hWnd, IntPtr item)
        {
            return TreeView_GetNextItemPtr(hWnd, TreeViewConst.TVGN_PREVIOUS, item);
        }

        public static TVITEMW? TreeView_GetPrevSibling(IntPtr hWnd, TVITEMW item)
        {
            return TreeView_GetNextItem(hWnd, TreeViewConst.TVGN_PREVIOUS, item);
        }
        public static IntPtr TreeView_GetParentPtr(IntPtr hWnd, IntPtr intem)
        {
            return TreeView_GetNextItemPtr(hWnd, TreeViewConst.TVGN_PARENT, intem);
        }
        public static TVITEMW? TreeView_GetParent(IntPtr hWnd, TVITEMW item)
        {
            return TreeView_GetNextItem(hWnd, TreeViewConst.TVGN_PARENT, item);
        }

        public static IntPtr TreeView_GetFirstVisiblePtr(IntPtr hWnd, IntPtr item)
        {
            return TreeView_GetNextItemPtr(hWnd, TreeViewConst.TVGN_FIRSTVISIBLE, item);
        }

        public static TVITEMW? TreeView_GetFirstVisible(IntPtr hWnd, TVITEMW item)
        {
            return TreeView_GetNextItem(hWnd, TreeViewConst.TVGN_FIRSTVISIBLE, item);
        }

        public static IntPtr TreeView_GetNexVisible(IntPtr hWnd, IntPtr item)
        {
            return TreeView_GetNextItemPtr(hWnd, TreeViewConst.TVGN_NEXTVISIBLE, item);
        }
        public static TVITEMW? TreeView_GetNexVisible(IntPtr hWnd, TVITEMW item)
        {
            return TreeView_GetNextItem(hWnd, TreeViewConst.TVGN_NEXTVISIBLE, item);
        }

        public static IntPtr TreeView_GetPrevVisiblePtr(IntPtr hWnd, IntPtr item)
        {
            return TreeView_GetNextItemPtr(hWnd, TreeViewConst.TVGN_PREVIOUSVISIBLE, item);
        }

        public static TVITEMW? TreeView_GetPrevVisible(IntPtr hWnd, TVITEMW item)
        {
            return TreeView_GetNextItem(hWnd, TreeViewConst.TVGN_PREVIOUSVISIBLE, item);
        }

        public static IntPtr TreeView_GetSelectionPtr(IntPtr hWnd)
        {
            return TreeView_GetNextItemPtr(hWnd, TreeViewConst.TVGN_CARET, IntPtr.Zero);
        }

        public static TVITEMW? TreeView_GetSelection(IntPtr hWnd)
        {
            return TreeView_GetNextItem(hWnd, TreeViewConst.TVGN_CARET, null);
        }

        public static IntPtr TreeView_GetDropHilightPtr(IntPtr hWnd)
        {
            return TreeView_GetNextItemPtr(hWnd, TreeViewConst.TVGN_DROPHILITE, IntPtr.Zero);
        }

        public static TVITEMW? TreeView_GetDropHilight(IntPtr hWnd)
        {
            return TreeView_GetNextItem(hWnd, TreeViewConst.TVGN_DROPHILITE, null);
        }

        public static IntPtr TreeView_GetRootPtr(IntPtr hWnd)
        {
            return TreeView_GetNextItemPtr(hWnd, TreeViewConst.TVGN_ROOT, IntPtr.Zero);
        }
        public static TVITEMW? TreeView_GetRoot(IntPtr hWnd)
        {
            return TreeView_GetNextItem(hWnd, TreeViewConst.TVGN_ROOT, null);
        }

        public static IntPtr TreeView_GetLastVisiblePtr(IntPtr hWnd)
        {
            return TreeView_GetNextItemPtr(hWnd, TreeViewConst.TVGN_LASTVISIBLE, IntPtr.Zero);
        }

        public static TVITEMW? TreeView_GetLastVisible(IntPtr hWnd)
        {
            return TreeView_GetNextItem(hWnd, TreeViewConst.TVGN_LASTVISIBLE, null);
        }

        public static IntPtr TreeView_GetNextSelectedPtr(IntPtr hWnd, IntPtr item)
        {
            return TreeView_GetNextItemPtr(hWnd, TreeViewConst.TVGN_NEXTSELECTED, item);
        }

        public static TVITEMW? TreeView_GetNextSelected(IntPtr hWnd, TVITEMW item)
        {
            return TreeView_GetNextItem(hWnd, TreeViewConst.TVGN_NEXTSELECTED, item);
        }

        public static bool TreeView_SelectPtr(IntPtr hWnd, uint code, IntPtr item)
        {
            IntPtr result = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_SELECTITEM, item, (int)code);
            return (ApiBool)result.ToInt32();

        }

        public static bool TreeView_Select(IntPtr hWnd, uint code, TVITEMW? item)
        {
            if (item == null)
            {
                IntPtr result = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_SELECTITEM, IntPtr.Zero, (int)code);
                return (ApiBool)result.ToInt32();
            }
            else
            {
                using (var p = new ApiStructHandleRef<TVITEMW>(item))
                {
                    IntPtr result = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_SELECTITEM, p, (int)code);
                    return (ApiBool)result.ToInt32();
                }
            }
        }

        public static bool TreeView_SelectItemPtr(IntPtr hWnd, IntPtr item)
        {
            return TreeView_SelectPtr(hWnd, TreeViewConst.TVGN_CARET, item);
        }
        public static bool TreeView_SelectItem(IntPtr hWnd, TVITEMW item)
        {
            return TreeView_Select(hWnd, TreeViewConst.TVGN_CARET, item);
        }

        public static bool TreeView_SelectDropTargetPtr(IntPtr hWnd, IntPtr item)
        {
            return TreeView_SelectPtr(hWnd, TreeViewConst.TVGN_DROPHILITE, item);
        }
        public static bool TreeView_SelectDropTarget(IntPtr hWnd, TVITEMW item)
        {
            return TreeView_Select(hWnd, TreeViewConst.TVGN_DROPHILITE, item);
        }

        public static bool TreeView_SelectSetFirstVisiblePtr(IntPtr hWnd, IntPtr item)
        {
            return TreeView_SelectPtr(hWnd, TreeViewConst.TVGN_FIRSTVISIBLE, item);
        }

        public static bool TreeView_SelectSetFirstVisible(IntPtr hWnd, TVITEMW item)
        {
            return TreeView_Select(hWnd, TreeViewConst.TVGN_FIRSTVISIBLE, item);
        }




        public static bool TreeView_GetItem(IntPtr hWnd, ref TVITEMW item)
        {
            using (var p = new ApiStructHandleRef<TVITEMW>(item))
            {
                IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_GETITEMW, IntPtr.Zero, p);
                ApiBool ok = (ApiBool)result.ToInt32();
                if (ok)
                {
                    item = p.GetStruct();
                    return true;
                }
                return false;
            }
        }

        public static bool TreeView_GetItem(IntPtr hWnd, ref TVITEMEXW item)
        {
            using (var p = new ApiStructHandleRef<TVITEMEXW>(item))
            {
                IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_GETITEMW, IntPtr.Zero, p);
                ApiBool ok = (ApiBool)result.ToInt32();
                if (ok)
                {
                    item = p.GetStruct();
                    return true;
                }
                return false;
            }
        }
        public static bool TreeView_SetItem(IntPtr hWnd, TVITEMW item)
        {
            using (var p = new ApiStructHandleRef<TVITEMW>(item))
            {
                IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_SETITEMW, IntPtr.Zero, p);
                return (ApiBool)result.ToInt32();
            }
        }

        public static bool TreeView_SetItem(IntPtr hWnd, TVITEMEXW item)
        {
            using (var p = new ApiStructHandleRef<TVITEMW>(item))
            {
                IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_SETITEMW, IntPtr.Zero, p);
                return (ApiBool)result.ToInt32();
            }
        }

        public static IntPtr TreeView_EditLabel(IntPtr hWnd, TVITEMW item)
        {
            using (var p = new ApiStructHandleRef<TVITEMW>(item))
            {
                return User32.SendMessage(hWnd, TreeViewConst.TVM_EDITLABELW, IntPtr.Zero, p);
            }
        }

        public static IntPtr TreeView_GetEditControl(IntPtr hWnd)
        {
            return User32.SendMessage(hWnd, TreeViewConst.TVM_GETEDITCONTROL);
        }

        public static int TreeView_GetVisibleCount(IntPtr hWnd)
        {
            IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_GETVISIBLECOUNT);
            return result.ToInt32();
        }

        public static bool TreeView_HitTest(IntPtr hWnd, TVHITTESTINFO hitTestItem, out TVITEMW item)
        {
            using (var p = new ApiStructHandleRef<TVHITTESTINFO>(hitTestItem))
            {
                IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_HITTEST, IntPtr.Zero, p);
                if (result != IntPtr.Zero)
                {
                    item = Marshal.PtrToStructure<TVITEMW>(result);
                    return true;
                }
                else
                {
                    item = new TVITEMW();
                    return false;
                }
            }
        }

        public static IntPtr TreeView_CreateDragImage(IntPtr hWnd, TVITEMW item)
        {
            using (var p = new ApiStructHandleRef<TVITEMW>(item))
            {
                return User32.SendMessage(hWnd, TreeViewConst.TVM_CREATEDRAGIMAGE, IntPtr.Zero, p);

            }
        }

        public static bool TreeView_SortChildren(IntPtr hWnd, TVITEMW item, bool recourive)
        {
            using (var p = new ApiStructHandleRef<TVITEMW>(item))
            {

                IntPtr result = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_SORTCHILDREN, (ApiBool)recourive, p);
                return (ApiBool)result.ToInt32();
            }
        }
        public static bool TreeView_EnsureVisible(IntPtr hWnd, TVITEMW item)
        {
            using (var p = new ApiStructHandleRef<TVITEMW>(item))
            {
                IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_ENSUREVISIBLE, IntPtr.Zero, p);
                return (ApiBool)result.ToInt32();
            }
        }

        public static bool TreeView_SortChildrenCB(IntPtr hWnd, TVSORTCB sortCb)
        {
            using (var p = new ApiStructHandleRef<TVSORTCB>(sortCb))
            {
                IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_SORTCHILDRENCB, IntPtr.Zero, p);
                return (ApiBool)result.ToInt32();
            }
        }

        public static bool TreeView_EndEditLabelNow(IntPtr hWnd, bool cancel)
        {
            IntPtr result = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_ENDEDITLABELNOW, (ApiBool)cancel, 0);
            return (ApiBool)result.ToInt32();
        }

        public static IntPtr TreeView_SetToolTips(IntPtr hWnd, IntPtr toolTip)
        {
            return User32.SendMessage(hWnd, (int)TreeViewConst.TVM_SETTOOLTIPS, toolTip, IntPtr.Zero);
        }

        public static IntPtr TreeView_GetToolTips(IntPtr hWnd)
        {
            return User32.SendMessage(hWnd, TreeViewConst.TVM_GETTOOLTIPS);
        }

        public static int TreeView_GetISearchString(IntPtr hWnd, out string searchString)
        {
            StringBuilder sb = new StringBuilder(1024);
            IntPtr result = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_GETISEARCHSTRINGW, 0, sb);
            searchString = sb.ToString();
            return result.ToInt32();
        }

        public static int TreeView_SetInsertMark(IntPtr hWnd, bool placeAfter, TVITEMW? item)
        {
            if (item == null)
            {
                IntPtr result = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_SETINSERTMARK, (ApiBool)placeAfter, IntPtr.Zero);
                return result.ToInt32();
            }
            else
            {
                using (var p = new ApiStructHandleRef<TVITEMW>(item))
                {
                    IntPtr result = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_SETINSERTMARK, (ApiBool)placeAfter, p);
                    return result.ToInt32();
                }

            }

        }

        public static bool TreeView_SetUnicodeFormat(IntPtr hWnd, bool unicode)
        {
            IntPtr result = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_SETUNICODEFORMAT, (ApiBool)unicode, 0);
            return (ApiBool)result.ToInt32();
        }


        public static bool TreeView_GetUnicodeFormat(IntPtr hWnd)
        {
            IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_GETUNICODEFORMAT);
            return (ApiBool)result.ToInt32();
        }

        public static int TreeView_SetItemHeight(IntPtr hWnd, int height)
        {
            IntPtr result = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_SETITEMHEIGHT, height, 0);
            return result.ToInt32();
        }

        public static int TreeView_GetItemHeight(IntPtr hWnd)
        {
            IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_GETITEMHEIGHT);
            return result.ToInt32();
        }

        public static int TreeView_SetBkColor(IntPtr hWnd, int color)
        {
            IntPtr result = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_SETBKCOLOR, 0, color);
            return result.ToInt32();
        }

        public static int TreeView_SetTextColor(IntPtr hWnd, int color)
        {
            IntPtr result = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_SETTEXTCOLOR, 0, color);
            return result.ToInt32();
        }

        public static int TreeView_GetBkColor(IntPtr hWnd)
        {
            IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_GETBKCOLOR);
            return result.ToInt32();
        }
        public static int TreeView_GetTextColor(IntPtr hWnd)
        {
            IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_GETTEXTCOLOR);
            return result.ToInt32();
        }

        public static uint TreeView_SetScrollTime(IntPtr hWnd, uint uTime)
        {
            IntPtr result = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_SETSCROLLTIME, uTime, 0);
            return (uint)result.ToInt64();
        }
        public static uint TreeView_GetScrollTime(IntPtr hWnd)
        {
            IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_GETSCROLLTIME);
            return (uint)result.ToInt64();
        }

        public static int TreeView_SetInsertMarkColor(IntPtr hWnd, int color)
        {
            IntPtr result = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_SETINSERTMARKCOLOR, 0, color);
            return result.ToInt32();
        }

        public static int TreeView_GetInsertMarkColor(IntPtr hWnd)
        {
            IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_GETINSERTMARKCOLOR);
            return result.ToInt32();
        }

        public static int TreeView_SetBorder(IntPtr hWnd, uint dwFalg, int xBorder, int yBorder)
        {
            IntPtr result = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_SETBORDER, (int)dwFalg, Win32Api.MakeLParam(xBorder, yBorder));
            return result.ToInt32();
        }

        public static bool TreeView_SetItemState(IntPtr hWnd, TVITEMW item, uint data, uint mask)
        {
            using (var pItem = new ApiStructHandleRef<TVITEMW>(item))
            {
                TVITEMW iItem = new TVITEMW();
                iItem.mask = TreeViewConst.TVIF_STATE;
                iItem.hItem = pItem;
                iItem.stateMask = mask;
                iItem.state = data;
                TreeView_SetItem(hWnd, iItem);
                return TreeView_SetItem(hWnd, iItem);


            }
        }

        //public unsafe static TVITEMEXW ItemToItemEx(TVITEMW* item)
        //{
        //    TVITEMEXW* pt = (TVITEMEXW*)item;
        //    return *pt;
        //}
        //public unsafe static TVITEMW ItemExToItem(TVITEMEXW* item)
        //{
        //    TVITEMW* pt = (TVITEMW*)item;
        //    return *pt;
        //}
        public static int INDEXTOSTATEIMAGEMASK(int index)
        {
            return index << 12;
        }
        public static bool TreeView_SetCheckState(IntPtr hWnd, TVITEMW item, bool check)
        {
            return TreeView_SetItemState(hWnd, item, (uint)INDEXTOSTATEIMAGEMASK(check ? 2 : 1), TreeViewConst.TVIS_STATEIMAGEMASK);
        }

        public static uint TreeView_GetItemState(IntPtr hWnd, TVITEMW item, uint mask)
        {
            using (var p = new ApiStructHandleRef<TVITEMW>(item))
            {
                IntPtr result = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_GETITEMSTATE, p, (int)mask);
                return (uint)result.ToInt64();
            }
        }

        public static int TreeView_GetCheckState(IntPtr hWnd, TVITEMW item)
        {
            using (var p = new ApiStructHandleRef<TVITEMW>(item))
            {
                IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_GETITEMSTATE, p, (int)TreeViewConst.TVIS_STATEIMAGEMASK);
                int vla = result.ToInt32();
                return ((vla >> 12) - 1);
            }
        }

        public static int TreeView_SetLineColor(IntPtr hWnd, int color)
        {
            IntPtr result = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_SETLINECOLOR, 0, color);
            return result.ToInt32();
        }
        public static int TreeView_GetLineColor(IntPtr hWnd)
        {
            IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_GETLINECOLOR);
            return result.ToInt32();
        }

        public static bool TreeView_MapAccIDToHTREEITEM(IntPtr hWnd, uint id, out TVITEMW intem)
        {
            IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_MAPACCIDTOHTREEITEM, id);
            if (result != IntPtr.Zero)
            {
                intem = Marshal.PtrToStructure<TVITEMW>(result);
                return true;
            }
            else
            {
                intem = new TVITEMW();
                return false;
            }
        }

        public static uint TreeView_MapHTREEITEMToAccID(IntPtr hWnd, TVITEMW item)
        {
            using (var p = new ApiStructHandleRef<TVITEMW>(item))
            {
                IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_MAPHTREEITEMTOACCID, p, 0);
                return (uint)result.ToInt64();
            }
        }

        public static int TreeView_SetExtendedStyle(IntPtr hWnd, uint dw, uint maks)
        {
            IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_SETEXTENDEDSTYLE, maks, dw);
            return result.ToInt32();
        }

        public static uint TreeView_GetExtendedStyle(IntPtr hWnd)
        {
            IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_GETEXTENDEDSTYLE);
            return (uint)result.ToInt64();
        }
        public static bool TreeView_SetAutoScrollInfo(IntPtr hWnd, uint uPixPerSec, uint uUpdateTime)
        {
            IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_SETAUTOSCROLLINFO, uPixPerSec, uUpdateTime);
            return (ApiBool)result.ToInt32();
        }

        public static bool TreeView_SetHot(IntPtr hWnd, TVITEMW item)
        {
            using (var p = new ApiStructHandleRef<TVITEMW>(item))
            {
                IntPtr result = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_SETHOT, 0, p);
                return (ApiBool)result.ToInt32();
            }
        }

        public static uint TreeView_GetSelectedCount(IntPtr hWnd)
        {
            IntPtr result = User32.SendMessage(hWnd, TreeViewConst.TVM_GETSELECTEDCOUNT);
            return (uint)result.ToInt64();
        }

        public static uint TreeView_ShowInfoTip(IntPtr hWnd, TVITEMW item)
        {
            using (var p = new ApiStructHandleRef<TVITEMW>(item))
            {
                IntPtr result = User32.SendMessage(hWnd, (int)TreeViewConst.TVM_SHOWINFOTIP, 0, p);
                return (uint)result.ToInt64();
            }
        }
    }
    public static class ListViewMacros
    {

        public static int ListView_GeItemCount(IntPtr hWnd)
        {
            IntPtr result = User32.SendMessage(hWnd, ListViewMessageConst.LVM_GETITEMCOUNT, IntPtr.Zero, IntPtr.Zero);
            return result.ToInt32();
        }
        public static void ListView_CancelEditLabel(IntPtr hWnd)
        {
            User32.SendMessage(hWnd, ListViewMessageConst.LVM_CANCELEDITLABEL, IntPtr.Zero, IntPtr.Zero);

        }

        public static IntPtr ListView_GetEditControl(IntPtr hWnd)
        {
            return User32.SendMessage(hWnd, ListViewMessageConst.LVM_GETEDITCONTROL, IntPtr.Zero, IntPtr.Zero);

        }

        public static ApiBool ListView_GetItemW(IntPtr hwnd, out tagLVITEMW pItem)
        {

            //using(var p = new ApiStructHandleRef<tagLVITEMW>())
            //{
            //    IntPtr result = User32.SendMessage(hwnd, (int)ListViewMessageConst.LVM_GETITEMW, IntPtr.Zero, p);
            //    ApiBool ok = result.ToInt32();
            //    pItem = ok ? p.GetStruct() : default(tagLVITEMW);
            //    return ok;
            //}

            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(tagLVITEMW)));
            tagLVITEMW tmpTag = new tagLVITEMW();
            Marshal.StructureToPtr(tmpTag, p, false);
            IntPtr result = User32.SendMessage(hwnd, (int)ListViewMessageConst.LVM_GETITEMW, IntPtr.Zero, p);
            int r = result.ToInt32();
            ApiBool ok = r;
            if (ok)
            {
                pItem = Marshal.PtrToStructure<tagLVITEMW>(p);
            }
            else
            {
                pItem = default(tagLVITEMW);
            }
            Marshal.FreeHGlobal(p);
            return ok;
        }


        public static ApiBool ListView_GetItemA(IntPtr hWnd, out tagLVITEMA pItem)
        {
            //using (var p = new ApiStructHandleRef<tagLVITEMA>())
            //{
            //    IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_GETITEMA, IntPtr.Zero, p);
            //    ApiBool ok = result.ToInt32();
            //    pItem = ok ? p.GetStruct() : default(tagLVITEMA);
            //    return ok;
            //}

            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(tagLVITEMA)));
            tagLVITEMA tmpTag = new tagLVITEMA();
            Marshal.StructureToPtr(tmpTag, p, false);
            IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_GETITEMA, IntPtr.Zero, p);
            int r = result.ToInt32();
            ApiBool ok = r;
            if (ok)
            {
                pItem = Marshal.PtrToStructure<tagLVITEMA>(p);
            }
            else
            {
                pItem = default(tagLVITEMA);
            }
            Marshal.FreeHGlobal(p);
            return ok;
        }

        public static ApiBool ListView_SetItemW(IntPtr hWnd, tagLVITEMW pItem)
        {
            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(tagLVITEMW)));
            Marshal.StructureToPtr(pItem, p, false);
            IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_SETITEMW, IntPtr.Zero, p);
            int r = result.ToInt32();
            Marshal.FreeHGlobal(p);
            return r;


        }

        public static ApiBool ListView_SetItemA(IntPtr hWnd, tagLVITEMA pItem)
        {
            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(tagLVITEMA)));
            Marshal.StructureToPtr(pItem, p, true);
            IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_SETITEMA, IntPtr.Zero, p);
            int r = result.ToInt32();
            Marshal.FreeHGlobal(p);
            return r;

        }

        public static int ListView_InsertItemW(IntPtr hWnd, tagLVITEMW pItem)
        {
            //using (var p = new ApiStructHandleRef<tagLVITEMW>(pItem))
            //{
            //    IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_INSERTITEMW, IntPtr.Zero, p);
            //    int r = result.ToInt32();
            //    return r;
            //}
            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(tagLVITEMW)));
            Marshal.StructureToPtr(pItem, p, false);
            IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_INSERTITEMW, 0, p);
            int r = result.ToInt32();
            Marshal.FreeHGlobal(p);
            return r;
        }

        public static int ListView_InsertItemA(IntPtr hWnd, tagLVITEMA pItem)
        {
            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(tagLVITEMA)));
            Marshal.StructureToPtr(pItem, p, false);
            IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_INSERTITEMA, 0, p);
            int r = result.ToInt32();
            Marshal.FreeHGlobal(p);
            return r;
        }

        public static ApiBool ListView_DeleteItem(IntPtr hWnd, int index)
        {
            IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_DELETEITEM, index, 0);
            int r = result.ToInt32();
            return r;
        }

        public static ApiBool ListView_DeleteAllItems(IntPtr hWnd)
        {
            IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_DELETEALLITEMS, 0, 0);
            int r = result.ToInt32();
            return r;
        }

        public static ApiBool ListView_GetCallbackMask(IntPtr hWnd)
        {
            IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_GETCALLBACKMASK, 0, 0);
            int r = result.ToInt32();
            return r;
        }

        public static int ListView_InsertColumnW(IntPtr hWnd, int index, tagLVCOLUMNW col)
        {

            using (var p = new ApiStructHandleRef<tagLVCOLUMNW>(col))
            {
                IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_INSERTCOLUMNW, index, p);
                int r = result.ToInt32();
                return r;
            }
            //IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(tagLVCOLUMNW)));
            //Marshal.StructureToPtr(col, p, false);
            //IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_INSERTCOLUMNW, index, p);
            //int r = result.ToInt32();
            //Marshal.FreeHGlobal(p);
            //return r;
        }
        public static int ListView_InsertColumnA(IntPtr hWnd, int index, tagLVCOLUMNA col)
        {
            using (var p = new ApiStructHandleRef<tagLVCOLUMNA>(col))
            {
                IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_INSERTCOLUMNW, index, p);
                int r = result.ToInt32();
                return r;
            }

            //IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(tagLVCOLUMNA)));
            //Marshal.StructureToPtr(col, p, false);
            //IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_INSERTCOLUMNA, index, p);
            //int r = result.ToInt32();
            //Marshal.FreeHGlobal(p);
            //return r;
        }
        public static ApiBool ListView_SetCallbackMask(IntPtr hWnd, uint mask)
        {

            IntPtr result = User32.SendMessage(hWnd, ListViewMessageConst.LVM_SETCALLBACKMASK, mask, 0);
            int r = result.ToInt32();
            return r;


            //IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_SETCALLBACKMASK, , IntPtr.Size);
            //mask = (uint)p.ToInt64();
            //int r = result.ToInt32();
            //Marshal.FreeHGlobal(p);
            //return r;
        }
        public static int ListView_GetNextItem(IntPtr hWnd, int i, uint flag)
        {

            IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_GETNEXTITEM, i, Win32Api.MakeLParam((int)flag, 0));
            return result.ToInt32();
        }

        public static int ListView_SetItemCount(IntPtr hWnd, int i)
        {
            IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_SETITEMCOUNT, i, 0);
            return result.ToInt32();
        }

        public static int ListView_SetItemTextW(IntPtr hWnd, int itemIndex, int subItemIndex, string text)
        {
            tagLVITEMW item = new tagLVITEMW
            {
                mask = ListViewItemMemberValidInfoConst.LVIF_TEXT,
                iSubItem = subItemIndex,
                pszText = text
            };
            using (var p = new ApiStructHandleRef<tagLVITEMW>(item))
            {
                IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_SETITEMTEXTW, itemIndex, p);
                int r = result.ToInt32();
                return r;
            }
            //IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(tagLVITEMW)));
            //Marshal.StructureToPtr(item, p, false);
            //IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_SETITEMTEXTW, itemIndex, p);
            //int r = result.ToInt32();
            //Marshal.FreeHGlobal(p);
            //return r;
        }
        public static uint ListView_GetItemState(IntPtr hWnd, int i)
        {
            IntPtr p = Marshal.AllocHGlobal(sizeof(uint));
            IntPtr intPtr = User32.SendMessage(hWnd, ListViewMessageConst.LVM_GETITEMSTATE, (IntPtr)i, p);
            uint v = (uint)intPtr.ToInt64();
            Marshal.FreeHGlobal(p);
            return v;

        }
        public static void ListView_GetItemTextW(IntPtr hWnd, int indexIndex, int SubItemIndex, out string text)
        {
            tagLVITEMW item = new tagLVITEMW
            {


                iSubItem = SubItemIndex,
                cchTextMax = 255,
                pszText = new string('\0', 255)

            };

            using (var p = new ApiStructHandleRef<tagLVITEMW>(item))
            {
                IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_GETITEMTEXTW, indexIndex, p);
                int r = result.ToInt32();
                if (r > 0)
                {
                    tagLVITEMW it = p.GetStruct();
                    string txt = it.pszText;
                    text = txt;
                }
                else
                {
                    text = "";
                }


            }

        }
        public static int ListView_SetItemTextA(IntPtr hWnd, int itemIndex, int subItemIndex, string text)
        {
            tagLVITEMA item = new tagLVITEMA
            {
                mask = ListViewItemMemberValidInfoConst.LVIF_TEXT,
                iSubItem = subItemIndex,
                pszText = text
            };
            using (var pp = new ApiStructHandleRef<tagLVITEMA>(item))
            {
                IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_SETITEMTEXTA, itemIndex, pp);
                int r = result.ToInt32();
                return r;
            }
            //IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(tagLVITEMA)));
            //Marshal.StructureToPtr(item, p, false);
            //IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_SETITEMTEXTA, itemIndex, p);
            //int r = result.ToInt32();
            //Marshal.FreeHGlobal(p);
            //return r;
        }

        public static int ListView_SetView(IntPtr hWnd, uint viewType)
        {
            IntPtr result = User32.SendMessage(hWnd, ListViewMessageConst.LVM_SETVIEW, viewType);
            int r = result.ToInt32();
            return r;
        }

        public static ApiBool ListView_HitTest(IntPtr hWend, out tagLVHITTESTINFO hitTestInfo)
        {
            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(tagLVHITTESTINFO)));
            tagLVHITTESTINFO tmpTag = new tagLVHITTESTINFO();
            Marshal.StructureToPtr(tmpTag, p, false);

            IntPtr result = User32.SendMessage(hWend, (int)ListViewMessageConst.LVM_HITTEST, 0, p);
            int r = result.ToInt32();
            ApiBool ok = r;
            hitTestInfo = ok ? Marshal.PtrToStructure<tagLVHITTESTINFO>(p) : default(tagLVHITTESTINFO);

            Marshal.FreeHGlobal(p);
            return ok;
        }
        public static ApiBool ListView_HitTestEx(IntPtr hWend, out tagLVHITTESTINFO hitTestInfo)
        {
            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(tagLVHITTESTINFO)));
            tagLVHITTESTINFO tmpTag = new tagLVHITTESTINFO();
            Marshal.StructureToPtr(tmpTag, p, false);

            IntPtr result = User32.SendMessage(hWend, (int)ListViewMessageConst.LVM_HITTEST, -1, p);
            int r = result.ToInt32();
            ApiBool ok = r;
            hitTestInfo = ok ? Marshal.PtrToStructure<tagLVHITTESTINFO>(p) : default(tagLVHITTESTINFO);

            Marshal.FreeHGlobal(p);
            return ok;
        }

        public static int ListView_SubItemHitTest(IntPtr hWnd, ref tagLVHITTESTINFO hitTestInfo)
        {
            using (var p = new ApiStructHandleRef<tagLVHITTESTINFO>(hitTestInfo))
            {
                var r = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_SUBITEMHITTEST, 0, p);
                int r2 = r.ToInt32();
                if (r2 != -1)
                {
                    hitTestInfo = p.GetStruct();
                }
                return r.ToInt32();
            }
        }

        public static int ListView_SubItemHitTestEx(IntPtr hWnd, ref tagLVHITTESTINFO hitTestInfo)
        {
            using (var p = new ApiStructHandleRef<tagLVHITTESTINFO>(hitTestInfo))
            {
                var r = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_SUBITEMHITTEST, -1, p);
                return r.ToInt32();
            }
        }

        public static IntPtr ListView_GetHeader(IntPtr hWnd)
        {
            IntPtr result = User32.SendMessage(hWnd, ListViewMessageConst.LVM_GETHEADER);
            return result;
        }

        public static bool ListView_GetSubItemRect(IntPtr hWnd, int iItem, int iSubItem, int code, out Rect rect)
        {
            Rect rc = new Rect();
            rc.Top = iSubItem;
            rc.Left = code;
            using (var p = new ApiStructHandleRef<Rect>(rc))
            {
                var r = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_GETSUBITEMRECT, iItem, p);
                ApiBool ok = r.ToInt32();
                rect = ok ? p.GetStruct() : default(Rect);
                return ok;
            }
        }
        public static uint ListView_SetExtendedListViewStyle(IntPtr hWnd, uint style)
        {
            User32.SendMessage(hWnd, ListViewMessageConst.LVM_SETEXTENDEDLISTVIEWSTYLE, 0, style);
            uint res = 0;//(uint)Marshal.ReadInt64(result);
            return res;
        }

        public static uint ListView_SetExtendedListViewStyleEx(IntPtr hWnd, uint mask, uint style)
        {
            User32.SendMessage(hWnd, ListViewMessageConst.LVM_SETEXTENDEDLISTVIEWSTYLE, mask, style);
            uint res = 0;//(uint)Marshal.ReadInt64(result);
            return res;
        }

        public static uint ListView_GetExtendedListViewStyle(IntPtr hWnd)
        {
            IntPtr result = User32.SendMessage(hWnd, ListViewMessageConst.LVM_GETEXTENDEDLISTVIEWSTYLE, 0, 0);
            uint res = (uint)Marshal.ReadInt64(result);

            return res;
        }


    }
    public enum CommonControls : uint
    {
        ICC_UNDEFINED = 0,
        ICC_LISTVIEW_CLASSES = 0x00000001, // listview, header
        ICC_TREEVIEW_CLASSES = 0x00000002, // treeview, tooltips
        ICC_BAR_CLASSES = 0x00000004, // toolbar, statusbar, trackbar, tooltips
        ICC_TAB_CLASSES = 0x00000008, // tab, tooltips
        ICC_UPDOWN_CLASS = 0x00000010, // updown
        ICC_PROGRESS_CLASS = 0x00000020, // progress
        ICC_HOTKEY_CLASS = 0x00000040, // hotkey
        ICC_ANIMATE_CLASS = 0x00000080, // animate
        ICC_WIN95_CLASSES = 0x000000FF,
        ICC_DATE_CLASSES = 0x00000100, // month picker, date picker, time picker, updown
        ICC_USEREX_CLASSES = 0x00000200, // comboex
        ICC_COOL_CLASSES = 0x00000400, // rebar (coolbar) control
        ICC_INTERNET_CLASSES = 0x00000800,
        ICC_PAGESCROLLER_CLASS = 0x00001000, // page scroller
        ICC_NATIVEFNTCTL_CLASS = 0x00002000, // native font control
        ICC_STANDARD_CLASSES = 0x00004000,
        ICC_LINK_CLASS = 0x00008000
    }
}