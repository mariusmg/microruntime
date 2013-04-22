using NUnit.Framework;
using voidsoft.MicroRuntime;

namespace Tests
{
    [TestFixture()]
    public class RangeTests
    {
        private Range<int> start = null;
        private Range<int> end = null;


        [TestFixtureSetUp]
        public void SetUp()
        {
            start = new Range<int>(3, 5);
            end = new Range<int>(7, 9);
        }


        [Test]
        public void IsBigger()
        {
            Assert.IsTrue(end > start);
        }

        [Test]
        public void IsSmaller()
        {
            Assert.IsTrue(end > start);
        }


        [Test]
        public void IsInRange()
        {
            Assert.IsTrue(start.IsInRange(5));
        }

        [Test]
        public void IsDifferent()
        {
            Assert.IsTrue(start != end);
        }


        [Test]
        public void IsTheSame()
        {
            Assert.IsTrue(start == new Range<int>(3, 5));
        }
    }
}