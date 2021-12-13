using System;

namespace Diga.Core.Api.Win32.Com
{
    [Flags]
    public enum DispatchCallType : int
    {
        DISPATCH_METHOD = 0x1,
        DISPATCH_PROPERTYGET = 0x2,
        DISPATCH_PROPERTYPUT = 0x4,
        DISPATCH_PROPERTYPUTREF = 0x8
    }
}