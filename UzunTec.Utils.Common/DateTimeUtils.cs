using System;
using System.Diagnostics;

namespace UzunTec.Utils.Common
{
    public static class DateTimeUtils
    {
        public static DateTime EndOfMonth(this DateTime dt)
        {
            return dt.AddDays(1 - dt.Day).AddMonths(1).AddDays(-1);
        }

        public static DateTime RandomDate(DateTime min, DateTime max)
        {
            long totalMilliseconds = (long)max.Subtract(min).TotalMilliseconds;
            int factor = (int)(totalMilliseconds / int.MaxValue);
            int maxInt = (int)(totalMilliseconds % int.MaxValue);
            int rndFactor = new Random().Next(0, factor) + 1;
            int rndValue = new Random().Next(0, maxInt) + 1;
            return min.AddMilliseconds((long)rndFactor * rndValue);
        }
        public static DateTime RandomDate()
        {
            return RandomDate(new DateTime(1900, 1, 1), new DateTime(2999, 12, 31));
        }

        public static DateTime RandomDate(DateTime min)
        {
            return RandomDate(min, DateTime.MaxValue);
        }
        public static string ElapsedFormated(this Stopwatch timer)
        {
            int ms = timer.Elapsed.Milliseconds;
            int s = timer.Elapsed.Seconds;
            int m = timer.Elapsed.Minutes;
            int h = timer.Elapsed.Hours;

            return ((h > 0) ? $"{h} h " : "")
                + ((m > 0) ? $"{m} min " : "")
                + $"{s}.{ms:D3} secs";
        }
    }
}
