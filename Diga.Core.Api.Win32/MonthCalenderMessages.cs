namespace Diga.Core.Api.Win32
{
    public static class MonthCalenderMessages
    {
        public const uint MCM_FIRST = 0x1000;
        public const uint MCM_GETCURSEL = (MCM_FIRST + 1);
        public const uint MCM_SETCURSEL = (MCM_FIRST + 2);
        public const uint MCM_GETMAXSELCOUNT = (MCM_FIRST + 3);
        public const uint MCM_SETMAXSELCOUNT = (MCM_FIRST + 4);
        public const uint MCM_GETSELRANGE = (MCM_FIRST + 5);
        public const uint MCM_SETSELRANGE = (MCM_FIRST + 6);
        public const uint MCM_GETMONTHRANGE = (MCM_FIRST + 7);
        public const uint MCM_SETDAYSTATE = (MCM_FIRST + 8);
        public const uint MCM_GETMINREQRECT = (MCM_FIRST + 9);
        public const uint MCM_SETCOLOR = (MCM_FIRST + 10);
        public const uint MCM_GETCOLOR = (MCM_FIRST + 11);
        public const int MCSC_BACKGROUND = 0;
        public const int MCSC_TEXT = 1;
        public const int MCSC_TITLEBK = 2;
        public const int MCSC_TITLETEXT = 3;
        public const int MCSC_MONTHBK = 4;
        public const int MCSC_TRAILINGTEXT = 5;
        public const uint MCM_SETTODAY = (MCM_FIRST + 12);
        public const uint MCM_GETTODAY = (MCM_FIRST + 13);
        public const uint MCM_HITTEST = (MCM_FIRST + 14);

    }
}