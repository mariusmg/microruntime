using Microsoft.VisualStudio.TestTools.UnitTesting;
using voidsoft.MicroRuntime;

namespace Tests
{
	[TestClass]
	public class StringUtilitiesTests
	{
		[TestMethod]
		public void IsInteger()
		{
			Assert.IsTrue((new StringUtilities()).IsInteger("1"));
		}

		[TestMethod]
		public void IsIntegerWithString()
		{
			bool res = (new StringUtilities()).IsInteger("sdfdsfds");
			Assert.IsTrue(res == false);
		}

		[TestMethod]
		public void IsNegativeNumber()
		{
			string s = "-45645645456";
			Assert.IsTrue((new StringUtilities()).IsNegativeNumber(s));
		}
	}
}