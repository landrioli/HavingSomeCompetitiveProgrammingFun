using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.Tree
{
    public static class HuffmanDecodingTree
    {
        public class HuffmanNode
        {
            public int frequency; 
            public char data;
            public HuffmanNode left, right;
            public HuffmanNode(int freq, char dataValue)
            {
                data = dataValue;
                frequency = freq;
            }
        }

        public static string DecodeIterative(string s, HuffmanNode root)
        {
            StringBuilder sb = new StringBuilder();
            HuffmanNode c = root;
            for (int i = 0; i < s.Length; i++)
            {
                c = s[i] == '1' ? c.right : c.left;
                if (c.left == null && c.right == null)
                {
                    sb.Append(c.data);
                    c = root;
                }
            }
            return sb.ToString();
        }

        static int index = 0;
        public static string DecodeRecursive(string s, HuffmanNode root)
        {
            StringBuilder decoded = new StringBuilder();
            while (index < s.Length)
            {
                decoded.Append(FindCharacter(s, root));
            }
            return decoded.ToString();
        }

        public static char FindCharacter(string s, HuffmanNode node) {
            if (node.data != ' ')
            {
                return node.data;
            }
            if (s[index] == '1')
            {
                index++;
                return FindCharacter(s, node.right);
            }
            else
            {
                index++;
                return FindCharacter(s, node.left);
            }
        }

        public static void Main() {
            var node5 = new HuffmanNode(5, ' ');
            var node2 = new HuffmanNode(2, ' ');
            var node3a = new HuffmanNode(3, 'a');
            var node1b = new HuffmanNode(1, 'b');
            var node1c = new HuffmanNode(1, 'c');

            node5.left = node2;
            node5.right = node3a;
            node2.left = node1b;
            node2.right = node1c;
            var result =  DecodeIterative("1001011", node5);
            var resultRecursive = DecodeRecursive("1001011", node5);
        }
    }

   



}
