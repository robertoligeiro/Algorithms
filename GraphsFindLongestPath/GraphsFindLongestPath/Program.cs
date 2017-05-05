using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsFindLongestPath
{
    class Program
    {
        static void Main(string[] args)
        {
            var n0 = new Node(0);
            var n1 = new Node(1);
            var n2 = new Node(2);
            var n3 = new Node(3);
            var n4 = new Node(4);
            var n5 = new Node(5);
            n0.children.Add(n1);
            n0.children.Add(n2);
            n1.children.Add(n4);
            n2.children.Add(n4);
            n4.children.Add(n0);
            n4.children.Add(n1);
            var r = GetMaxPath(n0);
        }
        public class Node
        {
            public int val { get; set; }
            public List<Node> children;
            public bool visited;
            public int dist;
            public Node(int v) { val = v; children = new List<Node>(); dist = -1; }
            public Node Copy()
            {
                return new Node(this.val);
            }
        }

        public static int GetMaxPath(Node r)
        {
            int maxSoFar = 0;
            var q = new Queue<Node>();
            q.Enqueue(r);
            while (q.Count > 0)
            {
                var curr = q.Dequeue();
                foreach (var c in curr.children)
                {
                    if (c.dist == -1)
                    {
                        var parentDist = curr.dist != -1 ? curr.dist : 0;
                        c.dist =  parentDist + 1;
                        q.Enqueue(c);
                    }
                    maxSoFar = Math.Max(maxSoFar, c.dist);
                }
            }

            return maxSoFar;
        }
    }
}
