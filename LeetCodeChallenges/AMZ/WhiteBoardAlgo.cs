using System.Collections.Generic;
using System.Text;
using System;
using LeetCodeChallenges.AMZ;
using System.Linq;

namespace LeetCodeChallenges.AMZ.WhiteBoard
{
    public class WhiteBoardAlgo
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

        #region breadth first search BFS
        //O(v + e) time | O(v) space
        public List<int> Bfs(Node root)
        {
            if (root == null)
                return null;

            List<int> result = new List<int>();
            var queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();
                result.Add(currentNode.val);
                foreach (var node in currentNode.children)
                {
                    queue.Enqueue(node);
                }
            }

            return result;
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

        #region Matrix traverse
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

        #region River Sizes
        //O(RxC) | O(N)
        private const int Visited = -1;
        public List<int> RiverSizes(int[][] matrix)
        {
            var riverSizesResult = new List<int>();
            var directions = new List<KeyValuePair<int, int>>() {
                new KeyValuePair<int, int>(-1, 0), //Up
                new KeyValuePair<int, int>(1, 0),  //Down
                new KeyValuePair<int, int>(0, -1), //Left
                new KeyValuePair<int, int>(0, 1) //Right
            };
            int currentRiverSize = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0 || matrix[i][j] == Visited)
                        continue;

                    ExploreDfs(i, j, matrix, directions, ref currentRiverSize);
                    riverSizesResult.Add(currentRiverSize);
                    currentRiverSize = 0;
                }
            }
            return riverSizesResult;
        }

        private void ExploreDfs(int row, int column, int[][] matrix, List<KeyValuePair<int, int>> directions, ref int currentRiverSize)
        {
            matrix[row][column] = Visited;
            currentRiverSize++;
            foreach (var direction in directions)
            {
                int newRow = row + direction.Key;
                int newColumn = column + direction.Value;
                int maxRow = matrix.Length - 1;
                int maxColumn = matrix[0].Length - 1;
                if (newRow >= 0 && newRow <= maxRow && newColumn >= 0 && newColumn <= maxColumn && matrix[newRow][newColumn] == 1) //TODO: Review this formula- Traverse all valid directions
                {
                    ExploreDfs(newRow, newColumn, matrix, directions, ref currentRiverSize); //HERE: I need to use the newrow and newcoloum in order to traverse the matrix
                }
            }
        }
        #endregion
        #endregion

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

        //O(denoms x value)  | O(value)
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

        //O(NM) | O(NM)
        public int LevenshteinDistanceNumberOfChangesToSameString(string strOne, string strTwo)
        {
            int[][] dp = new int[strOne.Length + 1][];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new int[strTwo.Length + 1];

            for (int i = 1; i < dp.Length; i++)
                dp[i][0] = dp[i - 1][0] + 1;

            for (int i = 1; i < dp[0].Length; i++)
                dp[0][i] = dp[0][i - 1] + 1;

            for (int i = 1; i < dp.Length; i++) //Starts at index 1 because we already computed the first row and coloumns as '' string
            {
                for (int j = 1; j < dp[0].Length; j++)
                {
                    if (strOne[i - 1] == strTwo[j - 1]) //Equal, get diagonal
                    {
                        dp[i][j] = dp[i - 1][j - 1];
                    }
                    else //Different, needs to change, get min
                    {
                        dp[i][j] = 1 + Math.Min(dp[i][j - 1], Math.Min(dp[i - 1][j - 1], dp[i - 1][j]));
                    }
                }
            }

            return dp[dp.Length - 1][dp[0].Length - 1];
        }


        //O(N) | O(N)
        public int GetMaxSumSubArrayKadanesAlgorithm(int[] arr)
        {
            int maxSum = 0;
            int[] dp = new int[arr.Length];
            dp[0] = arr[0]; //Base case, the first has no other to add...
            for (int i = 1; i < arr.Length; i++) //ATENCAO PARA INDEX 1!!!
            {
                dp[i] = Math.Max(arr[i], arr[i] + dp[i - 1]);
                maxSum = Math.Max(maxSum, dp[i]);
            }

            return maxSum;
        }


        public int[] GetPositionsOfMaxSumSubArrayKadanesAlgorithm(int[] arr)
        {
            // nao funciona, mas a ideia é essaa....
            int maxSum = 0;
            int[] dp = new int[arr.Length];
            int[] positions = new int[arr.Length];
            for (int i = 0; i < positions.Length; i++)
                positions[i] = -1;

            dp[0] = arr[0]; //Base case, the first has no other to add...
            for (int i = 1; i < arr.Length; i++) //ATENCAO PARA INDEX 1!!!
            {
                if (arr[i] + dp[i - 1] > arr[i])
                    positions[i] = i - 1;
                dp[i] = Math.Max(arr[i], arr[i] + dp[i - 1]);
                maxSum = Math.Max(maxSum, dp[i]);
            }

            return null;
        }

        //O(N) | O(1)
        public int GetMaxSumSubArrayKadanesAlgorithmOptimized(int[] arr)
        {
            int totalMax = int.MinValue;
            int maxEndingHere = 0;
            for (int i = 1; i < arr.Length; i++) //ATENCAO PARA INDEX 1!!!
            {
                maxEndingHere = Math.Max(arr[i], arr[i] + maxEndingHere);
                totalMax = Math.Max(totalMax, maxEndingHere);
            }

            return totalMax;
        }
        #endregion

        #region HasSingleCycleArray
        //O(N) | O(1)
        public bool HasSingleCycleArray(int[] arr)
        {
            int numElementsVisited = 0;
            var currentIdx = 0;
            while (numElementsVisited < arr.Length)
            {
                if (numElementsVisited != 0 && currentIdx == 0)
                    return false;
                numElementsVisited++;
                currentIdx = GetNextPosition(currentIdx, arr);
            }
            return currentIdx == 0;
        }

        private int GetNextPosition(int currentIdx, int[] arr)
        {
            var jump = arr[currentIdx];
            var nextPosition = (currentIdx + jump) % arr.Length;

            return nextPosition >= 0 ? nextPosition : nextPosition + arr.Length; // deal with negative indexes
        }
        #endregion

        #region Youngest Common Ancestor
        //O(d) time (deapth of the deapest descendent) | O(1)
        public NodeWithAncestor<char> GetYoungestCommonAncestor(NodeWithAncestor<char> root, NodeWithAncestor<char> descendentOne, NodeWithAncestor<char> descendentTwo)
        {
            int depthOne = GetDepth(root, descendentOne);
            int depthTwo = GetDepth(root, descendentTwo);
            int depthDifference = Math.Abs(depthOne - depthTwo);
            if (depthOne > depthTwo)
                descendentOne = AdjustNodePosition(descendentOne, depthDifference);
            else
                descendentTwo = AdjustNodePosition(descendentTwo, depthDifference);
            return BacktrackUntillGetCommonAncestor(descendentOne, descendentTwo);
        }

        private NodeWithAncestor<char> BacktrackUntillGetCommonAncestor(NodeWithAncestor<char> descendentOne, NodeWithAncestor<char> descendentTwo)
        {
            while (descendentOne != descendentTwo)
            {
                descendentOne = descendentOne.Ancestor;
                descendentTwo = descendentTwo.Ancestor;
            }
            return descendentOne;
        }

        private NodeWithAncestor<char> AdjustNodePosition(NodeWithAncestor<char> descendent, int depthDifference)
        {
            for (int i = 0; i < depthDifference; i++)
            {
                descendent = descendent.Ancestor;
            }
            return descendent;
        }

        private int GetDepth(NodeWithAncestor<char> root, NodeWithAncestor<char> descendent)
        {
            int depth = 0;
            while (descendent != root)
            {
                depth++;
                descendent = descendent.Ancestor;
            }
            return depth;
        }

        #endregion

        public SinglyLinkedListNode RemoveNthLinkedList(SinglyLinkedListNode head, int position)
        {
            var first = head;
            var second = head;
            int count = 1;
            while (first != null && count <= position)
            {
                first = first.next;
                count++;
            }
            if (first == null)
                return second.next;

            while (first.next != null)
            {
                first = first.next;
                second = second.next;
            }
            second.next = second.next.next;
            return head;
        }

        #region Permutation
        //O(N*!N) time | O(N*!N) space 
        public List<IList<int>> PermutationsArray(int[] arr)
        {
            var finalResults = new List<IList<int>>();
            PermutationsArrayRecursive(0, arr, finalResults);
            return finalResults;
        }

        private void PermutationsArrayRecursive(int i, int[] arr, List<IList<int>> finalResults)
        {
            if (arr.Length - 1 == i)
            {
                finalResults.Add(new List<int>(arr));
            }
            else
            {
                for (int j = i; j < arr.Length; j++)
                {
                    SwapPositions(i, j, arr);
                    PermutationsArrayRecursive(i + 1, arr, finalResults);
                    SwapPositions(i, j, arr);
                }
            }
        }

        private void SwapPositions(int i, int pos, int[] list)
        {
            var temp = list[i];
            list[i] = list[pos];
            list[pos] = temp;
        }

        public List<List<int>> PowerSetCombination(int[] arr)
        {
            var finalResult = new List<List<int>>();
            finalResult.Add(new List<int>());
            for (int i = 0; i < arr.Length; i++)
            {
                var currentSize = finalResult.Count;
                for (int j = 0; j < currentSize; j++)
                {
                    var newSet = new List<int>(finalResult[j]);
                    newSet.Add(arr[i]);
                    finalResult.Add(newSet);
                }
            }
            return finalResult;
        }
        #endregion

        public KeyValuePair<int, int> SearchSortedMatrix(int[][] matrix, int target)
        {
            int currentRow = 0;
            int currentColumn = matrix[0].Length - 1;

            while (currentColumn >= 0 && currentRow <= matrix.Length)
            {
                int currentValue = matrix[currentRow][currentColumn];
                if (target == currentValue)
                {
                    return new KeyValuePair<int, int>(currentRow, currentColumn);
                }
                else if (target < currentValue)
                {
                    currentColumn--;
                }
                else //(target > currentValue)
                {
                    currentRow++;
                }
            }
            return new KeyValuePair<int, int>(-1, -1);
        }

        public bool IsValidBracket(string s)
        {
            if (string.IsNullOrEmpty(s))
                return true;
            var dictionary = new Dictionary<char, char>() {
                { '(', ')'},
                { '[', ']'},
                { '{', '}'},
            };
            var stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                var currentBracket = s[i];
                if (dictionary.ContainsKey(currentBracket))
                    stack.Push(dictionary[currentBracket]);
                else if (stack.Count > 0)
                {
                    var currentClosingBracket = stack.Pop();
                    if (currentClosingBracket != currentBracket)
                        return false;
                }
                else
                {
                    return false;
                }
            }
            return stack.Count == 0;
        }

        #region Longest Palindrome Substring
        //O(N^2) | O(1)
        public string LongestPalindromeSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            var longestPalindrome = new KeyValuePair<int, int>(0, 0);
            for (int i = 0; i < s.Length; i++)
            {
                var even = GetPalindrome(i, i + 1, s);
                var odd = GetPalindrome(i, i, s);
                if ((even.Value - even.Key) > (longestPalindrome.Value - longestPalindrome.Key))
                    longestPalindrome = even;
                if ((odd.Value - odd.Key) > (odd.Value - odd.Key))
                    longestPalindrome = odd;
            }
            var finalResult = s.Substring(longestPalindrome.Key, longestPalindrome.Value - longestPalindrome.Key);
            return finalResult;
        }

        private KeyValuePair<int, int> GetPalindrome(int left, int right, string s)
        {
            while (left >= 0 && right < s.Length)
            {
                if (s[left] != s[right])
                    break;
                left--;
                right++;
            }
            return new KeyValuePair<int, int>(left + 1, right); //Initialposition, number of counts
        }
        #endregion

        //Time: O(NKlog K), where N is the length of strs, and K is the maximum length of a string in strs | Space: O(NK)
        public List<IList<string>> GroupAnagrams(List<string> words)
        {
            var dict = new Dictionary<string, List<string>>();
            var results = new List<IList<string>>();
            if (words.Count == 0)
                return results;
            foreach (var word in words)
            {
                var strArray = word.ToCharArray();
                Array.Sort(strArray);
                var key = new string(strArray);
                if (!dict.ContainsKey(key))
                    dict.Add(key, new List<string>());
                dict[key].Add(word);
            }
            foreach (var obj in dict)
                results.Add(obj.Value);

            return results;
        }




        public void Main()
        {
            var sufixTrie = new SufixTrie();
            sufixTrie.PopulateSufixTrieFrom("babc");
            sufixTrie.Contains("bcx");
            sufixTrie.Contains("babc");
            var anagrams = GroupAnagrams(new List<string>() { "yo", "act", "flop", "tac", "cat", "oy", "olfp" });
            var longest = LongestPalindromeSubstring("abaxyzzyxf");
            var isValid = IsValidBracket("({}[])");
            isValid = IsValidBracket("({}[]))");
            isValid = IsValidBracket("({}[]))");
            var minMaxStack = new MinMaxStack();
            minMaxStack.Push(5);
            var value = minMaxStack.GetMin();
            value = minMaxStack.GetMax();
            minMaxStack.Push(7);
            value = minMaxStack.GetMin();
            value = minMaxStack.GetMax();
            minMaxStack.Push(2);
            value = minMaxStack.GetMin();
            value = minMaxStack.GetMax();
            minMaxStack.Pop();
            value = minMaxStack.GetMin();
            value = minMaxStack.GetMax();

            var s = SearchSortedMatrix(new int[3][] {
                new int[4] { 1, 2, 3, 4 },
                new int[4] { 5, 6, 7, 8 },
                new int[4] { 9, 10, 11, 12 }
            }, 10);
            var ps = PowerSetCombination(new int[3] { 1, 2, 3 });
            var permutation = PermutationsArray(new int[] { 1, 2, 3 });
            var l1 = new SinglyLinkedListNode(1);
            var l2 = new SinglyLinkedListNode(2);
            var l3 = new SinglyLinkedListNode(3);
            var l4 = new SinglyLinkedListNode(4);
            var l5 = new SinglyLinkedListNode(5);
            l1.next = l2;
            l2.next = l3;
            l3.next = l4;
            l4.next = l5;
            RemoveNthLinkedList(l1, 3);
            var A = new NodeWithAncestor<char>('A');
            var B = new NodeWithAncestor<char>('B');
            var G = new NodeWithAncestor<char>('G');
            var H = new NodeWithAncestor<char>('H');
            var I = new NodeWithAncestor<char>('I');
            var P = new NodeWithAncestor<char>('P');
            var T = new NodeWithAncestor<char>('T');
            var U = new NodeWithAncestor<char>('U');
            T.Ancestor = P;
            U.Ancestor = P;
            P.Ancestor = H;
            H.Ancestor = B;
            G.Ancestor = B;
            I.Ancestor = B;
            B.Ancestor = A;
            var cYa = GetYoungestCommonAncestor(A, I, T);
            var matrix = new int[5][] {
                new int[5]{ 1,0,0,1,0},
                new int[5]{ 1,0,1,0,0},
                new int[5]{ 0,0,1,0,1},
                new int[5]{ 1,0,1,0,1},
                new int[5]{ 1,0,1,1,0},
            };
            RiverSizes(matrix);
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node4 = new Node(4);
            var node5 = new Node(5);
            node2.children = new List<Node>() { node3 };
            node1.children = new List<Node>() { node2, node4, node5 };
            Bfs(node1);
            Dfs(node1);
            HasSingleCycleArray(new int[] { 2, 3, 1, -4, -4, 2 });
            GetPositionsOfMaxSumSubArrayKadanesAlgorithm(new int[] { 3, 5, -9, 1, 3, -2, 3, 4, 7, 2, -9, 6, 3, 1, -5, 4 });
            GetMaxSumSubArrayKadanesAlgorithm(new int[] { 3, 5, -9, 1, 3, -2, 3, 4, 7, 2, -9, 6, 3, 1, -5, 4 });
            LevenshteinDistanceNumberOfChangesToSameString("abc", "yabd");
            NumberOfWaysToMakeChange(new int[] { 1, 5, 10, 25 }, 10);
            var results = MaxSubsetSumNoAdjacent(new int[] { 7, 10, 12, 7, 9, 14 });
            var resultTwos = MaxSubsetSumNoAdjacentOptimized(new int[] { 7, 10, 12, 7, 9, 14 });

            //var node1 = new TreeNode(1);
            //var node10 = new TreeNode(10);
            //var node5 = new TreeNode(5);
            //var node55 = new TreeNode(5);
            //var node2 = new TreeNode(2);
            //var node15 = new TreeNode(15);
            //var node13 = new TreeNode(13);
            //var node22 = new TreeNode(22);
            //var node14 = new TreeNode(14);
            //node10.left = node5;
            //node10.right = node15;
            //node5.left = node2;
            //node5.right = node55;
            //node2.left = node1;
            //node15.left = node13;
            //node15.right = node22;
            //node13.right = node14;
            //var result = InvertBinaryTree(node10);
            //var resultIterative = InvertBinaryTreeIterative(node10);

            LongestPeak(new int[] { 1, 2, 3, 3, 4, 0, 10, 6, 5, -1, -3, 2, 3 });
            SpiralTraverseMatrix(new int[4][] {
                new[] { 1, 2, 3, 4 },
                new[] { 12, 13, 14, 5 },
                new[] { 11, 16, 15, 6 },
                new[] { 10, 9, 8, 7 } });

        }
    }

    public class MinMaxStack
    {
        private Stack<MinMax> _minMaxStack;
        private Stack<int> _stack;

        public MinMaxStack()
        {
            _minMaxStack = new Stack<MinMax>();
            _stack = new Stack<int>();
        }

        public int Peek()
        {
            return _stack.Last();
        }

        public int Pop()
        {
            _minMaxStack.Pop();
            return _stack.Pop();
        }

        public void Push(int number)
        {
            if (_minMaxStack.Count == 0)
            {
                _minMaxStack.Push(new MinMax() { Max = number, Min = number });
            }
            else
            {
                var min = Math.Min(number, _minMaxStack.Peek().Min);
                var max = Math.Max(number, _minMaxStack.Peek().Max);
                _minMaxStack.Push(new MinMax() { Max = max, Min = min });
            }

            _stack.Push(number);
        }

        public int GetMin()
        {
            return _minMaxStack.Peek().Min;
        }

        public int GetMax()
        {
            return _minMaxStack.Peek().Max;
        }

        public class MinMax
        {
            public int Min;
            public int Max;
        }
    }

    public class SufixTrie
    {
        public Dictionary<char, SufixTrie> Data = new Dictionary<char, SufixTrie>();
        public bool IsEnd = false;

        //O(N^2) | O(N^2)
        public void PopulateSufixTrieFrom(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                InsertSubstring(i, str);
            }
        }

        //O(N) | O(N)
        private void InsertSubstring(int i, string str)
        {
            var current = this;
            for (int j = i; j < str.Length; j++)
            {
                var letter = str[j];
                if (!current.Data.ContainsKey(letter))
                {
                    current.Data.Add(letter, new SufixTrie());
                }
                current = current.Data[letter];
            }
            current.IsEnd = true;
        }

        //O(N) | O(1)
        public bool Contains(string str)
        {
            var current = this;
            for (int i = 0; i < str.Length; i++)
            {
                var letter = str[i];
                if (!current.Data.ContainsKey(letter))
                    return false;
                current = current.Data[letter];
            }
            return current.IsEnd;
        }
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

    public class NodeWithAncestor<T>
    {
        public T Val;
        public NodeWithAncestor<T> Ancestor;

        public NodeWithAncestor() { }

        public NodeWithAncestor(T _val)
        {
            Val = _val;
        }
    }

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

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}

