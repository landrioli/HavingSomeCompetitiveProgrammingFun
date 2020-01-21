using System;

namespace myapp
{
	//https://leetcode.com/problems/merge-two-sorted-lists
	//Merge two sorted linked lists and return it as a new list. The new list should be made by splicing together the nodes of the first two lists.
    public class MergeTwoOrderedLinkedList
    {
		public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public ListNode MergeTwoListsIterative(ListNode l1, ListNode l2)
        {
            ListNode head = new ListNode(0);
            var finalList = head;
            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    finalList.next = new ListNode(l1.val);
                    l1 = l1.next;
                    finalList = finalList.next;
                }
                else
                {
                    finalList.next = new ListNode(l2.val);
                    l2 = l2.next;
                    finalList = finalList.next;
                }
            }

            if (l1 != null)
            {
                finalList.next = l1;
            }
            else if (l2 != null)
            {
                finalList.next = l2;
            }

            return head.next;
        }

        public ListNode MergeTwoListsRecursive(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            if (l1.val <= l2.val)
            {
                l1.next = MergeTwoListsRecursive(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoListsRecursive(l1, l2.next);
                return l2;
            }
        }
    }
}
