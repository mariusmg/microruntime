using System;

namespace Microruntime
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Range<T> where T : IComparable<T>
    {
        private T start = default(T);

        private T end = default(T);


        /// <summary>
        /// Initializes a new instance of the <see cref="Range&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        public Range(T start, T end)
        {
            Start = start;
            End = end;
        }

     
        public static bool operator >(Range<T> range, Range<T> newRange)
        {
            int startComparationResult = range.Start.CompareTo(newRange.Start);

            int endComparationResult = range.End.CompareTo(newRange.End);

            return (startComparationResult == 1 && endComparationResult == 1) ? true : false;
        }


        public static bool operator <(Range<T> range, Range<T> newRange)
        {
            int startComparationResult = range.Start.CompareTo(newRange.Start);
            int endComparationResult = range.End.CompareTo(newRange.End);

            return (startComparationResult == -1 && endComparationResult == -1) ? true : false;
        }


        /// <summary>
        /// Operator == the specified range.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <param name="newRange">The new range.</param>
        /// <returns></returns>
        public static bool operator ==(Range<T> range, Range<T> newRange)
        {
            int startComparationResult = range.Start.CompareTo(newRange.Start);
            int endComparationResult = range.End.CompareTo(newRange.End);

            return (startComparationResult == 0 && endComparationResult == 0) ? true : false;
        }


        /// <summary>
        /// Operator !=s the specified range.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <param name="newRange">The new range.</param>
        /// <returns></returns>
        public static bool operator !=(Range<T> range, Range<T> newRange)
        {
            int startComparationResult = range.Start.CompareTo(newRange.Start);
            int endComparationResult = range.End.CompareTo(newRange.End);

            return (startComparationResult != 0 && endComparationResult != 0) ? true : false;
        }


        /// <summary>
        /// Determines whether [is in range] [the specified t].
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns>
        /// 	<c>true</c> if [is in range] [the specified t]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsInRange(T t)
        {
            int startComparationResult = Start.CompareTo(t);

            int endComparationResult = End.CompareTo(t);

            return ((startComparationResult == -1 || startComparationResult == 0) && (endComparationResult == 1 || endComparationResult == 0) ? true : false);
        }


        /// <summary>
        /// Gets or sets the start value
        /// </summary>
        /// <value>The start.</value>
        public T Start
        {
            get
            {
                return start;
            }
            set
            {
                start = value;
            }
        }

        /// <summary>
        /// Gets or sets the end value
        /// </summary>
        /// <value>The end.</value>
        public T End
        {
            get
            {
                return end;
            }
            set
            {
                end = value;
            }
        }
    }
}