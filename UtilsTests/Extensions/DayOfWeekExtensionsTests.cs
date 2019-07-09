using System;
using UtilsLib.Extensions;
using Xunit;

namespace UtilsTests.Extensions
{
    public class DayOfWeekExtensionsTests
    {
        [Theory]
        [InlineData(DayOfWeek.Monday, DayOfWeek.Wednesday, 2)]
        [InlineData(DayOfWeek.Monday, DayOfWeek.Sunday, 6)]
        [InlineData(DayOfWeek.Friday, DayOfWeek.Monday, 3)]
        [InlineData(DayOfWeek.Wednesday, DayOfWeek.Monday, 5)]
        [InlineData(DayOfWeek.Monday, DayOfWeek.Monday, 0)]
        [InlineData(DayOfWeek.Tuesday, DayOfWeek.Thursday, 2)]
        [InlineData(DayOfWeek.Tuesday, DayOfWeek.Saturday, 4)]
        public void DaysUntil(DayOfWeek day1, DayOfWeek day2, int expected)
        {
            var daysUntil = day1.DaysUntil(day2);
            Assert.Equal(expected, daysUntil);
        }
    }
}
