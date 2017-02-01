using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsCloneGraph
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
            //n0.children.Add(n1);

            var r = CloneGraph(n0);
        }

        public class Node
        {
            public int val { get; set; }
            public List<Node> children;
            public Node(int v) { val = v;  children = new List<Node>(); }
        }

        public static Node CloneGraph(Node s)
        {
            if (s == null) return null;
            var visited = new HashSet<Node>() { s };
            var created = new Dictionary<int, Node>();
            var q = new Queue<Node>();
            q.Enqueue(s);
            created.Add(s.val, new Node(s.val));

            while (q.Count > 0)
            {
                var curr = q.Dequeue();
                var parent = created[curr.val];

                foreach (var c in curr.children)
                {
                    if (visited.Add(c))
                    {
                        var t = new Node(c.val);
                        parent.children.Add(t);
                        created.Add(t.val, t);
                        q.Enqueue(c);
                    }
                    else
                    {
                        parent.children.Add(created[c.val]);
                    }
                }
            }

            return created[s.val];
        }
    }
}
