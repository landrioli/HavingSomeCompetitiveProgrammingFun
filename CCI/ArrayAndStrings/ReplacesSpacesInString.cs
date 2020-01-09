using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.ArrayAndStrings
{
    /*
      URLify: Write a method to replace all spaces in a string with '%2e: You may assume that the string
      has sufficient space at the end to hold the additional characters, and that you are given the "true"
      length of the string. (Note: if implementing in Java, please use a character array so that you can
      perform this operation in place.)
      EXAMPLE:
      Input: "Mr John Smith JJ, 13
      Output: "Mr%2eJohn%2eSmith"
     */
    public class ReplacesSpacesInString
    {
        public static void ReplaceSpaces(string input, int trueLength)
        {
            char[] str = input.ToCharArray();
            int spaceCount = 0;
            int index = 0;
            for (int i = 0; i < trueLength; i++)
            {
                if (str[i] == ' ')
                {
                    spaceCount++;
                }
            }

            index = trueLength + spaceCount * 2; //we count the number of spaces.By tripling this number, we can compute how many extra characters we will have in the final string
            if (trueLength < str.Length)
                str[trueLength] = '\0';

            for (int i = trueLength - 1; i >= 0; i--)
            {
                if (str[i] == ' ')
                {
                    str[index - 1] = '0';
                    str[index - 2] = '2';
                    str[index - 3] = '%';
                    index = index - 3;
                }
                else
                {
                    str[index - 1] = str[i];
                    index--;
                }
            }

        }

    }
}
