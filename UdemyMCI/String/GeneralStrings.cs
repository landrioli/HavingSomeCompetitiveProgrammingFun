using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyMCI.String
{
    public class GeneralStrings
    {
        public static string ReverseString(string str)
        {
            var strBuilder = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--)
                strBuilder.Append(str[i]);
            return strBuilder.ToString();
        }
    }
}
