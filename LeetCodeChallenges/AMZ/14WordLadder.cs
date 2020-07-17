using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    public class WordLadder
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            var hash = new HashSet<string>(wordList);
            var queue = new Queue<string>();
            queue.Enqueue(beginWord);
            int level = 1;
            while (queue.Count != 0)
            {
                int size = queue.Count;
                for (int q = 0; q < size; q++)
                {
                    char[] cur = queue.Dequeue().ToCharArray();
                    int initNumberOfOptions = queue.Count;
                    // I will search for all the positions of the word and replace one by one tring to find a respctive match in the dictionary
                    for (int i = 0; i < cur.Length; i++)
                    {
                        char tmp = cur[i];
                        for (char chr = 'a'; chr <= 'z'; chr++)
                        {
                            cur[i] = chr;
                            string dest = new string(cur);
                            if (hash.Contains(dest))
                            {
                                if (dest.Equals(endWord))
                                    return level + 1;
                                queue.Enqueue(dest);
                                hash.Remove(dest);
                            }
                        }
                        cur[i] = tmp;
                    }
                }
                level++;
            }
            // if go out of loop, it means that no more options are available, so return zero.
            return 0;
        }

        public void Main()
        {
            LadderLength("hit", "cog", new List<string>() { "hot", "dot", "dog", "lot", "log", "cog"});
        }
    }
}
