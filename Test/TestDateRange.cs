using System;
using voidsoft.MicroRuntime;
using Xunit;

namespace Tests
{
	public class TestDateRange
	{
		private DateRange end;
		private DateRange start;

		public TestDateRange()
		{
			start = new DateRange(new DateTime(2000, 1, 1), new DateTime(2000, 12, 1));
			start = new DateRange(new DateTime(2004, 1, 1), new DateTime(2004, 12, 1));
		}

		[Fact]
		public void GetMonthscount()
		{
			Console.WriteLine(start.Months.ToString());
			Assert.True(start.Months == 12);
		}
	}
}