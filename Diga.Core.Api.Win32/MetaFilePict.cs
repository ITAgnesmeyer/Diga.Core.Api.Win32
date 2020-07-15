using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MetaFilePict
    {

        /// LONG->int
        public int mm;

        /// LONG->int
        public int xExt;

        /// LONG->int
        public int yExt;

        /// HMETAFILE->HMETAFILE__*
        public IntPtr hMF;
    }
}