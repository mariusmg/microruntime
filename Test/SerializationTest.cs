using Microruntime;
using Xunit;

namespace Tests
{
	public struct ATest
	{
		public int a;

		public int b;

		public string c;
	}

	public class SerializationTest
	{
		[Fact]
		public void SerializeToText()
		{
			ATest test = new ATest();
			test.a = 435;
			test.b = 33;
			test.c = "safsdfsdfsdf";

			Serialization serialization = new Serialization();
			string ggg = serialization.SerializeToText(test);

			Assert.True(ggg != null);
		}

		[Fact]
		public void DeserializeFromText()
		{
			Serialization serialization = new Serialization();

			ATest test = (ATest) serialization.DeserializeFromText("a=435;b=33;c=safsdfsdfsdf;", typeof (ATest));

			//Assert.IsTrue(test != null);
		}
	}
}