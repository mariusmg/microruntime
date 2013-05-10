using System;

namespace voidsoft.MicroRuntime
{
	/// <summary>
	///     Utilities for manipulating multidimensional arrays
	/// </summary>
	public class MultidimensionalArray
	{
		/// <summary>
		///     Gets the values on diagonal from a multimensional array.
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		public object[] GetDiagonalValues(Array a)
		{
			int length = VerifyArrayAndGetLength(a);
			return GetArrayValues(a, length, true);
		}

		/// <summary>
		///     Gets the values from reversed diagonal form a multidimensional array
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		public object[] GetReverseDiagonalValues(Array a)
		{
			int length = VerifyArrayAndGetLength(a);
			return GetArrayValues(a, length, false);
		}

		private object[] GetArrayValues(Array a, int length, bool fromStart)
		{
			object[] values = new object[length];

			if (fromStart)
			{
				for (int i = 0; i < length; i++)
				{
					values[i] = a.GetValue(i, i);
				}

				return values;
			}

			for (int i = length; i-- > 0;)
			{
				values[length - (i + 1)] = a.GetValue(i, i);
			}

			return values;
		}

		private int VerifyArrayAndGetLength(Array a)
		{
			int rank = a.Rank;

			int length = -1;

			for (int i = 0; i < rank; i++)
			{
				int l = a.GetLength(i);

				if (length == -1)
				{
					length = l;
					continue;
				}

				if (length != l)
				{
					throw new ArgumentException("Array must have the same length for all dimensions");
				}
			}

			return length;
		}
	}
}