using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenges.WeeklyContest
{
    public class WeeklyContest189
    {
        //https://leetcode.com/contest/weekly-contest-189/problems/number-of-students-doing-homework-at-a-given-time/
        //Given two integer arrays startTime and endTime and given an integer queryTime.
        //The ith student started doing their homework at the time startTime[i] and finished it at time endTime[i].
        //Return the number of students doing their homework at time queryTime.More formally, return the number of students where queryTime lays
        //in the interval[startTime[i], endTime[i]] inclusive.
        public int BusyStudent(int[] startTime, int[] endTime, int queryTime)
        {
            int totalStudents = 0;
            for (int i = 0; i < startTime.Length; i++)
            {
                if (startTime[i] <= queryTime && endTime[i] <= queryTime)
                    totalStudents++;
            }

            return totalStudents;
        }

        //https://leetcode.com/problems/rearrange-words-in-a-sentence/
        //Given a sentence text(A sentence is a string of space-separated words) in the following format:
        //First letter is in upper case.
        //Each word in text are separated by a single space.
        //    Your task is to rearrange the words in text such that all words are rearranged in an increasing order of their lengths.If two words have the same length, arrange them in their original order.
        //    Return the new text following the format shown above.
        public string ArrangeWords(string text)
        {
            var words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            words = words.OrderBy(x => x.Length).Select(x => x.ToLowerInvariant()).ToArray();
            words[0] = (words[0].Substring(0, 1).ToUpperInvariant() + words[0].Substring(1));
            var finalString = string.Join(" ", words);
            return finalString;
        }

        ////https://leetcode.com/contest/weekly-contest-189/problems/people-whose-list-of-favorite-companies-is-not-a-subset-of-another-list/
        //People Whose List of Favorite Companies Is Not a Subset of Another List
        //    Given the array favoriteCompanies where favoriteCompanies[i] is the list of favorites companies for the ith person(indexed from 0).
        //Return the indices of people whose list of favorite companies is not a subset of any other list of favorites companies.You must return the indices in increasing order.
        public IList<int> PeopleIndexes(List<List<string>> favoriteCompanies)
        {
            var ctoi = new Dictionary<string, List<int>>();
            for (var i = 0; i < favoriteCompanies.Count; ++i)
            {
                foreach (var c in favoriteCompanies[i])
                {
                    if (!ctoi.ContainsKey(c)) ctoi[c] = new List<int>();
                    ctoi[c].Add(i);
                }
            }
            var result = new List<int>();
            var cur = new HashSet<int>();
            for (var i = 0; i < favoriteCompanies.Count; ++i)
            {
                cur.UnionWith(ctoi[favoriteCompanies[i][0]]);
                for (var j = 1; j < favoriteCompanies[i].Count; ++j)
                {
                    var next = ctoi[favoriteCompanies[i][j]];
                    cur.IntersectWith(next);
                    if (cur.Count == 1) break;
                }
                if (cur.Count == 1)
                    result.Add(cur.First());
                cur.Clear();
            }

            return result;
        }


        public void Main()
        {
            //BusyStudent(new int[] { 1, 2, 3 }, new int[] { 3, 2, 7 }, 4);
            var final = new List<List<string>>
            {
                new List<string> { "a","b","c","d" },
                new List<string> { "a","d" },
                new List<string> { "e", "f" }
            };

            PeopleIndexes(final);
        }
    }
}
