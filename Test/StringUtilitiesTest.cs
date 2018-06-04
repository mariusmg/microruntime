using Microruntime;
using Xunit;

namespace Tests
{
	public class StringUtilitiesTest
	{

		[Fact]

		public void IsSameString()
		{
			string s = "test";

			Assert.True(new StringUtilities().IsSameString(s,s));
		}

		[Fact]
		public void IsSameStringIgnoreCaseSensitive()
		{
			string s = "test";
			string d = "TEST";

			Assert.True(new StringUtilities().IsSameString(s, d, false));
		}

		[Fact]
		public void IsSameStringCaseSensitive()
		{
			string s = "test";
			string d = "TEST";

			Assert.False(new StringUtilities().IsSameString(s, d, true));
		}

		[Fact]
		public void IsInteger()
		{
			Assert.True(new StringUtilities().IsInteger("1"));
		}

		[Fact]
		public void IsIntegerWithString()
		{
			bool res = new StringUtilities().IsInteger("sdfdsfds");
			Assert.True(res == false);
		}

		[Fact]
		public void IsNegativeNumber()
		{
			string s = "-45645645456";
			Assert.True(new StringUtilities().IsNegativeNumber(s));
		}

		[Fact]
		public void IsNegativeNumberInvalid()
		{
			string s = "22";
			Assert.False(new StringUtilities().IsNegativeNumber(s));
		}
	}
}