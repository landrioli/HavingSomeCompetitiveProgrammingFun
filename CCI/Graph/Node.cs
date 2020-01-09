using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.BinaryTree
{
    public class Node
    {
        public Node()
        {
            Adjacents = new List<Node>();
            Visited = false;
        }

        public int Value { get; set; }
        public bool Visited { get; set; }
        public IList<Node> Adjacents { get; set; }
    }

    public class Graph
    {
        private List<Project> nodes = new List<Project>();
        private Dictionary<String, Project> map = new Dictionary<String, Project>();

        public Project getOrCreateNode(String name)
        {
            if (!map.ContainsKey(name))
            {
                Project node = new Project(name);
                nodes.Add(node);
                map[name] = node;
            }

            return map[name];
        }

        public void addEdge(String startName, String endName)
        {
            Project start = getOrCreateNode(startName);
            Project end = getOrCreateNode(endName);
            start.addNeighbor(end);
        }

        public List<Project> getNodes()
        {
            return nodes;
        }

        public class Project
        {
            public enum State { COMPLETE, PARTIAL, BLANK };
            private List<Project> children = new List<Project>();
            private Dictionary<string, Project> map = new Dictionary<string, Project>();
            private String name;
            private State state = State.BLANK;

            public Project(string n)
            {
                name = n;
            }

            public string getName()
            {
                return name;
            }

            public void addNeighbor(Project node)
            {
                if (!map.ContainsKey(node.getName()))
                {
                    children.Add(node);
                    map[node.getName()] = node;
                }
            }

            public State getState()
            {
                return state;
            }

            public void setState(State st)
            {
                state = st;
            }

            public List<Project> getChildren()
            {
                return children;
            }
        }
    }
}
