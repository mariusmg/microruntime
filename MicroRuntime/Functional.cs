using System;
using System.Collections.Generic;

namespace MicroRuntime
{
	public static class Functional
	{

		public static void Run<T>(T t, Predicate<T> p, Action action)
		{
			if (p(t))
			{
				action();
			}
		}

		public static void RunIfNonEmpty(string parameter, Action action)
		{
			if (!string.IsNullOrEmpty(parameter))
			{
				action();
			}
		}

		public static void RunIfNonEmpty<T>(string parameter, T t, Action<T> action)
		{
			if (!string.IsNullOrEmpty(parameter))
			{
				action(t);
			}
		}

		public static void RunIfNull<T>(T t, Action action) where T : class
		{
			if (t == null)
			{
				action();
			}
		}

		public static void RunIfNotNull<T>(T t, Action action) where T : class
		{
			if (t != null)
			{
				action();
			}
		}

		public static void RunIfHasDefaultValue<T>(T t, Action action) where T : struct
		{
			if (EqualityComparer<T>.Default.Equals(t, default(T)))
			{
				action();
			}
		}

		public static void RunIfDoesntHaveDefaultValue<T>(T t, Action action) where T : struct
		{
			if (EqualityComparer<T>.Default.Equals(t, default(T)) == false)
			{
				action();
			}
		}
	}
}