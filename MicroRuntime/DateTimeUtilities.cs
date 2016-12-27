using System;

namespace Microruntime
{
	/// <summary>
	/// DateTime utilities
	/// </summary>
	public class DateTimeUtilities
	{
		public bool IsSameDay(DateTime first, DateTime second)
		{
			if (first.Day == second.Day && first.Month == second.Month && first.Year == second.Year)
			{
				return true;
			}

			return false;
		}

		public bool IsToday(DateTime d)
		{
			DateTime now = DateTime.Now;

			if (d.Date.Day == now.Day && d.Date.Month == now.Month && d.Date.Year == now.Year)
			{
				return true;
			}

			return false;
		}

		public bool IsNowPastThisDay(DateTime day)
		{
			if (DateTime.UtcNow.CompareTo(day) > 0)
			{
				return true;
			}

			return false;
		}




		public bool IsLaterThanNow(DateTime date)
		{
			if (DateTime.UtcNow.CompareTo(date) < 0)
			{
				return true;
			}

			return false;

		}

		/// <summary>
		/// Combines the specified date and time parts into a new DateTime
		/// </summary>
		/// <param name="datePart">The date part.</param>
		/// <param name="timePart">The time part.</param>
		/// <returns></returns>
		public DateTime Combine(DateTime datePart, DateTime timePart)
		{
			return new DateTime(datePart.Year, datePart.Month, datePart.Day, timePart.Hour, timePart.Minute, timePart.Second, timePart.Millisecond);
		}

		/// <summary>
		/// Determines whether the specified year is leap
		/// </summary>
		/// <param name="year">The year.</param>
		/// <returns>
		/// 	<c>true</c> if [is leap year] [the specified year]; otherwise, <c>false</c>.
		/// </returns>
		public bool IsLeapYear(int year)
		{
			return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
		}

		/// <summary>
		/// Determines if a day is the last day of the given month
		/// </summary>
		/// <param name="month">The month of the year 1-12</param>
		/// <param name="day">The day of the month 1-31</param>
		/// <param name="year">The four-digit year</param>
		/// <returns></returns>
		/// <remarks>Properly handles February with regard to leap years. All dates must be valid.</remarks>
		public bool IsLastDayOfMonth(int month, int day, int year)
		{
			int[] lastDay = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

			if (2 == month)
			{
				return (29 == day) || (28 == day && !IsLeapYear(year));
			}
			if (1 <= month && month <= 12)
			{
				return (day == lastDay[month - 1]);
			}
			throw new ArgumentOutOfRangeException("month", month, "should be 1 to 12");
		}
	}
}