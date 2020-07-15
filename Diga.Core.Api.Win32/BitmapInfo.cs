using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BitmapInfo
    {

        /// BITMAPINFOHEADER->tagBITMAPINFOHEADER
        public BitmapInfoHeader bmiHeader;

        /// RGBQUAD[1]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.Struct)]
        public RgbQuad[] bmiColors;
    }
}