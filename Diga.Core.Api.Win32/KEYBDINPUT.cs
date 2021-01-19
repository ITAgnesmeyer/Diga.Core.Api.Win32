using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct KEYBDINPUT
    {

        /// WORD->unsigned short
        public ushort wVk;

        /// WORD->unsigned short
        public ushort wScan;

        /// DWORD->unsigned int
        public uint dwFlags;

        /// DWORD->unsigned int
        public uint time;

        /// ULONG_PTR->unsigned int
        public uint dwExtraInfo;
    }
}