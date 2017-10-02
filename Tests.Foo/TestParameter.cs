using System.Collections.Generic;
using System.Diagnostics;

namespace Tests.Foo
{
	public class TestParameter : ITestParameter
	{
		private Dictionary<string, string> ags;

		public TestParameter(Dictionary<string, string> a)
		{
			ags = a;
		}

		public void DoTheFoo()
		{

		}

		public Dictionary<string, string> FF => ags;
	}
}