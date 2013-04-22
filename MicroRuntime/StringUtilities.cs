
using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace voidsoft.MicroRuntime
{
    /// <summary>
    /// String utilities
    /// </summary>
    public static class StringUtilities
    {
        /// <summary>
        ///Check if the specified string is a number
        /// </summary>
        /// <param name="input"></param>
        /// <returns>True if string is a valid integer</returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static bool IsInteger(string input)
        {
            if (input.Length == 0)
            {
                return false;
            }

            for (int index = 0; index < input.Length; index++)
            {
                if (!Char.IsNumber(input[index]))
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// Procedure to test for Positive Integers
        /// </summary>
        /// <param name="number">String to check</param>
        /// <returns>True if the specified string is a valid positive number</returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static bool IsPositiveNumber(string number)
        {
            Regex notNaturalPattern = new Regex("[^0-9]");
            Regex naturalPattern = new Regex("0*[0-9][0-9]*");

            return !notNaturalPattern.IsMatch(number) && naturalPattern.IsMatch(number);
        }



        /// <summary>
        /// Determines whether [is negative number] [the specified number].
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        /// 	<c>true</c> if [is negative number] [the specified number]; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static bool IsNegativeNumber(string number)
        {
            if (number.Length == 0)
            {
                return false;
            }

            double value = 0;


            return (Double.TryParse(number, out value) && number.StartsWith("-")) ? true : false;
        }


        /// <summary>
        /// Determines whether the specified string is multiline
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// 	<c>true</c> if [is multi line] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static bool IsMultiLine(string value)
        {
            return (value.IndexOf(Environment.NewLine) > -1 ? true : false);
        }

        /// <summary>
        /// Makes a string single line
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static string MakeSingleLine(string value)
        {
            return value.Replace(Environment.NewLine, " ");
        }

        /// <summary>
        /// Checks if any string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static bool Contains(string value, string[] args)
        {
            foreach (string v in args)
            {
                if (value.Contains(v))
                {
                    return true;
                }
            }

            return false;
        }


        [MethodImpl(MethodImplOptions.Synchronized)]
        public static bool Contains(string value, char[] args)
        {
            foreach (char v in args)
            {
                if (value.Contains(v.ToString()))
                {
                    return true;
                }
            }

            return false;
        }


    }
}