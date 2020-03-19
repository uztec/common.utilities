using System;

namespace UzunTec.Utils.Common
{
    public static class DateTimeUtils
    {
        public static DateTime EndOfMonth(this DateTime dt)
        {
            return dt.AddDays(1 - dt.Day).AddMonths(1).AddDays(-1);
        }
    }
}
