using Microruntime;
using Xunit;

namespace Tests
{
	public class MaybeTest
	{
		[Fact]
		public void ValueTypeInvalid()
		{
			Maybe<int>  m = new Maybe<int>();
			Assert.False(m.HasValue);
		}



		[Fact]
		public void ReferenceTypeInvalid()
		{
			Maybe<MaybeTest> m = new Maybe<MaybeTest>();
			Assert.False(m.HasValue);
			Assert.True(m.Value == null);
		}


		[Fact]
		public void ReferenceType()
		{
			Maybe<MaybeTest> m = new Maybe<MaybeTest>( new MaybeTest());
			Assert.True(m.HasValue);
			Assert.True(m.Value != null);
		}


	}
}