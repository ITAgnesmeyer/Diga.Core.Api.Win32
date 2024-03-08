using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Local

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHSTOCKICONINFO
    {

        /// DWORD->unsigned int
        public uint cbSize;

        /// HICON->HICON__*
        public IntPtr hIcon;

        /// int
        public int iSysImageIndex;

        /// int
        public int iIcon;

        /// WCHAR[260]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szPath;
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