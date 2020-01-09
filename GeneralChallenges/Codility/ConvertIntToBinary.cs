using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralChallenges.Codility
{
    /*
     A binary gap within a positive integer N is any maximal sequence of consecutive zeros that is surrounded by ones at both ends in the binary representation of N.
    For example, number 9 has binary representation 1001 and contains a binary gap of length 2. The number 529 has binary representation 1000010001 
    and contains two binary gaps: one of length 4 and one of length 3. The number 20 has binary representation 10100 and contains one binary gap of length 1. 
    The number 15 has binary representation 1111 and has no binary gaps. The number 32 has binary representation 100000 and has no binary gaps.
         */
    public static class ConvertIntToBinary
    {
        public static int CountLenghtOfLongestBinaryGap(string binarynumber)
        {
            var binaryChar = binarynumber.ToCharArray();
            int biggestGap = 0;
            for (int i = 0; i < binaryChar.Length; i++)
            {
                if (binaryChar[i] == '1')
                {
                    for (int j = i + 1; j < binaryChar.Length; j++)
                    {
                        if (binaryChar[j] == '1')
                        {
                            biggestGap = Math.Max(biggestGap, j - i - 1);
                            i = j - 1;
                            break;
                        }
                    }
                }
            }
            return biggestGap;
        }

        public static void ConvertIntToBinaryRecursive(int n, StringBuilder result)
        {
            // step 1 
            if (n > 1)
                ConvertIntToBinaryRecursive(n / 2, result);

            // The rest will be 0 or 1...
            if (n % 2 == 0)
            {
                result.Append("0");
            }
            else
            {
                result.Append("1");
            }
        }

        public static string ConvertIntToBinaryIterative(int n)
        {
            var data = new List<char>();
            while (n > 0)
            {
                data.Add(n % 2 == 0 ? '0' : '1');
                n /= 2;
            }

            StringBuilder result = new StringBuilder();
            for (int i = data.Count - 1; i >= 0; i--)
            {
                result.Append(data[i]);
            }

            return result.ToString();
        }
    }
}
