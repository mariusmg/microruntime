using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using voidsoft.MicroRuntime;

namespace Tests
{
	[TestClass]
	public class TestDateRange
	{
		private DateRange end;
		private DateRange start;

		[TestInitialize]
		public void SetUp()
		{
			start = new DateRange(new DateTime(2000, 1, 1), new DateTime(2000, 12, 1));
			start = new DateRange(new DateTime(2004, 1, 1), new DateTime(2004, 12, 1));
		}

		[TestMethod]
		public void TestEnumeration()
		{
			int counter = 0;
			foreach (DateTime o in start)
			{
				Console.WriteLine(o.ToShortDateString());

				++counter;
			}

			Assert.IsTrue(counter == start.Days);
		}

		[TestMethod]
		public void GetMonthscount()
		{
			Console.WriteLine(start.Months.ToString());
			Assert.IsTrue(start.Months == 12);
		}
	}
}