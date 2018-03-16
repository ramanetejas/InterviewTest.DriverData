using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTest.DriverData.UnitTests
{
    public static class TestCannedData
    {
        private static readonly DateTimeOffset _day = new DateTimeOffset(2016, 10, 15, 0, 0, 0, 0, TimeSpan.Zero);

        public static readonly IReadOnlyCollection<Period> HistoryWithMultipleUndocumentedPeriods = new[]
        {
            new Period
            {
                Start = _day + new TimeSpan(0, 0, 0),
                End = _day + new TimeSpan(8, 30, 0),
                AverageSpeed = 0m
            },
            new Period
            {
                Start = _day + new TimeSpan(9, 30, 0),
                End = _day + new TimeSpan(10, 0, 0),
                AverageSpeed = 25m
            },
            new Period
            {
                Start = _day + new TimeSpan(10, 0, 0),
                End = _day + new TimeSpan(11, 0, 0),
                AverageSpeed = 31m
            },
            new Period
            {
                Start = _day + new TimeSpan(11, 30, 0),
                End = _day + new TimeSpan(12, 0, 0),
                AverageSpeed = 25m
            },
            new Period
            {
                Start = _day + new TimeSpan(12, 0, 0),
                End = _day + new TimeSpan(13, 0, 0),
                AverageSpeed = 25m
            },
            new Period
            {
                Start = _day + new TimeSpan(13, 30, 0),
                End = _day + new TimeSpan(17, 30, 0),
                AverageSpeed = 25m
            },
            new Period
            {
                Start = _day + new TimeSpan(17, 30, 0),
                End = _day + new TimeSpan(24, 0, 0),
                AverageSpeed = 0m
            }
        };

        public static readonly IReadOnlyCollection<Period> HistoryWithAllPeriodsExceedingSpeedLimit = new[]
        {
            new Period
            {
                Start = _day + new TimeSpan(0, 0, 0),
                End = _day + new TimeSpan(8, 30, 0),
                AverageSpeed = 0m
            },
            new Period
            {
                Start = _day + new TimeSpan(9, 30, 0),
                End = _day + new TimeSpan(10, 0, 0),
                AverageSpeed = 31m
            },
            new Period
            {
                Start = _day + new TimeSpan(10, 0, 0),
                End = _day + new TimeSpan(11, 0, 0),
                AverageSpeed = 33m
            },
            new Period
            {
                Start = _day + new TimeSpan(11, 30, 0),
                End = _day + new TimeSpan(12, 0, 0),
                AverageSpeed = 34m
            },
            new Period
            {
                Start = _day + new TimeSpan(12, 0, 0),
                End = _day + new TimeSpan(13, 0, 0),
                AverageSpeed = 38m
            },
            new Period
            {
                Start = _day + new TimeSpan(13, 30, 0),
                End = _day + new TimeSpan(17, 30, 0),
                AverageSpeed = 35m
            },
            new Period
            {
                Start = _day + new TimeSpan(17, 30, 0),
                End = _day + new TimeSpan(24, 0, 0),
                AverageSpeed = 36m
            }
        };
    }
}
