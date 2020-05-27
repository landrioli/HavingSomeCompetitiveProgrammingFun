using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenges._30DaysChallengeCovid
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class DaySixMiddleOfTheLinkedList
    {
        //Time Complexity: O(N) where NN is the number of nodes in the given list. | Space Complexity: O(1), the space used by slow and fast.
        //When traversing the list with a pointer slow, make another pointer fast that traverses twice as fast. When fast         //    reaches the end of the list, slow must be in the middle.
        public ListNode MiddleNode(ListNode head)
        {
            ListNode slow = head, fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }

        //O(N) e O(N)
        public ListNode MiddleNodeSimpelrApprouch(ListNode head)
        {
            ListNode[] A = new ListNode[100];
            int t = 0;
            while (head.next != null)
            {
                A[t++] = head;
                head = head.next;
            }
            return A[t / 2];
        }

        public void Main() {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            var node5 = new ListNode(5);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;

            MiddleNode(node1);
        }
    }
}
