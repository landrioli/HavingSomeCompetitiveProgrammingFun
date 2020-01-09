using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.LinkedList
{
    public static class SumValues
    {
        /*Sum Lists: You have two numbers represented by a linked list, where each node contains a single
        digit.The digits are stored in reverse order, such that the 1 's digit is at the head of the list. Write a
        function that adds the two numbers and returns the sum as a linked list.
        EXAMPLE
        Input: (7-> 1 -> 6) + (5 -> 9 -> 2) .Thatis,617 + 295.
        Output: 2 - > 1 - > 9. That is, 912.
        #Propsed approuch:
        It's useful to remember in this problem how exactly addition works. Imagine the problem:
          6 1 7
        + 2 9 5        
        First, we add 7 and 5 to get 12. The digit 2 becomes the last digit of the number, and 1 gets carried over to
        the next step. Second, we add 1, 1, and 9 to get 11 . The 1 becomes the second digit, and the other 1 gets
        carried over the final step. Third and finally, we add 1,6 and 2 to get 9. So, our value becomes 912.
        We can mimic this process recursively by adding node by node, carrying over any "excess" data to the next
        node. Let's walk through this for the below linked list:
        7 -> 1 -> 6
        + 5 -> 9 -> 2
        We do the following:
        1. We add 7 and 5 first, getting a result of 12. 2 becomes the first node in our linked list, and we "carry" the
        1 to the next sum.
        List: 2 -> ?
        2. We then add 1 and 9, as well as the "carry;' getting a result of 11 . 1 becomes the second element of our
        linked list, and we carry the 1 to the next sum.
        List: 2 -> 1 -> ?
        3. Finally, we add 6, 2 and our "carry;' to get 9. This becomes the final element of our linked list.
        List: 2 - > 1 - > 9.
        
             THIS IS NOT READY FOR DIFFERENT SIZES */
        public static LinkedListNode<int> AddLists(LinkedListNode<int> l1, LinkedListNode<int> l2, int carry)
        {
            if (l1 == null && l2 == null && carry == 0)
            {
                return null;
            }
            var result = new LinkedListNode<int>();
            int value = carry;
            if (l1 != null)
            {
                value += l1.Data;
            }
            if (l2 != null)
            {
                value += l2.Data;
            }
            result.Data = value % 10; /*Second digit of number*/
            /*Recurse */
            if (l1 != null || l2 != null)
            {
                LinkedListNode<int> more = AddLists(l1 == null ? null : l1.Next,
                                                l2 == null ? null : l2.Next,
                                                value >= 10 ? 1 : 0);
                result.Next = more;
            }
            return result;
        }
    }
}
