using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WindowPlacement
    {
        public uint length;

        public uint flags;

        public uint showCmd;

        public Point ptMinPosition;

        public Point ptMaxPosition;

        public Rect rcNormalPosition;
    }
}