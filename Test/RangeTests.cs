using voidsoft.MicroRuntime;
using Xunit;

namespace Tests
{
	public class RangeTests
	{
		private Range<int> end;
		private Range<int> start;

		public RangeTests()
		{
			start = new Range<int>(3, 5);
			end = new Range<int>(7, 9);
		}

		[Fact]
		public void IsBigger()
		{
			Assert.True(end > start);
		}

		[Fact]
		public void IsSmaller()
		{
			Assert.True(end > start);
		}

		[Fact]
		public void IsInRange()
		{
			Assert.True(start.IsInRange(5));
		}

		[Fact]
		public void IsDifferent()
		{
			Assert.True(start != end);
		}

		[Fact]
		public void IsTheSame()
		{
			Assert.True(start == new Range<int>(3, 5));
		}
	}
}