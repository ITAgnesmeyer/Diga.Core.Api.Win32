// ReSharper disable InconsistentNaming

using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct tagLVITEMINDEX
    {

        /// int
        public int iItem;

        /// int
        public int iGroup;
    }


    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
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
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)]
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
        public System.IntPtr puColumns;

        /// int*
        public System.IntPtr piColFmt;

        /// int
        public int iGroup;
    }



    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
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
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
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
        public System.IntPtr puColumns;

        /// int*
        public System.IntPtr piColFmt;

        /// int
        public int iGroup;
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
    public enum ListViewNextItem:uint
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

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct tagLVFINDINFOA {
    
        /// UINT->unsigned int
        public uint flags;
    
        /// LPCSTR->CHAR*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string psz;
    
        /// LPARAM->LONG_PTR->int
        public int lParam;
    
        /// POINT->tagPOINT
        public Point pt;
    
        /// UINT->unsigned int
        public uint vkDirection;
    }

    
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct tagLVFINDINFOW {
    
        /// UINT->unsigned int
        public uint flags;
    
        /// LPCWSTR->WCHAR*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)]
        public string psz;
    
        /// LPARAM->LONG_PTR->int
        public int lParam;
    
        /// POINT->tagPOINT
        public Point pt;
    
        /// UINT->unsigned int
        public uint vkDirection;
    }


    public static class ListViewMacros
    {
        
        public static ApiBool ListView_GetItemW(IntPtr hwnd, out tagLVITEMW pItem)
        {
            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(tagLVITEMW)));



            IntPtr result = User32.SendMessage(hwnd, (int)ListViewMessageConst.LVM_GETITEMW, IntPtr.Zero, p);
            int r = result.ToInt32();

            pItem = Marshal.PtrToStructure<tagLVITEMW>(p);
            Marshal.FreeHGlobal(p);
            return r;
        }


        public static ApiBool ListView_GetItemA(IntPtr hWnd, out tagLVITEMA pItem)
        {
            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(tagLVITEMA)));

            IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_GETITEMA, IntPtr.Zero, p);
            int r = result.ToInt32();
            pItem = Marshal.PtrToStructure<tagLVITEMA>(p);
            Marshal.FreeHGlobal(p);
            return r;
        }

        public static ApiBool ListView_SetItemW(IntPtr hWnd, tagLVITEMW pItem)
        {
            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(tagLVITEMW)));
            Marshal.StructureToPtr(pItem, p,true);
            IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_SETITEMW, IntPtr.Zero, p);
            int r = result.ToInt32();
            Marshal.FreeHGlobal(p);
            return r;


        }

        public static ApiBool ListView_SetItemA(IntPtr hWnd, tagLVITEMA pItem)
        {
            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(tagLVITEMA)));
            Marshal.StructureToPtr(pItem, p,true);
            IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_SETITEMA, IntPtr.Zero, p);
            int r = result.ToInt32();
            Marshal.FreeHGlobal(p);
            return r;

        }

        public static int ListView_InsertItemW(IntPtr hWnd, tagLVITEMW pItem)
        {
            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(tagLVITEMW)));
            Marshal.StructureToPtr(pItem, p,true);
            IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_INSERTITEMW, IntPtr.Zero, p);
            int r = result.ToInt32();
            Marshal.FreeHGlobal(p);
            return r;
        }

        public static int ListView_InsertItemA(IntPtr hWnd, tagLVITEMA pItem)
        {
            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(tagLVITEMA)));
            Marshal.StructureToPtr(pItem, p,true);
            IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_INSERTITEMA, IntPtr.Zero, p);
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
            IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_DELETEALLITEMS, 0, 0);
            int r = result.ToInt32();
            return r;
        }

        public static ApiBool ListView_SetCallbackMask(IntPtr hWnd, out uint mask)
        {
            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(uint)));
            IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_DELETEALLITEMS,p, IntPtr.Size);
            mask = (uint)p.ToInt64();
            int r = result.ToInt32();
            return r;
        }
        public static int ListView_GetNextItem(IntPtr hWnd,int i,  uint flag)
        {

            IntPtr result = User32.SendMessage(hWnd, (int)ListViewMessageConst.LVM_GETNEXTITEM, i, Win32Api.MakeLParam((int)flag, 0));
            return result.ToInt32();
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