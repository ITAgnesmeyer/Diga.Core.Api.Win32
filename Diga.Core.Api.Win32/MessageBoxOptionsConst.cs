// ReSharper disable InconsistentNaming

namespace Diga.Core.Api.Win32
{
    ///<summary>
    /// Flags that define appearance and behaviour of a standard message box displayed by a call to the MessageBox function.
    /// </summary>    
    public static class MessageBoxOptionsConst
    {
        public const uint
            OkOnly = 0x000000;

        public const uint
            OkCancel = 0x000001;

        public const uint
            AbortRetryIgnore = 0x000002;

        public const uint
            YesNoCancel = 0x000003;

        public const uint
            YesNo = 0x000004;

        public const uint
            RetryCancel = 0x000005;

        public const uint
            CancelTryContinue = 0x000006;

        public const uint
            IconHand = 0x000010;

        public const uint
            IconQuestion = 0x000020;

        public const uint
            IconExclamation = 0x000030;

        public const uint
            IconAsterisk = 0x000040;

        public const uint
            UserIcon = 0x000080;

        public const uint
            IconWarning = IconExclamation;

        public const uint
            IconError = IconHand;

        public const uint
            IconInformation = IconAsterisk;

        public const uint
            IconStop = IconHand;

        public const uint
            DefButton1 = 0x000000;

        public const uint
            DefButton2 = 0x000100;

        public const uint
            DefButton3 = 0x000200;

        public const uint
            DefButton4 = 0x000300;

        public const uint
            ApplicationModal = 0x000000;

        public const uint
            SystemModal = 0x001000;

        public const uint
            TaskModal = 0x002000;

        public const uint
            Help = 0x004000;

        public const uint
            NoFocus = 0x008000;

        public const uint
            SetForeground = 0x010000;

        public const uint
            DefaultDesktopOnly = 0x020000;

        public const uint
            Topmost = 0x040000;

        public const uint
            Right = 0x080000;

        public const uint
            RTLReading = 0x100000;
    }
}