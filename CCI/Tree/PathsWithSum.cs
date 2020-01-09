using CCIChallenges.BinaryTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.Tree
{
    public static class PathsWithSum
    {
        #region First Approach Brute Force
        /*In the brute force approach, we just look at all possible paths. To do this, we traverse to each node. At each
            node, we recursively try all paths downwards, tracking the sum as we go. As soon as we hit our target sum,
            we increment the total.*/
        public static int countPathsWithSum(TreeNode root, int targetSum)
        {
            if (root == null) return 0;

            /* Count paths with sum starting from the root. */
            int pathsFromRoot = countPathsWithSumFromNode(root, targetSum, 0);

            /* Try the nodes on the left and right. */
            int pathsOnLeft = countPathsWithSum(root.LeftNode, targetSum);
            int pathsOnRight = countPathsWithSum(root.RightNode, targetSum);

            return pathsFromRoot + pathsOnLeft + pathsOnRight;
        }

        /* Returns the number of paths with this sum starting from this node. */
        public static int countPathsWithSumFromNode(TreeNode node, int targetSum, int currentSum)
        {
            if (node == null) return 0;

            currentSum += node.Data;

            int totalPaths = 0;
            if (currentSum == targetSum)
            { // Found a path from the root
                totalPaths++;
            }

            totalPaths += countPathsWithSumFromNode(node.LeftNode, targetSum, currentSum); // Go left
            totalPaths += countPathsWithSumFromNode(node.RightNode, targetSum, currentSum); // Go right

            return totalPaths;
        }
        #endregion

        #region Second Approach Optimized
        /*The improvement here is avoid traverse paths (or parts of it) repeatedly.*/
        public static int CountPathsWithSumOptimized(TreeNode root, int targetSum)
        {
            return CountPathsWithSumOptimized(root, targetSum, 0, new Dictionary<int, int>());
        }

        public static int CountPathsWithSumOptimized(TreeNode node, int targetSum, int runningSum, Dictionary<int, int> pathCount)
        {
            if (node == null) return 0; // Base case

            runningSum += node.Data;

            /* Count paths with sum ending at the current node. */
            int sum = runningSum - targetSum;
            int totalPaths = 0;
            pathCount.TryGetValue(sum, out totalPaths);

            /* If runningSum equals targetSum, then one additional path starts at root. Add in this path.*/
            if (runningSum == targetSum)
            {
                totalPaths++;
            }

            /* Add runningSum to pathCounts. */
            incrementHashTable(pathCount, runningSum, 1);

            /* Count paths with sum on the left and right. */
            totalPaths += CountPathsWithSumOptimized(node.LeftNode, targetSum, runningSum, pathCount);
            totalPaths += CountPathsWithSumOptimized(node.RightNode, targetSum, runningSum, pathCount);

            incrementHashTable(pathCount, runningSum, -1); // Remove runningSum
            return totalPaths;
        }

        public static void incrementHashTable(Dictionary<int, int> hashTable, int key, int delta)
        {
            int newCount = 0;
            hashTable.TryGetValue(key, out newCount);
            newCount += delta;
            if (newCount == 0)
            { // Remove when zero to reduce space usage
                hashTable.Remove(key);
            }
            else
            {
                hashTable[key] = newCount;
            }
        }
        #endregion
    }
}
