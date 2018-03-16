using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTest.DriverData.Helpers
{
    static class LinearRatingCalculator
    {
        /// <summary>
        /// Calculates linear rating based on speed and maximum speed
        /// </summary>
        /// <param name="maxSpeed"></param>
        /// <returns></returns>
        public static decimal CalculateLinearRating(this decimal speed, decimal maxSpeed)
        {
            return speed > 0 ? speed / maxSpeed : 0;
        }
    }
}
