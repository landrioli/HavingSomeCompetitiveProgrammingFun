using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    public class Assigment
    {
        public List<int> lengthEachScene(List<char> inputList)
        {
            var dict = new Dictionary<char, int>();
            for (int i = 0; i < inputList.Count; i++)
            {
                // Last index
                if (!dict.ContainsKey(inputList[i]))
                    dict.Add(inputList[i], i);
                dict[inputList[i]] = i;
            }

            int last = 0;
            int first = 0;
            var results = new List<int>();
            for (int i = 0; i < inputList.Count; i++)
            {
                last = Math.Max(last, dict[inputList[i]]); // Each iteration I need to check if there are another letter that need to be used as last
                if (last == i)
                {
                    results.Add(last - first + 1);
                    first = last + 1;
                }
            }

            return results;
        }

        public Tuple<int, int> IDsOfmovies(int flightDuration, int numMovies,
                                           List<int> movieDuration)
        {
            var targetTime = flightDuration - 30;
            var dict = BuildMappingPositions(movieDuration);
            int[] orderedMovies = movieDuration.OrderBy(p => p).ToArray();
            int j = orderedMovies.Length - 1;
            int i = 0;
            while (j > i)
            {
                int totalTimeOfMovies = orderedMovies[i] + orderedMovies[j];
                if (totalTimeOfMovies == targetTime)
                {
                    return new Tuple<int, int>(dict[orderedMovies[i]], dict[orderedMovies[j]]);
                }
                else if (totalTimeOfMovies > targetTime)
                {
                    j--;
                }
                else
                {
                    i++;
                }
            }

            return new Tuple<int, int>(-1, -1);
        }

        private Dictionary<int, int> BuildMappingPositions(List<int> movieDuration)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < movieDuration.Count; i++)
            {
                dict.Add(movieDuration[i], i);
            }

            return dict;
        }

        public void Main()
        {
            lengthEachScene(new List<char>() { 'a', 'b', 'c', 'a', 'b', 'd' });
        }
    }
}
