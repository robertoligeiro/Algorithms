using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsShortestPathDjakstra
{
    class Program
    {
        static void Main(string[] args)
        {
            var n0 = new Node() { val = 0 };
            var n1 = new Node() { val = 1 };
            var n2 = new Node() { val = 2 };
            var n3 = new Node() { val = 3 };
            var n4 = new Node() { val = 4 };
            n0.children.Add(n1, 0);
            n0.children.Add(n2, 10);
            n1.children.Add(n3, 30);
            n1.children.Add(n4, 40);
            n2.children.Add(n3, 10);
            n2.children.Add(n4, 15);
            n4.children.Add(n0, 10);
            var r = GetShortedPath(n0, n4);
        }

        public class Node : IComparable
        {
            public Dictionary<Node, int> children = new Dictionary<Node, int>();
            public int val;
            public Node parent;
            public int dist;
            public int cost;

            public int CompareTo(object obj)
            {
                var n = obj as Node;
                return cost.CompareTo(n.cost);
            }
        }

        public static int GetShortedPath(Node from, Node to)
        {
            var set = new SortedSet<Node>();
            var visited = new Dictionary<Node, int>() {};
            visited.Add(from, from.cost);

            set.Add(from);

            while (set.Count > 0)
            {
                var curr = set.FirstOrDefault();
                set.Remove(curr);
                foreach (var c in curr.children.Keys)
                {
                    var costFromThisChild = curr.cost + curr.children[c];
                    if (visited.ContainsKey(c))
                    {
                        if (visited[c] > costFromThisChild)
                        {
                            var updatedNode = visited.Keys.Where(x => x == c).FirstOrDefault();
                            visited.Remove(c);
                            updatedNode.cost = costFromThisChild;
                            updatedNode.parent = curr;
                            visited.Add(updatedNode, costFromThisChild);
                        }
                    }
                    else
                    {
                        c.parent = curr;
                        c.cost = costFromThisChild;
                        visited.Add(c, costFromThisChild);
                        set.Add(c);
                    }
                }
            }

            return visited[to];
        }
    }
}
