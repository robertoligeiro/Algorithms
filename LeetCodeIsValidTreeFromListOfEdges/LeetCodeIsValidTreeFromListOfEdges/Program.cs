using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeIsValidTreeFromListOfEdges
{
    class Program
    {
        static void Main(string[] args)
        {
            var b1 = IsValidTree(5, new List<Tuple<int, int>>() //true
            {
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(0, 2),
                new Tuple<int, int>(0, 3),
                new Tuple<int, int>(1, 4)
            });

            b1 = IsValidTree(7, new List<Tuple<int, int>>() //false, 5-6 disjoint
            {
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(2, 3),
                new Tuple<int, int>(1, 4),
                new Tuple<int, int>(5, 6),
            });

            b1 = IsValidTree(7, new List<Tuple<int, int>>() // true
            {
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(2, 3),
                new Tuple<int, int>(1, 4),
                new Tuple<int, int>(5, 6),
                new Tuple<int, int>(1, 6) //link disjoint node
            });

            b1 = IsValidTree(7, new List<Tuple<int, int>>() // false, loop
            {
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(2, 3),
                new Tuple<int, int>(1, 4),
                new Tuple<int, int>(5, 6),
                new Tuple<int, int>(1, 6),
                new Tuple<int, int>(3, 1) //loop
            });
        }

        public static bool IsValidTree(int n, List<Tuple<int, int>> edges)
        {
            var nodes = BuildDict(edges);
            var visited = new HashSet<int>();
            if (!IsValid(nodes.FirstOrDefault().Key, nodes.FirstOrDefault().Key, nodes, visited))
            {
                return false;
            }

            return visited.Count == n;
        }

        public static bool IsValid(int p, int c, Dictionary<int, HashSet<int>> nodes, HashSet<int> visited)
        {
            if (!visited.Add(c)) return false;
            foreach (var child in nodes[c])
            {
                if (p != child)
                {
                    if (!IsValid(c, child, nodes, visited)) return false;
                }
            }
            return true;
        }

        public static Dictionary<int, HashSet<int>> BuildDict(List<Tuple<int, int>> e)
        {
            var nodes = new Dictionary<int, HashSet<int>>();
            foreach (var t in e)
            {
                HashSet<int> h1 = null;
                nodes.TryGetValue(t.Item1, out h1);
                HashSet<int> h2 = null;
                nodes.TryGetValue(t.Item2, out h2);
                if (h1 == null)
                {
                    h1 = new HashSet<int>() { t.Item2 };
                    nodes.Add(t.Item1, h1);
                }
                else h1.Add(t.Item2);

                if (h2 == null)
                {
                    h2 = new HashSet<int>() { t.Item1 };
                    nodes.Add(t.Item2, h2);
                }
                else h2.Add(t.Item1);
            }

            return nodes;
        }
    }
}
