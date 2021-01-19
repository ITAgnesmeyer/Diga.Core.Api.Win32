using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.GDI
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LogPalette
    {

        /// WORD->unsigned short
        public ushort palVersion;

        /// WORD->unsigned short
        public ushort palNumEntries;

        /// PALETTEENTRY[1]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.Struct)]
        public PaletteEntry[] palPalEntry;
    }
}