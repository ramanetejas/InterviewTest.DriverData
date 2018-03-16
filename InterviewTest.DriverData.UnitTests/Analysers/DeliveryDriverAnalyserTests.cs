using System;
using InterviewTest.DriverData.Analysers;
using NUnit.Framework;
using System.Collections.Generic;

namespace InterviewTest.DriverData.UnitTests.Analysers
{
	[TestFixture]
	public class DeliveryDriverAnalyserTests
	{
        private DriverShiftDetails driverShiftDetails;
        public DeliveryDriverAnalyserTests() {
            driverShiftDetails = new DriverShiftDetails {
                startTime = new TimeSpan(9, 0, 0),
                endTime = new TimeSpan(17, 0, 0), maxSpeed = 30
            };
        }
        [Test]
		public void ShouldYieldCorrectValues()
		{
			var expectedResult = new HistoryAnalysis
			{
				AnalysedDuration = new TimeSpan(7, 45, 0),
				DriverRating = 0.7638m
			};

			var actualResult = new DeliveryDriverAnalyser(driverShiftDetails).Analyse(CannedDrivingData.History);

			Assert.That(actualResult.AnalysedDuration, Is.EqualTo(expectedResult.AnalysedDuration));
			Assert.That(actualResult.DriverRating, Is.EqualTo(expectedResult.DriverRating).Within(0.001m));
		}

        [Test]
        public void ShouldReturnZeroRatingForEmptyPeriodHistory()
        {
            var expectedResult = new HistoryAnalysis
            {
                AnalysedDuration = new TimeSpan(0, 0, 0),
                DriverRating = 0
            };

            var emptyPeriodHistory = new List<Period>();
            var actualResult = new DeliveryDriverAnalyser(driverShiftDetails).Analyse(emptyPeriodHistory);

            Assert.That(actualResult.AnalysedDuration, Is.EqualTo(expectedResult.AnalysedDuration));
            Assert.That(actualResult.DriverRating, Is.EqualTo(expectedResult.DriverRating));
        }

        [Test]
        public void ShouldYieldCorrectResultForMultipleUndocumentedPeriods()
        {
            var expectedResult = new HistoryAnalysis
            {
                AnalysedDuration = new TimeSpan(6, 30, 0),
                DriverRating = 0.5726875m
            };

            var actualResult = new DeliveryDriverAnalyser(driverShiftDetails).Analyse(TestCannedData.HistoryWithMultipleUndocumentedPeriods);

            Assert.That(actualResult.AnalysedDuration, Is.EqualTo(expectedResult.AnalysedDuration));
            Assert.That(actualResult.DriverRating, Is.EqualTo(expectedResult.DriverRating).Within(0.001m));
        }

        [Test]
        public void ShouldReturnZeroWhenSpeedLimitExceedForAllPeriods()
        {
            var expectedResult = new HistoryAnalysis
            {
                AnalysedDuration = new TimeSpan(6, 30, 0),
                DriverRating = 0
            };

            var actualResult = new DeliveryDriverAnalyser(driverShiftDetails).Analyse(TestCannedData.HistoryWithAllPeriodsExceedingSpeedLimit);

            Assert.That(actualResult.AnalysedDuration, Is.EqualTo(expectedResult.AnalysedDuration));
            Assert.That(actualResult.DriverRating, Is.EqualTo(expectedResult.DriverRating).Within(0.001m));
        }

    }
}
