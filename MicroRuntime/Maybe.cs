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

		public T Value
		{
			get
			{
				return t;
			}
			set
			{
				t = value;
			}
		}

		public bool HasValue
		{
			get
			{
				return hasValue;
			}
		}

	}
}