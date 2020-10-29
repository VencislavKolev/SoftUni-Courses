using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementMyList
{
    public static class StringExtensions
    {
        public static string ApplyWhiteSpace(this string input, int count = 1 )
            //default value
            //this is applied to the mentioned type
        {
            var whiteSpace = new string(' ', count);
            return $"{whiteSpace}{input}{whiteSpace}";
        }
    }
}
