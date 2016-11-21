using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightShortestPath
{
    class Program
    {
        public class Node
        {
            public int x { get; set; }
            public int y { get; set; }
            public int steps { get; set; }

            public bool isValid()
            {
                if (this.x >= 0 && this.x < 8 && this.y >= 0 && this.y < 8) return true;
                return false;
            }
            public override bool Equals(object obj)
            {
                var n = obj as Node;
                if (n != null)
                {
                    if (n.x == this.x && n.y == this.y) return true;
                }
                return false;
            }

            public override int GetHashCode()
            {
                return StringComparer.InvariantCultureIgnoreCase
                                     .GetHashCode(this.x);
            }
        }

        public class ShortestPath
        {
            public static List<Tuple<int, int>> posMoves = new List<Tuple<int, int>> { new Tuple<int, int>(-2,-1), new Tuple<int, int>(-2, 1), new Tuple<int, int>(-1, 2), new Tuple<int, int>(1, 2), new Tuple<int, int>(2,1), new Tuple<int, int>(2,-1), new Tuple<int, int>(1, -2), new Tuple<int, int>(-1,-2) };
            public static int GetKightShortestPath(Node s, Node e)
            {
                if (s == null || e == null || !s.isValid() || !e.isValid())
                {
                    return -1;
                }
                s.steps = 0;

                var known = new HashSet<Node>() { s };
                var q = new Queue<Node>();
                q.Enqueue(s);
                while (q.Count > 0)
                {
                    var curr = q.Dequeue();
                    if (curr.Equals(e))
                    {
                        return curr.steps + 1;
                    }

                    foreach (var move in posMoves)
                    {
                        var nNode = new Node() { x = curr.x + move.Item1, y = curr.y + move.Item2 };
                        if (nNode.isValid() && known.Add(nNode))
                        {
                            nNode.steps = curr.steps + 1;
                            q.Enqueue(nNode);
                        }
                    }
                }

                return -1;
            }
        }
        static void Main(string[] args)
        {
            int i = ShortestPath.GetKightShortestPath(new Node() { x = 0, y = 0 }, new Node() { x = 7, y =  5});
        }
    }
}
