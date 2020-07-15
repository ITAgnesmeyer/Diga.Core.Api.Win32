using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct EnumLogFontExDv
    {

        /// ENUMLOGFONTEXW->tagENUMLOGFONTEXW
        public EnumLogFontEx elfEnumLogfontEx;

        /// DESIGNVECTOR->tagDESIGNVECTOR
        public DesignVector elfDesignVector;
    }
}