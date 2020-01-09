using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankChallenges.Practice.Algorithm.Strings
{
    //https://www.hackerrank.com/challenges/richie-rich/problem?h_r=next-challenge&h_v=zen
    public class HighestValuePalindrome
    {
        // Complete the highestValuePalindrome function below. 0923282
        static string highestValuePalindrome(string s, int n, int k)
        {
            int lo = 0;
            int hi = n - 1; ;
            char[] charArray = s.ToCharArray();
            int diff = 0;

            for (int i = 0, j = n - 1; i < n / 2; i++, j--)
            {
                if (charArray[i] != charArray[j])
                {
                    diff++;
                }
            }

            if (diff > k)
            {
                return "-1";
            }

            while (hi >= lo)
            {
                if (k <= 0)
                {
                    break;
                }

                if (charArray[lo] == charArray[hi])
                {
                    if (k > 1 && (k - 2) >= diff && charArray[lo] != '9')
                    {
                        charArray[lo] = '9';
                        charArray[hi] = '9';
                        k -= 2;
                    }
                }
                else
                {
                    if (k > 1 && (k - 2) >= diff - 1)
                    {
                        if (charArray[lo] != '9')
                        {
                            charArray[lo] = '9';
                            k--;
                        }
                        if (charArray[hi] != '9')
                        {
                            charArray[hi] = '9';
                            k--;
                        }
                    }
                    else
                    {
                        if (charArray[lo] > charArray[hi])
                        {
                            charArray[hi] = charArray[lo];
                        }
                        else
                        {
                            charArray[lo] = charArray[hi];
                        }
                        k--;
                    }
                    diff--;
                }
                if (lo == hi && k > 0)
                {
                    charArray[lo] = '9';
                    k--;
                }
                lo++;
                hi--;
            }

            s = new string(charArray);
            return isPalindrome(s) ? s : "-1";
        }

        static bool isPalindrome(string s)
        {
            int i = 0;
            int j = s.Length - 1;
            var charArray = s.ToCharArray();

            while (j > i)
            {
                if (charArray[i] == charArray[j])
                {
                    i++; j--;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
