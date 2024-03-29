﻿using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Local

namespace Diga.Core.Api.Win32
{



    public class SHGetInfoFlags
    {
        public const uint SHGFI_ICON = 0x000000100;// get icon
        public const uint SHGFI_DISPLAYNAME = 0x000000200;// get display name
        public const uint SHGFI_TYPENAME = 0x000000400;// get type name
        public const uint SHGFI_ATTRIBUTES = 0x000000800;// get attributes
        public const uint SHGFI_ICONLOCATION = 0x000001000;// get icon location
        public const uint SHGFI_EXETYPE = 0x000002000;// return exe type
        public const uint SHGFI_SYSICONINDEX = 0x000004000;// get system icon index
        public const uint SHGFI_LINKOVERLAY = 0x000008000;// put a link overlay on icon
        public const uint SHGFI_SELECTED = 0x000010000;// show icon in selected state
        public const uint SHGFI_ATTR_SPECIFIED = 0x000020000;// get only specified attributes
        public const uint SHGFI_LARGEICON = 0x000000000;// get large icon
        public const uint SHGFI_SMALLICON = 0x000000001;// get small icon
        public const uint SHGFI_OPENICON = 0x000000002;// get open icon
        public const uint SHGFI_SHELLICONSIZE = 0x000000004;// get shell size icon
        public const uint SHGFI_PIDL = 0x000000008;// pszPath is a pidl
        public const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;// use passed dwFileAttribute
        public const uint SHGFI_ADDOVERLAYS = 0x000000020;// apply the appropriate overlays
        public const uint SHGFI_OVERLAYINDEX = 0x000000040;// Get the index of the overlay
        public const uint SHGSI_ICONLOCATION = 0;// you always get the icon location
        public const uint SHGSI_ICON = SHGFI_ICON;
        public const uint SHGSI_SYSICONINDEX = SHGFI_SYSICONINDEX;
        public const uint SHGSI_LINKOVERLAY = SHGFI_LINKOVERLAY;
        public const uint SHGSI_SELECTED = SHGFI_SELECTED;
        public const uint SHGSI_LARGEICON = SHGFI_LARGEICON;
        public const uint SHGSI_SMALLICON = SHGFI_SMALLICON;
        public const uint SHGSI_SHELLICONSIZE = SHGFI_SHELLICONSIZE;
    }
    //public class StdIconsIds
    //{
    //    public const uint IDI_APPLICATION = 32512;
    //    public const uint IDI_HAND = 32513;
    //    public const uint IDI_QUESTION = 32514;
    //    public const uint IDI_EXCLAMATION = 32515;
    //    public const uint IDI_ASTERISK = 32516;
    //    public const uint IDI_WINLOGO = 32517;
    //    public const uint IDI_SHIELD = 32518;
    //    public const uint IDI_WARNING = IDI_EXCLAMATION;
    //    public const uint IDI_ERROR = IDI_HAND;
    //    public const uint IDI_INFORMATION = IDI_ASTERISK;
    //}
}