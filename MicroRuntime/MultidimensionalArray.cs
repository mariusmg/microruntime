using System;

namespace voidsoft.MicroRuntime
{
	public class MultidimensionalArray
	{
		public object[] GetDiagonalValues(Array a)
		{
			int length = VerifyArrayAndGetLength(a);
			return GetArrayValues(a, length, true);
		}

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