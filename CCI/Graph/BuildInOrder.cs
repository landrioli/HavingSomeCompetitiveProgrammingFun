using System;
using System.Collections.Generic;
using System.Text;
using CCIChallenges.BinaryTree;
using static CCIChallenges.BinaryTree.Graph;

namespace CCIChallenges.Graph
{
    public static class BuildInOrder
    {
        /* 4.7 Build Order: You are given a list of projects and a list of dependencies (which is a list of pairs of
                            projects, where the second project is dependent on the first project). All of a project's dependencies
                            must be built before the project is. Find a build order that will allow the projects to be built. If there
                            is no valid build order, return an error.
                            EXAMPLE
                            Input:
                            projects: a, b, c, d, e, f
                            dependencies: (a, d), (f, b), (b, d), (f, a), (d, c)
                            Output: f, e, a, b, d, c
         
         * 1- Build a graph with dependencies list for each project
           2 - For each project in the graph we will perfom DFS.
                    - We mark the current node as State.Partial and go deep;
                    - When we hit the leaf, we mark the leaf as completed (avoid do again in next steps) and add it to the stack created to build as order as go 
                    add all the previus call to that
            PSEUDO LOGIC:
                    if (project.getState() == Project.State.PARTIAL)
                    {
                        return false; // Cycle
                    }

                    if (project.getState() == Project.State.BLANK)
                    {
                        project.setState(Project.State.PARTIAL);
                        foreach (var child in Project.children)
                        {
                            do DFS(child)
                        }
                        project.setState(Project.State.COMPLETE);
                        stack.Push(project);
             */
        public static CCIChallenges.BinaryTree.Graph BuildGraph(String[] projects, String[][] dependencies)
        {
            var graph = new CCIChallenges.BinaryTree.Graph();

            foreach (var dependency in dependencies)
            {
                string first = dependency[0];
                string second = dependency[1];
                graph.addEdge(first, second);
            }

            return graph;
        }

        public static bool DoDFS(Project project, Stack<Project> stack)
        {
            if (project.getState() == Project.State.PARTIAL)
            {
                return false; // Cycle
            }

            if (project.getState() == Project.State.BLANK)
            {
                project.setState(Project.State.PARTIAL);
                List<Project> children = project.getChildren();
                foreach (var child in children)
                {
                    if (!DoDFS(child, stack))
                    {
                        return false;
                    }
                }
                project.setState(Project.State.COMPLETE);
                stack.Push(project);
            }
            return true;
        }

        public static Stack<Project> OrderProjects(List<Project> projects)
        {
            Stack<Project> stack = new Stack<Project>();
            foreach (var project in projects)
            {
                if (project.getState() == Project.State.BLANK)
                {
                    if (!DoDFS(project, stack))
                    {
                        return null;
                    }
                }
            }
            return stack;
        }

        public static String[] convertToStringList(Stack<Project> projects)
        {
            String[] buildOrder = new String[projects.Count];
            for (int i = 0; i < buildOrder.Length; i++)
            {
                buildOrder[i] = projects.Pop().getName();
            }
            return buildOrder;
        }

        public static Stack<Project> findBuildOrder(String[] projects, String[][] dependencies)
        {
            CCIChallenges.BinaryTree.Graph graph = BuildGraph(projects, dependencies);
            return OrderProjects(graph.getNodes());
        }

        public static String[] BuildOrderWrapper(String[] projects, String[][] dependencies)
        {
            Stack<Project> buildOrder = findBuildOrder(projects, dependencies);
            if (buildOrder == null) return null;
            String[] buildOrderString = convertToStringList(buildOrder);
            return buildOrderString;
        }

        public static void Main()
        {
            String[] projects = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
            var dependencies = new string[11][] {
                 new string[]{ "a","b"},
                 new string[]{"b", "c"},
                 new string[]{"a", "c"},
                 new string[]{"d", "e"},
                 new string[]{"b", "d"},
                 new string[]{"e", "f"},
                 new string[]{"a", "f"},
                 new string[]{"h", "i"},
                 new string[]{"h", "j"},
                 new string[]{"i", "j"},
                 new string[]{"g", "j"}
            };
            string[] buildOrder = BuildOrderWrapper(projects, dependencies);
            if (buildOrder == null)
            {
                Console.WriteLine("Circular Dependency.");
            }
            else
            {
                foreach (var s in buildOrder)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
