using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    public class FourSearchSuggestionsSystem
    {
        //Slow Solution - Brute Force
        public IList<IList<string>> SuggestedProductsBruteForce(string[] products, string searchWord)
        {
            products = products.OrderBy(p => p).ToArray();
            var finalList = new List<IList<string>>();
            var letters = searchWord.ToCharArray();
            var currentWord = string.Empty;

            for (int i = 0; i < letters.Length; i++)
            {
                var currentlist = new List<string>();
                currentWord += letters[i];
                for (int j = 0; j < products.Length; j++)
                {
                    if (products[j].StartsWith(currentWord))
                    {
                        currentlist.Add(products[j]);
                    }

                    if (currentlist.Count == 3 || j + 1 == products.Length)
                    {
                        finalList.Add(currentlist);
                        break;
                    }
                }
            }
            return finalList;
        }

        /*As the products arrays will be ordered, we can binary search to find the first ocurrency and after that we try to get the index plus 2 + words that match
 O(n logn)*/
        public IList<IList<String>> SuggestedProductsImplementingBinarySearch(String[] products, String searchWord)
        {
            products = products.OrderBy(p => p).ToArray();
            IList<IList<String>> ans = new List<IList<string>>();
            for (int i = 1; i <= searchWord.Length; i++)
            {
                int index = BinarySearch(products, searchWord, i);
                if (index == -1)
                {
                    ans.Add(new List<string>());
                    continue;
                }
                List<String> prefixes = new List<string>();
                for (int j = 0; j < 3 && index + j < products.Length; j++)
                {
                    if (Compare(products[j + index], searchWord, i) == 0)
                    {
                        prefixes.Add(products[j + index]);
                    }
                }
                ans.Add(prefixes);
            }
            return ans;
        }

        private int BinarySearch(String[] p, String s, int len)
        {
            int l = 0;
            int r = p.Length - 1;
            while (l < r)
            {
                int m = (l + r) / 2;
                if (Compare(p[m], s, len) < 0)
                {
                    l = m + 1;
                }
                else
                {
                    r = m;
                }
            }
            if (Compare(p[l], s, len) == 0)
            {
                return l;
            }
            else
            {
                return -1;
            }
        }

        private int Compare(String a, String b, int prefix)
        {
            for (int i = 0; i < prefix; i++)
            {
                if (a.Length == i)
                {
                    return -1;
                }
                if (a[i] != b[i])
                {
                    return a[i] - b[i];
                }
            }
            return 0;
        }

        public IList<IList<String>> SuggestedProductsBinarySearchFromLibrary(String[] products, String searchWord)
        {
            IList<IList<String>> ans = new List<IList<String>>();
            products = products.OrderBy(x => x).ToArray();
            for (int i = 1; i <= searchWord.Length; ++i)
            {
                String cur = searchWord.Substring(0, i);
                int k = Array.BinarySearch(products, cur);
                while (k > 0 && cur.Equals(products[k - 1])) // in case there are more than 1 cur in products.
                    --k; // find the first one. 
                if (k < 0) // no cur in products. 
                    k = ~k; // find the first one larger than cur.
                List<String> suggestion = new List<String>();
                for (int j = k + 3; k < products.Length && k < j && products[k].StartsWith(cur); ++k)
                    suggestion.Add(products[k]);
                ans.Add(suggestion);
            }
            return ans;
        }

        public IList<IList<string>> SuggestedProductsWithTrieStructure(string[] products, string searchWord)
        {

            // Sort products to store product names in lexicographic order
            Array.Sort(products);

            // Load product names into Trie, each TrieNode stores at most 3 suggested word
            TrieNode root = new TrieNode();
            foreach (string prod in products)
            {
                TrieNode curr = root;
                foreach (char c in prod)
                {
                    if (curr.Children[c - 'a'] == null)
                        curr.Children[c - 'a'] = new TrieNode();
                    curr = curr.Children[c - 'a'];
                    if (curr.Suggestion.Count < 3)
                        curr.Suggestion.Add(prod);
                }
            }

            // Build result based on searchWord
            List<IList<string>> res = new List<IList<string>>();
            TrieNode curr2 = root;
            foreach (char c in searchWord)
            {
                if (curr2 != null)
                    curr2 = curr2.Children[c - 'a'];

                res.Add(curr2 == null ? new List<string>() : curr2.Suggestion);
            }

            return res;
        }

        public class TrieNode
        {
            public List<string> Suggestion;
            public TrieNode[] Children;
            public TrieNode()
            {
                Suggestion = new List<string>();
                Children = new TrieNode[26];
            }
        }
    }
}
