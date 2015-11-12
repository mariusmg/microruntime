using System;
using System.Collections.Generic;

namespace voidsoft.MicroRuntime
{
	public class DateRange : Range<DateTime>
	{
		public DateRange(DateTime start, DateTime end) : base(start, end)
		{
		}

		public void ForEachDay(Action<DateTime> action)
		{
			DateTime temp = Start;

			while (temp <= End)
			{
				temp = temp.AddDays(1);
				action(temp);
			}
		}

		/// <summary>
		/// Gets the enumerator.
		/// </summary>
		/// <returns></returns>
		public IEnumerator<DateTime> GetEnumerator()
		{
			DateTime temp = Start;
			temp = temp.AddDays(1);

			while (temp <= End)
			{
				yield return temp;
				temp = temp.AddDays(1);
			}
		}

		/// <summary>
		/// Gets the months.
		/// </summary>
		/// <value>The months.</value>
		public int Months
		{
			get
			{
				int counter = 0;

				DateTime temp = Start;

				while (temp <= End)
				{
					temp = temp.AddMonths(1);
					++counter;
				}

				return counter;
			}
		}

		/// <summary>
		/// Gets the days.
		/// </summary>
		/// <value>The days.</value>
		public int Days
		{
			get
			{
				int counter = 0;

				DateTime temp = Start;

				while (temp <= End)
				{
					temp = temp.AddDays(1);
					++counter;
				}

				return counter;
			}
		}
	}
}