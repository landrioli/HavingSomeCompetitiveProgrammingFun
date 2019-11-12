using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.RecursiveAndDynamicProgramming
{
    /*Permutations with Duplicates: Write a method to compute all permutations of a string whose
    chars are not necessarily unique. The list of permutations should not have duplicates.
     One simple way of handling this problem is to do the same work to check if a permutation has been created
    before and then, if not, add it to the list. A simple hash table will do the trick here. This solution will take
    o(n!) time in the worst case (and, in fact, in all cases).
         */
    /*
    The total number of permutations is:
       Find all the characters that is getting repeated, i.e., frequency of all the character. 
       Then, we divide the factorial of the length of string by multiplication of factorial of frequency of characters.

        Example -> Input : ghyhyrtgguf  Output : 1663200 
        number of character is 11 and here h and y are repeated 2 times whereas g is repeated 3 times.
        So, number of permutation is 11! / (2!2!3!) = 1663200 
    */
    public static class FindPermutationsWithDuplicates
    {
        public static Dictionary<char, int> BuildFreqTable(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach (char c in s.ToCharArray())
            {
                if (!map.ContainsKey(c))
                {
                    map.Add(c, 0);
                }
                map[c] = map[c] + 1;
            }
            return map;
        }

        public static void PrintPerms(Dictionary<char, int> map, string prefix, int remaining, List<string> result)
        {
            if (remaining == 0)
            {
                result.Add(prefix);
                return;
            }
            var keys = new List<char>(map.Keys);
            foreach (char c in keys)
            {
                int count = map[c];
                if (count > 0)
                {
                    map[c] = count - 1;
                    PrintPerms(map, prefix + c, remaining - 1, result);
                    map[c] = count;
                }
            }
        }

        public static List<string> PrintPermutations(string s)
        {
            List<string> result = new List<string>();
            Dictionary<char, int> map = BuildFreqTable(s);
            PrintPerms(map, "", s.Length, result);
            return result;
        }

        // Returns count of distinct permutations of str.  
        static int countDistinctPermutations(String str)
        {
            int length = str.Length;
            int MAX_CHAR = 26;
            int[] freq = new int[MAX_CHAR];

            // finding frequency of all the lower case 
            // alphabet and storing them in array of 
            // integer 
            for (int i = 0; i < length; i++)
                if (str[i] >= 'a')
                    freq[str[i] - 'a']++;

            // finding factorial of number of appearances 
            // and multiplying them since they are 
            // repeating alphabets 
            int fact = 1;
            for (int i = 0; i < MAX_CHAR; i++)
                fact = fact * Factorial(freq[i]);

            // finding factorial of size of string and 
            // dividing it by factorial found after 
            // multiplying 
            return Factorial(length) / fact;
        }

        // Utility function to find factorial of n. 
        static int Factorial(int n)
        {
            int fact = 1;
            for (int i = 2; i <= n; i++)
                fact = fact * i;

            return fact;
        }

        public static void Main()
        {
            string s = "aabc";
            List<string> result = PrintPermutations(s);
            foreach (string r in result)
            {
                Console.WriteLine(r);
            }
        }
    }
}
