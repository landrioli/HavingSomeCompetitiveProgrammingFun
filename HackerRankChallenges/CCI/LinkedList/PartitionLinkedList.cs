using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.LinkedList
{
    /*
     * Partition: Write code to partition a linked list around a value x, such that all nodes less than x come
        before all nodes greater than or equal to x. If x is contained within the list, the values of x only need
        to be after the elements less than x (see below). The partition element x can appear anywhere in the
        "right partition"; it does not need to appear between the left and right partitions.
        EXAMPLE
        Input:  3 -) 5 -) 8 -) 5  -) 10 -) 2 -) 1 [partition = 5]
        Output: 3 -) 1 -) 2 -) 10 -) 5  -) 5 -) 8
     */
    class PartitionLinkedList
    {
        public static LinkedListNode<int> Partition(LinkedListNode<int> node, int x)
        {
            //LinkedListNode<int> head = node;
            //LinkedListNode<int> tail = node;
            //while (node != null)
            //{
            //    LinkedListNode<int> next = node.Next;
            //    if (node.Value < x)
            //    {
            //        //Insert node at head.
            //        node.Next = head;
            //        head = node;
            //    }
            //    else
            //    {
            //        // Insert node at tail.
            //        tail.Next = node;
            //        tail = node;
            //    }
            //    node = next;
            //}
            //tail.Next = null;
            ////The head has changed, so we need to return it to the user.
            //return head;
        }
    }
}
