using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Foo
{
	public class SuperFoo : MarshalByRefObject, IFoo
	{
		public void DoTheFoo()
		{
			Debug.WriteLine("SuperFoo");
			Trace.WriteLine("SuperFoo");
		}
	}
}
