using System;
using System.Globalization;

namespace UtilsLib.Time
{
    public static class DateTimeHelper
    {
        public static bool TryParseLocalDateAsUtc(string localDatestring, string dateFormat, string timeZone, out DateTime parsedUtcDate)
        {
            try
            {
                var timezoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZone);

                if (timezoneInfo == TimeZoneInfo.Utc)
                {
                    return DateTime.TryParseExact(
                        localDatestring,
                        dateFormat,
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal,
                        out parsedUtcDate);
                }

                DateTime dt = DateTime.ParseExact(localDatestring, dateFormat, CultureInfo.InvariantCulture);
                parsedUtcDate = TimeZoneInfo.ConvertTimeToUtc(dt, timezoneInfo);

                return true;
            }
            catch
            {
                parsedUtcDate = DateTime.MinValue;
                return false;
            }
        }
    }
}
