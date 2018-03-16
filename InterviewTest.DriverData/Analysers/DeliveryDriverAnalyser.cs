using InterviewTest.DriverData.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTest.DriverData.Analysers
{
    // BONUS: Why internal?
    /*
     * Internal classes are accessible only inside an assembly. Here, DeliveryDriverAnalyser is internal as it should not
     * be modified outside this application, since this class is closed for modification interface IAnalyser is kept public
     * which can be extended.
    */
    internal class DeliveryDriverAnalyser : IAnalyser
    {
        private DriverShiftDetails _driverShiftDetails;
        public DeliveryDriverAnalyser(DriverShiftDetails driverShiftDetails)
        {
            _driverShiftDetails = driverShiftDetails;
        }

        public HistoryAnalysis Analyse(IReadOnlyCollection<Period> history)
        {
            var analysis = new HistoryAnalysis();
            if (history != null && history.Count > 0)
            {
                //get current day for data.
                var currentDay = history.FirstOrDefault().Start.GetCurrentDay();

                var shiftStartTime = currentDay + _driverShiftDetails.startTime;
                var shiftEndTime = currentDay + _driverShiftDetails.endTime;

                var validPeriods = history.GetValidPeriods(shiftStartTime, shiftEndTime);

                var analysedPeriods = AnalyzePeriods(validPeriods, shiftStartTime, shiftEndTime);

                var totalShiftDuration = shiftEndTime - shiftStartTime;
                if (analysedPeriods.HasUndocumentedPeriods(totalShiftDuration))
                {
                    analysedPeriods.Add(analysedPeriods.AnalyseUndocumentedPeriods(totalShiftDuration));
                }

                if (analysedPeriods.Any())
                {
                    //Calculate total analysed duration and overall driver's rating.          
                    analysis.AnalysedDuration = analysedPeriods.GetTotalAnayzedDuration();
                    analysis.DriverRating = analysedPeriods.CalculateOverallRating();
                }
            }
            return analysis;
        }

        #region Utilities

        private TimeSpan CalculatePeriodDuration(Period period, DateTimeOffset shiftStartTime, DateTimeOffset shiftEndTime)
        {
            //ignore anything before and after shift time to calculate valid period duration.
            var validPeriodStartTime = period.Start < shiftStartTime ? shiftStartTime : period.Start;
            var validPeriodEndTime = period.End > shiftEndTime ? shiftEndTime : period.End;

            return validPeriodEndTime - validPeriodStartTime;
        }

        private decimal CalculatePeriodRating(Period period, decimal maxSpeed)
        {
            if (period.AverageSpeed > maxSpeed)
            {
                //If AverageSpeed exceed maxSpeed rate period to zero.
                return 0;
            }

            return period.AverageSpeed.CalculateLinearRating(maxSpeed);
        }

        private IList<PeriodAnalysis> AnalyzePeriods(IEnumerable<Period> validPeriods, DateTimeOffset shiftStartTime, DateTimeOffset shiftEndTime)
        {
            var analysedPeriods = new List<PeriodAnalysis>();
            foreach (var period in validPeriods)
            {
                //Analyse duration and calculate rating based on the requirement specified in Task 1.1.md.
                analysedPeriods.Add(new PeriodAnalysis()
                {
                    Duration = CalculatePeriodDuration(period, shiftStartTime, shiftEndTime).Ticks,
                    Rating = CalculatePeriodRating(period, _driverShiftDetails.maxSpeed)
                });
            }
            return analysedPeriods;
        }

        #endregion
    }
}