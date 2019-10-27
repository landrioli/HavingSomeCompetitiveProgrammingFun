using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.LinkedList
{
    public class LinkedListNode<T>
    {
        public LinkedListNode()
        {

        }
        public LinkedListNode(T value)
        {
            Data = value;
        }

        public LinkedListNode<T> Next { get; set; }
        public T Data { get; set; }

    }
}
