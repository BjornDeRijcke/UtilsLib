using System;

namespace UtilsLib.Extensions
{
    public static class DayOfWeekExtensions
    {
        public static int DaysUntil(this DayOfWeek dayOfWeek, DayOfWeek otherDayOfWeek)
        {
            int day1 = (int)dayOfWeek;
            int day2 = (int)otherDayOfWeek;
            return (7 + (day2 - day1)) % 7;
        }
    }
}
