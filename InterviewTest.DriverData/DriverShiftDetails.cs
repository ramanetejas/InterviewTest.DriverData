using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTest.DriverData
{
    public class DriverShiftDetails
    {
        public TimeSpan startTime { get; set; }
        public TimeSpan endTime { get; set; }
        public decimal maxSpeed { get; set; }
    }
}
