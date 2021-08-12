namespace Diga.Core.Api.Win32.Dwm
{
    public static class DwmApiConstants
    {

        /// DWMAPI -> EXTERN_C DECLSPEC_IMPORT HRESULT STDAPICALLTYPE
        /// Error generating expression: Expression is not parsable.  Treating value as a raw string
        public const string DWMAPI = "EXTERN_C DECLSPEC_IMPORT HRESULT STDAPICALLTYPE";

        /// DWMAPIB -> EXTERN_C DECLSPEC_IMPORT BOOL STDAPICALLTYPE
        /// Error generating expression: Expression is not parsable.  Treating value as a raw string
        public const string DWMAPIB = "EXTERN_C DECLSPEC_IMPORT BOOL STDAPICALLTYPE";

        /// DWM_BB_ENABLE -> 0x00000001
        public const int DWM_BB_ENABLE = 1;

        /// DWM_BB_BLURREGION -> 0x00000002
        public const int DWM_BB_BLURREGION = 2;

        /// DWM_BB_TRANSITIONONMAXIMIZED -> 0x00000004
        public const int DWM_BB_TRANSITIONONMAXIMIZED = 4;

        /// DWM_CLOAKED_APP -> 0x00000001
        public const int DWM_CLOAKED_APP = 1;

        /// DWM_CLOAKED_SHELL -> 0x00000002
        public const int DWM_CLOAKED_SHELL = 2;

        /// DWM_CLOAKED_INHERITED -> 0x00000004
        public const int DWM_CLOAKED_INHERITED = 4;

        /// DWM_TNP_RECTDESTINATION -> 0x00000001
        public const int DWM_TNP_RECTDESTINATION = 1;

        /// DWM_TNP_RECTSOURCE -> 0x00000002
        public const int DWM_TNP_RECTSOURCE = 2;

        /// DWM_TNP_OPACITY -> 0x00000004
        public const int DWM_TNP_OPACITY = 4;

        /// DWM_TNP_VISIBLE -> 0x00000008
        public const int DWM_TNP_VISIBLE = 8;

        /// DWM_TNP_SOURCECLIENTAREAONLY -> 0x00000010
        public const int DWM_TNP_SOURCECLIENTAREAONLY = 16;

        /// DWM_FRAME_DURATION_DEFAULT -> -1
        public const int DWM_FRAME_DURATION_DEFAULT = -1;

        /// DWM_EC_DISABLECOMPOSITION -> 0
        public const int DWM_EC_DISABLECOMPOSITION = 0;

        /// DWM_EC_ENABLECOMPOSITION -> 1
        public const int DWM_EC_ENABLECOMPOSITION = 1;

        /// DWM_SIT_DISPLAYFRAME -> 0x00000001
        public const int DWM_SIT_DISPLAYFRAME = 1;

        
    /// HTTRANSPARENT -> (-1)
    public const int HTTRANSPARENT = -1;
    
    /// HTBOTTOMRIGHT -> 17
    public const int HTBOTTOMRIGHT = 17;
    
    /// HTBOTTOMLEFT -> 16
    public const int HTBOTTOMLEFT = 16;
    
    /// HTSIZEFIRST -> HTLEFT
    public const int HTSIZEFIRST = HTLEFT;
    
    /// HTMINBUTTON -> 8
    public const int HTMINBUTTON = 8;
    
    /// HTMAXBUTTON -> 9
    public const int HTMAXBUTTON = 9;
    
    /// HTTOPRIGHT -> 14
    public const int HTTOPRIGHT = 14;
    
    /// HTSIZELAST -> HTBOTTOMRIGHT
    public const int HTSIZELAST = HTBOTTOMRIGHT;
    
    /// HTVSCROLL -> 7
    public const int HTVSCROLL = 7;
    
    /// HTTOPLEFT -> 13
    public const int HTTOPLEFT = 13;
    
    /// HTSYSMENU -> 3
    public const int HTSYSMENU = 3;
    
    /// HTNOWHERE -> 0
    public const int HTNOWHERE = 0;
    
    /// HTHSCROLL -> 6
    public const int HTHSCROLL = 6;
    
    /// HTGROWBOX -> 4
    public const int HTGROWBOX = 4;
    
    /// HTCAPTION -> 2
    public const int HTCAPTION = 2;
    
    /// HTREDUCE -> HTMINBUTTON
    public const int HTREDUCE = HTMINBUTTON;
    
    /// HTOBJECT -> 19
    public const int HTOBJECT = 19;
    
    /// HTCLIENT -> 1
    public const int HTCLIENT = 1;
    
    /// HTBOTTOM -> 15
    public const int HTBOTTOM = 15;
    
    /// HTBORDER -> 18
    public const int HTBORDER = 18;
    
    /// HTRIGHT -> 11
    public const int HTRIGHT = 11;
    
    /// HTERROR -> (-2)
    public const int HTERROR = -2;
    
    /// HTCLOSE -> 20
    public const int HTCLOSE = 20;
    
    /// HTZOOM -> HTMAXBUTTON
    public const int HTZOOM = HTMAXBUTTON;
    
    /// HTSIZE -> HTGROWBOX
    public const int HTSIZE = HTGROWBOX;
    
    /// HTMENU -> 5
    public const int HTMENU = 5;
    
    /// HTLEFT -> 10
    public const int HTLEFT = 10;
    
    /// HTHELP -> 21
    public const int HTHELP = 21;
    
    /// HTTOP -> 12
    public const int HTTOP = 12;


    }
}