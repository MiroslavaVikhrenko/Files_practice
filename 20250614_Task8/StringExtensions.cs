using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20250614_Task8
{
    public static class StringExtensions
    {
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            input = input.TrimStart(); // remove leading spaces

            if (char.IsLetter(input[0]))
            {
                return char.ToUpper(input[0]) + input.Substring(1);
            }

            return input;
        }
    }
}
