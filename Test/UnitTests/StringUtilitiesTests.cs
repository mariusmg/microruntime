using NUnit.Framework;
using voidsoft.MicroRuntime;

namespace Tests
{
    [TestFixture]
    public class StringUtilitiesTests
    {
        [Test]
        public void IsInteger()
        {
            Assert.IsTrue(StringUtilities.IsInteger("1"));
        }


        [Test]
        public void IsIntegerWithString()
        {
            bool res = StringUtilities.IsInteger("sdfdsfds");
            Assert.IsTrue(res == false);
        }


        [Test]
        public void IsNegativeNumber()
        {
            string s = "-45645645456";
            Assert.IsTrue(StringUtilities.IsNegativeNumber(s));
        }
        
        
        
    }
}