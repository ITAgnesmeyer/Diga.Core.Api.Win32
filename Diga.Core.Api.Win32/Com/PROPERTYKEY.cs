using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32.Com
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct PROPERTYKEY
    {
        internal Guid fmtid;
        internal uint pid;
    }
}