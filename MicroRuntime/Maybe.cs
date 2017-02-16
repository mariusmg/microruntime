namespace Microruntime
{
	public class Maybe<T> where T : class
	{
		private T t;
		private bool hasValue;

		public Maybe()
		{
		}

		public Maybe(T t)
		{
			this.t = t;
			hasValue = t != null;
		}

		public static Maybe<T> Empty()
		{
			return new Maybe<T>();
		}

		public T Value => t;

		public bool HasValue => hasValue;
	}
}