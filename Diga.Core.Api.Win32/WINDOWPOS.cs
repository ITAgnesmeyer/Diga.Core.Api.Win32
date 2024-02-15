using System;
using System.Runtime.InteropServices;

// ReSharper disable IdentifierTypo

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPOS
    {

        /// HWND->HWND__*
        public IntPtr hwnd;

        /// HWND->HWND__*
        public IntPtr hwndInsertAfter;

        /// int
        public int x;

        /// int
        public int y;

        /// int
        public int cx;

        /// int
        public int cy;

        /// UINT->unsigned int
        public uint flags;
    }
}