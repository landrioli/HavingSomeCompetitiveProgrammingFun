using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    public class MergeKOrderedLists
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0)
                return null;

            var indexes = new ListNode[lists.Length];
            var dummyHead = new ListNode();
            var constructionHead = new ListNode();
            dummyHead.next = constructionHead;
            for (int i = 0; i < lists.Length; i++)
            {
                indexes[i] = lists[i];
            }

            while (true)
            {
                var dict = new List<KeyValuePair<int, int>>(); // <indexArray, value>
                for (int i = 0; i < lists.Length; i++)
                {
                    if (lists[i] == null)
                        continue;

                    var currentValue = lists[i].val;
                    dict.Add(new KeyValuePair<int, int>(i, currentValue));
                }

                if (dict.Count == 0)
                    break;

                var minPair = GetMin(dict);
                var minIndex = minPair.Key;
                var minValue = minPair.Value;
                var newNode = new ListNode(minValue);
                constructionHead.next = newNode;
                constructionHead = newNode;
                lists[minIndex] = lists[minIndex].next;
            }

            return dummyHead.next.next; //The first is just an mock node //The first is just an mock node
        }

        private KeyValuePair<int, int> GetMin(List<KeyValuePair<int, int>> dict)
        {
            int indexOfsmallest = 0;
            return dict.OrderBy(p => p.Value).First();
        }

        public void Main()
        {
            var node11 = new ListNode(11);
            var node44 = new ListNode(44);
            var node5 = new ListNode(5);
            var node1 = new ListNode(1);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            var node2 = new ListNode(2);
            var node6 = new ListNode(6);

            node44.next = node5;
            node11.next = node44;

            node3.next = node4;
            node1.next = node3;

            node2.next = node6;

            MergeKLists(new ListNode[3] {null, node1, node2});
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}
