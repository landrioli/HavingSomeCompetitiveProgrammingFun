using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.LinkedList
{
    public class KthToLastLinkedList
    {
        public static int PrintKthToLast(LinkedListNode<int> head, int k)
        {
            if (head == null)
            {
                return 0;
            }
            int index = PrintKthToLast(head.Next, k) + 1;
            if (index == k)
            {
                Console.WriteLine(k + "th to last node is " + head.Value);
            }
            return index;
        }
    }
}
