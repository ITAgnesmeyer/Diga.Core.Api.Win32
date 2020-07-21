using System;

namespace Diga.Core.Api.Win32
{
    public static class ResourceTypes
    {
        private const int DIFFERENCE = 11;
        public const int RT_CURSOR_ID = 1;
        public const int RT_BITMAP_ID = 2;
        public const int RT_ICON_ID = 3;
        public const int RT_MENU_ID = 4;
        public const int RT_DIALOG_ID = 5;
        public const int RT_STRING_ID = 6;
        public const int RT_FONTDIR_ID = 7;
        public const int RT_FONT_ID = 8;
        public const int RT_ACCELERATOR_ID = 9;
        public const int RT_RCDATA_ID = 10;
        public const int RT_MESSAGETABLE_ID = 11;
        public const int RT_GROUP_CURSOR_ID = RT_CURSOR_ID + DIFFERENCE;
        public const int RT_GROUP_ICON_ID = RT_ICON_ID + DIFFERENCE;
        public const int RT_VERSION_ID = 16;
        public const int RT_DLGINCLUDE_ID = 17;
        public const int RT_PLUGPLAY_ID = 19;
        public const int RT_VXD_ID = 20;
        public const int RT_ANICURSOR_ID = 21;
        public const int RT_ANIICON_ID = 22;
        public const int RT_HTML_ID = 23;
        public const int RT_MANIFEST_ID = 24;
        public static IntPtr RT_CURSOR = Win32Api.MakeInterSource(RT_CURSOR_ID);
        public static IntPtr RT_BITMAP = Win32Api.MakeInterSource(RT_BITMAP_ID);
        public static IntPtr RT_ICON = Win32Api.MakeInterSource(RT_ICON_ID);
        public static IntPtr RT_MENU = Win32Api.MakeInterSource(RT_MENU_ID);
        public static IntPtr RT_DIALOG = Win32Api.MakeInterSource(RT_DIALOG_ID);
        public static IntPtr RT_STRING = Win32Api.MakeInterSource(RT_STRING_ID);
        public static IntPtr RT_FONTDIR = Win32Api.MakeInterSource(RT_FONTDIR_ID);
        public static IntPtr RT_FONT = Win32Api.MakeInterSource(RT_FONT_ID);
        public static IntPtr RT_ACCELERATOR = Win32Api.MakeInterSource(RT_ACCELERATOR_ID);
        public static IntPtr RT_RCDATA = Win32Api.MakeInterSource(RT_RCDATA_ID);
        public static IntPtr RT_MESSAGETABLE = Win32Api.MakeInterSource(RT_MESSAGETABLE_ID);
        public static IntPtr RT_GROUP_CURSOR = Win32Api.MakeInterSource(RT_GROUP_CURSOR_ID);
        public static IntPtr RT_GROUP_ICON = Win32Api.MakeInterSource(RT_GROUP_ICON_ID);
        public static IntPtr RT_VERSION = Win32Api.MakeInterSource(RT_VERSION_ID);
        public static IntPtr RT_DLGINCLUDE = Win32Api.MakeInterSource(RT_DLGINCLUDE_ID);
        public static IntPtr RT_PLUGPLAY = Win32Api.MakeInterSource(RT_PLUGPLAY_ID);
        public static IntPtr RT_VXD = Win32Api.MakeInterSource(RT_VXD_ID);
        public static IntPtr RT_ANICURSOR = Win32Api.MakeInterSource(RT_ANICURSOR_ID);
        public static IntPtr RT_ANIICON = Win32Api.MakeInterSource(RT_ANIICON_ID);
        public static IntPtr RT_HTML = Win32Api.MakeInterSource(RT_HTML_ID);
        public static IntPtr RT_MANIFEST = Win32Api.MakeInterSource(RT_MANIFEST_ID);
        public static IntPtr CREATEPROCESS_MANIFEST_RESOURCE_ID = Win32Api.MakeInterSource(1);
        public static IntPtr ISOLATIONAWARE_MANIFEST_RESOURCE_ID = Win32Api.MakeInterSource(2);
        public static IntPtr ISOLATIONAWARE_NOSTATICIMPORT_MANIFEST_RESOURCE_ID = Win32Api.MakeInterSource(3);
        public static IntPtr MINIMUM_RESERVED_MANIFEST_RESOURCE_ID = Win32Api.MakeInterSource(1);
        public static IntPtr MAXIMUM_RESERVED_MANIFEST_RESOURCE_ID = Win32Api.MakeInterSource(16);

    }
}