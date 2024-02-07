
// ReSharper disable InconsistentNaming

namespace Diga.Core.Api.Win32
{
    public static class LocaleIdentifier
    {


        public const int LOCALE_IDEFAULTEBCDICCODEPAGE = 4114;

        public const int LOCALE_IDEFAULTANSICODEPAGE = 4100;

        public const int LOCALE_IDEFAULTMACCODEPAGE = 4113;

        public const int LOCALE_SABBREVMONTHNAME13 = 4111;

        public const int LOCALE_SABBREVMONTHNAME12 = 79;

        public const int LOCALE_SABBREVMONTHNAME11 = 78;

        public const int LOCALE_SABBREVMONTHNAME10 = 77;

        public const int LOCALE_IDIGITSUBSTITUTION = 4116;

        // LOCALE_SABBREVMONTHNAME9 -> 0x0000004C
        public const int LOCALE_SABBREVMONTHNAME9 = 76;

        // LOCALE_SABBREVMONTHNAME8 -> 0x0000004B
        public const int LOCALE_SABBREVMONTHNAME8 = 75;

        // LOCALE_SABBREVMONTHNAME7 -> 0x0000004A
        public const int LOCALE_SABBREVMONTHNAME7 = 74;

        // LOCALE_SABBREVMONTHNAME6 -> 0x00000049
        public const int LOCALE_SABBREVMONTHNAME6 = 73;

        // LOCALE_SABBREVMONTHNAME5 -> 0x00000048
        public const int LOCALE_SABBREVMONTHNAME5 = 72;

        // LOCALE_SABBREVMONTHNAME4 -> 0x00000047
        public const int LOCALE_SABBREVMONTHNAME4 = 71;

        // LOCALE_SABBREVMONTHNAME3 -> 0x00000046
        public const int LOCALE_SABBREVMONTHNAME3 = 70;

        // LOCALE_SABBREVMONTHNAME2 -> 0x00000045
        public const int LOCALE_SABBREVMONTHNAME2 = 69;

        // LOCALE_SABBREVMONTHNAME1 -> 0x00000044
        public const int LOCALE_SABBREVMONTHNAME1 = 68;

        // LOCALE_IOPTIONALCALENDAR -> 0x0000100B
        public const int LOCALE_IOPTIONALCALENDAR = 4107;

        // LOCALE_SISO3166CTRYNAME -> 0x0000005A
        public const int LOCALE_SISO3166CTRYNAME = 90;

        // LOCALE_IFIRSTWEEKOFYEAR -> 0x0000100D
        public const int LOCALE_IFIRSTWEEKOFYEAR = 4109;

        // LOCALE_IDEFAULTLANGUAGE -> 0x00000009
        public const int LOCALE_IDEFAULTLANGUAGE = 9;

        // LOCALE_IDEFAULTCODEPAGE -> 0x0000000B
        public const int LOCALE_IDEFAULTCODEPAGE = 11;

        // LOCALE_SNATIVELANGNAME -> 0x00000004
        public const int LOCALE_SNATIVELANGNAME = 4;

        // LOCALE_SNATIVECURRNAME -> 0x00001008
        public const int LOCALE_SNATIVECURRNAME = 4104;

        // LOCALE_SNATIVECTRYNAME -> 0x00000008
        public const int LOCALE_SNATIVECTRYNAME = 8;

        // LOCALE_SMONTHOUSANDSEP -> 0x00000017
        public const int LOCALE_SMONTHOUSANDSEP = 23;

        // LOCALE_SISO639LANGNAME -> 0x00000059
        public const int LOCALE_SISO639LANGNAME = 89;

        // LOCALE_SABBREVLANGNAME -> 0x00000003
        public const int LOCALE_SABBREVLANGNAME = 3;

        // LOCALE_SABBREVDAYNAME7 -> 0x00000037
        public const int LOCALE_SABBREVDAYNAME7 = 55;

        // LOCALE_SABBREVDAYNAME6 -> 0x00000036
        public const int LOCALE_SABBREVDAYNAME6 = 54;

        // LOCALE_SABBREVDAYNAME5 -> 0x00000035
        public const int LOCALE_SABBREVDAYNAME5 = 53;

        // LOCALE_SABBREVDAYNAME4 -> 0x00000034
        public const int LOCALE_SABBREVDAYNAME4 = 52;

        // LOCALE_SABBREVDAYNAME3 -> 0x00000033
        public const int LOCALE_SABBREVDAYNAME3 = 51;

        // LOCALE_SABBREVDAYNAME2 -> 0x00000032
        public const int LOCALE_SABBREVDAYNAME2 = 50;

        // LOCALE_SABBREVDAYNAME1 -> 0x00000031
        public const int LOCALE_SABBREVDAYNAME1 = 49;

        // LOCALE_SABBREVCTRYNAME -> 0x00000007
        public const int LOCALE_SABBREVCTRYNAME = 7;

        // LOCALE_IPOSSYMPRECEDES -> 0x00000054
        public const int LOCALE_IPOSSYMPRECEDES = 84;

        // LOCALE_INEGSYMPRECEDES -> 0x00000056
        public const int LOCALE_INEGSYMPRECEDES = 86;

        // LOCALE_IINTLCURRDIGITS -> 0x0000001A
        public const int LOCALE_IINTLCURRDIGITS = 26;

        // LOCALE_IFIRSTDAYOFWEEK -> 0x0000100C
        public const int LOCALE_IFIRSTDAYOFWEEK = 4108;

        // LOCALE_IDEFAULTCOUNTRY -> 0x0000000A
        public const int LOCALE_IDEFAULTCOUNTRY = 10;

        // LOCALE_SYSTEM_DEFAULT -> (MAKELCID(LANG_SYSTEM_DEFAULT, SORT_DEFAULT))
        // Error generating expression: Error generating function call.  Operation not implemented
        public static int LOCALE_SYSTEM_DEFAULT = (int)(Win32Api.MakeLcId(LANG_SYSTEM_DEFAULT, SORT_DEFAULT));

        // LOCALE_SMONDECIMALSEP -> 0x00000016
        public const int LOCALE_SMONDECIMALSEP = 22;

        // LOCALE_NOUSEROVERRIDE -> 0x80000000
        public const int LOCALE_NOUSEROVERRIDE = -2147483648;

        // LOCALE_IPOSSEPBYSPACE -> 0x00000055
        public const int LOCALE_IPOSSEPBYSPACE = 85;

        // LOCALE_INEGSEPBYSPACE -> 0x00000057
        public const int LOCALE_INEGSEPBYSPACE = 87;

        // LOCALE_SPOSITIVESIGN -> 0x00000050
        public const int LOCALE_SPOSITIVESIGN = 80;

        // LOCALE_SNEGATIVESIGN -> 0x00000051
        public const int LOCALE_SNEGATIVESIGN = 81;

        // LOCALE_SNATIVEDIGITS -> 0x00000013
        public const int LOCALE_SNATIVEDIGITS = 19;

        // LOCALE_RETURN_NUMBER -> 0x20000000
        public const int LOCALE_RETURN_NUMBER = 536870912;

        // LOCALE_ITIMEMARKPOSN -> 0x00001005
        public const int LOCALE_ITIMEMARKPOSN = 4101;

        // LOCALE_ICALENDARTYPE -> 0x00001009
        public const int LOCALE_ICALENDARTYPE = 4105;

        // LOCALE_FONTSIGNATURE -> 0x00000058
        public const int LOCALE_FONTSIGNATURE = 88;


        // LOCALE_SMONTHNAME13 -> 0x0000100E
        public const int LOCALE_SMONTHNAME13 = 4110;

        // LOCALE_SMONTHNAME12 -> 0x00000043
        public const int LOCALE_SMONTHNAME12 = 67;

        // LOCALE_SMONTHNAME11 -> 0x00000042
        public const int LOCALE_SMONTHNAME11 = 66;

        // LOCALE_SMONTHNAME10 -> 0x00000041
        public const int LOCALE_SMONTHNAME10 = 65;

        // LOCALE_SMONGROUPING -> 0x00000018
        public const int LOCALE_SMONGROUPING = 24;

        // LOCALE_SENGLANGUAGE -> 0x00001001
        public const int LOCALE_SENGLANGUAGE = 4097;

        // LOCALE_SENGCURRNAME -> 0x00001007
        public const int LOCALE_SENGCURRNAME = 4103;

        // LOCALE_IPOSSIGNPOSN -> 0x00000052
        public const int LOCALE_IPOSSIGNPOSN = 82;

        // LOCALE_INEGSIGNPOSN -> 0x00000053
        public const int LOCALE_INEGSIGNPOSN = 83;

        // LOCALE_STIMEFORMAT -> 0x00001003
        public const int LOCALE_STIMEFORMAT = 4099;

        // LOCALE_SMONTHNAME9 -> 0x00000040
        public const int LOCALE_SMONTHNAME9 = 64;

        // LOCALE_SMONTHNAME8 -> 0x0000003F
        public const int LOCALE_SMONTHNAME8 = 63;

        // LOCALE_SMONTHNAME7 -> 0x0000003E
        public const int LOCALE_SMONTHNAME7 = 62;

        // LOCALE_SMONTHNAME6 -> 0x0000003D
        public const int LOCALE_SMONTHNAME6 = 61;

        // LOCALE_SMONTHNAME5 -> 0x0000003C
        public const int LOCALE_SMONTHNAME5 = 60;

        // LOCALE_SMONTHNAME4 -> 0x0000003B
        public const int LOCALE_SMONTHNAME4 = 59;

        // LOCALE_SMONTHNAME3 -> 0x0000003A
        public const int LOCALE_SMONTHNAME3 = 58;

        // LOCALE_SMONTHNAME2 -> 0x00000039
        public const int LOCALE_SMONTHNAME2 = 57;

        // LOCALE_SMONTHNAME1 -> 0x00000038
        public const int LOCALE_SMONTHNAME1 = 56;

        // LOCALE_SINTLSYMBOL -> 0x00000015
        public const int LOCALE_SINTLSYMBOL = 21;

        // LOCALE_SENGCOUNTRY -> 0x00001002
        public const int LOCALE_SENGCOUNTRY = 4098;

        // LOCALE_ICURRDIGITS -> 0x00000019
        public const int LOCALE_ICURRDIGITS = 25;

        // LOCALE_USE_CP_ACP -> 0x40000000
        public const int LOCALE_USE_CP_ACP = 1073741824;

        // LOCALE_SYEARMONTH -> 0x00001006
        public const int LOCALE_SYEARMONTH = 4102;

        // LOCALE_SSHORTDATE -> 0x0000001F
        public const int LOCALE_SSHORTDATE = 31;

        // LOCALE_IPAPERSIZE -> 0x0000100A
        public const int LOCALE_IPAPERSIZE = 4106;

        // LOCALE_INEGNUMBER -> 0x00001010
        public const int LOCALE_INEGNUMBER = 4112;

        // LOCALE_STHOUSAND -> 0x0000000F
        public const int LOCALE_STHOUSAND = 15;

        // LOCALE_SSORTNAME -> 0x00001013
        public const int LOCALE_SSORTNAME = 4115;

        // LOCALE_SLONGDATE -> 0x00000020
        public const int LOCALE_SLONGDATE = 32;

        // LOCALE_SLANGUAGE -> 0x00000002
        public const int LOCALE_SLANGUAGE = 2;

        // LOCALE_SGROUPING -> 0x00000010
        public const int LOCALE_SGROUPING = 16;

        // LOCALE_SDAYNAME7 -> 0x00000030
        public const int LOCALE_SDAYNAME7 = 48;

        // LOCALE_SDAYNAME6 -> 0x0000002F
        public const int LOCALE_SDAYNAME6 = 47;

        // LOCALE_SDAYNAME5 -> 0x0000002E
        public const int LOCALE_SDAYNAME5 = 46;

        // LOCALE_SDAYNAME4 -> 0x0000002D
        public const int LOCALE_SDAYNAME4 = 45;

        // LOCALE_SDAYNAME3 -> 0x0000002C
        public const int LOCALE_SDAYNAME3 = 44;

        // LOCALE_SDAYNAME2 -> 0x0000002B
        public const int LOCALE_SDAYNAME2 = 43;

        // LOCALE_SDAYNAME1 -> 0x0000002A
        public const int LOCALE_SDAYNAME1 = 42;

        // LOCALE_SCURRENCY -> 0x00000014
        public const int LOCALE_SCURRENCY = 20;
        public const int LANG_INVARIANT = 127;
        // LOCALE_INVARIANT -> (MAKELCID(MAKELANGID(LANG_INVARIANT, SUBLANG_NEUTRAL), SORT_DEFAULT))
        // Error generating expression: Expression is not parsable.  Treating value as a raw string
        public static int LOCALE_INVARIANT = (int)(Win32Api.MakeLcId((int)Win32Api.MakeLangId(LANG_INVARIANT, SUBLANG_NEUTRAL), SORT_DEFAULT));

        // LOCALE_IMONLZERO -> 0x00000027
        public const int LOCALE_IMONLZERO = 39;

        // LOCALE_ILANGUAGE -> 0x00000001
        public const int LOCALE_ILANGUAGE = 1;

        // LOCALE_IDAYLZERO -> 0x00000026
        public const int LOCALE_IDAYLZERO = 38;

        // LOCALE_ICURRENCY -> 0x0000001B
        public const int LOCALE_ICURRENCY = 27;

        // LOCALE_SDECIMAL -> 0x0000000E
        public const int LOCALE_SDECIMAL = 14;

        // LOCALE_SCOUNTRY -> 0x00000006
        public const int LOCALE_SCOUNTRY = 6;

        // LOCALE_INEGCURR -> 0x0000001C
        public const int LOCALE_INEGCURR = 28;

        // LOCALE_IMEASURE -> 0x0000000D
        public const int LOCALE_IMEASURE = 13;

        // LOCALE_ICOUNTRY -> 0x00000005
        public const int LOCALE_ICOUNTRY = 5;

        // LOCALE_ICENTURY -> 0x00000024
        public const int LOCALE_ICENTURY = 36;

        // LOCALE_ENUMPROC -> LOCALE_ENUMPROCW
        // Error generating expression: Value LOCALE_ENUMPROCW is not resolved
        //public const string LOCALE_ENUMPROC = LOCALE_ENUMPROCW;

        // LOCALE_USE_NLS -> 0x10000000
        public const int LOCALE_USE_NLS = 268435456;

        public const int SUBLANG_NEUTRAL = 0;

        // LOCALE_NEUTRAL -> (MAKELCID(MAKELANGID(LANG_NEUTRAL, SUBLANG_NEUTRAL), SORT_DEFAULT))
        // Error generating expression: Expression is not parsable.  Treating value as a raw string
        public static int LOCALE_NEUTRAL => (int)Win32Api.MakeLcId((int)Win32Api.MakeLangId(LANG_NEUTRAL, SUBLANG_NEUTRAL), SORT_DEFAULT);

        // LOCALE_ITLZERO -> 0x00000025
        public const int LOCALE_ITLZERO = 37;

        // LOCALE_IDIGITS -> 0x00000011
        public const int LOCALE_IDIGITS = 17;

        // LOCALE_ILZERO -> 0x00000012
        public const int LOCALE_ILZERO = 18;

        // LOCALE_ILDATE -> 0x00000022
        public const int LOCALE_ILDATE = 34;

        // LOCALE_STIME -> 0x0000001E
        public const int LOCALE_STIME = 30;

        // LOCALE_SLIST -> 0x0000000C
        public const int LOCALE_SLIST = 12;

        // LOCALE_SDATE -> 0x0000001D
        public const int LOCALE_SDATE = 29;

        // LOCALE_S2359 -> 0x00000029
        public const int LOCALE_S2359 = 41;

        // LOCALE_S1159 -> 0x00000028
        public const int LOCALE_S1159 = 40;

        // LOCALE_ITIME -> 0x00000023
        public const int LOCALE_ITIME = 35;

        // LOCALE_IDATE -> 0x00000021
        public const int LOCALE_IDATE = 33;

        // LANG_SYSTEM_DEFAULT -> (MAKELANGID(LANG_NEUTRAL, SUBLANG_SYS_DEFAULT))
        // Error generating expression: Error generating function call.  Operation not implemented
        public static int LANG_SYSTEM_DEFAULT => (int)Win32Api.MakeLangId( LANG_NEUTRAL, SUBLANG_SYS_DEFAULT);

        // SORT_DEFAULT -> 0x0
        public const int SORT_DEFAULT = 0;

        // LANG_USER_DEFAULT -> (MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT))
        // Error generating expression: Error generating function call.  Operation not implemented
        public static int LANG_USER_DEFAULT = (int)Win32Api.MakeLangId(LANG_NEUTRAL, SUBLANG_DEFAULT);
        // LOCALE_USER_DEFAULT -> (MAKELCID(LANG_USER_DEFAULT, SORT_DEFAULT))
        // Error generating expression: Error generating function call.  Operation not implemented
        public static int LOCALE_USER_DEFAULT = (int)Win32Api.MakeLangId(LANG_USER_DEFAULT, SORT_DEFAULT);

        // LANG_NEUTRAL -> 0x00
        public const int LANG_NEUTRAL = 0;

        // SUBLANG_SYS_DEFAULT -> 0x02
        public const int SUBLANG_SYS_DEFAULT = 2;

        // SUBLANG_DEFAULT -> 0x01
        public const int SUBLANG_DEFAULT = 1;

    }

    // Return Type: BOOL->int
}