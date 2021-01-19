using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.GDI
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct OutlineTextMetric
    {

        /// UINT->unsigned int
        public uint otmSize;

        /// TEXTMETRICW->tagTEXTMETRICW
        public TextMetric otmTextMetrics;

        /// BYTE->unsigned char
        public byte otmFiller;

        /// PANOSE->tagPANOSE
        public PanOse otmPanoseNumber;

        /// UINT->unsigned int
        public uint otmfsSelection;

        /// UINT->unsigned int
        public uint otmfsType;

        /// int
        public int otmsCharSlopeRise;

        /// int
        public int otmsCharSlopeRun;

        /// int
        public int otmItalicAngle;

        /// UINT->unsigned int
        public uint otmEMSquare;

        /// int
        public int otmAscent;

        /// int
        public int otmDescent;

        /// UINT->unsigned int
        public uint otmLineGap;

        /// UINT->unsigned int
        public uint otmsCapEmHeight;

        /// UINT->unsigned int
        public uint otmsXHeight;

        /// RECT->tagRECT
        public Rect otmrcFontBox;

        /// int
        public int otmMacAscent;

        /// int
        public int otmMacDescent;

        /// UINT->unsigned int
        public uint otmMacLineGap;

        /// UINT->unsigned int
        public uint otmusMinimumPPEM;

        /// POINT->tagPOINT
        public Point otmptSubscriptSize;

        /// POINT->tagPOINT
        public Point otmptSubscriptOffset;

        /// POINT->tagPOINT
        public Point otmptSuperscriptSize;

        /// POINT->tagPOINT
        public Point otmptSuperscriptOffset;

        /// UINT->unsigned int
        public uint otmsStrikeoutSize;

        /// int
        public int otmsStrikeoutPosition;

        /// int
        public int otmsUnderscoreSize;

        /// int
        public int otmsUnderscorePosition;

        /// PSTR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string otmpFamilyName;

        /// PSTR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string otmpFaceName;

        /// PSTR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string otmpStyleName;

        /// PSTR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string otmpFullName;
    }
}