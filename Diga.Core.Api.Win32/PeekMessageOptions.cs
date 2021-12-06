using System;

namespace Diga.Core.Api.Win32
{
    [Flags]
    public enum PeekMessageOptions:uint
    {
        NoRemove = 0x0000,
        Remove = 0x0001,
        NoYield = 0x0002
    }
}