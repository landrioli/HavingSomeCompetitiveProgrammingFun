using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class InsertNodeLinkedList
    {
        //https://www.hackerrank.com/challenges/insert-a-node-at-a-specific-position-in-a-linked-list/problem
        // Insert a node at a specific position in a linked list

        class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
            }
        }

        class SinglyLinkedList
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

        static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep, TextWriter textWriter)
        {
            while (node != null)
            {
                textWriter.Write(node.data);

                node = node.next;

                if (node != null)
                {
                    textWriter.Write(sep);
                }
            }
        }

        static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode head, int data, int position)
        {
            if (head == null)
                return new SinglyLinkedListNode(data);

            int counter = 0;
            var currentItem = head;
            while (true)
            {
                if (counter == position - 1)
                {
                    var newNode = new SinglyLinkedListNode(data);
                    newNode.next = currentItem.next;
                    currentItem.next = newNode;
                    return head;
                }
                currentItem = currentItem.next;
                counter++;
            }
        }

    }
}
