using Microruntime;
using Xunit;

namespace Tests
{
	public class StringUtilitiesTests
	{
		[Fact]
		public void IsInteger()
		{
			Assert.True((new StringUtilities()).IsInteger("1"));
		}

		[Fact]
		public void IsIntegerWithString()
		{
			bool res = (new StringUtilities()).IsInteger("sdfdsfds");
			Assert.True(res == false);
		}

		[Fact]
		public void IsNegativeNumber()
		{
			string s = "-45645645456";
			Assert.True((new StringUtilities()).IsNegativeNumber(s));
		}
	}
}