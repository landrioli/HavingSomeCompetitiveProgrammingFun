using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenges.AMZ
{

    public class TenCourseSchedule
    {
        // https://leetcode.com/problems/course-schedule/
        /*  There are a total of numCourses courses you have to take, labeled from 0 to numCourses-1.
            Some courses may have prerequisites, for example to take course 0 you have to first take course 1, which is expressed as a pair: [0,1]
            Given the total number of courses and a list of prerequisite pairs, is it possible for you to finish all courses?
                    Input: numCourses = 2, prerequisites = [[1,0]]
                Output: true
                Explanation: There are a total of 2 courses to take. 
                    To take course 1 you should have finished course 0. So it is possible.
        */
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            // Build Graph
            var graph = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < prerequisites.Length; i++)
            {
                var course = prerequisites[i][0];
                var dependency = prerequisites[i][1];
                // depednency has a dependet course
                graph[dependency].Add(course);
            }

            // DFS to detect cycles
            var visitedHash = new HashSet<int>();
            for (int i = 0; i < numCourses; i++)
            {
                bool hasCycles = HasCyclesUsingDfs(graph, visitedHash, i);
                if (hasCycles)
                    return false;
            }

            return true;
        }

        private bool HasCyclesUsingDfs(List<int>[] graph, HashSet<int> visitedHash, int courseNum)
        {
            if (visitedHash.Contains(courseNum))
                return true;
            else
                visitedHash.Add(courseNum);

            for (int i = 0; i < graph[courseNum].Count; i++)
            {
                bool hasCycle = HasCyclesUsingDfs(graph, visitedHash, graph[courseNum][i]);
                if (hasCycle)
                    return true;
            }
            //Remove to the next round
            visitedHash.Remove(courseNum);
            return false;
        }

        //https://leetcode.com/problems/course-schedule-ii/
        /*There are a total of n courses you have to take, labeled from 0 to n-1.
            Some courses may have prerequisites, for example to take course 0 you have to first take course 1, which is expressed as a pair: [0,1]
            Given the total number of courses and a list of prerequisite pairs, return the ordering of courses you should take to finish all courses.
            There may be multiple correct orders, you just need to return one of them. If it is impossible to finish all courses, return an empty array.
                Input: 2, [[1,0]] 
                Output: [0,1]
                Explanation: There are a total of 2 courses to take. To take course 1 you should have finished   
                 course 0. So the correct course order is [0,1] .

             Time: O(V + E)
             Space: O(V + E)
         */
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            // Build Graph
            var graph = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < prerequisites.Length; i++)
            {
                var course = prerequisites[i][0];
                var dependency = prerequisites[i][1];
                // depednency has a dependet course
                graph[dependency].Add(course);
            }

            // DFS to detect cycles - I used 0, 1, 2 to represent the states of "unvisited", "visiting", "visited", respectively.
            var visitStatus = new int[numCourses];
            var orderedCourses = new List<int>();
            for (int i = 0; i < numCourses; i++)
            {
                bool hasCycles = FindOrderUsingDfs(graph, visitStatus, i, orderedCourses);
                if (hasCycles)
                    return new int[0];
            }

            orderedCourses.Reverse();
            return orderedCourses.ToArray();
        }

        private bool FindOrderUsingDfs(List<int>[] graph, int[] visitStatus, int courseNum, List<int> orderedCourses)
        {
            if (visitStatus[courseNum] == 0)
            {
                visitStatus[courseNum] = 1; //visiting
                for (int i = 0; i < graph[courseNum].Count; i++)
                {
                    bool hasCycle = FindOrderUsingDfs(graph, visitStatus, graph[courseNum][i], orderedCourses);
                    if (hasCycle)
                        return true;
                }
                visitStatus[courseNum] = 2;
            }
            else if (visitStatus[courseNum] == 2)
                return false;
            else if (visitStatus[courseNum] == 1)
                return true;

            orderedCourses.Add(courseNum);

            return false;
        }


        public void Main() {
            var matrix = new int[2][];
            matrix[0] = new int[2] { 1, 0};
            matrix[1] = new int[2] { 2, 1 };
            FindOrder(3, matrix);
        }
    }
}
