using System.Collections.Generic;
using System.Linq;
using Microruntime;
using Xunit;

namespace Tests
{
	public class TypeInstanceTests
	{
		[Fact]
		public void CreateInstance()
		{
			IFoo f =	new TypeInstance().CreateInstance<IFoo>("Tests.Foo.SuperFoo,c:\\Tests.Foo.dll");
			Assert.True(f != null);
			f.DoTheFoo();
		}

		[Fact]
		public void CreateInstanceWithArguments()
		{

			Dictionary<string,string> gg = new Dictionary<string, string>();
			gg.Add("test","glx");

			ITestParameter fx = new TypeInstance().CreateInstance<ITestParameter>("Tests.Foo.TestParameter,c:\\Tests.Foo.dll", gg);
			Assert.True(fx != null);
			Assert.True(fx.FF != null);
			Assert.True(fx.FF.Keys.FirstOrDefault() == "test");
			fx.DoTheFoo();

		}

	}
}