using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using voidsoft.MicroRuntime;

namespace Tests
{

	[TestClass]
	public class DateTimeUtilitiesTests
	{


		[TestMethod]
		public void IsLaterFalse()
		{
			Assert.IsFalse((new DateTimeUtilities()).IsLaterComparedWithNow(new DateTime(1990, 1, 1)));
		}


		[TestMethod]
		public void IsLaterCorrect()
		{
			Assert.IsTrue((new DateTimeUtilities()).IsLaterComparedWithNow(new DateTime(2200, 1, 1)));
		}

	}
}