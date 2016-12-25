using System.CodeDom;

namespace Microruntime
{
	public class Maybe<T>
	{

		private T t = default(T);
		private bool hasValue = false;

		public Maybe()
		{

		}

		public Maybe(T t)
		{
			this.t = t;
			hasValue = true;
		}


		public static Maybe<T> Empty()
		{
			return new Maybe<T>();
		}

		public T Value => t;

		public bool HasValue => hasValue;
	}
}