using System;

namespace Diga.Core.Api.Win32
{
    [Flags]
    public enum PeekMessageFlag : uint
    {
        PM_NOREMOVE =0x0000,
        PM_NOYIELD = 0x0002,
        PM_REMOVE = 0x0001

    }
}