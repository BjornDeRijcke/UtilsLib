using System;
using System.Collections;
using System.Collections.Generic;
using UtilsLib.Extensions;
using Xunit;

namespace UtilsTests.Extensions
{
    public class DateTimeExtensionsTests
    {
        [Theory]
        [ClassData(typeof(GetIso8601WeekOfYearTestData))]
        public void GetIso8601WeekOfYear(DateTime date, int expectedWeekNumber)
        {
            var wn = date.GetIso8601WeekOfYear();
            Assert.Equal(expectedWeekNumber, wn);
        }

        public class GetIso8601WeekOfYearTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new DateTime(2033, 6, 6), 23 };
                yield return new object[] { new DateTime(2024, 12, 30), 1 };
                yield return new object[] { new DateTime(2024, 12, 31), 1 };
                yield return new object[] { new DateTime(2023, 2, 27), 9 };
                yield return new object[] { new DateTime(2018, 1, 1), 1 };
                yield return new object[] { new DateTime(2017, 1, 1), 52 };
                yield return new object[] { new DateTime(2052, 10, 19), 42 };
                yield return new object[] { new DateTime(1976, 1, 1), 1 };
                yield return new object[] { new DateTime(1976, 12, 31), 53 };
                yield return new object[] { new DateTime(1977, 1, 2), 53 };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
