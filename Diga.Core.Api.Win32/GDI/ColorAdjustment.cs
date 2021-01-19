using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.GDI
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ColorAdjustment
    {

        /// WORD->unsigned short
        public ushort caSize;

        /// WORD->unsigned short
        public ushort caFlags;

        /// WORD->unsigned short
        public ushort caIlluminantIndex;

        /// WORD->unsigned short
        public ushort caRedGamma;

        /// WORD->unsigned short
        public ushort caGreenGamma;

        /// WORD->unsigned short
        public ushort caBlueGamma;

        /// WORD->unsigned short
        public ushort caReferenceBlack;

        /// WORD->unsigned short
        public ushort caReferenceWhite;

        /// SHORT->short
        public short caContrast;

        /// SHORT->short
        public short caBrightness;

        /// SHORT->short
        public short caColorfulness;

        /// SHORT->short
        public short caRedGreenTint;
    }
}