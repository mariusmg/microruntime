using Microruntime;
using Xunit;

namespace Tests
{
	public class TypeInstanceTests
	{
		[Fact]
		public void CreateInstance()
		{
			IFoo f =	new TypeInstance().CreateInstance<IFoo>("Tests.Foo.SuperFoo,Tests.Foo.dll");
			Assert.True(f != null);
			f.DoTheFoo();
		}
	}
}