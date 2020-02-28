using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
	/**https://leetcode.com/problems/swap-nodes-in-pairs/
	Definition for singly-linked list.
	Given a linked list, swap every two adjacent nodes and return its head.
	You may not modify the values in the list's nodes, only nodes itself may be changed.
	Sample:Given 1->2->3->4, you should return the list as 2->1->4->3.*/
    public class SwapPairsLinkedList
    {				
		public class ListNode {
			  public int val;
			  public ListNode next;
			  public ListNode(int x) { val = x; }
		}

		public ListNode SwapPairs(ListNode head)
		{
			ListNode dummyHead = new ListNode(0);
			dummyHead.next = head;
			ListNode prev = dummyHead;
			ListNode curr = head;

			while (curr != null && curr.next != null)
			{
				ListNode next = curr.next;
				ListNode nextnext = next.next;
				prev.next = next;
				next.next = curr;
				curr.next = nextnext;

				prev = curr;
				curr = curr.next;
			}

			return dummyHead.next;
		}
    }
}
