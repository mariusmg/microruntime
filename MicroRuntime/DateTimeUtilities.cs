using System;
using System.Runtime.CompilerServices;

namespace voidsoft.MicroRuntime
{
    
    /// <summary>
    /// DateTime utilities
    /// </summary>
    public static class DateTimeUtilities
    {
        /// <summary>
        /// Combines the specified date and time parts into a new DateTime
        /// </summary>
        /// <param name="datePart">The date part.</param>
        /// <param name="timePart">The time part.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static DateTime Combine(DateTime datePart, DateTime timePart)
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
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
        }

        
        
        /// <summary>
        /// Determines if a day is the last day of the given month
        /// </summary>
        /// <param name="month">The month of the year 1-12</param>
        /// <param name="day">The day of the month 1-31</param>
        /// <param name="year">The four-digit year</param>
        /// <returns></returns>
        /// <remarks>Properly handles February with regard to leap years. All dates must be valid.</remarks>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static bool IsLastDayOfMonth(int month, int day, int year)
        {
            int[] lastDay = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            if (2 == month)
            {
                return (29 == day) || (28 == day && !IsLeapYear(year));
            }
            else if (1 <= month && month <= 12)
            {
                return (day == lastDay[month - 1]);
            }
            else
            {
                throw new ArgumentOutOfRangeException("month", month, "should be 1 to 12");
            }
        }

        

    }
}