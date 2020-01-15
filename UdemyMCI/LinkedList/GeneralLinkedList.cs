

using CCIChallenges.LinkedList;

namespace UdemyMCI.LinkedList
{
    public static class GeneralLinkedList
    {
        // 1 - 2 -3- 4 -5
        public static LinkedListNode<int> ReverseLinkedList(LinkedListNode<int> list)
        {
            if (list.Next == null)
                return list;

            LinkedListNode<int> prev = null, current = list;
            while (current != null)
            {
                // Before changing next of current, store next node
                LinkedListNode<int> next = current.Next;
                // Now change next of current, This is where actual reversing happens
                current.Next = prev;
                // Move prev and curr one step forward
                prev = current;
                current = next;
            }
            return prev;
        }
    }
}
