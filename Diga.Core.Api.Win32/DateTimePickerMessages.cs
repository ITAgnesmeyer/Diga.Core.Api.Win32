using System;
using System.Runtime.InteropServices;

namespace Diga.Core.Api.Win32
{
    public static class DateTimePickerNotifications
    {
        public const uint DTN_FIRST = 0xfffffd1c;
        public const uint DTN_LAST = 0xfffffd17;
        public const uint DTN_FIRST2 = 0xfffffd0f;
        public const uint DTN_LAST2 = 0xfffffce1;
        public const uint DTN_DATETIMECHANGE = (DTN_FIRST2 - 6);
        public const uint DTN_USERSTRINGA = (DTN_FIRST2 - 5);
        public const uint DTN_USERSTRINGW = (DTN_FIRST - 5);
        public const uint DTN_WMKEYDOWNA = (DTN_FIRST2 - 4);
        public const uint DTN_WMKEYDOWNW = (DTN_FIRST - 4);
        public const uint DTN_FORMATA = (DTN_FIRST2 - 3);
        public const uint DTN_FORMATW = (DTN_FIRST - 3);
        public const uint DTN_FORMATQUERYA = (DTN_FIRST2 - 2);
        public const uint DTN_FORMATQUERYW = (DTN_FIRST - 2);
        public const uint DTN_DROPDOWN = (DTN_FIRST2 - 1);
        public const uint DTN_CLOSEUP = (DTN_FIRST2);


    }
    public static class DateTimePickerMessages
    {
        public const uint DTM_FIRST = 0x1000;
        public const uint DTM_GETSYSTEMTIME  = (DTM_FIRST + 1);
        public const uint DTM_SETSYSTEMTIME = (DTM_FIRST + 2);
        public const uint DTM_GETRANGE = (DTM_FIRST + 3);
        public const uint DTM_SETRANGE = (DTM_FIRST + 4);
        public const uint DTM_SETFORMATA = (DTM_FIRST + 5);
        public const uint DTM_SETFORMATW = (DTM_FIRST + 50);
        public const uint DTM_SETMCCOLOR = (DTM_FIRST + 6);
        public const uint DTM_GETMCCOLOR = (DTM_FIRST + 7);
        public const uint DTM_GETMONTHCAL = (DTM_FIRST + 8);
        public const uint DTM_SETMCFONT = (DTM_FIRST + 9);
        public const uint DTM_GETMCFONT = (DTM_FIRST + 10);
        public const uint DTM_SETMCSTYLE = (DTM_FIRST + 11);
        public const uint DTM_GETMCSTYLE = (DTM_FIRST + 12);
        public const uint DTM_CLOSEMONTHCAL = (DTM_FIRST + 13);
        public const uint DTM_GETDATETIMEPICKERINFO = (DTM_FIRST + 14);
        public const uint DTM_GETIDEALSIZE = (DTM_FIRST + 15);
        
        public  const uint GDTR_MIN = 0x0001;

        public const uint GDTR_MAX = 0x0002;

        public const int GDT_ERROR = -1;

        public const int GDT_VALID = 0;

        public const int GDT_NONE = 1;
        //Macros
        public static void DateTime_CloseMonthCal(IntPtr hDp)
        {
            User32.SendMessage(hDp, DTM_CLOSEMONTHCAL);
        }

        public static void DateTime_GetDateTimePickerInfo(IntPtr hDp, out DateTimePickerInfo info)
        {
            DateTimePickerInfo dti = new DateTimePickerInfo();
            dti.cbSize = (uint)Marshal.SizeOf<DateTimePickerInfo>();
            using (ApiStructHandleRef<DateTimePickerInfo> ifo = new ApiStructHandleRef<DateTimePickerInfo>(dti))
            {
                User32.SendMessage(hDp, (int)DTM_GETDATETIMEPICKERINFO, 0,  ifo.Handle);
                info = Marshal.PtrToStructure<DateTimePickerInfo>(ifo.Handle);
            }
        }

        public static void DateTime_GetIdealSize(IntPtr hDp, out Size size)
        {
            Size sz = new Size();
            using (ApiStructHandleRef<Size> psz = new ApiStructHandleRef<Size>(sz))
            {
                User32.SendMessage(hDp, (int)DTM_GETIDEALSIZE, 0, psz.Handle);
                size = Marshal.PtrToStructure<Size>(psz.Handle);

            }
        }

        public static IntPtr DateTime_GetMonthCal(IntPtr hDp)
        {
            return User32.SendMessage(hDp, DTM_GETMONTHCAL);
        }

        public static uint DateTime_GetMonthCalColor(IntPtr hDp, int iColor)
        {
            IntPtr retVal = User32.SendMessage(hDp, (int)DTM_GETMCCOLOR, iColor, 0);
            return Win32Api.GetIntPtrUInt(retVal);
        }

        public static IntPtr DateTime_GetMonthCalFont(IntPtr hDp)
        {
            return User32.SendMessage(hDp, DTM_GETMCFONT);
        }

        public static uint DateTime_GetMonthCalStyle(IntPtr hDp)
        {
            IntPtr retVal = User32.SendMessage(hDp, DTM_GETMCSTYLE);
            return Win32Api.GetIntPtrUInt(retVal);
        }

        public static SystemTimeRange DateTime_GetRange(IntPtr hDp)
        {

            SystemTimeRange range = new SystemTimeRange();
            using (ApiStructHandleRef<SystemTimeRange> r = new ApiStructHandleRef<SystemTimeRange>(range))
            {
                IntPtr retVal = User32.SendMessage(hDp, (int)DTM_GETRANGE, 0, r.Handle);

                uint maxMin = Win32Api.GetIntPtrUInt(retVal);
                SystemTimeRange retRange = Marshal.PtrToStructure<SystemTimeRange>(r.Handle);

                if ((maxMin & GDTR_MAX) == 0)
                {
                    retRange.RangeEnd = new SystemTime(DateTime.MinValue);
                }

                if ((maxMin & GDTR_MIN) == 0)
                {
                    retRange.RangeStart = new SystemTime();
                }

                return retRange;
            }

            
        }

        public static int DateTime_GetSystemtime(IntPtr hDp, out SystemTime retTime)
        {
            IntPtr retVal = User32.SendMessage(hDp, DTM_GETSYSTEMTIME, 0, out SystemTime time);
            retTime = time;
            return retVal.ToInt32();
        }

        public static bool DateTime_SetSystemtime(IntPtr hDp, SystemTime time)
        {
            IntPtr retVal = User32.SendMessage(hDp, DTM_SETSYSTEMTIME, 0, time);
            return retVal.ToInt32() == 0;
        }

    }
}