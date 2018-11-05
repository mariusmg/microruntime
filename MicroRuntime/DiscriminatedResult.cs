
namespace Microruntime
{

	enum DoubleValueSet
	{
		NotSet = 0,
		A = 1,
		B = 2
	}

	enum TripleValueSet
	{
		NotSet = 0,
		A = 1,
		B = 2,
		C = 3
	}

	enum QuadrupleValueSet
	{
		NotSet = 0,
		A = 1,
		B = 2,
		C = 3,
		D = 4
	}

	public class DiscriminatedResult<TA, TB>
	{
		private TA a;
		private TB b;

		private DoubleValueSet set = DoubleValueSet.NotSet;



		public DiscriminatedResult()
		{
			this.a = default(TA);
			this.b = default(TB);
		}

		public DiscriminatedResult(TA instance)
		{
			this.a = instance;
			this.b = default(TB);
			set = DoubleValueSet.A;
		}

		public DiscriminatedResult(TB instance)
		{
			this.b = instance;
			this.a = default(TA);
			set = DoubleValueSet.B;
		}


		public void Set(TA instance)
		{
			this.a = instance;
			this.b = default(TB);
			set = DoubleValueSet.A;
		}

		public void Set(TB instance)
		{
			this.b = instance;
			this.a = default(TA);
			set = DoubleValueSet.B;
		}

		public bool IsTA => set ==  DoubleValueSet.A;
		public bool IsTB => set == DoubleValueSet.B;

		public TA AsTA => a;
		public TB AsTB => b;
	}


	public class DiscriminatedResult<TA, TB, TC>
	{
		private TA a;
		private TB b;
		private TC c;

		private TripleValueSet set = TripleValueSet.NotSet;


		public DiscriminatedResult()
		{
			this.a = default(TA);
			this.b = default(TB);
			this.c = default(TC);
		}

		public DiscriminatedResult(TA instance)
		{
			this.a = instance;
			this.b = default(TB);
			this.c = default(TC);
			set = TripleValueSet.A;
		}

		public DiscriminatedResult(TB instance)
		{
			this.b = instance;
			this.a = default(TA);
			this.c = default(TC);
			set = TripleValueSet.B;
		}

		public DiscriminatedResult(TC instance)
		{
			this.c = instance;
			this.a = default(TA);
			this.b = default(TB);
			set = TripleValueSet.C;
		}


		public void Set(TA instance)
		{
			this.a = instance;
			this.b = default(TB);
			this.c = default(TC);
			set = TripleValueSet.A;
		}

		public void Set(TB instance)
		{
			this.b = instance;
			this.a = default(TA);
			this.c = default(TC);
			set = TripleValueSet.B;
		}

		public void Set(TC instance)
		{
			this.c = instance;
			this.a = default(TA);
			this.b = default(TB);
			set = TripleValueSet.C;
		}

		public bool IsTA => set == TripleValueSet.A;
		public bool IsTB => set == TripleValueSet.B;
		public bool IsTC => set == TripleValueSet.C;

		public TA AsTA => a;
		public TB AsTB => b;
		public TC AsTC => c;
	}


	public class DiscriminatedResult<TA, TB, TC, TD>
	{
		private TA a;
		private TB b;
		private TC c;
		private TD d;

		private QuadrupleValueSet set = QuadrupleValueSet.NotSet;


		public DiscriminatedResult()
		{
			this.a = default(TA);
			this.b = default(TB);
			this.c = default(TC);
			this.d = default(TD);
		}

		public DiscriminatedResult(TA instance)
		{
			this.a = instance;
			this.b = default(TB);
			this.c = default(TC);
			this.d = default(TD);
			set = QuadrupleValueSet.A;
		}

		public DiscriminatedResult(TB instance)
		{
			this.b = instance;
			this.a = default(TA);
			this.c = default(TC);
			this.d = default(TD);
			set = QuadrupleValueSet.B;
		}

		public DiscriminatedResult(TC instance)
		{
			this.c = instance;
			this.a = default(TA);
			this.b = default(TB);
			this.d = default(TD);
			set = QuadrupleValueSet.C;
		}


		public void Set(TA instance)
		{
			this.a = instance;
			this.b = default(TB);
			this.c = default(TC);
			this.d = default(TD);
			set = QuadrupleValueSet.A;
		}

		public void Set(TB instance)
		{
			this.b = instance;
			this.a = default(TA);
			this.c = default(TC);
			this.d = default(TD);
			set = QuadrupleValueSet.B;
		}

		public void Set(TC instance)
		{
			this.c = instance;
			this.a = default(TA);
			this.b = default(TB);
			this.d = default(TD);
			set = QuadrupleValueSet.C;
		}

		public void Set(TD instance)
		{
			this.d = instance;
			this.a = default(TA);
			this.b = default(TB);
			this.c = default(TC);
			set = QuadrupleValueSet.C;
		}

		public bool IsTA => set == QuadrupleValueSet.A;
		public bool IsTB => set == QuadrupleValueSet.B;
		public bool IsTC => set == QuadrupleValueSet.C;
		public bool IsTD => set == QuadrupleValueSet.D;

		public TA AsTA => a;
		public TB AsTB => b;
		public TC AsTC => c;
		public TD AsTD => d;
	}

}
