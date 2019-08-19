using System;

namespace Cycloid.Extensions
{
    public static class EpochExtentions
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Convert epoch to datetime
        /// </summary>
        /// <param name="unixTime"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this long unixTime)
        {
            return Epoch.AddSeconds(unixTime);
        }

        /// <summary>
        /// Convert datetime to epoch
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static long ToUnixTime(this DateTime date)
        {
            return Convert.ToInt64((date - Epoch).TotalSeconds);
        }

        public static DateTime EnsureUtcDate(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, DateTimeKind.Utc);
        }
    }
}
