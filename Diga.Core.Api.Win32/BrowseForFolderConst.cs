namespace Diga.Core.Api.Win32
{
    public static class BrowseForFolderConst
    {
        // Constants for sending and receiving messages in BrowseCallBackProc

        public const uint BFFM_INITIALIZED = 1;
        public const uint BFFM_SELCHANGED = 2;
        public const uint BFFM_VALIDATEFAILEDA = 3;
        public const uint BFFM_VALIDATEFAILEDW = 4;
        public const uint BFFM_IUNKNOWN = 5; // provides IUnknown to client. lParam: IUnknown*
        public const uint BFFM_SETSTATUSTEXTA = WindowsMessages.WM_USER + 100;
        public const uint BFFM_ENABLEOK = WindowsMessages.WM_USER + 101;
        public const uint BFFM_SETSELECTIONA = WindowsMessages.WM_USER + 102;
        public const uint BFFM_SETSELECTIONW = WindowsMessages.WM_USER + 103;
        public const uint BFFM_SETSTATUSTEXTW = WindowsMessages.WM_USER + 104;
        public const uint BFFM_SETOKTEXT = WindowsMessages.WM_USER + 105; // Unicode only
        public const uint BFFM_SETEXPANDED = WindowsMessages.WM_USER + 106; // Unicode only

        // Browsing for directory.
        public const uint BIF_RETURNONLYFSDIRS = 0x0001;  // For finding a folder to start document searching
        public const uint BIF_DONTGOBELOWDOMAIN = 0x0002;  // For starting the Find Computer
        public const uint BIF_STATUSTEXT = 0x0004;  // Top of the dialog has 2 lines of text for BROWSEINFO.lpszTitle and one line if
        // this flag is set.  Passing the message BFFM_SETSTATUSTEXTA to the hwnd can set the
        // rest of the text.  This is not used with BIF_USENEWUI and BROWSEINFO.lpszTitle gets
        // all three lines of text.
        public const uint BIF_RETURNFSANCESTORS = 0x0008;
        public const uint BIF_EDITBOX = 0x0010;   // Add an editbox to the dialog
        public const uint BIF_VALIDATE = 0x0020;   // insist on valid result (or CANCEL)

        public const uint BIF_NEWDIALOGSTYLE = 0x0040;   // Use the new dialog layout with the ability to resize
        // Caller needs to call OleInitialize() before using this API
        public const uint BIF_USENEWUI = 0x0040 + 0x0010; //(BIF_NEWDIALOGSTYLE | BIF_EDITBOX);

        public const uint BIF_BROWSEINCLUDEURLS = 0x0080;   // Allow URLs to be displayed or entered. (Requires BIF_USENEWUI)
        public const uint BIF_UAHINT = 0x0100;   // Add a UA hint to the dialog, in place of the edit box. May not be combined with BIF_EDITBOX
        public const uint BIF_NONEWFOLDERBUTTON = 0x0200;   // Do not add the "New Folder" button to the dialog.  Only applicable with BIF_NEWDIALOGSTYLE.
        public const uint BIF_NOTRANSLATETARGETS = 0x0400;  // don't traverse target as shortcut

        public const uint BIF_BROWSEFORCOMPUTER = 0x1000;  // Browsing for Computers.
        public const uint BIF_BROWSEFORPRINTER = 0x2000;// Browsing for Printers
        public const uint BIF_BROWSEINCLUDEFILES = 0x4000; // Browsing for Everything
        public const uint BIF_SHAREABLE = 0x8000;  // sharable resources displayed (remote shares, requires BIF_USENEWUI)
    }
}