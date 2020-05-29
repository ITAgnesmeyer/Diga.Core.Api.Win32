﻿using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    public static class Ole32
    {
        // ReSharper disable InconsistentNaming
        private const string OLE32 = "ole32.dll";
        // ReSharper restore InconsistentNaming

        ///pvReserved: LPVOID->void*
        [DllImport(OLE32, EntryPoint = "OleInitialize", CallingConvention = CallingConvention.StdCall)]
        public static extern int OleInitialize(IntPtr pvReserved);

        /// Return Type: void
        [DllImport(OLE32, EntryPoint = "OleUninitialize", CallingConvention = CallingConvention.StdCall)]
        public static extern void OleUninitialize();


    }
}