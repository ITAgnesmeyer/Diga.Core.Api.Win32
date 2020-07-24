namespace Diga.Core.Api.Win32
{
    public static class DialogBoxStyles
    {
        
        /// DS_SETFOREGROUND -> 0x200L
        public const uint DS_SETFOREGROUND = 0x200;
    
        /// DS_NOFAILCREATE -> 0x0010L
        public const uint DS_NOFAILCREATE = 0x0010;
    
        /// DS_CONTEXTHELP -> 0x2000L
        public const uint DS_CONTEXTHELP = 0x2000;
    
        /// DS_CENTERMOUSE -> 0x1000L
        public const uint DS_CENTERMOUSE = 0x1000;
    
        /// DS_MODALFRAME -> 0x80L
        public const uint DS_MODALFRAME = 0x80;
    
        /// DS_S_SUCCESS -> NO_ERROR
        public const uint DS_S_SUCCESS = 0;
    
        /// DS_SHELLFONT -> (DS_SETFONT | DS_FIXEDSYS)
        public const uint DS_SHELLFONT = DS_SETFONT | DS_FIXEDSYS;
    
        /// DS_NOIDLEMSG -> 0x100L
        public const uint DS_NOIDLEMSG = 0x100;
    
        /// DS_LOCALEDIT -> 0x20L
        public const uint DS_LOCALEDIT = 0x20;
    
        /// DS_SYSMODAL -> 0x02L
        public const uint DS_SYSMODAL = 0x02;
    
        /// DS_FIXEDSYS -> 0x0008L
        public const uint DS_FIXEDSYS = 0x0008;
    
        /// DS_ABSALIGN -> 0x01L
        public const uint DS_ABSALIGN = 0x01;
    
        /// DS_SETFONT -> 0x40L
        public const uint DS_SETFONT = 0x40;
    
        /// DS_CONTROL -> 0x0400L
        public const uint DS_CONTROL = 0x0400;
    
        /// DS_CENTER -> 0x0800L
        public const uint DS_CENTER = 0x0800;
    
        /// DS_3DLOOK -> 0x0004L
        public const uint DS_3DLOOK = 0x0004;
    
        
    }
}