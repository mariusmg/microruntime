using System;
using Microruntime;
using Xunit;

namespace Tests
{

	public class DateTimeUtilitiesTest
	{
		[Fact]
		public void IsToday()
		{
			Assert.True(new DateTimeUtilities().IsToday(DateTime.Now));
		}

		[Fact]
		public void IsTodayInvalid()
		{
			Assert.False(new DateTimeUtilities().IsToday(DateTime.Now.AddDays(2)));
		}

		[Fact]
		public void IsLaterFalse()
		{
			Assert.False((new DateTimeUtilities()).IsLaterComparedWithNow(new DateTime(1990, 1, 1)));
		}


		[Fact]
		public void IsLaterCorrect()
		{
			Assert.True((new DateTimeUtilities()).IsLaterComparedWithNow(new DateTime(2200, 1, 1)));
		}

	}
}