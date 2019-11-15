using CCIChallenges.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.SystemDesignAndScalability
{
    public static class SocialNetworkDesign
    {
        public static LinkedList<Person> mergePaths(BFSData bfs1, BFSData bfs2, int connection)
        {
            PathNode end1 = bfs1.visited[connection]; // end1 -> source
            PathNode end2 = bfs2.visited[connection]; // end2 -> dest
            LinkedList<Person> pathOne = end1.collapse(false); // forward: source -> connection
            LinkedList<Person> pathTwo = end2.collapse(true); // reverse: connection -> dest
            pathTwo.RemoveFirst(); // remove connection
            pathOne.AppendRange(pathTwo); // add second path
            return pathOne;
        }

        /* Search one level and return collision, if any. */
        public static Person searchLevel(Dictionary<int, Person> people, BFSData primary, BFSData secondary)
        {
            /* We only want to search one level at a time. Count how many nodes are currently in the primary's
             * level and only do that many nodes. We'll continue to add nodes to the end. */
            int count = primary.toVisit.Count;
            for (int i = 0; i < count; i++)
            {
                /* Pull out first node. */
                PathNode pathNode = primary.toVisit.First.Value;
                int personId = pathNode.getPerson().getID();

                /* Check if it's already been visited. */
                if (secondary.visited.ContainsKey(personId))
                {
                    return pathNode.getPerson();
                }

                /* Add friends to queue. */
                Person person = pathNode.getPerson();
                List<int> friends = person.getFriends();
                foreach (int friendId in friends)
                {
                    if (!primary.visited.ContainsKey(friendId))
                    {
                        Person friend = people[friendId];
                        PathNode next = new PathNode(friend, pathNode);
                        primary.visited[friendId] = next;
                        primary.toVisit.AddLast(next);
                    }
                }
            }
            return null;
        }

        public static LinkedList<Person> findPathBiBFS(Dictionary<int, Person> people, int source, int destination)
        {
            BFSData sourceData = new BFSData(people[source]);
            BFSData destData = new BFSData(people[destination]);

            while (!sourceData.isFinished() && !destData.isFinished())
            {
                /* Search out from source. */
                Person collision = searchLevel(people, sourceData, destData);
                if (collision != null)
                {
                    return mergePaths(sourceData, destData, collision.getID());
                }

                /* Search out from destination. */
                collision = searchLevel(people, destData, sourceData);
                if (collision != null)
                {
                    return mergePaths(sourceData, destData, collision.getID());
                }
            }
            return null;
        }

        public static void Main()
        {
            int nPeople = 11;
            Dictionary<int, Person> people = new Dictionary<int, Person>();
            for (int k = 0; k < nPeople; k++)
            {
                Person p = new Person(k);
                people[k] =p;
            }

            var edges = new int[11][];
            edges[0] = new int[2]{ 1, 4 };
            edges[1] = new int[2] { 1, 2 };
            edges[2] = new int[2] { 1, 3 };
            edges[3] = new int[2] { 3, 2 };
            edges[4] = new int[2] { 4,6 };
            edges[5] = new int[2] { 3,7 };
            edges[6] = new int[2] { 6,9 };
            edges[7] = new int[2] { 9,10 };
            edges[8] = new int[2] { 5,10 };
            edges[9] = new int[2] { 2,5 };
            edges[10] = new int[2] { 3,7 };
            
            foreach (var edge in edges)
            {
                Person source = people[edge[0]];
                source.addFriend(edge[1]);

                Person destination = people[edge[1]];
                destination.addFriend(edge[0]);
            }

            int i = 1;
            int j = 10;
            LinkedList<Person> path1 = findPathBiBFS(people, i, j);
            //Tester.printPeople(path1);
        }


    }

    public class Person
    {
        private List<int> friends = new List<int>();
        private int personID;
        private String info;

        public String getInfo() { return info; }
        public void setInfo(String info)
        {
            this.info = info;
        }

        public List<int> getFriends()
        {
            return friends;
        }

        public int getID() { return personID; }
        public void addFriend(int id) { friends.Add(id); }

        public Person(int id)
        {
            this.personID = id;
        }
    }

    public class BFSData
    {
        public LinkedList<PathNode> toVisit = new LinkedList<PathNode>();
        public Dictionary<int, PathNode> visited = new Dictionary<int, PathNode>();

        public BFSData(Person root)
        {
            PathNode sourcePath = new PathNode(root, null);
            toVisit.AddLast(sourcePath);
            visited[root.getID()] = sourcePath;
        }

        public bool isFinished()
        {
            return toVisit.Count == 0;
        }
    }
    public class PathNode
    {
        private Person person = null;
        private PathNode previousNode = null;
        public PathNode(Person p, PathNode previous)
        {
            person = p;
            previousNode = previous;
        }

        public Person getPerson()
        {
            return person;
        }

        public LinkedList<Person> collapse(bool startsWithRoot)
        {
            LinkedList<Person> path = new LinkedList<Person>();
            PathNode node = this;
            while (node != null)
            {
                if (startsWithRoot)
                {
                    path.AddLast(node.person);
                }
                else
                {
                    path.AddFirst(node.person);
                }
                node = node.previousNode;
            }
            return path;
        }
    }
}
