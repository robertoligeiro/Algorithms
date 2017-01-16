using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathDijAndBFS
{
    class Program
    {
        static void Main(string[] args)
        {
            /* graph
             *        lp ____15guitar
             *       5 \    30       \20
             * book /    \  /              piano
             *      \   /   \           10
             *       0/       \        /
             *                 20      1drumsStick
             *       poster____35drums/
             * 
             */
            var book = new Node() { name = "book"};
            var poster = new Node() { name = "poster" };
            var lp = new Node() { name = "lp" };
            var guitar = new Node() { name = "guitar" };
            var drums = new Node() { name = "drums" };
            var drumsStick = new Node() { name = "drumsStick" };
            var piano = new Node() { name = "piano" };

            book.neighbors.Add(lp, 5);
            book.neighbors.Add(poster, 0);

            lp.neighbors.Add(guitar, 15);
            lp.neighbors.Add(drums, 20);

            poster.neighbors.Add(guitar, 30);
            poster.neighbors.Add(drums, 35);

            guitar.neighbors.Add(piano, 20);
            drums.neighbors.Add(drumsStick, 1);
            drumsStick.neighbors.Add(piano, 10);

            var djkastraResult = DjkastraAlgo.GetShortestPath(book, piano);
            // djkastraResult == 36, it includes 5 nodes - book, lp, drums, drumsStick, piano.

            var bstShortestPath = BsfShortestPath.ShortestPath(book, piano);
            // bsf returns == 4, since shortest path is 4nodes - book, lp, guitar, piano.
        }

        public class Node : IComparable
        {
            public string name { get; set; }

            public Dictionary<Node, int> neighbors { get; set; }

            public Node parent;
            public int pathCost { get; set; }

            public int CompareTo(object obj)
            {
                if (obj == null) return 1;

                Node otherNode = obj as Node;
                if (this.pathCost > otherNode.pathCost) return 1;
                return -1;
            }

            public Node()
            {
                pathCost = -1;
                neighbors = new Dictionary<Node, int>();
            }
        }


        public class DjkastraAlgo
        {
            public static int GetShortestPath(Node start, Node end)
            {
                var nodesToProcess = new List<Node>();
                var visitedNodes = new HashSet<Node>();
                foreach (var n in start.neighbors.Keys)
                {
                    n.pathCost = start.neighbors[n];
                    nodesToProcess.Add(n);
                    visitedNodes.Add(n);
                }

                while (nodesToProcess.Count > 0)
                {
                    nodesToProcess.Sort();

                    var curr = nodesToProcess[0];
                    nodesToProcess.RemoveAt(0);

                    if (curr == end)
                    {
                        return curr.pathCost;
                    }

                    foreach (var n in curr.neighbors.Keys)
                    {
                        if (visitedNodes.Contains(n))
                        {
                            if (n.pathCost > (curr.pathCost + curr.neighbors[n]))
                            {
                                n.pathCost = curr.pathCost + curr.neighbors[n];
                            }
                        }
                        else
                        {
                            n.pathCost = curr.neighbors[n] + curr.pathCost;
                            visitedNodes.Add(n);
                            nodesToProcess.Add(n);
                        }
                    }
                }

                return -1;
            }
        }

        public class BsfShortestPath
        {
            public static int ShortestPath(Node start, Node end)
            {
                var visited = new HashSet<Node>();
                var qNodes = new Queue<Node>();
                start.pathCost = 0;
                qNodes.Enqueue(start);
                visited.Add(start);

                while (qNodes.Count > 0)
                {
                    var curr = qNodes.Dequeue();

                    if (curr == end) return curr.pathCost + 1;

                    foreach (var n in curr.neighbors.Keys)
                    {
                        if (!visited.Contains(n))
                        {
                            n.pathCost = curr.pathCost + 1;
                            qNodes.Enqueue(n);
                            visited.Add(n);
                        }
                    }
                }

                return -1;
            }
        }
    }
}
