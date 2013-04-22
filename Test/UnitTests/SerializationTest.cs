using NUnit.Framework;
using voidsoft.MicroRuntime;

namespace Tests
{
    public struct ATest
    {
        public int a;

        public int b;

        public string c;
    }


    [TestFixture]
    public class SerializationTest
    {
        [Test]
        public void SerializeToText()
        {
            ATest test = new ATest();
            test.a = 435;
            test.b = 33;
            test.c = "safsdfsdfsdf";


            Serialization serialization = new Serialization();
            string ggg = serialization.SerializeToText(test);

            Assert.IsTrue(ggg != null);
        }


        [Test]
        public void DeserializeFromText()
        {
            Serialization serialization = new Serialization();

            ATest test = (ATest) serialization.DeserializeFromText("a=435;b=33;c=safsdfsdfsdf;", typeof (ATest));

            //Assert.IsTrue(test != null);
        }
    }
}