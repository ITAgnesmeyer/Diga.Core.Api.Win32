using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{

    // ReSharper disable once IdentifierTypo
    // ReSharper disable once InconsistentNaming
    public struct DLGITEMTEMPLATEALL
    {
        public uint HelpID;
        public uint ExStyle;
        public uint Style;
        public short x;
        public short y;
        public short cx;
        public short cy;
        public uint Id;
        public ushort ClassID;
        public string ClassName;
        public ushort TitleID;
        public string Title;
        public ushort ExtraCount;

    };

    // ReSharper disable once IdentifierTypo
    // ReSharper disable once InconsistentNaming
    public struct DLGTEMPLATEALL
    {
        // ReSharper disable once InconsistentNaming
        public ushort Version;
        public bool IsExtended;
        public uint HelpID;
        public uint ExStyle;
        public uint Style;
        public ushort ItemsCount;
        public short x;
        public short y;
        public short cx;
        public short cy;
        public ushort MenuID;
        public string MenuName;
        public ushort ClassID;
        public string ClassName;
        public string Title;
        public ushort PointSize;
        public ushort Weight;
        public byte Italic;
        public byte CharSet;
        public string TypeFace;

    };

    public struct BYTESPLIT
    {
        public byte First;
        public byte Second;
    }

    [StructLayout(LayoutKind.Sequential,Pack = 1)]
    // ReSharper disable once InconsistentNaming
    // ReSharper disable once IdentifierTypo
    public struct DLGTEMPLATE_API
    {

        /// DWORD->unsigned int
        public uint style;

        /// DWORD->unsigned int
        public uint dwExtendedStyle;

        /// WORD->unsigned short
        public ushort cdit;

        /// short
        public short x;

        /// short
        public short y;

        /// short
        public short cx;

        /// short
        public short cy;
    }

    [StructLayout(LayoutKind.Sequential,Pack = 1)]
    // ReSharper disable once InconsistentNaming
    // ReSharper disable once IdentifierTypo
    public struct DLGITEMTEMPLATE_API
    {

        /// DWORD->unsigned int
        public uint style;

        /// DWORD->unsigned int
        public uint dwExtendedStyle;

        /// short
        public short x;

        /// short
        public short y;

        /// short
        public short cx;

        /// short
        public short cy;

        /// WORD->unsigned short
        public ushort id;
    }

    //Very important to pack 1
    [StructLayout(LayoutKind.Sequential,Pack = 1)]
    // ReSharper disable once InconsistentNaming
    // ReSharper disable once IdentifierTypo
    public struct DLGTEMPLATEEX_API
    {
        //word
        public ushort dlgVer;
        public ushort signature;
        public uint helpID;
        public uint exStyle;
        public uint style;
        public ushort cDlgItems;
        public short x;
        public short y;
        public short cx;
        public short cy;
        // Everything else in this structure is variable length,
        // and therefore must be determined dynamically

        // sz_Or_Ord menu;			// name or ordinal of a menu resource
        // sz_Or_Ord windowClass;	// name or ordinal of a window class
        // WCHAR title[titleLen];	// title string of the dialog box
        // short pointsize;			// only if DS_SETFONT is set
        // short weight;			// only if DS_SETFONT is set
        // short bItalic;			// only if DS_SETFONT is set
        // WCHAR font[fontLen];		// typeface name, if DS_SETFONT is set
    }

    //Very important to pack 1
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    // ReSharper disable once InconsistentNaming
    // ReSharper disable once IdentifierTypo
    public struct DLGITEMTEMPLATEEX_API
    {
        public uint helpID;
        public uint exStyle;
        public uint style;
        public short x;
        public short y;
        public short cx;
        public short cy;
        public uint id;
        // Everything else in this structure is variable length,
        // and therefore must be determined dynamically

        // sz_Or_Ord windowClass;	// name or ordinal of a window class
        // sz_Or_Ord title;			// title string or ordinal of a resource
        // WORD extraCount;			// bytes following creation data
    }

    /*
       Packed 1;
       struct DLGTEMPLATEEX
       {
       	WORD dlgVer;
       	WORD signature;
       	DWORD helpID;
       	DWORD exStyle;
       	DWORD style;
       	WORD cDlgItems;
       	short x;
       	short y;
       	short cx;
       	short cy;
       
       	// Everything else in this structure is variable length,
       	// and therefore must be determined dynamically
       
       	// sz_Or_Ord menu;			// name or ordinal of a menu resource
       	// sz_Or_Ord windowClass;	// name or ordinal of a window class
       	// WCHAR title[titleLen];	// title string of the dialog box
       	// short pointsize;			// only if DS_SETFONT is set
       	// short weight;			// only if DS_SETFONT is set
       	// short bItalic;			// only if DS_SETFONT is set
       	// WCHAR font[fontLen];		// typeface name, if DS_SETFONT is set
       };
       struct DLGITEMTEMPLATEEX
       {
       	DWORD helpID;
       	DWORD exStyle;
       	DWORD style;
       	short x;
       	short y;
       	short cx;
       	short cy;
       	DWORD id;
       
       	// Everything else in this structure is variable length,
       	// and therefore must be determined dynamically
       
       	// sz_Or_Ord windowClass;	// name or ordinal of a window class
       	// sz_Or_Ord title;			// title string or ordinal of a resource
       	// WORD extraCount;			// bytes following creation data
       };
     */

    [StructLayout(LayoutKind.Sequential)]
    public struct DlgTemplate 
    {
    
        /// DWORD->unsigned int
        public uint style;
    
        /// DWORD->unsigned int
        public uint dwExtendedStyle;
    
        /// WORD->unsigned short
        public ushort cdit;
    
        /// short
        public short x;
    
        /// short
        public short y;
    
        /// short
        public short cx;
    
        /// short
        public short cy;
    }
}