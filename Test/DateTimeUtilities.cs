using System;
using voidsoft.MicroRuntime;
using Xunit;

namespace Tests
{

	public class DateTimeUtilitiesTests
	{


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