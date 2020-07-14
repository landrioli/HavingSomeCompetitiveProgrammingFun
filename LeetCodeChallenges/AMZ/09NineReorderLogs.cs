using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    public class NineReorderLogs
    {


        public string[] ReorderLogFiles(string[] logs)
        {
            var separator = new[] { ' ' };
            List<string> letterLogs = new List<string>();
            List<string> digitLogs = new List<string>();

            for (int i = 0; i < logs.Length; i++)
            {
                var words = logs[i].Split(separator, StringSplitOptions.RemoveEmptyEntries);
                bool letter = words[1].ToCharArray().All(c => c >= 'a' && c <= 'z');
                if (letter)
                {
                    letterLogs.Add(logs[i]);
                }
                else
                {
                    digitLogs.Add(logs[i]);
                }
            }

            IList<string> res = new List<string>();

            letterLogs.Sort((l1, l2) =>
            {
                var words1 = l1.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                var words2 = l2.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                var contentOne = string.Join(" ", words1.Skip(1).ToArray());
                var contentTwo = string.Join(" ", words2.Skip(1).ToArray());
                var cmp = string.CompareOrdinal(contentOne, contentTwo);
                if (cmp != 0)
                    return cmp;

                return string.CompareOrdinal(words1[0], words2[0]);
            });

            foreach (var letterLog in letterLogs)
                res.Add(letterLog);

            foreach (var digitLog in digitLogs)
                res.Add(digitLog);

            return res.ToArray();
        }

        // Error because input has a key with the same value..
        public string[] ReorderLogFilesNotAllCasesPassing(string[] logs)
        {
            SortedList<string, string> letterLog = new SortedList<string, string>();
            List<string> digitLogs = new List<string>(),
                         result = new List<string>();

            foreach (var item in logs)
                if (item[item.IndexOf(' ') + 1] >= 'a' && item[item.IndexOf(' ') + 1] <= 'z')
                    letterLog.Add(item.Substring(item.IndexOf(' ') + 1), item);
                else
                    digitLogs.Add(item);

            foreach (var item in letterLog)
                result.Add(item.Value);

            foreach (var item in digitLogs)
                result.Add(item);

            return result.ToArray();
        }
    }
}
