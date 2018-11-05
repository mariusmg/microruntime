
using Microruntime;
using Xunit;

namespace Tests
{


	public class TestA
	{
		
	}

	public class TestB
	{

	}

	public class TestC
	{

	}

	public class DiscriminatedResultTest
	{

		[Fact]
		public void TestDiscrimatedDoubleResult()
		{
			DiscriminatedResult<TestA, TestB> result = new DiscriminatedResult<TestA, TestB>();
			result.Set(new TestA());

			Assert.True(result.IsTA);
			Assert.True(result.IsTB == false);
			Assert.True(result.AsTA != null);
			Assert.True(result.AsTB == null);


			DiscriminatedResult<TestA, TestB> resultB = new DiscriminatedResult<TestA, TestB>(new TestB());

			Assert.True(resultB.IsTB);
			Assert.True(resultB.IsTA == false);
			Assert.True(resultB.AsTB != null);
			Assert.True(resultB.AsTA == null);


			DiscriminatedResult<TestA, TestB> resultInstance = new DiscriminatedResult<TestA, TestB>(new TestB());
			resultInstance.Set(new TestA() );
			resultInstance.Set(new TestB() );

			Assert.True(resultB.IsTB);
			Assert.True(resultB.IsTA == false);



			DiscriminatedResult<TestA, int> resultMixed = new DiscriminatedResult<TestA, int>();
			resultMixed.Set(new TestA());
			resultMixed.Set(77);

			Assert.True(resultMixed.IsTB);
			Assert.True(resultMixed.IsTA == false);




			DiscriminatedResult<byte, int> resultX = new DiscriminatedResult<byte, int>();
			resultX.Set(2);
			resultX.Set(77);

			Assert.True(resultX.IsTB);
			Assert.True(resultX.IsTA == false);


		}
	}
}
