using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.Tree
{
    public static class BSTSequence
    {
        //public static void weaveLists(LinkedList<int> first, LinkedList<int> second, List<LinkedList<int>> results, LinkedList<int> prefix)
        //{
        //    /* One list is empty. Add the remainder to [a cloned] prefix and
        //     * store result. */
        //    if (first.size() == 0 || second.size() == 0)
        //    {
        //        LinkedList<int> result = (LinkedList<int>)prefix.clone();
        //        result.addAll(first);
        //        result.addAll(second);
        //        results.add(result);
        //        return;
        //    }

        //    /* Recurse with head of first added to the prefix. Removing the
        //     * head will damage first, so we’ll need to put it back where we
        //     * found it afterwards. */
        //    int headFirst = first.removeFirst();
        //    prefix.addLast(headFirst);
        //    weaveLists(first, second, results, prefix);
        //    prefix.removeLast();
        //    first.addFirst(headFirst);

        //    /* Do the same thing with second, damaging and then restoring
        //     * the list.*/
        //    int headSecond = second.removeFirst();
        //    prefix.addLast(headSecond);
        //    weaveLists(first, second, results, prefix);
        //    prefix.removeLast();
        //    second.addFirst(headSecond);
        //}

        //public static ArrayList<LinkedList<int>> allSequences(TreeNode node)
        //{
        //    ArrayList<LinkedList<int>> result = new ArrayList<LinkedList<int>>();

        //    if (node == null)
        //    {
        //        result.add(new LinkedList<int>());
        //        return result;
        //    }

        //    LinkedList<int> prefix = new LinkedList<int>();
        //    prefix.add(node.data);

        //    /* Recurse on left and right subtrees. */
        //    ArrayList<LinkedList<int>> leftSeq = allSequences(node.left);
        //    ArrayList<LinkedList<int>> rightSeq = allSequences(node.right);

        //    /* Weave together each list from the left and right sides. */
        //    for (LinkedList<int> left : leftSeq)
        //    {
        //        for (LinkedList<int> right : rightSeq)
        //        {
        //            ArrayList<LinkedList<int>> weaved = new ArrayList<LinkedList<int>>();
        //            weaveLists(left, right, weaved, prefix);
        //            result.addAll(weaved);
        //        }
        //    }
        //    return result;
        //}

        //public static void main(String[] args)
        //{
        //    TreeNode node = new TreeNode(100);
        //    int[] array = { 100, 50, 20, 75, 150, 120, 170 };
        //    for (int a : array)
        //    {
        //        node.insertInOrder(a);
        //    }
        //    ArrayList<LinkedList<int>> allSeq = allSequences(node);
        //    for (LinkedList<int> list : allSeq)
        //    {
        //        System.out.println(list);
        //    }
        //    System.out.println(allSeq.size());
        //}
    }
}
