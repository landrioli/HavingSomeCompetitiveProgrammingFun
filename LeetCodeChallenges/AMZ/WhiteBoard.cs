using System.Collections.Generic;
using System.Text;
using System;

namespace LeetCodeChallenges.AMZ.WhiteBoard
{
    public class WhiteBoard
    {
        #region Closest Value in BST
        private int closest = int.MaxValue;
        //Time O(log(N))  |  Space O(log(N))
        public int FindClosestValueInBst(TreeNode root, int target)
        {
            if (root == null)
                return -1;

            FindClosestValueInBstRecursive(root, target, int.MaxValue);
            return closest;
        }

        private int FindClosestValueInBstRecursive(TreeNode root, int target, int closest)
        {
            if (root == null)
                return closest;

            if (Math.Abs(target - root.val) < Math.Abs(target - closest))
                closest = root.val;
            if (closest == 0)
                return closest;
            else if (root.val < target)
                return FindClosestValueInBstRecursive(root.left, target, closest);
            else
                return FindClosestValueInBstRecursive(root.right, target, closest);
        }

        //Time O(log(N)) |  Space = O(1)
        private int FindClosestValueInBstIterative(TreeNode root, int target, int closest)
        {
            while (root != null)
            {
                if (Math.Abs(target - root.val) < Math.Abs(target - closest))
                    closest = root.val;
                if (closest == 0)
                    return closest;
                else if (root.val < target)
                    root = root.left;
                else
                    root = root.right;
            }
            return closest;

        }

        #endregion

        #region Branch Sums BST

        //Time O(N) | Space O(N)
        public List<int> GetBranchSum(TreeNode root)
        {
            var finalList = new List<int>();
            GetBreanchSumRecursive(root, 0, finalList);

            return finalList;
        }

        public void GetBreanchSumRecursive(TreeNode root, int sum, List<int> finalList)
        {
            if (root == null)
            {
                finalList.Add(sum);
                return;
            }
            GetBreanchSumRecursive(root.left, root.val + sum, finalList);
            GetBreanchSumRecursive(root.right, root.val + sum, finalList);
        }

        #endregion

        #region Depth first search DFS
        public List<int> Dfs(Node root)
        {
            var list = new List<int>();
            DfsRecursive(root, list);
            return list;
        }

        private List<int> DfsRecursive(Node root, List<int> list)
        {
            list.Add(root.val);
            foreach (var child in root.children)
            {
                DfsRecursive(child, list);
            }

            return list;
        }
        #endregion

        #region Smallest difference between two arrays
        //O N(logN)  |  O(1)
        public Tuple<int, int> GetSmallestDifference(int[] one, int[] two)
        {
            Array.Sort(one);
            Array.Sort(two);
            int oneIndex = 0;
            int twoIndex = 0;
            int smallestDifference = int.MaxValue;
            var currentDifference = int.MaxValue;

            var tuple = new Tuple<int, int>(0, 0);
            while (oneIndex < one.Length && twoIndex < two.Length)
            {
                var numberOne = one[oneIndex];
                var numberTwo = two[twoIndex];

                if (numberOne == numberTwo)
                    return new Tuple<int, int>(numberOne, numberTwo);
                else if (numberTwo < numberOne)
                {
                    currentDifference = numberOne - numberTwo;
                    twoIndex++;
                }
                else
                {
                    currentDifference = numberTwo - numberOne;
                    oneIndex++;
                }
                if (currentDifference < smallestDifference)
                {
                    smallestDifference = currentDifference;
                    tuple = new Tuple<int, int>(numberOne, numberTwo);
                }
            }

            return tuple;
        }

        #endregion

        #region Move Element to End
        public int[] MoveElementToEnd(int[] arr, int element)
        {
            if (arr.Length <= 1)
                return arr;

            int left = 0;
            int right = arr.Length - 1;

            while (left < right)
            {
                if (arr[left] == element)
                {
                    while (left < right && arr[right] == element)
                    {
                        right--;
                    }
                    arr[left] = arr[right];
                    arr[right] = element;
                }
                left++;
            }

            return arr;
        }
        #endregion

        #region Monotonic arry - Array increasing or decreasing
        public bool IsMonotonicArray(int[] arr)
        {
            if (arr.Length <= 2)
                return true;

            bool isIncreasing = true;
            bool isDecreasing = true;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] < arr[i + 1])
                    isDecreasing = false;
                else
                    isIncreasing = false;
            }

            return isIncreasing || isDecreasing;
        }
        #endregion

        public List<int> SpiralTraverseMatrix(int[][] matrix)
        {
            var result = new List<int>();
            var startRow = 0;
            int endRow = matrix.Length - 1;
            var startColumn = 0;
            int endColumn = matrix[0].Length - 1;
            while (startRow < endRow && startColumn < endColumn)
            {
                //Go Right
                for (int i = startColumn; i <= endColumn; i++)
                    result.Add(matrix[startRow][i]);

                //Go Down
                for (int i = startRow + 1; i <= endRow; i++)
                    result.Add(matrix[i][endColumn]);

                //Go Left
                for (int i = endColumn - 1; i >= startColumn; i--)
                    result.Add(matrix[endRow][i]);

                //Go Up
                for (int i = endRow - 1; i >= startRow + 1; i--)
                    result.Add(matrix[i][startColumn]);

                startRow++;
                endRow--;
                startColumn++;
                endColumn--;
            }

            return result;
        }

        #region Longest peak in array
        //O(N) | O(1)
        public int LongestPeak(int[] arr)
        {
            int longestPeak = 0;
            for (int i = 1; i < arr.Length - 1; i++)
            {
                if (IsAPeak(arr, i))
                {
                    int left = i - 1;
                    int right = i + 1;
                    int currentPeakSize = 1;
                    //Go left
                    while (left >= 0 && arr[left] < arr[left + 1])
                    {
                        currentPeakSize++;
                        left--;
                    }
                    //Go right
                    while (right < arr.Length && arr[right] < arr[right - 1])
                    {
                        currentPeakSize++;
                        right++;
                    }
                    longestPeak = Math.Max(longestPeak, currentPeakSize);
                }
            }
            return longestPeak;
        }

        private bool IsAPeak(int[] arr, int currentPosition)
        {
            return arr[currentPosition - 1] < arr[currentPosition]
                && arr[currentPosition + 1] < arr[currentPosition];
        }
        #endregion

        #region Binary Search Tree - BST
        #region Search in binaryTree - BST Construction
        public TreeNode SearchInBinaryTreeRecursive(TreeNode root, int target)
        {
            if (root == null)
                return null;

            if (root.val == target)
                return root;
            else if (target < root.val)
                return SearchInBinaryTreeRecursive(root.left, target);
            else
                return SearchInBinaryTreeRecursive(root.right, target);
        }

        public TreeNode SearchInBinaryTreeIterative(TreeNode root, int target)
        {
            while (root != null)
            {
                if (root.val == target)
                    return root;
                else if (target < root.val)
                    root = root.left;
                else
                    root = root.right;
            }
            return null;
        }
        #endregion

        //O(N) | O(N)
        public bool IsValidBST(TreeNode root)
        {
            return IsValidBSTRecursive(root, int.MinValue, int.MaxValue);
        }

        public bool IsValidBSTRecursive(TreeNode root, int minValue, int maxValue)
        {
            if (root == null)
                return true;

            if (root.val < minValue || root.val >= maxValue)
                return false;

            bool isValidLeft = IsValidBSTRecursive(root.left, minValue, root.val);
            bool isValidRight = IsValidBSTRecursive(root.right, root.val, maxValue);

            return isValidLeft && isValidRight;
        }

        #region Traverse Binary Search Tree
        public List<int> InOrderTraversal(TreeNode tree, List<int> result)
        {
            if (tree != null)
            {
                InOrderTraversal(tree.left, result);
                result.Add(tree.val);
                InOrderTraversal(tree.right, result);
            }
            return result;
        }
        public List<int> PreOrderTraversal(TreeNode tree, List<int> result)
        {
            if (tree != null)
            {
                result.Add(tree.val);
                InOrderTraversal(tree.left, result);
                InOrderTraversal(tree.right, result);
            }
            return result;
        }

        public List<int> PostOrderTraversal(TreeNode tree, List<int> result)
        {
            if (tree != null)
            {
                InOrderTraversal(tree.left, result);
                InOrderTraversal(tree.right, result);
                result.Add(tree.val);
            }
            return result;
        }
        #endregion

        #region Invert Binary Search Tree
        //O(N) | O(d) because of recursion the deaph of biggest branch of recursion
        public TreeNode InvertBinaryTree(TreeNode tree)
        {
            if (tree == null)
                return tree;

            InvertBinaryTreeRecursive(tree);
            return tree;
        }

        public void InvertBinaryTreeRecursive(TreeNode tree)
        {
            if (tree == null)
                return;

            SwapLeftAndRight(tree);
            InvertBinaryTreeRecursive(tree.left);
            InvertBinaryTreeRecursive(tree.right);
        }

        //O(N) | O(N) because of queue
        public TreeNode InvertBinaryTreeIterative(TreeNode tree)
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(tree);

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                if (current == null)
                    continue;
                SwapLeftAndRight(current);
                queue.Enqueue(current.left);
                queue.Enqueue(current.right);
            }

            return tree;
        }

        private void SwapLeftAndRight(TreeNode tree)
        {
            var temp = tree.left;
            tree.left = tree.right;
            tree.right = temp;
        }
        #endregion
        #endregion

        #region Dinamic Programming
        #region Max Subset sum no adjacent
        //O(N) | O(N)
        public int MaxSubsetSumNoAdjacent(int[] arr)
        {
            int[] dp = new int[arr.Length];
            dp[0] = arr[0];
            dp[1] = Math.Max(arr[0], arr[1]);

            for (int i = 2; i < arr.Length; i++)
            {
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + arr[i]);
            }

            return dp[arr.Length - 1];
        }

        //O(N) | O(N)
        public int MaxSubsetSumNoAdjacentOptimized(int[] arr)
        {
            int first = arr[0];
            int second = Math.Max(arr[0], arr[1]);

            for (int i = 2; i < arr.Length; i++)
            {
                int current = Math.Max(second, first + arr[i]);
                first = second;
                second = current;
            }

            return second;
        }
        #endregion

        public int NumberOfWaysToMakeChange(int[] denoms, int value)
        {
            int[] ways = new int[value + 1];
            ways[0] = 1; //base case
            foreach (var denom in denoms)
            {
                for (int i = 1; i < value + 1; i++)
                {
                    if (denom <= i)
                        ways[i] += ways[i - denom];
                }
            }

            return ways[value];
        }
        #endregion
    }

    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
            children = new List<Node>();
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }
}

