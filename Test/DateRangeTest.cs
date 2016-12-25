using System;
using Microruntime;
using Xunit;

namespace Tests
{
	public class DateRangeTest
	{
		private DateRange range;

		public DateRangeTest()
		{
			range = new DateRange(new DateTime(2000, 1, 1), new DateTime(2000, 12, 1));
		}

		[Fact]
		public void GetMonths()
		{
			Assert.True(range.Months == 12);
		}


		[Fact]
		public void GetDays()
		{
			DateRange r = new DateRange(DateTime.Now, DateTime.Now.AddDays(4));
			Assert.True(r.Days == 5);
		}

	}
}