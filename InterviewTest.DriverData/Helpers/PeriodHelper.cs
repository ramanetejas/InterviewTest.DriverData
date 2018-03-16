using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTest.DriverData.Helpers
{
    static class PeriodHelper
    {
        /// <summary>
        /// Analyses undocumented periods if any within the shift timing.
        /// </summary>
        /// <param name="analyzedPeriods"></param>
        /// <param name="totalShiftDuration"></param>
        /// <returns></returns>
        public static PeriodAnalysis AnalyseUndocumentedPeriods(this IEnumerable<PeriodAnalysis> analyzedPeriods, TimeSpan totalShiftDuration)
        {
            var periodAnalysis = new PeriodAnalysis();
            var unDocumentedPeriod = totalShiftDuration.Ticks - analyzedPeriods.Sum(x => x.Duration);
            if (unDocumentedPeriod > 0)
            {
                periodAnalysis.Duration = unDocumentedPeriod;
                periodAnalysis.Rating = 0;
                periodAnalysis.isUndocumentedPeriod = true;
            }
            return periodAnalysis;
        }

        /// <summary>
        /// Checks if there are any undocumented periods within the shift timing.
        /// </summary>
        /// <param name="analyzedPeriods"></param>
        /// <param name="totalShiftDuration"></param>
        /// <returns></returns>
        public static bool HasUndocumentedPeriods(this IEnumerable<PeriodAnalysis> analyzedPeriods, TimeSpan totalShiftDuration)
        {
            var unDocumentedPeriod = totalShiftDuration.Ticks - analyzedPeriods.Sum(x => x.Duration);
            if (unDocumentedPeriod > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Fetches history periods within the shift timing.
        /// </summary>
        /// <param name="history"></param>
        /// <param name="shiftStartTime"></param>
        /// <param name="shiftEndTime"></param>
        /// <returns></returns>
        public static IEnumerable<Period> GetValidPeriods(this IEnumerable<Period> history,DateTimeOffset shiftStartTime, DateTimeOffset shiftEndTime)
        {
            return history.Where(m => m.End > shiftStartTime && m.Start < shiftEndTime);
        }

        /// <summary>
        /// Calculates total analyzed duration excluding undocumented periods
        /// </summary>
        /// <param name="analyzedPeriods"></param>
        /// <returns></returns>
        public static TimeSpan GetTotalAnayzedDuration(this IEnumerable<PeriodAnalysis> analyzedPeriods)
        {
            return new TimeSpan(analyzedPeriods.Where(x => !x.isUndocumentedPeriod).Sum(r => r.Duration));
        }

        /// <summary>
        /// Calculates the overall rating from given list of analysed periods
        /// </summary>
        /// <param name="analysedPeriods"></param>
        /// <returns></returns>
        public static decimal CalculateOverallRating(this IEnumerable<PeriodAnalysis> analysedPeriods)
        {
            //Calculate the weighted sum by taking total of products of durations and ratings
            var weightedSum = analysedPeriods.Select(x => x.Duration * x.Rating).Sum();
            //Calculate overall rating by dividing the weighted sum by total duration including undocumented periods.

            return weightedSum > 0 ? weightedSum / analysedPeriods.Sum(x => x.Duration) : 0;
        }
    }
}
