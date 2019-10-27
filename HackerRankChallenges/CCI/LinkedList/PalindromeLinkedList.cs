using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.LinkedList
{
    public static class PalindromeLinkedList
    {
        /*Palindrome: Implement a function to check if a linked list is a palindrome.
         Solution #1: Reverse and Compare
            Our first solution is to reverse the linked list and compare the reversed list to the original list. If they're the
            same, the lists are identical (we only actually need to compare the first half of the list.).
        Solution 2: Iterative approach:
            If we know the size of the linked list, we can iterate through the first half of the elements in a standard for
            loop, pushing each element onto a stack. We must be careful, of course, to handle the case where the length
            of the linked list is odd.
            If we don't know the size of the linked list, we can iterate through the linked list, using the fast runner / slow
            runner technique described in the beginning of the chapter. At each step in the loop, we push the data from
            the slow runner onto a stack. When the fast runner hits the end of the list, the slow runner will have reached
            the middle of the linked list. By this point, the stack will have all the elements from the front of the linked
            list, but in reverse order.
             */
        public static LinkedListNode<int> ReverseAndClone(LinkedListNode<int> node)
        {
            LinkedListNode<int> head = null;
            while (node != null)
            {
                var n = new LinkedListNode<int>(node.Data);
                n.Next = head;
                head = n;
                node = node.Next;
            }
            return head;
        }

        public static bool IsEqual(LinkedListNode<int> one, LinkedListNode<int> two)
        {
            while (one != null && two != null)
            {
                if (one.Data != two.Data)
                {
                    return false;
                }
                one = one.Next;
                two = two.Next;
            }
            return one == null && two == null;
        }
    }
}
