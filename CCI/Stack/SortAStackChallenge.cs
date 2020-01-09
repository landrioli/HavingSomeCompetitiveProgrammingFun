using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.Stack
{
    public static class SortAStackChallenge
    {
        /*
         Sort Stack: Write a program to sort a stack such that the smallest items are on the top. You can use only one
             additional temporary stack, but you may not copy the elements into any other data structure
            (such as an array). The stack supports the following operations: push, pop, peek, and isEmpty.
            This algorithm is 0 (N2 ) time and 0 (N) space.
                NOTE: I Know that If we were allowed to use unlimited stacks, we could implement a modified quicksort or mergesort.
                    With the mergesort solution, we would create two extra stacks and divide the stack into two parts. We
                    would recursively sort each stack, and then merge them back together in sorted order into the original
                    stack. Note that this would require the creation of two additional stacks per level of recursion.
                    With the quicksort solution, we would create two additional stacks and divide the stack into the two stacks
                    based on a pivot element. The two stacks would be recursively sorted, and then merged back together
                    into the original stack. Like the earlier solution, this one involves creating two additional stacks per level of
                    recursion.
         */
        public static void SortStack(Stack<int> s)
        {
            Stack<int> r = new Stack<int>();
            while (s.Count > 0)
            {
                /* Insert each element in s in sorted order into r. */
                int tmp = s.Pop();
                while (r.Count > 0 && r.Peek() > tmp)
                {
                    s.Push(r.Pop());
                }
                r.Push(tmp);
            }
            /* Copy the elements from r back into s. */
            while (r.Count > 0) {
                s.Push(r.Pop());
            }
        }
    }
}
