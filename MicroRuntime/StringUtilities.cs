using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Microruntime
{
	public class StringUtilities
	{
		public bool IsSameString(string a, string b, bool caseSensitiveComparation = true)
		{
			if (caseSensitiveComparation)
			{
				return string.Compare(a, b, StringComparison.Ordinal) == 0;
			}

			return string.Compare(a, b, StringComparison.OrdinalIgnoreCase) == 0;
		}

		public bool IsInteger(string input)
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

		public bool IsPositiveNumber(string number)
		{
			Regex notNaturalPattern = new Regex("[^0-9]");
			Regex naturalPattern = new Regex("0*[0-9][0-9]*");

			return !notNaturalPattern.IsMatch(number) && naturalPattern.IsMatch(number);
		}

		public bool IsNegativeNumber(string number)
		{
			if (number.Length == 0)
			{
				return false;
			}

			double value = 0;

			return (Double.TryParse(number, out value) && number.StartsWith("-")) ? true : false;
		}

		public bool IsMultiLine(string value)
		{
			return value.IndexOf(Environment.NewLine) > -1;
		}

		public bool Contains(string value, string[] args)
		{
			return args.Any(value.Contains);
		}

		public bool Contains(string value, char[] args)
		{
			return args.Any(v => value.Contains(v.ToString()));
		}
	}
}