﻿namespace Diga.Core.Api.Win32.Com
{
    public enum MKSYS:int 
    {
        MKSYS_NONE = 0,
        MKSYS_GENERICCOMPOSITE = 1,
        MKSYS_FILEMONIKER = 2,
        MKSYS_ANTIMONIKER = 3,
        MKSYS_ITEMMONIKER = 4,
        MKSYS_POINTERMONIKER = 5,
        MKSYS_CLASSMONIKER = 7,
        MKSYS_OBJREFMONIKER = 8,
        MKSYS_SESSIONMONIKER = 9,
        MKSYS_LUAMONIKER = 10
    }
}