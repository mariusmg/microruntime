using Microsoft.VisualStudio.TestTools.UnitTesting;
using voidsoft.MicroRuntime;

namespace Tests
{

	[TestClass]
	public class MultidimensionalArrayTests
	{
		
		[TestMethod]
		public void GetDiagonal()
		{
			int[,] f = new int[5,5];

			int[] expectedResult = {0, 1, 2, 3, 4};
			
			for (int i = 0; i < f.GetLength(0); i++)
			{
				for (int j = 0; j < f.GetLength(1); j++)
				{
					f[i, j] = i;
				}
			}

			object[] diagonalValues = (new MultidimensionalArray()).GetDiagonalValues(f);

			Assert.IsTrue(diagonalValues.Length == expectedResult.Length);

			for (int i = 0; i < expectedResult.Length; i++)
			{
				Assert.IsTrue(expectedResult[i] == (int)diagonalValues[i]);
			}
		}



		[TestMethod]
		public void GetReverseDiagonal()
		{
			int[,] f = new int[5, 5];

			int[] expectedResult = { 4, 3, 2, 1, 0 };

			for (int i = 0; i < f.GetLength(0); i++)
			{
				for (int j = 0; j < f.GetLength(1); j++)
				{
					f[i, j] = i;
				}
			}

			object[] diagonalValues = (new MultidimensionalArray()).GetReverseDiagonalValues(f);

			Assert.IsTrue(diagonalValues.Length == expectedResult.Length);

			for (int i = 0; i < expectedResult.Length; i++)
			{
				Assert.IsTrue(expectedResult[i] == (int)diagonalValues[i]);
			}
		}
	}
}