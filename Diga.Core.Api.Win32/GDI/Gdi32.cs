using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Local

namespace Diga.Core.Api.Win32.GDI
{
    public static class Gdi32
    {
        private const string GDI32 = "gdi32.dll";
        private const CharSet CHARSET = CharSet.Auto;


        [DllImport(GDI32, EntryPoint = "AddFontResource", CharSet = CHARSET)]
        public static extern int AddFontResource([In] string param0);

        [DllImport(GDI32, EntryPoint = "AddFontResourceEx", CharSet = CHARSET)]
        public static extern int AddFontResourceEx([In] string name, uint fl, IntPtr res);

        [DllImport(GDI32, EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr ho);



        [DllImport(GDI32, EntryPoint = "AnimatePalette")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AnimatePalette(IntPtr hPal, uint iStartIndex, uint cEntries, ref PaletteEntry ppe);

        [DllImport(GDI32, EntryPoint = "Arc")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Arc(IntPtr hdc, int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4);


        [DllImport(GDI32, EntryPoint = "BitBlt")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BitBlt(IntPtr hdc, int x, int y, int cx, int cy, IntPtr hdcSrc, int x1, int y1, uint rop);



        [DllImport(GDI32, EntryPoint = "CancelDC")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CancelDC(IntPtr hdc);



        [DllImport(GDI32, EntryPoint = "Chord")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Chord(IntPtr hdc, int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4);


        [DllImport(GDI32, EntryPoint = "CombineRgn")]
        public static extern int CombineRgn(IntPtr hrgnDst, IntPtr hrgnSrc1, IntPtr hrgnSrc2, int iMode);


        [DllImport(GDI32, EntryPoint = "CreateBitmap")]
        public static extern IntPtr CreateBitmap(int nWidth, int nHeight, uint nPlanes, uint nBitCount, IntPtr lpBits);


        [DllImport(GDI32, EntryPoint = "CreateBitmapIndirect")]
        public static extern IntPtr CreateBitmapIndirect(ref Bitmap pbm);



        [DllImport(GDI32, EntryPoint = "CreateBrushIndirect")]
        public static extern IntPtr CreateBrushIndirect(ref LogBrush plbrush);


        [DllImport(GDI32, EntryPoint = "CreateCompatibleBitmap")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int cx, int cy);



        [DllImport(GDI32, EntryPoint = "CreateDiscardableBitmap")]
        public static extern IntPtr CreateDiscardableBitmap(IntPtr hdc, int cx, int cy);


        [DllImport(GDI32, EntryPoint = "CreateCompatibleDC")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);


        [DllImport(GDI32, EntryPoint = "CreateDC", CharSet = CHARSET)]
        public static extern IntPtr CreateDC([In] string pwszDriver, [In] string pwszDevice, [In] string pszPort, ref DevMode pdm);


        [DllImport(GDI32, EntryPoint = "CreateFontIndirect", CharSet = CHARSET)]
        public static extern IntPtr CreateFontIndirect([In] ref LogFont lplf);


        [DllImport(GDI32, EntryPoint = "CloseMetaFile")]
        public static extern IntPtr CloseMetaFile(IntPtr hdc);


        [DllImport(GDI32, EntryPoint = "CopyMetaFile", CharSet = CHARSET)]
        public static extern IntPtr CopyMetaFile(IntPtr param0, [In] string param1);


        [DllImport(GDI32, EntryPoint = "CreateDIBitmap")]
        public static extern IntPtr CreateDIBitmap(IntPtr hdc, ref BitmapInfoHeader pbmih, uint flInit, IntPtr pjBits, ref BitmapInfo pbmi, uint iUsage);

        [DllImport(GDI32, EntryPoint = "CreateDIBPatternBrushPt")]
        public static extern IntPtr CreateDIBPatternBrushPt(IntPtr lpPackedDIB, uint iUsage);


        [DllImport(GDI32, EntryPoint = "CreateEllipticRgn")]
        public static extern IntPtr CreateEllipticRgn(int x1, int y1, int x2, int y2);



        [DllImport(GDI32, EntryPoint = "CreateEllipticRgnIndirect")]
        public static extern IntPtr CreateEllipticRgnIndirect(ref Rect lprect);



        [DllImport(GDI32, EntryPoint = "CreateDIBPatternBrush")]
        public static extern IntPtr CreateDIBPatternBrush(IntPtr h, uint iUsage);




        [DllImport(GDI32, EntryPoint = "CreateFont", CharSet = CHARSET)]
        public static extern IntPtr CreateFont(int cHeight, int cWidth, int cEscapement, int cOrientation, int cWeight, uint bItalic, uint bUnderline, uint bStrikeOut, uint iCharSet, uint iOutPrecision, uint iClipPrecision, uint iQuality, uint iPitchAndFamily, [In] string pszFaceName);




        [DllImport(GDI32, EntryPoint = "CreateHatchBrush")]
        public static extern IntPtr CreateHatchBrush(int iHatch, uint color);


        [DllImport(GDI32, EntryPoint = "CreateIC", CharSet = CHARSET)]
        public static extern IntPtr CreateIC([In] string pszDriver, [In] string pszDevice, [In] string pszPort, ref DevMode pdm);



        [DllImport(GDI32, EntryPoint = "CreateMetaFile", CharSet = CHARSET)]
        public static extern IntPtr CreateMetaFile([In] string pszFile);


        [DllImport(GDI32, EntryPoint = "ChoosePixelFormat")]
        public static extern int ChoosePixelFormat(IntPtr hdc, ref PixelFormatDescriptor ppfd);

        [DllImport(GDI32, EntryPoint = "CreatePalette")]
        public static extern IntPtr CreatePalette(ref LogPalette plpal);

        [DllImport(GDI32, EntryPoint = "CreatePen")]
        public static extern IntPtr CreatePen(int iStyle, int cWidth, uint color);

        [DllImport(GDI32, EntryPoint = "CreatePenIndirect")]
        public static extern IntPtr CreatePenIndirect(ref LogPen plpen);

        [DllImport(GDI32, EntryPoint = "CreatePatternBrush")]
        public static extern IntPtr CreatePatternBrush(IntPtr hbm);


        [DllImport(GDI32, EntryPoint = "CreateRectRgn")]
        public static extern IntPtr CreateRectRgn(int x1, int y1, int x2, int y2);

        [DllImport(GDI32, EntryPoint = "CreateRectRgnIndirect")]
        public static extern IntPtr CreateRectRgnIndirect(ref Rect lprect);

        [DllImport(GDI32, EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(int x1, int y1, int x2, int y2, int w, int h);

        [DllImport(GDI32, EntryPoint = "CreateScalableFontResource", CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateScalableFontResource(uint fdwHidden, [In] string lpszFont, [In] string lpszFile, [In] string lpszPath);

        [DllImport(GDI32, EntryPoint = "CreateSolidBrush")]
        public static extern IntPtr CreateSolidBrush(uint color);



        [DllImport(GDI32, EntryPoint = "GetDeviceCaps")]
        public static extern int GetDeviceCaps([In] IntPtr hdc, int index);

        [DllImport(GDI32, EntryPoint = "DeleteDC")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteDC(IntPtr hdc);


        [DllImport(GDI32, EntryPoint = "DeleteMetaFile")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteMetaFile(IntPtr hmf);


        [DllImport(GDI32, EntryPoint = "Ellipse")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Ellipse(IntPtr hdc, int left, int top, int right, int bottom);


        [DllImport(GDI32, EntryPoint = "EnumFontFamiliesEx", CharSet = CHARSET)]
        public static extern int EnumFontFamiliesExW(IntPtr hdc, ref LogFont lpLogfont, OldFontEnumProc lpProc, [MarshalAs(UnmanagedType.SysInt)] int lParam, uint dwFlags);


        [DllImport(GDI32, EntryPoint = "EnumFontFamilies", CharSet = CHARSET)]
        public static extern int EnumFontFamilies(IntPtr hdc, [In] string lpLogfont, OldFontEnumProc lpProc, [MarshalAs(UnmanagedType.SysInt)] int lParam);


        [DllImport(GDI32, EntryPoint = "EnumFonts", CharSet = CHARSET)]
        public static extern int EnumFonts(IntPtr hdc, [In] string lpLogfont, OldFontEnumProc lpProc, [MarshalAs(UnmanagedType.SysInt)] int lParam);


        [DllImport(GDI32, EntryPoint = "EnumObjects")]
        public static extern int EnumObjects(IntPtr hdc, int nType, GObjEnumProc lpFunc, IntPtr lParam);

        [DllImport(GDI32, EntryPoint = "EqualRgn")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EqualRgn(IntPtr hrgn1, IntPtr hrgn2);


        [DllImport(GDI32, EntryPoint = "ExcludeClipRect")]
        public static extern int ExcludeClipRect(IntPtr hdc, int left, int top, int right, int bottom);

        [DllImport(GDI32, EntryPoint = "ExtFloodFill")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ExtFloodFill(IntPtr hdc, int x, int y, uint color, uint type);

        [DllImport(GDI32, EntryPoint = "FillRgn")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FillRgn(IntPtr hdc, IntPtr hrgn, IntPtr hbr);

        [DllImport(GDI32, EntryPoint = "FloodFill")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FloodFill(IntPtr hdc, int x, int y, uint color);

        [DllImport(GDI32, EntryPoint = "FrameRgn")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FrameRgn(IntPtr hdc, IntPtr hrgn, IntPtr hbr, int w, int h);

        [DllImport(GDI32, EntryPoint = "GetROP2")]
        public static extern int GetROP2(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "GetAspectRatioFilterEx")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetAspectRatioFilterEx(IntPtr hdc, ref Size lpsize);

        [DllImport(GDI32, EntryPoint = "GetBkColor")]
        public static extern uint GetBkColor(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "GetObject", CharSet = CHARSET, SetLastError = true)]
        public static extern int GetObject([In] IntPtr h, int c, IntPtr pv);


        [DllImport(GDI32, CharSet = CHARSET, SetLastError = true)]
        public static extern int GetObject(IntPtr hObject, int nSize, [In, Out] LogFont lf);

        public static int GetObject(IntPtr hObject, LogFont lp)
        {
            return GetObject(hObject, Marshal.SizeOf(typeof(LogFont)), lp);
        }

        [DllImport(GDI32, EntryPoint = "GetDCBrushColor")]
        public static extern uint GetDCBrushColor(IntPtr hdc);


        [DllImport(GDI32, EntryPoint = "GetDCPenColor")]
        public static extern uint GetDCPenColor(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "GetBkMode")]
        public static extern int GetBkMode(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "GetBitmapDimensionEx")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetBitmapDimensionEx(IntPtr hbit, ref Size lpsize);

        [DllImport(GDI32, EntryPoint = "GetBoundsRect")]
        public static extern uint GetBoundsRect(IntPtr hdc, ref Rect lprect, uint flags);

        [DllImport(GDI32, EntryPoint = "GetBrushOrgEx")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetBrushOrgEx(IntPtr hdc, ref Point lppt);

        [DllImport(GDI32, EntryPoint = "GetCharWidth", CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCharWidth(IntPtr hdc, uint iFirst, uint iLast, ref int lpBuffer);

        [DllImport(GDI32, EntryPoint = "GetCharWidthFloat", CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCharWidthFloat(IntPtr hdc, uint iFirst, uint iLast, ref float lpBuffer);

        [DllImport(GDI32, EntryPoint = "GetCharABCWidths", CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCharABCWidths(IntPtr hdc, uint wFirst, uint wLast, ref ABC lpABC);

        [DllImport(GDI32, EntryPoint = "GetCharABCWidthsFloat", CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCharABCWidthsFloat(IntPtr hdc, uint iFirst, uint iLast, ref ABCFloat lpABC);

        [DllImport(GDI32, EntryPoint = "GetClipBox")]
        public static extern int GetClipBox(IntPtr hdc, ref Rect lprect);

        [DllImport(GDI32, EntryPoint = "GetMetaRgn")]
        public static extern int GetMetaRgn(IntPtr hdc, IntPtr hrgn);

        [DllImport(GDI32, EntryPoint = "GetCurrentObject")]
        public static extern IntPtr GetCurrentObject(IntPtr hdc, uint type);

        [DllImport(GDI32, EntryPoint = "GetCurrentPositionEx")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCurrentPositionEx(IntPtr hdc, ref Point lppt);

        [DllImport(GDI32, EntryPoint = "GetDIBits")]
        public static extern int GetDIBits(IntPtr hdc, IntPtr hbm, uint start, uint cLines, IntPtr lpvBits, ref BitmapInfo lpbmi, uint usage);


        [DllImport(GDI32, EntryPoint = "GetFontData")]
        public static extern uint GetFontData(IntPtr hdc, uint dwTable, uint dwOffset, IntPtr pvBuffer, uint cjBuffer);

        [DllImport(GDI32, EntryPoint = "GetGlyphOutline", CharSet = CHARSET)]
        public static extern uint GetGlyphOutline(IntPtr hdc, uint uChar, uint fuFormat, ref GlypHMetrics lpgm, uint cjBuffer, IntPtr pvBuffer, ref Mat2 lpmat2);

        [DllImport(GDI32, EntryPoint = "GetGraphicsMode")]
        public static extern int GetGraphicsMode(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "GetMapMode")]
        public static extern int GetMapMode(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "GetMetaFileBitsEx")]
        public static extern uint GetMetaFileBitsEx(IntPtr hMF, uint cbBuffer, IntPtr lpData);

        [DllImport(GDI32, EntryPoint = "GetMetaFile", CharSet = CHARSET)]
        public static extern IntPtr GetMetaFile([In] string lpName);

        [DllImport(GDI32, EntryPoint = "GetNearestColor")]
        public static extern uint GetNearestColor(IntPtr hdc, uint color);

        [DllImport(GDI32, EntryPoint = "GetNearestPaletteIndex")]
        public static extern uint GetNearestPaletteIndex(IntPtr h, uint color);

        [DllImport(GDI32, EntryPoint = "GetObjectType")]
        public static extern uint GetObjectType(IntPtr h);


        [DllImport(GDI32, EntryPoint = "GetOutlineTextMetrics", CharSet = CHARSET)]
        public static extern uint GetOutlineTextMetrics(IntPtr hdc, uint cjCopy, ref OutlineTextMetric potm);

        [DllImport(GDI32, EntryPoint = "GetPaletteEntries")]
        public static extern uint GetPaletteEntries(IntPtr hpal, uint iStart, uint cEntries, ref PaletteEntry pPalEntries);

        [DllImport(GDI32, EntryPoint = "GetPixel")]
        public static extern uint GetPixel(IntPtr hdc, int x, int y);

        [DllImport(GDI32, EntryPoint = "GetPixelFormat")]
        public static extern int GetPixelFormat(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "GetPolyFillMode")]
        public static extern int GetPolyFillMode(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "GetRasterizerCaps")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetRasterizerCaps(ref RasterizerStatus lpraststat, uint cjBytes);

        [DllImport(GDI32, EntryPoint = "GetRandomRgn")]
        public static extern int GetRandomRgn(IntPtr hdc, IntPtr hrgn, int i);


        [DllImport(GDI32, EntryPoint = "GetRegionData")]
        public static extern uint GetRegionData(IntPtr hrgn, uint nCount, ref RgnData lpRgnData);

        [DllImport(GDI32, EntryPoint = "GetRgnBox")]
        public static extern int GetRgnBox(IntPtr hrgn, ref Rect lprc);

        [DllImport(GDI32, EntryPoint = "GetStockObject")]
        public static extern IntPtr GetStockObject(int i);

        [DllImport(GDI32, EntryPoint = "GetStretchBltMode")]
        public static extern int GetStretchBltMode(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "GetSystemPaletteEntries")]
        public static extern uint GetSystemPaletteEntries(IntPtr hdc, uint iStart, uint cEntries, ref PaletteEntry pPalEntries);

        [DllImport(GDI32, EntryPoint = "GetSystemPaletteUse")]
        public static extern uint GetSystemPaletteUse(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "GetTextCharacterExtra")]
        public static extern int GetTextCharacterExtra(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "GetTextAlign")]
        public static extern uint GetTextAlign(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "GetTextColor")]
        public static extern uint GetTextColor(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "GetTextExtentExPoint", CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetTextExtentExPointW(IntPtr hdc, [In] string lpszString, int cchString, int nMaxExtent, ref int lpnFit, ref int lpnDx, ref Size lpSize);

        [DllImport(GDI32, EntryPoint = "GetTextCharset")]
        public static extern int GetTextCharset(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "GetTextCharsetInfo")]
        public static extern int GetTextCharsetInfo(IntPtr hdc, ref FontSignature lpSig, uint dwFlags);

        [DllImport(GDI32, EntryPoint = "GetFontLanguageInfo")]
        public static extern uint GetFontLanguageInfo(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "GetFontUnicodeRanges")]
        public static extern uint GetFontUnicodeRanges(IntPtr hdc, ref GlyphSet lpgs);

        [DllImport(GDI32, EntryPoint = "GetCharWidthI")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCharWidthI(IntPtr hdc, uint giFirst, uint cgi, ref ushort pgi, ref int piWidths);

        [DllImport(GDI32, EntryPoint = "GetCharABCWidthsI")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCharABCWidthsI(IntPtr hdc, uint giFirst, uint cgi, ref ushort pgi, ref ABC pabc);

        [DllImport(GDI32, EntryPoint = "AddFontMemResourceEx")]
        public static extern IntPtr AddFontMemResourceEx(IntPtr pFileView, uint cjSize, IntPtr pvResrved, ref uint pNumFonts);
        [DllImport(GDI32, EntryPoint = "RemoveFontMemResourceEx")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RemoveFontMemResourceEx(IntPtr h);

        [DllImport(GDI32, EntryPoint = "CreateFontIndirectEx", CharSet = CHARSET)]
        public static extern IntPtr CreateFontIndirectEx(ref EnumLogFontExDv param0);

        [DllImport(GDI32, EntryPoint = "GetViewportExtEx")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetViewportExtEx(IntPtr hdc, ref Size lpsize);

        [DllImport(GDI32, EntryPoint = "GetViewportOrgEx")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetViewportOrgEx(IntPtr hdc, ref Point lppoint);

        [DllImport(GDI32, EntryPoint = "GetWindowExtEx")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowExtEx(IntPtr hdc, ref Size lpsize);

        [DllImport(GDI32, EntryPoint = "GetWindowOrgEx")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowOrgEx(IntPtr hdc, ref Point lppoint);

        [DllImport(GDI32, EntryPoint = "IntersectClipRect")]
        public static extern int IntersectClipRect(IntPtr hdc, int left, int top, int right, int bottom);

        [DllImport(GDI32, EntryPoint = "InvertRgn")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InvertRgn(IntPtr hdc, IntPtr hrgn);

        [DllImport(GDI32, EntryPoint = "LineDDA")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LineDDA(int xStart, int yStart, int xEnd, int yEnd, LineDDAProc lpProc, [MarshalAs(UnmanagedType.SysInt)] int data);

        [DllImport(GDI32, EntryPoint = "LineTo")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LineTo(IntPtr hdc, int x, int y);

        [DllImport(GDI32, EntryPoint = "MaskBlt")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MaskBlt(IntPtr hdcDest, int xDest, int yDest, int width, int height, IntPtr hdcSrc, int xSrc, int ySrc, IntPtr hbmMask, int xMask, int yMask, uint rop);

        [DllImport(GDI32, EntryPoint = "OffsetClipRgn")]
        public static extern int OffsetClipRgn(IntPtr hdc, int x, int y);

        [DllImport(GDI32, EntryPoint = "OffsetRgn")]
        public static extern int OffsetRgn(IntPtr hrgn, int x, int y);

        [DllImport(GDI32, EntryPoint = "PatBlt")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PatBlt(IntPtr hdc, int x, int y, int w, int h, uint rop);

        [DllImport(GDI32, EntryPoint = "Pie")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Pie(IntPtr hdc, int left, int top, int right, int bottom, int xr1, int yr1, int xr2, int yr2);

        [DllImport(GDI32, EntryPoint = "PlayMetaFile")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PlayMetaFile(IntPtr hdc, IntPtr hmf);

        [DllImport(GDI32, EntryPoint = "PaintRgn")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PaintRgn(IntPtr hdc, IntPtr hrgn);

        [DllImport(GDI32, EntryPoint = "PtInRegion")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PtInRegion(IntPtr hrgn, int x, int y);


        [DllImport(GDI32, EntryPoint = "PtVisible")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PtVisible(IntPtr hdc, int x, int y);

        [DllImport(GDI32, EntryPoint = "RectInRegion")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RectInRegion(IntPtr hrgn, ref Rect lprect);


        [DllImport(GDI32, EntryPoint = "RectVisible")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RectVisible(IntPtr hdc, ref Rect lprect);

        [DllImport(GDI32, EntryPoint = "Rectangle")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Rectangle(IntPtr hdc, int left, int top, int right, int bottom);

        [DllImport(GDI32, EntryPoint = "RestoreDC")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RestoreDC(IntPtr hdc, int nSavedDC);

        [DllImport(GDI32, EntryPoint = "ResetDC", CharSet = CHARSET)]
        public static extern IntPtr ResetDCW(IntPtr hdc, ref DevMode lpdm);

        [DllImport(GDI32, EntryPoint = "RealizePalette")]
        public static extern uint RealizePalette(IntPtr hdc);


        [DllImport(GDI32, EntryPoint = "RemoveFontResource", CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RemoveFontResource([In] string lpFileName);

        [DllImport(GDI32, EntryPoint = "RoundRect")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RoundRect(IntPtr hdc, int left, int top, int right, int bottom, int width, int height);

        [DllImport(GDI32, EntryPoint = "ResizePalette")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ResizePalette(IntPtr hpal, uint n);

        [DllImport(GDI32, EntryPoint = "SaveDC")]
        public static extern int SaveDC(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "SelectClipRgn")]
        public static extern int SelectClipRgn(IntPtr hdc, IntPtr hrgn);

        [DllImport(GDI32, EntryPoint = "ExtSelectClipRgn")]
        public static extern int ExtSelectClipRgn(IntPtr hdc, IntPtr hrgn, int mode);

        [DllImport(GDI32, EntryPoint = "SetMetaRgn")]
        public static extern int SetMetaRgn(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "SelectObject")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr h);

        [DllImport(GDI32, EntryPoint = "SelectPalette")]
        public static extern IntPtr SelectPalette(IntPtr hdc, IntPtr hPal, [MarshalAs(UnmanagedType.Bool)] bool bForceBkgd);

        [DllImport(GDI32, EntryPoint = "SetBkColor")]
        public static extern uint SetBkColor(IntPtr hdc, uint color);

        [DllImport(GDI32, EntryPoint = "SetDCBrushColor")]
        public static extern uint SetDCBrushColor(IntPtr hdc, uint color);

        [DllImport(GDI32, EntryPoint = "SetDCPenColor")]
        public static extern uint SetDCPenColor(IntPtr hdc, uint color);

        [DllImport(GDI32, EntryPoint = "SetBkMode")]
        public static extern int SetBkMode(IntPtr hdc, int mode);


        [DllImport(GDI32, EntryPoint = "SetBoundsRect")]
        public static extern uint SetBoundsRect(IntPtr hdc, ref Rect lprect, uint flags);

        [DllImport(GDI32, EntryPoint = "SetDIBits")]
        public static extern int SetDIBits(IntPtr hdc, IntPtr hbm, uint start, uint cLines, IntPtr lpBits, ref BitmapInfo lpbmi, uint ColorUse);

        [DllImport(GDI32, EntryPoint = "SetDIBitsToDevice")]
        public static extern int SetDIBitsToDevice(IntPtr hdc, int xDest, int yDest, uint w, uint h, int xSrc, int ySrc, uint StartScan, uint cLines, IntPtr lpvBits, ref BitmapInfo lpbmi, uint ColorUse);

        [DllImport(GDI32, EntryPoint = "SetMapperFlags")]
        public static extern uint SetMapperFlags(IntPtr hdc, uint flags);

        [DllImport(GDI32, EntryPoint = "SetGraphicsMode")]
        public static extern int SetGraphicsMode(IntPtr hdc, int iMode);

        [DllImport(GDI32, EntryPoint = "SetMapMode")]
        public static extern int SetMapMode(IntPtr hdc, int iMode);

        [DllImport(GDI32, EntryPoint = "SetLayout")]
        public static extern uint SetLayout(IntPtr hdc, uint l);

        [DllImport(GDI32, EntryPoint = "GetLayout")]
        public static extern uint GetLayout(IntPtr hdc);


        [DllImport(GDI32, EntryPoint = "SetPaletteEntries")]
        public static extern uint SetPaletteEntries(IntPtr hpal, uint iStart, uint cEntries, ref PaletteEntry pPalEntries);

        [DllImport(GDI32, EntryPoint = "SetPixel")]
        public static extern uint SetPixel(IntPtr hdc, int x, int y, uint color);


        [DllImport(GDI32, EntryPoint = "SetPixelV")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetPixelV(IntPtr hdc, int x, int y, uint color);


        [DllImport(GDI32, EntryPoint = "SetPixelFormat")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetPixelFormat(IntPtr hdc, int format, ref PixelFormatDescriptor ppfd);

        [DllImport(GDI32, EntryPoint = "SetPolyFillMode")]
        public static extern int SetPolyFillMode(IntPtr hdc, int mode);


        [DllImport(GDI32, EntryPoint = "StretchBlt")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool StretchBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSrc, int xSrc, int ySrc, int wSrc, int hSrc, uint rop);

        [DllImport(GDI32, EntryPoint = "SetRectRgn")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetRectRgn(IntPtr hrgn, int left, int top, int right, int bottom);

        [DllImport(GDI32, EntryPoint = "StretchDIBits")]
        public static extern int StretchDIBits(IntPtr hdc, int xDest, int yDest, int DestWidth, int DestHeight, int xSrc, int ySrc, int SrcWidth, int SrcHeight, IntPtr lpBits, ref BitmapInfo lpbmi, uint iUsage, uint rop);

        [DllImport(GDI32, EntryPoint = "SetROP2")]
        public static extern int SetROP2(IntPtr hdc, int rop2);


        [DllImport(GDI32, EntryPoint = "SetStretchBltMode")]
        public static extern int SetStretchBltMode(IntPtr hdc, int mode);

        [DllImport(GDI32, EntryPoint = "SetSystemPaletteUse")]
        public static extern uint SetSystemPaletteUse(IntPtr hdc, uint use);


        [DllImport(GDI32, EntryPoint = "SetTextCharacterExtra")]
        public static extern int SetTextCharacterExtra(IntPtr hdc, int extra);

        [DllImport(GDI32, EntryPoint = "SetTextColor")]
        public static extern uint SetTextColor(IntPtr hdc, uint color);

        [DllImport(GDI32, EntryPoint = "SetTextAlign")]
        public static extern uint SetTextAlign(IntPtr hdc, uint align);


        [DllImport(GDI32, EntryPoint = "SetTextJustification")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetTextJustification(IntPtr hdc, int extra, int count);

        [DllImport(GDI32, EntryPoint = "UpdateColors")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UpdateColors(IntPtr hdc);


        [DllImport(GDI32, EntryPoint = "GdiAlphaBlend")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GdiAlphaBlend(IntPtr hdcDest, int xoriginDest, int yoriginDest, int wDest, int hDest, IntPtr hdcSrc, int xoriginSrc, int yoriginSrc, int wSrc, int hSrc, BlendFunction ftn);

        [DllImport(GDI32, EntryPoint = "GdiTransparentBlt")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GdiTransparentBlt(IntPtr hdcDest, int xoriginDest, int yoriginDest, int wDest, int hDest, IntPtr hdcSrc, int xoriginSrc, int yoriginSrc, int wSrc, int hSrc, uint crTransparent);


        [DllImport(GDI32, EntryPoint = "EnumMetaFile")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumMetaFile(IntPtr hdc, IntPtr hmf, MfEnumProc proc, [MarshalAs(UnmanagedType.SysInt)] int param);

        [DllImport(GDI32, EntryPoint = "CloseEnhMetaFile")]
        public static extern IntPtr CloseEnhMetaFile(IntPtr hdc);


        [DllImport(GDI32, EntryPoint = "CopyEnhMetaFile", CharSet = CHARSET)]
        public static extern IntPtr CopyEnhMetaFileW(IntPtr hEnh, [In] string lpFileName);

        [DllImport(GDI32, EntryPoint = "CreateEnhMetaFile", CharSet = CHARSET)]
        public static extern IntPtr CreateEnhMetaFile(IntPtr hdc, [In] string lpFilename, ref Rect lprc, [In] string lpDesc);

        [DllImport(GDI32, EntryPoint = "DeleteEnhMetaFile")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteEnhMetaFile(IntPtr hmf);


        [DllImport(GDI32, EntryPoint = "EnumEnhMetaFile")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumEnhMetaFile(IntPtr hdc, IntPtr hmf, EnhMfEnumProc proc, IntPtr param, ref Rect lpRect);


        [DllImport(GDI32, EntryPoint = "GetEnhMetaFile", CharSet = CHARSET)]
        public static extern IntPtr GetEnhMetaFile([In] string lpName);


        [DllImport(GDI32, EntryPoint = "GetEnhMetaFilePaletteEntries")]
        public static extern uint GetEnhMetaFilePaletteEntries(IntPtr hemf, uint nNumEntries, ref PaletteEntry lpPaletteEntries);
        [DllImport(GDI32, EntryPoint = "GetEnhMetaFilePixelFormat")]
        public static extern uint GetEnhMetaFilePixelFormat(IntPtr hemf, uint cbBuffer, ref PixelFormatDescriptor ppfd);

        [DllImport(GDI32, EntryPoint = "PlayEnhMetaFile")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PlayEnhMetaFile(IntPtr hdc, IntPtr hmf, ref Rect lprect);

        [DllImport(GDI32, EntryPoint = "SetEnhMetaFileBits")]
        public static extern IntPtr SetEnhMetaFileBits(uint nSize, ref byte pb);

        [DllImport(GDI32, EntryPoint = "SetWinMetaFileBits")]
        public static extern IntPtr SetWinMetaFileBits(uint nSize, [In] IntPtr lpMeta16Data, [In] IntPtr hdcRef, [In] IntPtr lpMFP);


        [DllImport(GDI32, EntryPoint = "SetWinMetaFileBits")]
        public static extern IntPtr SetWinMetaFileBits(uint nSize, [In] byte[] lpMeta16Data, IntPtr hdcRef, ref MetaFilePict lpMFP);

        [DllImport(GDI32, EntryPoint = "GdiComment")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GdiComment(IntPtr hdc, uint nSize, ref byte lpData);

        [DllImport(GDI32, EntryPoint = "GdiComment")]
        [return: MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool GdiComment([In] IntPtr hdc, uint nSize, [In] IntPtr lpData);


        [DllImport(GDI32, EntryPoint = "GetTextMetrics", CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetTextMetrics(IntPtr hdc, ref TextMetric lptm);

        [DllImport(GDI32, EntryPoint = "AngleArc")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AngleArc(IntPtr hdc, int x, int y, uint r, float StartAngle, float SweepAngle);


        [DllImport(GDI32, EntryPoint = "GetWorldTransform")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWorldTransform(IntPtr hdc, ref XForm lpxf);

        [DllImport(GDI32, EntryPoint = "SetWorldTransform")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWorldTransform(IntPtr hdc, ref XForm lpxf);

        [DllImport(GDI32, EntryPoint = "ModifyWorldTransform")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ModifyWorldTransform(IntPtr hdc, ref XForm lpxf, uint mode);

        [DllImport(GDI32, EntryPoint = "CombineTransform")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CombineTransform(ref XForm lpxfOut, ref XForm lpxf1, ref XForm lpxf2);


        [DllImport(GDI32, EntryPoint = "GetDIBColorTable")]
        public static extern uint GetDIBColorTable(IntPtr hdc, uint iStart, uint cEntries, ref RgbQuad prgbq);

        [DllImport(GDI32, EntryPoint = "SetDIBColorTable")]
        public static extern uint SetDIBColorTable(IntPtr hdc, uint iStart, uint cEntries, ref RgbQuad prgbq);

        [DllImport(GDI32, EntryPoint = "SetColorAdjustment")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetColorAdjustment(IntPtr hdc, ref ColorAdjustment lpca);


        [DllImport(GDI32, EntryPoint = "GetColorAdjustment")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetColorAdjustment(IntPtr hdc, ref ColorAdjustment lpca);

        [DllImport(GDI32, EntryPoint = "CreateHalftonePalette")]
        public static extern IntPtr CreateHalftonePalette(IntPtr hdc);


        [DllImport(GDI32, EntryPoint = "StartDoc", CharSet = CHARSET)]
        public static extern int StartDocW(IntPtr hdc, ref DocInfo lpdi);

        [DllImport(GDI32, EntryPoint = "EndDoc")]
        public static extern int EndDoc(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "StartPage")]
        public static extern int StartPage(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "EndPage")]
        public static extern int EndPage(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "AbortDoc")]
        public static extern int AbortDoc(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "SetAbortProc")]
        public static extern int SetAbortProc(IntPtr hdc, AbortProc proc);

        [DllImport(GDI32, EntryPoint = "AbortPath")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AbortPath(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "ArcTo")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ArcTo(IntPtr hdc, int left, int top, int right, int bottom, int xr1, int yr1, int xr2, int yr2);

        [DllImport(GDI32, EntryPoint = "BeginPath")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BeginPath(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "CloseFigure")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseFigure(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "EndPath")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EndPath(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "FillPath")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FillPath(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "FlattenPath")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FlattenPath(IntPtr hdc);


        [DllImport(GDI32, EntryPoint = "PathToRegion")]
        public static extern IntPtr PathToRegion(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "SelectClipPath")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SelectClipPath(IntPtr hdc, int mode);

        [DllImport(GDI32, EntryPoint = "SetArcDirection")]
        public static extern int SetArcDirection(IntPtr hdc, int dir);

        [DllImport(GDI32, EntryPoint = "SetMiterLimit")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetMiterLimit(IntPtr hdc, float limit, ref float old);

        [DllImport(GDI32, EntryPoint = "StrokeAndFillPath")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool StrokeAndFillPath(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "StrokePath")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool StrokePath(IntPtr hdc);


        [DllImport(GDI32, EntryPoint = "WidenPath")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WidenPath(IntPtr hdc);

        [DllImport(GDI32, EntryPoint = "CreateSolidBrush", SetLastError = true)]
        public static extern IntPtr CreateSolidBrush(int crColor);


        [DllImport(GDI32, EntryPoint = "SetBkColor", SetLastError = true)]
        public static extern uint SetBkColor(IntPtr hdc, int crColor);

        [DllImport(GDI32, EntryPoint = "SetTextColor", SetLastError = true)]
        public static extern uint SetTextColor(IntPtr hdc, int crColor);

        [DllImport(GDI32, EntryPoint = "GetStockObject", SetLastError = true)]
        public static extern IntPtr GetStockObject(StockObjects fnObject);

        [DllImport(GDI32, EntryPoint = "RemoveFontResourceEx", CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RemoveFontResourceEx([In] string name, uint fl, IntPtr pdv);



        public static int RGB(int r, int g, int b) => checked(checked(checked(b * 65536) + checked(g * 256)) + r);

        public static byte GetRValue(uint rgb)
        {
            return Win32Api.LoByte((ushort) rgb);
        }

        public static byte GetGValue(uint rgb)
        {
            ushort v = (ushort)((ushort) rgb >> 8);
            return Win32Api.LoByte(v);
        }

        public static byte GetBValue(uint rgb)
        {
            ushort v = (ushort) (rgb >> 16);
            return Win32Api.LoByte(v);
        }
    }



}


