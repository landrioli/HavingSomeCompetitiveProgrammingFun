using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class DetectLoopLinkedList
    {
        /*
         Floyd’s Cycle-Finding Algorithm: This is the fastest method and has been described below:
            Traverse linked list using two pointers. 
            Move one pointer(slow_p) by one and another pointer(fast_p) by two. 
            If these pointers meet at the same node then there is a loop. If pointers do not meet then linked list doesn’t have a loop
               Time Complexity: O(n)
               Auxiliary Space: O(1)  
       */
        public static bool DetectLoop(SinglyLinkedListNode head)
        {
            var slow = head;
            var fast = head;
            Console.WriteLine($"Slow: {slow?.data} - Fast: {fast?.data}");
            while (slow != null && fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                Console.WriteLine($"Slow: {slow?.data} - Fast: {fast?.data}");
                if (slow == fast)
                {
                    Console.WriteLine("Found loop");
                    return true;
                }
            }
            return false;
        }

        #region LinkedList Structure

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

        public class SinglyLinkedList
        {
            public SinglyLinkedListNode head;
            public SinglyLinkedListNode tail;

            public SinglyLinkedList()
            {
                this.head = null;
                this.tail = null;
            }

            public void InsertNode(int nodeData)
            {
                SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

                if (this.head == null)
                {
                    this.head = node;
                }
                else
                {
                    this.tail.next = node;
                }

                this.tail = node;
            }
        }
        #endregion
    }

}