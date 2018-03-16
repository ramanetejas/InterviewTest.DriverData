using System;
using System.Diagnostics;

namespace InterviewTest.DriverData
{
	[DebuggerDisplay("{_DebuggerDisplay,nq}")]
	public class Period
	{
        /* 
         * A DateTime value represents a particular calendar date and time for different timezones.         
         * The DateTimeOffset value represents  a point in time which is universal for everyone, indexpendent of timezones
         */
        public DateTimeOffset Start;
		public DateTimeOffset End;

        // BONUS: What's the difference between decimal and double?
        /*
         * Decimal is 128 bit, it stores values as a floating decimal point type.
         * Double is 64 bit and will store the value as binary floating point type.
         * Decimals have higher precision than Double hence we use decimal in our application
        */
        public decimal AverageSpeed;

		private string _DebuggerDisplay => $"{Start:t} - {End:t}: {AverageSpeed}";
	}
}
