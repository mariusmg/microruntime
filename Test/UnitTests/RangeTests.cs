using Microsoft.VisualStudio.TestTools.UnitTesting;
using voidsoft.MicroRuntime;

namespace Tests
{
	[TestClass]
	public class RangeTests
	{
		private Range<int> end;
		private Range<int> start;

		[TestInitialize]
		public void SetUp()
		{
			start = new Range<int>(3, 5);
			end = new Range<int>(7, 9);
		}

		[TestMethod]
		public void IsBigger()
		{
			Assert.IsTrue(end > start);
		}

		[TestMethod]
		public void IsSmaller()
		{
			Assert.IsTrue(end > start);
		}

		[TestMethod]
		public void IsInRange()
		{
			Assert.IsTrue(start.IsInRange(5));
		}

		[TestMethod]
		public void IsDifferent()
		{
			Assert.IsTrue(start != end);
		}

		[TestMethod]
		public void IsTheSame()
		{
			Assert.IsTrue(start == new Range<int>(3, 5));
		}
	}
}