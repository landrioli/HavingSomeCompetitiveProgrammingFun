using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    public class LinkedListHasCycle
    {
        // https://leetcode.com/problems/linked-list-cycle
        // time O(N) |  space O(1)
        public bool HasCycle(ListNode head)
        {
            var fast = head;
            var slow = head;
            while (slow != null && fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                    return true;
            }
            return false;
        }

        /*https://leetcode.com/problems/linked-list-cycle-ii/
         Given a linked list, return the node where the cycle begins. If there is no cycle, return null.
         To represent a cycle in the given linked list, we use an integer pos which represents the position (0-indexed) in the linked list where tail connects to. 
         If pos is -1, then there is no cycle in the linked list.
             */
        public ListNode DetectCycle(ListNode head)
        {
            var fast = head;
            var slow = head;
            bool hasCycle = false;
            while (slow != null && fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    hasCycle = true;
                    break;
                }
            }
            if (!hasCycle)
                return null;
            // now we apply the algorithm to find the cycle begin
            slow = head;
            while (slow != fast)
            {
                slow = slow.next;
                fast = fast.next;
            }
            return slow;
        }


        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }
    }
}
