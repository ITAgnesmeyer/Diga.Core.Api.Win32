
using Diga.Core.Api.Win32.Tools;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Com
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct GUID
    {

        /// unsigned int
        public uint Data1;

        /// unsigned short
        public ushort Data2;

        /// unsigned short
        public ushort Data3;

        /// unsigned char[8]
        //[System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 8,ArraySubType = UnmanagedType.U1)]
        public byte Data4_0;
        public byte Data4_1;
        public byte Data4_2;
        public byte Data4_3;
        public byte Data4_4;
        public byte Data4_5;
        public byte Data4_6;
        public byte Data4_7;
    }
}