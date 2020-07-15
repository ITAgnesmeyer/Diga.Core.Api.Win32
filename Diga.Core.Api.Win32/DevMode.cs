using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct DevMode
    {

        /// WCHAR[32]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string dmDeviceName;

        /// WORD->unsigned short
        public ushort dmSpecVersion;

        /// WORD->unsigned short
        public ushort dmDriverVersion;

        /// WORD->unsigned short
        public ushort dmSize;

        /// WORD->unsigned short
        public ushort dmDriverExtra;

        /// DWORD->unsigned int
        public uint dmFields;

        /// Anonymous_7a7460d9_d99f_4e9a_9ebb_cdd10c08463d
        public DevModeUnion1 Union1;

        /// short
        public short dmColor;

        /// short
        public short dmDuplex;

        /// short
        public short dmYResolution;

        /// short
        public short dmTTOption;

        /// short
        public short dmCollate;

        /// WCHAR[32]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string dmFormName;

        /// WORD->unsigned short
        public ushort dmLogPixels;

        /// DWORD->unsigned int
        public uint dmBitsPerPel;

        /// DWORD->unsigned int
        public uint dmPelsWidth;

        /// DWORD->unsigned int
        public uint dmPelsHeight;

        /// Anonymous_084dbe97_5806_4c28_a299_ed6037f61d90
        public DevModeUnion2 Union2;

        /// DWORD->unsigned int
        public uint dmDisplayFrequency;

        /// DWORD->unsigned int
        public uint dmICMMethod;

        /// DWORD->unsigned int
        public uint dmICMIntent;

        /// DWORD->unsigned int
        public uint dmMediaType;

        /// DWORD->unsigned int
        public uint dmDitherType;

        /// DWORD->unsigned int
        public uint dmReserved1;

        /// DWORD->unsigned int
        public uint dmReserved2;

        /// DWORD->unsigned int
        public uint dmPanningWidth;

        /// DWORD->unsigned int
        public uint dmPanningHeight;
    }
}