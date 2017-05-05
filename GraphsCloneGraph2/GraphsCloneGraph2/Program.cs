using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsCloneGraph2
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
            var r = Clone(n0);
        }

        public class Node
        {
            public int val { get; set; }
            public List<Node> children;
            public Node(int v) { val = v; children = new List<Node>(); }
            public Node Copy()
            {
                return new Node(this.val);
            }
        }

        public static Node Clone(Node r)
        {
            var created = new Dictionary<int, Node>();
            var q = new Queue<Node>();
            q.Enqueue(r);

            var visited = new HashSet<Node>();
            var newRoot = r.Copy();
            created.Add(newRoot.val, newRoot);
            while (q.Count > 0)
            {
                r = q.Dequeue();
                
                //avoid loops
                if (!visited.Add(r)) continue;

                var curr = created[r.val];
                foreach (var c in r.children)
                {
                    Node newChild;
                    if (!created.TryGetValue(c.val, out newChild))
                    {
                        newChild = c.Copy();
                        created.Add(newChild.val, newChild);
                    }
                    curr.children.Add(newChild);
                    q.Enqueue(c);
                }
            }
            return newRoot;
        }
    }
}
