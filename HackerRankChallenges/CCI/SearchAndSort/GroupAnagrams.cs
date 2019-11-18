using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.SearchAndSort
{
     /*
     Group Anagrams: write a method to sort an array of strings so that all the anagrams are next to each other.*/
    public class GroupAnagrams
    {
        //PS:What's the easiest way of checking if two words are anagrams? We could count the occurrences of the
        //distinct characters in each string and return true if they match. Or, we could just sort the string. After all,
        //two words which are anagrams will look the same once they're sorted.
        //Here we will use the comparison to achieve it
        private class AnagramComparator : IComparer<object>
        {
            private string SortChars(string s)
            {
                char[] content = s.ToCharArray();
                Array.Sort<char>(content);
                return new string(content);
            }

            int IComparer<object>.Compare(object x, object y)
            {
                return SortChars((string)x).CompareTo(SortChars((string)y));
            }
        }


        /*We can do this by using a hash table which maps from the sorted version of a word to a list of its anagrams. So, for example, ac re will map to the list 
        {acre, racecare}. Once we've grouped all the words into these lists by anagram, we can then put them back into the array.*/
        private string SortChars(string s)
        {
            char[] content = s.ToCharArray();
            Array.Sort<char>(content);
            return new string(content);
        }
        private void Sort(string[] array)
        {
            Dictionary<string, LinkedList<string>> hash = new Dictionary<string, LinkedList<string>>();

            /* Group words by anagram */
            foreach (string s in array)
            {
                string key = SortChars(s);
                if (!hash.ContainsKey(key))
                {
                    hash.Add(key, new LinkedList<string>());
                }
                LinkedList<string> anagrams = hash[key];
                anagrams.AddLast(s);
            }

            /* Convert hash table to array */
            int index = 0;
            foreach (string key in hash.Keys)
            {
                LinkedList<string> list = hash[key];
                foreach (string t in list)
                {
                    array[index] = t;
                    index++;
                }
            }
        }

        public void Main()
        {
            //First approach
            string[] array = { "apple", "banana", "carrot", "ele", "duck", "papel", "tarroc", "cudk", "eel", "lee" };
            Array.Sort(array, new AnagramComparator());

            //Second approach
            string[] array2 = { "apple", "banana", "carrot", "ele", "duck", "papel", "tarroc", "cudk", "eel", "lee" };
            Sort(array);
        }
    }
}
