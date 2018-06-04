using System.Drawing;
using MicroRuntime;
using Xunit;

namespace Tests
{
	public class FunctionalTest
	{


		[Fact]
		public void RunWithDefaultValueInverted()
		{
			int x = 5;

			string ff = string.Empty;
			
			Functional.RunIfHasDefaultValue<int>(x, () => { ff = "b"; });

			Assert.True(string.IsNullOrEmpty(ff));
		}


		[Fact]
		public void RunWithDefaultValue()
		{
			int x = 0;

			string ff = string.Empty;

		
			Functional.RunIfHasDefaultValue<int>(x, () => { ff = "b"; });
			
			Assert.True(ff == "b");
		}


		[Fact]
		public void DontRun()
		{
			Bitmap b = new Bitmap(100,100);

			string ff = string.Empty;

			Functional.Run(b, bitmap =>
			{
				return bitmap == null;
			}, () =>
			{
				ff = "b";
			});

			Assert.True( string.IsNullOrEmpty(ff));
		}


		[Fact]
		public void RunInverted()
		{
			Bitmap b = null;

			string ff = string.Empty;

			Functional.Run(b, bitmap =>
			{
				return bitmap == null;
			}, () =>
			{
				ff = "b";
			});

			Assert.True(ff == "b");
		}


		[Fact]
		public void Run()
		{
			Bitmap b = new Bitmap(100,100);
			
			string ff = string.Empty;

			Functional.Run(b, bitmap =>
			{
				return bitmap != null;
			}, () =>
			{
				ff = "b";
			} );

			Assert.True(ff == "b");

		}



		[Fact]
		public void RunIfEmpty()
		{
			Bitmap b = null;
			string ff = string.Empty;

			Functional.RunIfNull(b, () =>
			{
				ff = "b";
			});

			Assert.True(ff == "b");
		}

		[Fact]
		public void RunIfNotNull()
		{
			Bitmap b = new Bitmap(100,100);
			string ff = string.Empty;

			Functional.RunIfNotNull(b, () =>
			{
				ff = "b";
			});

			Assert.True(ff == "b");
		}


		[Fact]
		public void RunIfNonEmpty()
		{
			string s = "a";
			string ff = string.Empty;

			Functional.RunIfNonEmpty(s, () =>
			{
				ff = "b";
			});

			Assert.True(ff == "b");
		}


		[Fact]
		public void RunIfNonEmptyGenericParameter()
		{
			string s = "x";
			string ff = string.Empty;

			Bitmap b = new Bitmap(100,100);

			Functional.RunIfNonEmpty(s, b, bitmap =>
			{
				Assert.NotNull(bitmap);
				ff = "b";
			});

			Assert.True(ff == "b");
		}


	}
}