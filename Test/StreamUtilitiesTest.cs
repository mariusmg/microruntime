using System.IO;
using System.Text;
using Microruntime;
using Xunit;

namespace Tests
{
	public class StreamUtilitiesTest
	{

		[Fact]
		public void GetStreamFromText()
		{
			Stream stream = new StreamUtilities().ToStream("aadsdasdasdasdasda", Encoding.Unicode);
			Assert.True(stream != null);
			Assert.True(stream.Length > 1);
		}


		[Fact]
		public void GetStreamFromBytes()
		{
			byte[] b = {1, 2, 3, 4, 5};
			Stream stream = new StreamUtilities().ToStream(b);
			Assert.True(stream != null);
			Assert.True(stream.Length > 1);
		}


	}
}