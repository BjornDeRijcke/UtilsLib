﻿using System;
using System.Collections;
using System.Collections.Generic;
using UtilsLib.Time;
using Xunit;

namespace UtilsTests.Time
{
    public class DateTimeHelperTests
    {
        [Theory]
        [ClassData(typeof(TryParseLocalDateAsUtcTestData))]
        public void TryParseLocalDateAsUtc(string date, string timeZone, bool expectedSuccess, DateTime expectedDateTime)
        {
            var success = DateTimeHelper.TryParseLocalDateAsUtc(date, "yyyy+MM+dd HH:mm:ss", timeZone, out DateTime dt);

            Assert.Equal(expectedSuccess, success);
            Assert.Equal(expectedDateTime, dt);
        }

        public class TryParseLocalDateAsUtcTestData : IEnumerable<object[]>
        {
            private DateTime UtcZoneDt(int year, int month, int day)
                => UtcZoneDt(year, month, day, 0, 0, 0);
            private DateTime UtcZoneDt(int year, int month, int day, int hours, int minutes, int seconds)
            {
                return new DateTime(year, month, day, hours, minutes, seconds, DateTimeKind.Utc);
            }

            public IEnumerator<object[]> GetEnumerator()
            {
                // CEST. Summer -> winter time.  UTC+2 to UTC+1
                yield return new object[] { "2019+10+27 00:00:00", "Central Europe Standard Time", true, UtcZoneDt(2019, 10, 26, 22, 0, 0) };
                yield return new object[] { "2019+10+27 01:00:00", "Central Europe Standard Time", true, UtcZoneDt(2019, 10, 26, 23, 0, 0) };
                yield return new object[] { "2019+10+27 02:00:00", "Central Europe Standard Time", true, UtcZoneDt(2019, 10, 27, 1, 0, 0) };

                // CEST. Winter -> summer time.  UTC+1 to UTC+2
                yield return new object[] { "2001+03+25 00:00:00", "Romance Standard Time", true, UtcZoneDt(2001, 03, 24, 23, 0, 0) };
                yield return new object[] { "2001+03+25 01:00:00", "Romance Standard Time", true, UtcZoneDt(2001, 03, 25, 0, 0, 0) };
                yield return new object[] { "2001+03+25 02:00:00", "Romance Standard Time", false, DateTime.MinValue }; // Invalid time (02:00 becomes 03:00)
                yield return new object[] { "2001+03+25 03:00:00", "Romance Standard Time", true, UtcZoneDt(2001, 03, 25, 1, 0, 0) };

                // Morocco Standard Time. End of ramadan 1 hour change. UTC+2 to UTC+1
                yield return new object[] { "2021+05+16 01:00:00", "Morocco Standard Time", true, UtcZoneDt(2021, 05, 16, 01, 00, 00) };
                yield return new object[] { "2021+05+16 02:00:00", "Morocco Standard Time", false, DateTime.MinValue }; // Invalid time (02:00 becomes 03:00)
                yield return new object[] { "2021+05+16 03:00:00", "Morocco Standard Time", true, UtcZoneDt(2021, 05, 16, 02, 0, 0) };

                // Cen. Australia Standard Time. Winter -> summer time. UTC+9:30 to UTC+10:30
                yield return new object[] { "2021+10+03 01:00:00", "Cen. Australia Standard Time", true, UtcZoneDt(2021, 10, 02, 15, 30, 0) };
                yield return new object[] { "2021+10+03 02:00:00", "Cen. Australia Standard Time", false, DateTime.MinValue }; // Invalid time (02:00 becomes 03:00)
                yield return new object[] { "2021+10+03 03:00:00", "Cen. Australia Standard Time", true, UtcZoneDt(2021, 10, 02, 16, 30, 0) };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
