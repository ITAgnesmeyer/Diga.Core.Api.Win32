﻿using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Auto)]
    public delegate int OldFontEnumProc(ref LogFont param0, ref TextMetric param1, uint param2, IntPtr param3);
}