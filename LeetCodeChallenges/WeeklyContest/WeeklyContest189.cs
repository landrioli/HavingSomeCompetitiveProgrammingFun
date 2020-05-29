using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenges.WeeklyContest
{
    public class WeeklyContest189
    {
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

        public string ArrangeWords(string text)
        {
            var words = text.Split(' ');
            var dict = new Dictionary<int, List<string>>();
            foreach (var word in words)
            {
                if (dict.ContainsKey(word.Length))
                {
                    dict[word.Length].Add(word);
                }
                else
                {
                    dict.Add(word.Length, new List<string> { word });
                }
            }
            var result = new StringBuilder();
            foreach (var size in dict.Keys.OrderBy(p => p))
            {
                var wordsPerSize = dict[size];
                wordsPerSize.ForEach(p => result.Append(p.ToLower() + " "));
            }

            var final = result.ToString();
            return char.ToUpper(final[0]) + final.Substring(1, result.Length - 2);
        }

        public IList<int> PeopleIndexes(List<List<string>> favoriteCompanies)
        {
            // TODO: Continue here
            //var listHashes = new List<HashSet<string>>();
            //foreach (var favoriteSet in favoriteCompanies)
            //{
            //    listHashes.Add(new HashSet<string>(favoriteSet));
            //}

            //var result = new List<int>();
            //for (int i = 0; i < favoriteCompanies.Count; i++)
            //{
            //    var isSubset = false;
            //    for (int j = 0; j < listHashes[j].Count; j++)
            //    {
            //        listHashes[j].All(p=>p.Contains())
            //    }
            //}

            //return result;
            return null;
        }


        public void Main()
        {
            //BusyStudent(new int[] { 1, 2, 3 }, new int[] { 3, 2, 7 }, 4);

            var final = new List<List<string>>
            {
                new List<string> { "a","b","c","d","e","f" },
                new List<string> { "a","b","d","e","f" },
                new List<string> { "b", "c", "d", "e", "f" }
            };

            PeopleIndexes(final);
        }
    }
}
