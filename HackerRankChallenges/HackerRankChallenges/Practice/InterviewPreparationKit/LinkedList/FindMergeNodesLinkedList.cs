using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    //https://www.hackerrank.com/challenges/find-the-merge-point-of-two-joined-linked-lists/problem
    //Find Merge Point of Two Lists
    //Given pointers to the head nodes of 2 linked lists that merge together at some point, find the Node where the two lists merge. It is guaranteed that the two head Nodes will be different, and neither will be NULL.
    public static class FindMergeNodesLinkedList
    {
        public class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
            }
        }

        //You just sync the two list iterators by connecting the ends of each list to the beginning of the next list
        //because when they be the same you will hit the same position on both, so the current.data will be the point of merge
        public static int FindMergeNode(SinglyLinkedListNode headA, SinglyLinkedListNode headB)
        {
            SinglyLinkedListNode currentA = headA;
            SinglyLinkedListNode currentB = headB;

            //Do till the two nodes are the same
            while (currentA != currentB)
            {
                //If you reached the end of one list start at the beginning of the other one
                //currentA
                if (currentA.next == null)
                {
                    currentA = headB;
                }
                else
                {
                    currentA = currentA.next;
                }
                //currentB
                if (currentB.next == null)
                {
                    currentB = headA;
                }
                else
                {
                    currentB = currentB.next;
                }
            }
            return currentB.data;
        }
    }
}
