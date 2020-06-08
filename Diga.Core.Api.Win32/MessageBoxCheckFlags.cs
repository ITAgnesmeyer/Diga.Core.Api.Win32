// ReSharper disable InconsistentNaming

namespace Diga.Core.Api.Win32
{
    public static class MessageBoxCheckFlags
    {
        public const uint MB_OK = 0x00000000;

        public const uint MB_OKCANCEL = 0x00000001;

        public const uint MB_YESNO = 0x00000004;

        public const uint MB_ICONHAND = 0x00000010;

        public const uint MB_ICONQUESTION = 0x00000020;

        public const uint MB_ICONEXCLAMATION = 0x00000030;

        public const uint MB_ICONINFORMATION = 0x00000040;
    }
}