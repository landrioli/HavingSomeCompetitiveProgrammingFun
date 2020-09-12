using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenges.AMZ.WhiteBoardLeetCode
{
    public class WhiteBoardLeetCode
    {
        //Time O(kN) k is the number of linklists | Space O(1) selected nodes instead of creating new nodes to fill the new linked list.
        public ListNode MergeKLists(ListNode[] lists)
        {
            var dummyHead = new ListNode(0);
            var prev = dummyHead;
            while (true)
            {
                bool shouldBreak = true;
                int idxOfSmallestValue = -1;
                int smallestValue = int.MaxValue;
                for (int i = 0; i < lists.Length; i++)
                {
                    if (lists[i] != null)
                    {
                        shouldBreak = false;
                        if (lists[i].val < smallestValue)
                        {
                            idxOfSmallestValue = i;
                            smallestValue = lists[i].val;
                        }
                    }
                }
                if (shouldBreak)
                    break;
                prev.next = lists[idxOfSmallestValue];
                prev = prev.next;
                lists[idxOfSmallestValue] = lists[idxOfSmallestValue].next;
            }

            return dummyHead.next;
        }

        #region Number To Words
        public String NumberToWords(int num)
        {
            if (num == 0)
                return "Zero";

            int billion = num / 1000000000;
            int million = (num - billion * 1000000000) / 1000000;
            int thousand = (num - billion * 1000000000 - million * 1000000) / 1000;
            int rest = num - billion * 1000000000 - million * 1000000 - thousand * 1000;

            String result = "";
            if (billion != 0)
                result = three(billion) + " Billion";
            if (million != 0)
            {
                if (!string.IsNullOrEmpty(result))
                    result += " ";
                result += three(million) + " Million";
            }
            if (thousand != 0)
            {
                if (!string.IsNullOrEmpty(result))
                    result += " ";
                result += three(thousand) + " Thousand";
            }
            if (rest != 0)
            {
                if (!string.IsNullOrEmpty(result))
                    result += " ";
                result += three(rest);
            }
            return result;
        }

        public String one(int num)
        {
            switch (num)
            {
                case 1: return "One";
                case 2: return "Two";
                case 3: return "Three";
                case 4: return "Four";
                case 5: return "Five";
                case 6: return "Six";
                case 7: return "Seven";
                case 8: return "Eight";
                case 9: return "Nine";
            }
            return "";
        }

        public String twoLessThan20(int num)
        {
            switch (num)
            {
                case 10: return "Ten";
                case 11: return "Eleven";
                case 12: return "Twelve";
                case 13: return "Thirteen";
                case 14: return "Fourteen";
                case 15: return "Fifteen";
                case 16: return "Sixteen";
                case 17: return "Seventeen";
                case 18: return "Eighteen";
                case 19: return "Nineteen";
            }
            return "";
        }

        public String ten(int num)
        {
            switch (num)
            {
                case 2: return "Twenty";
                case 3: return "Thirty";
                case 4: return "Forty";
                case 5: return "Fifty";
                case 6: return "Sixty";
                case 7: return "Seventy";
                case 8: return "Eighty";
                case 9: return "Ninety";
            }
            return "";
        }

        public String two(int num)
        {
            if (num == 0)
                return "";
            else if (num < 10)
                return one(num);
            else if (num < 20)
                return twoLessThan20(num);
            else
            {
                int tenner = num / 10;
                int rest = num - tenner * 10;
                if (rest != 0)
                    return ten(tenner) + " " + one(rest);
                else
                    return ten(tenner);
            }
        }

        public String three(int num)
        {
            int hundred = num / 100;
            int rest = num - hundred * 100;
            String res = "";
            if (hundred * rest != 0)
                res = one(hundred) + " Hundred " + two(rest);
            else if ((hundred == 0) && (rest != 0))
                res = two(rest);
            else if ((hundred != 0) && (rest == 0))
                res = one(hundred) + " Hundred";
            return res;
        }
        #endregion

        #region LRU Cache
        public class LRUCache
        {
            private Dictionary<int, DLinkedNode> cache = new Dictionary<int, DLinkedNode>();
            private int size;
            private int capacity;
            private DLinkedNode head;
            private DLinkedNode tail;

            public LRUCache(int capacity)
            {
                this.size = 0;
                this.capacity = capacity;

                head = new DLinkedNode();
                // head.prev = null;

                tail = new DLinkedNode();
                // tail.next = null;

                head.next = tail;
                tail.prev = head;
            }

            public int Get(int key)
            {
                if (!cache.ContainsKey(key))
                    return -1;

                DLinkedNode node = cache[key];
                moveToHead(node);
                return node.value;
            }

            public void Put(int key, int value)
            {
                if (cache.ContainsKey(key))
                {
                    // update the value.
                    cache[key].value = value;
                    moveToHead(cache[key]);
                }
                else
                {
                    DLinkedNode newNode = new DLinkedNode();
                    newNode.key = key;
                    newNode.value = value;

                    cache.Add(key, newNode);
                    addNode(newNode);

                    ++size;

                    if (size > capacity)
                    {
                        // pop the tail
                        DLinkedNode tail = popTail();
                        cache.Remove(tail.key);
                        --size;
                    }
                }

            }

            private void addNode(DLinkedNode node)
            {
                //Always add the new node right after head.
                node.prev = head;
                node.next = head.next;

                head.next.prev = node;
                head.next = node;
            }

            private void removeNode(DLinkedNode node)
            {
                // Remove an existing node from the linked list.
                DLinkedNode prev = node.prev;
                DLinkedNode next = node.next;

                prev.next = next;
                next.prev = prev;
            }

            private void moveToHead(DLinkedNode node)
            {
                // Move certain node in between to the head.
                removeNode(node);
                addNode(node);
            }

            private DLinkedNode popTail()
            {
                //Pop the current tail.
                DLinkedNode res = tail.prev;
                removeNode(res);
                return res;
            }

        }
        #endregion

        #region Product array Except Self
        //O(N) | O(N)
        public int[] ProductExceptSelf(int[] nums)
        {
            // The left and right arrays as described in the algorithm
            int[] L = new int[nums.Length];
            int[] R = new int[nums.Length];

            // Final answer array to be returned
            int[] answer = new int[nums.Length];

            // L[i] contains the product of all the elements to the left
            // Note: for the element at index '0', there are no elements to the left,
            // so L[0] would be 1
            L[0] = 1;
            for (int i = 1; i < nums.Length; i++)
            {

                // L[i - 1] already contains the product of elements to the left of 'i - 1'
                // Simply multiplying it with nums[i - 1] would give the product of all
                // elements to the left of index 'i'
                L[i] = nums[i - 1] * L[i - 1];
            }

            // R[i] contains the product of all the elements to the right
            // Note: for the element at index 'nums.Length - 1', there are no elements to the right,
            // so the R[nums.Length - 1] would be 1
            R[nums.Length - 1] = 1;
            for (int i = nums.Length - 2; i >= 0; i--)
            {

                // R[i + 1] already contains the product of elements to the right of 'i + 1'
                // Simply multiplying it with nums[i + 1] would give the product of all
                // elements to the right of index 'i'
                R[i] = nums[i + 1] * R[i + 1];
            }

            // Constructing the answer array
            for (int i = 0; i < nums.Length; i++)
            {
                // For the first element, R[i] would be product except self
                // For the last element of the array, product except self would be L[i]
                // Else, multiple product of all elements to the left and to the right
                answer[i] = L[i] * R[i];
            }

            return answer;
        }

        //Time complexity : O(N)O(N) where NN represents the number of elements in the input array. We use one iteration to construct the array LL, one to update the array answeranswer.
        // Space complexity : O(1) since don't use any additional array for our computations (the return arry is not considered here)
        public int[] ProductExceptSelfOptimizedSpace(int[] nums)
        {
            // Final answer array to be returned
            int[] answer = new int[nums.Length];

            // answer[i] contains the product of all the elements to the left
            // Note: for the element at index '0', there are no elements to the left,
            // so the answer[0] would be 1
            answer[0] = 1;
            for (int i = 1; i < nums.Length; i++)
            {

                // answer[i - 1] already contains the product of elements to the left of 'i - 1'
                // Simply multiplying it with nums[i - 1] would give the product of all 
                // elements to the left of index 'i'
                answer[i] = nums[i - 1] * answer[i - 1];
            }

            // R contains the product of all the elements to the right
            // Note: for the element at index 'nums.Length - 1', there are no elements to the right,
            // so the R would be 1
            int R = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {

                // For the index 'i', R would contain the 
                // product of all elements to the right. We update R accordingly
                answer[i] = answer[i] * R;
                R *= nums[i];
            }

            return answer;
        }
        #endregion

        #region BestTimeToBuyAndSellStocks
        //O(N) | O(1)
        public int MaxProfitBestTimeToBuyAndSellStocks(int[] prices)
        {
            int minprice = int.MaxValue;
            int maxProfit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minprice)
                    minprice = prices[i];
                else if (prices[i] - minprice > maxProfit)
                    maxProfit = prices[i] - minprice;
            }
            return maxProfit;
        }

        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/
        //O(N) | O(1)
        public int MaxProfitBestTimeToBuyAndSellStocks2(int[] prices)
        {
            int maxprofit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                    maxprofit += prices[i] - prices[i - 1];
            }
            return maxprofit;
        }

        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iii/
        //Design an algorithm to find the maximum profit. You may complete at most two transactions.
        //O(N) | O(N)
        public int MaxProfitBestTimeToBuyAndSellStocks3(int[] prices)
        {
            if (prices.Length <= 1) return 0;

            int leftMin = prices[0];
            int rightMax = prices[prices.Length - 1];

            int[] leftProfits = new int[prices.Length];
            // pad the right DP array with an additional zero for convenience.
            int[] rightProfits = new int[prices.Length + 1];

            // construct the bidirectional DP array
            for (int l = 1; l < prices.Length; ++l)
            {
                leftProfits[l] = Math.Max(leftProfits[l - 1], prices[l] - leftMin);
                leftMin = Math.Min(leftMin, prices[l]);

                int r = prices.Length - 1 - l;
                rightProfits[r] = Math.Max(rightProfits[r + 1], rightMax - prices[r]);
                rightMax = Math.Max(rightMax, prices[r]);
            }

            int maxProfit = 0;
            for (int i = 0; i < prices.Length; ++i)
            {
                maxProfit = Math.Max(maxProfit, leftProfits[i] + rightProfits[i + 1]);
            }
            return maxProfit;
        }
        #endregion

        #region WordLadder 1 2
        //O(N x S) time where N is the length of wordList and S is the Length of the biggest word | O(N x S) space
        public int WordLadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            var hash = new HashSet<string>(wordList);
            var queue = new Queue<string>();
            int transformations = 1;
            queue.Enqueue(beginWord);

            while (queue.Count != 0)
            {
                int currentPosibilitiestoCountTransformation = queue.Count; //I need it because i can have 2 different tarnsformations form one word but I need to cout only one
                for (int q = 0; q < currentPosibilitiestoCountTransformation; q++)
                {
                    var currKey = queue.Dequeue().ToCharArray();
                    for (int i = 0; i < currKey.Length; i++)
                    {
                        var tempChar = currKey[i];
                        for (char chr = 'a'; chr <= 'z'; chr++)
                        {
                            currKey[i] = chr;
                            string newKey = new string(currKey);
                            if (hash.Contains(newKey))
                            {
                                if (newKey == endWord)
                                    return transformations + 1;
                                queue.Enqueue(newKey);
                                hash.Remove(newKey);
                            }
                        }
                        currKey[i] = tempChar;
                    }
                }
                transformations++;
            }
            return 0; //case where there are no matches
        }

        public IList<IList<string>> FindLadders(string start, string end, IList<String> wordList)
        {
            var hash = new HashSet<string>(wordList);
            var res = new List<IList<string>>();
            var nodeNeighbors = new Dictionary<string, IList<string>>();// Neighbors for every node
            var distance = new Dictionary<String, int>();// Distance of every node from the start node
            var solution = new List<String>();
            hash.Remove(start); //We eliminate the initialWord from the options to go into in next steps 
            bfs(start, end, hash, nodeNeighbors, distance);
            dfs(start, end, nodeNeighbors, distance, solution, res);
            return res;
        }
        // BFS: Trace every node's distance from the start node (level by level).
        private void bfs(string start, string endWord, HashSet<String> hash, Dictionary<String, IList<String>> nodeNeighbors, Dictionary<String, int> distance)
        {
            foreach (string str in hash)
                nodeNeighbors[str] = new List<String>();
            nodeNeighbors[start] = new List<String>(); //Initialize with the start node (it is not in the hash of intermediates)
            distance[start] = 0;

            Queue<String> queue = new Queue<String>();
            queue.Enqueue(start);

            while (queue.Count != 0)
            {
                bool foundEnd = false;
                int currentPosibilitiestoCountTransformation = queue.Count;
                for (int q = 0; q < currentPosibilitiestoCountTransformation; q++)
                {
                    var currKeyString = queue.Dequeue();
                    var currKey = currKeyString.ToCharArray();
                    int curDistance = distance[currKeyString];

                    for (int i = 0; i < currKey.Length; i++)
                    {
                        var tempChar = currKey[i];
                        for (char chr = 'a'; chr <= 'z'; chr++)
                        {
                            currKey[i] = chr;
                            string newKey = new string(currKey);
                            if (hash.Contains(newKey))
                            {
                                var currentNeighborns = nodeNeighbors[currKeyString];
                                currentNeighborns.Add(newKey);
                                nodeNeighbors[currKeyString] = currentNeighborns;
                                distance[newKey] = curDistance + 1;

                                if (newKey == endWord)
                                    foundEnd = true; //I can not return here because I can find the end but the transfomation can find another options from a-z in this loop...
                                else
                                {
                                    queue.Enqueue(newKey);
                                    hash.Remove(newKey);
                                }
                            }
                        }
                        currKey[i] = tempChar;
                    }
                }
                if (foundEnd)
                    break;
            }
        }

        private void dfs(string cur, string end, Dictionary<String, IList<String>> nodeNeighbors, Dictionary<String, int> distance, IList<String> solution, IList<IList<string>> res)
        {
            solution.Add(cur);
            if (end == cur)
            {
                res.Add(new List<String>(solution));
            }
            else
            {
                foreach (string next in nodeNeighbors[cur])
                {
                    if (distance[next] == distance[cur] + 1) // Here I can know what is the next transformation
                    {
                        dfs(next, end, nodeNeighbors, distance, solution, res);
                    }
                }
            }
            solution.RemoveAt(solution.Count - 1);
        }
        #endregion
        public int[][] kClosest(int[][] points, int K)
        {
            Array.Sort(points, (p1, p2) => p1[0] * p1[0] + p1[1] * p1[1] - p2[0] * p2[0] - p2[1] * p2[1]);
            return points.Take(K).ToArray();
        }

        #region Word Break
        public bool WordBreak(string s, IList<string> wordDict)
        {
            var hash = new HashSet<string>(wordDict);
            var cache = new bool?[s.Length];
            return WordBreakRecursiveWithMemoization(s, hash, 0, cache);
        }

        //Time complexity : O(n^2). Size of recursion tree can go up to n^2n  | Space complexity : O(n) The depth of recursion tree can go up to n.
        public bool WordBreakRecursiveWithMemoization(string s, HashSet<string> hash, int start, bool?[] cache)
        {
            if (start == s.Length)
            {
                return true;
            }
            if (cache[start] != null)
            {
                return (bool)cache[start];
            }
            for (int end = start + 1; end <= s.Length; end++)
            {
                var currentWord = s.Substring(start, end - start);
                if (hash.Contains(currentWord))
                {
                    if (WordBreakRecursiveWithMemoization(s, hash, end, cache))
                    {
                        cache[start] = true;
                        return true;
                    }
                }
            }
            cache[start] = false;
            return false;
        }

        //Time complexity : O(n^3). There are two nested loops, and substring computation at each iteration. | Space complexity: O(N) length of array is N + 1
        public bool WordBreakDinamicProgramming(String s, List<String> wordDict)
        {
            var wordDictSet = new HashSet<string>(wordDict);
            bool[] dp = new bool[s.Length + 1];
            dp[0] = true;
            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (dp[j] && wordDictSet.Contains(s.Substring(j, i - j)))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }
            return dp[s.Length];
        }


        //Using DFS directly will lead to TLE, so I just used HashMap to save the previous results to prune duplicated branches, as the following:
        // O(2^n) Time Worst Case
        public List<String> WordBreakTwo(String s, HashSet<String> wordDict)
        {
            return WordBreakTwoDFS(s, wordDict, new Dictionary<String, List<String>>());
        }

        // DFS function returns an array including all substrings derived from s.
        List<String> WordBreakTwoDFS(String s, HashSet<String> wordDict, Dictionary<String, List<String>> map)
        {
            if (map.ContainsKey(s))
                return map[s];

            var res = new List<String>();
            if (s.Length == 0)
            {
                res.Add("");
                return res;
            }
            foreach (String word in wordDict)
            {
                if (s.StartsWith(word))
                {
                    List<String> sublist = WordBreakTwoDFS(s.Substring(word.Length), wordDict, map);
                    foreach (String sub in sublist)
                        res.Add(word + (string.IsNullOrEmpty(sub) ? "" : " ") + sub);
                }
            }
            map[s] = res;
            return res;
        }

        private int dist(int[] point)
        {
            return point[0] * point[0] + point[1] * point[1];
        }
        #endregion

        #region Binary Tree
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var levels = new List<IList<int>>();
            if (root == null)
                return levels;

            var queue = new Queue<TreeNode>();
            var currentLevel = 0;
            queue.Enqueue(root);
            bool zigzag = false;
            while (queue.Count != 0)
            {
                var currentSizeForTheLevel = queue.Count;
                levels.Add(new List<int>());

                for (int i = 0; i < currentSizeForTheLevel; i++)
                {
                    var current = queue.Dequeue();
                    if (zigzag)
                        levels[currentLevel].Insert(0, current.val);
                    else
                        levels[currentLevel].Add(current.val);
                    if (current.left != null)
                        queue.Enqueue(current.left);
                    if (current.right != null)
                        queue.Enqueue(current.right);
                }
                currentLevel++;
                zigzag = !zigzag;
            }
            return levels;
        }


        int maxSum = int.MinValue;
        //Time complexity: O(N), where N is number of nodes, since we visit each node not more than 2 times.
        //Space complexity: O(H), where H is a tree height, to keep the recursion stack. In the average case of balanced tree, the tree height H = log N, in the worst case of skewed tree, H = N.
        private int MaxGain(TreeNode node)
        {
            if (node == null) return 0;

            // max sum on the left and right sub-trees of node
            int currentLeftGain = MaxGain(node.left);
            int totalLeftGain = Math.Max(currentLeftGain, 0);

            int currentRightGain = MaxGain(node.right);
            int totalRightGain = Math.Max(currentRightGain, 0);

            // the price to start a new path where `node` is a highest node
            int price_newpath = node.val + totalLeftGain + totalRightGain;

            // update max_sum if it's better to start a new path
            maxSum = Math.Max(maxSum, price_newpath);

            // for recursion :
            // return the max gain if continue the same path
            return node.val + Math.Max(totalLeftGain, totalRightGain);
        }

        public int MaxPathSum(TreeNode root)
        {
            MaxGain(root);
            return maxSum;
        }
        #endregion

        #region Topological Sort - Projects depdencies
        private List<int> orderedCoursesForBonusInformation = new List<int>();
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            if (numCourses == 0)
                return true;

            var listDependencies = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++)
                listDependencies[i] = new List<int>();

            foreach (var preRequisit in prerequisites)
            {
                int course = preRequisit[0];
                int dependency = preRequisit[1];
                listDependencies[dependency].Add(course);
            }

            var visitStatus = new int[numCourses]; //0, 1, 2 - "unvisited", "visiting", "visited"
            for (int i = 0; i < numCourses; i++)
            {
                bool hasCycle = HasCycleDfs(listDependencies, visitStatus, i);
                if (hasCycle)
                    return false;
            }
            return true;
        }

        private bool HasCycleDfs(List<int>[] dependencies, int[] visitStatus, int courseId)
        {
            if (visitStatus[courseId] == 1)
                return true;

            if (visitStatus[courseId] == 2)
                return false;

            visitStatus[courseId] = 1;
            var coursesThatDependsFromMe = dependencies[courseId];
            foreach (var course in coursesThatDependsFromMe)
            {
                bool hasCycle = HasCycleDfs(dependencies, visitStatus, course);
                if (hasCycle)
                    return true;
            }
            visitStatus[courseId] = 2;

            orderedCoursesForBonusInformation.Insert(0, courseId);

            return false;
        }

        #endregion

        public string MostCommonWord(string paragraph, string[] banned)
        {
            var bannedWords = new HashSet<string>(banned);

            // 1). replace the punctuations with spaces,
            // and put all letters in lower case
            char[] invalidChars = new char[] { '!', '?', ',', '.', ';', ' ', '\'' };
            string clearParagraph = paragraph.ToLower();
            string[] words = clearParagraph.Split(invalidChars);


            var wordCount = new Dictionary<string, int>();
            // 3). count the appearance of each word, excluding the banned words
            foreach (var word in words)
            {
                if (!string.IsNullOrEmpty(word) && !bannedWords.Contains(word))
                {
                    if (!wordCount.ContainsKey(word))
                        wordCount[word] = 1;
                    else
                        wordCount[word] = wordCount[word] + 1;
                }
            }

            // 4). return the word with the highest frequency
            return wordCount.OrderByDescending(p => p.Value).First().Key;
        }


        #region Copy List with Random Pointer
        //Time Complexity : O(N) because we make one pass over the original linked list.
        //Space Complexity : O(N) as we have a dictionary containing mapping from old list nodes to new list nodes.Since there are N nodes
        public Node CopyRandomList(Node head)
        {
            if (head == null)
            {
                return null;
            }
            // Visited dictionary to hold old node reference as "key" and new node reference as the "value"
            var visited = new Dictionary<Node, Node>();
            Node oldNode = head;

            // Creating the new head node.
            Node newNode = new Node(oldNode.val);
            visited[oldNode] = newNode;

            // Iterate on the linked list until all nodes are cloned.
            while (oldNode != null)
            {
                // Get the clones of the nodes referenced by random and next pointers.
                newNode.random = GetClonedNode(oldNode.random, visited);
                newNode.next = GetClonedNode(oldNode.next, visited);

                // Move one step ahead in the linked list.
                oldNode = oldNode.next;
                newNode = newNode.next;
            }
            return visited[head];
        }

        private Node GetClonedNode(Node node, Dictionary<Node, Node> visited)
        {
            // If the node exists then
            if (node != null)
            {
                // Check if the node is in the visited dictionary
                if (visited.ContainsKey(node))
                {
                    // If its in the visited dictionary then return the new node reference from the dictionary
                    return visited[node];
                }
                else
                {
                    // Otherwise create a new node, add to the dictionary and return it
                    visited[node] = new Node(node.val);
                    return visited[node];
                }
            }
            return null;
        }

        //Time Complexity : O(N)
        //Space Complexity : O(1)
        public Node CopyRandomListOptimized(Node head)
        {
            if (head == null)
            {
                return null;
            }

            // Creating a new weaved list of original and copied nodes.
            Node ptr = head;
            while (ptr != null)
            {

                // Cloned node
                Node newNode = new Node(ptr.val);

                // Inserting the cloned node just next to the original node.
                // If A->B->C is the original linked list,
                // Linked list after weaving cloned nodes would be A->A'->B->B'->C->C'
                newNode.next = ptr.next;
                ptr.next = newNode;
                ptr = newNode.next;
            }

            ptr = head;

            // Now link the random pointers of the new nodes created.
            // Iterate the newly created list and use the original nodes' random pointers, to assign references to random pointers for cloned nodes.
            while (ptr != null)
            {
                ptr.next.random = (ptr.random != null) ? ptr.random.next : null;
                ptr = ptr.next.next;
            }

            // Unweave the linked list to get back the original linked list and the cloned list.
            // i.e. A->A'->B->B'->C->C' would be broken to A->B->C and A'->B'->C'
            Node ptr_old_list = head; // A->B->C
            Node ptr_new_list = head.next; // A'->B'->C'
            Node head_new = head.next;
            while (ptr_old_list != null)
            {
                ptr_old_list.next = ptr_old_list.next.next;
                ptr_new_list.next = (ptr_new_list.next != null) ? ptr_new_list.next.next : null;
                ptr_old_list = ptr_old_list.next;
                ptr_new_list = ptr_new_list.next;
            }
            return head_new;
        }

        #endregion

        #region Meeting Rooms
        //O(Nlog(N)) time | O(1) space
        public bool CanAttendMeetings(int[][] intervals)
        {
            if (intervals.Length == 0)
                return true;

            //Array.Sort(intervals, (int[] i1, int[] i2) => (i1[0] - i2[0]));
            intervals = intervals.OrderBy(p => p[0]).ToArray();
            for (int i = 0; i < intervals.Length - 1; i++)
                if (intervals[i][1] > intervals[i + 1][0])
                    return false;
            return true;
        }

        //Time Complexity: O(NlogN) because all we are doing is sorting the two arrays for start timings and end timings individually and each of them would contain N elements considering there are N intervals.
        //Space Complexity: O(N) because we create two separate arrays of size N, one for recording the start times and one for the end times.
        //A meeting is defined by its start and end times. However, for this specific algorithm, we need to treat the start and end times individually. 
        //This might not make sense right away because a meeting is defined by its start and end times. If we separate the two and treat them individually, then the identity of a meeting goes away. This is fine because:When we encounter an ending event, that means that some meeting that started earlier has ended now. We are not really concerned with which meeting has ended. All we need is that some meeting ended thus making a room available.
        public int MinMeetingRooms(int[][] intervals)
        {
            // Check for the base case. If there are no intervals, return 0
            if (intervals.Length == 0)
            {
                return 0;
            }

            var start = new int[intervals.Length];
            var end = new int[intervals.Length];

            for (int i = 0; i < intervals.Length; i++)
            {
                start[i] = intervals[i][0];
                end[i] = intervals[i][1];
            }

            start = start.OrderBy(p => p).ToArray();
            end = end.OrderBy(p => p).ToArray();

            // The two pointers in the algorithm: e_ptr and s_ptr.
            int startPointer = 0, endPointer = 0;

            // Variables to keep track of maximum number of rooms used.
            int usedRooms = 0;

            // Iterate over intervals.
            while (startPointer < intervals.Length)
            {

                // If there is a meeting that has ended by the time the meeting at `start_pointer` starts
                if (start[startPointer] >= end[endPointer])
                {
                    usedRooms -= 1;
                    endPointer += 1;
                }

                // We do this irrespective of whether a room frees up or not.
                // If a room got free, then this used_rooms += 1 wouldn't have any effect. used_rooms would
                // remain the same in that case. If no room was free, then this would increase used_rooms
                usedRooms += 1;
                startPointer += 1;

            }

            return usedRooms;
        }

        #endregion


        private Dictionary<int, char[]> letterDict = new Dictionary<int, char[]>()
        {
            {2, new char[3]{'a', 'b', 'c'} },
            {3, new char[3]{'d', 'e', 'f'}},
            {4, new char[3]{'g', 'h', 'i'}},
            {5, new char[3]{'j', 'k', 'l'}},
            {6, new char[3]{'m', 'n', 'o'}},
            {7, new char[4]{'p', 'q', 'r', 's'}},
            {8, new char[3]{'t', 'u', 'v'}},
            {9, new char[4]{'w', 'x', 'y', 'z'}}
        };

        public IList<string> LetterCombinations(string digits)
        {
            var result = new List<string>();
            LetterCombinationsRecursive(0, digits, string.Empty, result);
            return result;
        }

        //Time O(3^N x 4^N) where N is number of digits that maps to 3 and 4 letters | Space O(3^N x 4^N) where N is number of digits that maps to 3 and 4 letters
        private void LetterCombinationsRecursive(int currDigPosition, string digits, string prefix, List<string> result)
        {
            if (prefix.Length == digits.Length)
            {
                result.Add(prefix);
                return;
            }
            var currentDigit = digits[currDigPosition] - '0';
            var currentLetters = letterDict[currentDigit];
            for (int i = 0; i < currentLetters.Length; i++)
            {
                LetterCombinationsRecursive(currDigPosition + 1, digits, prefix + currentLetters[i], result);
            }
        }


        public void Main()
        {
            LetterCombinations("23");
            var rooms = MinMeetingRooms(new int[3][] {
                new int[2] { 0,30},
                new int[2] { 5,10},
                new int[2] { 15,20},
            });
            MostCommonWord("Bob hit a ball, the hit BALL flew far after it was hit.", new string[] { "hit" });
            var matrix = new int[1][];
            matrix[0] = new int[] { 1, 0 };
            CanFinish(2, matrix);

            var t1 = new TreeNode(-10);
            var t2 = new TreeNode(9);
            var t3 = new TreeNode(20);
            var t4 = new TreeNode(15);
            var t5 = new TreeNode(7);
            t1.left = t2;

            t1.right = t3;
            t3.left = t4;
            t3.right = t5;
            int max = MaxPathSum(t1);
            ZigzagLevelOrder(t1);

            var wb = WordBreakDinamicProgramming("ele", new List<string>() { "e", "le" });
            var len2 = FindLadders("red", "tax", new List<string>() { "ted", "tex", "red", "tax", "tad", "den", "rex", "pee" });
            var len1 = WordLadderLength("hit", "cog", new string[] { "hot", "dot", "dog", "lot", "log", "cog" });
            var profit = MaxProfitBestTimeToBuyAndSellStocks2(new int[3] { 7, 3, 5 });
            var lruCache = new LRUCache(3);
            lruCache.Put(1, 1);
            lruCache.Put(2, 2);
            lruCache.Put(3, 3);
            lruCache.Get(1);
            lruCache.Put(4, 4);
            var num = NumberToWords(1222333);
            var ln1 = new ListNode(1);
            var ln11 = new ListNode(1);
            var ln2 = new ListNode(2);
            var ln3 = new ListNode(3);
            var ln4 = new ListNode(4);
            var ln44 = new ListNode(4);
            var ln5 = new ListNode(5);
            var ln6 = new ListNode(6);
            ln1.next = ln4;
            ln4.next = ln5;
            ln11.next = ln3;
            ln3.next = ln44;
            ln2.next = ln6;
            var merge = MergeKLists(new ListNode[3] { ln1, ln11, ln2 });
        }
    }



    public class DLinkedNode
    {
        public int key;
        public int value;
        public DLinkedNode prev;
        public DLinkedNode next;
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


    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }

}
