using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.BinaryTree
{
    /*
     In BFS, node a visits each of a's neighbors before visiting any of their neighbors. You can think of this as
    searching level by level out from a.
    */
    public static class BreadthFirstSearch
    {
        public static void BfsSearch(Node root)
        {
            Queue<Node> queue = new Queue<Node>();
            root.Visited = true;
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var element = queue.Dequeue();
                Console.WriteLine($"Visited {element.Value}");
                foreach (var node in element.Adjacents)
                {
                    if (!node.Visited)
                    {
                        node.Visited = true;
                        queue.Enqueue(node);
                    }
                }
            }
        }
    }
}
