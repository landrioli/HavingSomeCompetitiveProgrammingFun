
using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.Common
{
    public static class ExtensionMethods
    {
        public static void AppendRange<T>(this LinkedList<T> source,
                                      IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                source.AddLast(item);
            }
        }
    }
}
