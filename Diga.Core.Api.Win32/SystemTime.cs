using System;
using System.Runtime.InteropServices;


namespace Diga.Core.Api.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SystemTime 
    {
        public ushort wYear;
    
        public ushort wMonth;
    
        public ushort wDayOfWeek;
    
        public ushort wDay;
    
        public ushort wHour;
    
        public ushort wMinute;
    
        public ushort wSecond;
    
        public ushort wMilliseconds;

        private SystemTime(ushort year, ushort month, ushort dayOfWeek, ushort day, ushort hour, ushort minute, ushort second, ushort miliSecond)
        {
            this.wYear = year;
            this.wMonth = month;
            this.wDayOfWeek = dayOfWeek;
            this.wDay = day;
            this.wHour = hour;
            this.wMinute = minute;
            this.wSecond = second;
            this.wMilliseconds = miliSecond;
        }

        public SystemTime(DateTime dt):this((ushort)dt.Year, (ushort)dt.Month, (ushort)dt.DayOfWeek, (ushort)dt.Day, (ushort)dt.Hour, (ushort)dt.Minute, (ushort)dt.Second, (ushort)dt.Millisecond)
        {

        }

        public static implicit operator SystemTime(DateTime input)
        {
            return new SystemTime(input);
        }

        public static implicit operator DateTime(SystemTime input)
        {
            DateTime dt = new DateTime(input.wYear, input.wMonth, input.wDay, input.wHour, input.wMinute,
                input.wSecond);
            return dt;
        }
    }
}