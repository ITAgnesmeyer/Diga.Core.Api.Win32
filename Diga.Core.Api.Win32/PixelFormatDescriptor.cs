using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PixelFormatDescriptor
    {

        /// WORD->unsigned short
        public ushort nSize;

        /// WORD->unsigned short
        public ushort nVersion;

        /// DWORD->unsigned int
        public uint dwFlags;

        /// BYTE->unsigned char
        public byte iPixelType;

        /// BYTE->unsigned char
        public byte cColorBits;

        /// BYTE->unsigned char
        public byte cRedBits;

        /// BYTE->unsigned char
        public byte cRedShift;

        /// BYTE->unsigned char
        public byte cGreenBits;

        /// BYTE->unsigned char
        public byte cGreenShift;

        /// BYTE->unsigned char
        public byte cBlueBits;

        /// BYTE->unsigned char
        public byte cBlueShift;

        /// BYTE->unsigned char
        public byte cAlphaBits;

        /// BYTE->unsigned char
        public byte cAlphaShift;

        /// BYTE->unsigned char
        public byte cAccumBits;

        /// BYTE->unsigned char
        public byte cAccumRedBits;

        /// BYTE->unsigned char
        public byte cAccumGreenBits;

        /// BYTE->unsigned char
        public byte cAccumBlueBits;

        /// BYTE->unsigned char
        public byte cAccumAlphaBits;

        /// BYTE->unsigned char
        public byte cDepthBits;

        /// BYTE->unsigned char
        public byte cStencilBits;

        /// BYTE->unsigned char
        public byte cAuxBuffers;

        /// BYTE->unsigned char
        public byte iLayerType;

        /// BYTE->unsigned char
        public byte bReserved;

        /// DWORD->unsigned int
        public uint dwLayerMask;

        /// DWORD->unsigned int
        public uint dwVisibleMask;

        /// DWORD->unsigned int
        public uint dwDamageMask;
    }
}