using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewSplunkOnSiteScreeningCopyGag
{
    class Program
    {
        static void Main(string[] args)
        {
            var n1 = new Node() { val = 1 };
            var n2 = new Node() { val = 2 };
            var n3 = new Node() { val = 3 };
            var n4 = new Node() { val = 4 };
            var n5 = new Node() { val = 5 };
            n1.children.Add(n2);
            n1.children.Add(n3);
            n2.children.Add(n1);
            n2.children.Add(n5);
            n2.children.Add(n3);
            n3.children.Add(n4);
            n3.children.Add(n5);
            n5.children.Add(n1);

            var r = CopyDag(n1);
        }

        public class Node
        {
            public int val { get; set; }
            public List<Node> children = new List<Node>();
        }

        public static Node CopyDag(Node n)
        {
            var q = new Queue<Node>();
            var m = new Dictionary<int, Node>();
            var newRoot = new Node() { val = n.val };
            q.Enqueue(n);
            m.Add(newRoot.val, newRoot);
            while (q.Count > 0)
            {
                var curr = q.Dequeue();
                var currNew = m[curr.val];
                foreach (var c in curr.children)
                {
                    Node newChild;
                    if (!m.TryGetValue(c.val, out newChild))
                    {
                        newChild = new Node() { val = c.val };
                        q.Enqueue(c);
                        m.Add(newChild.val, newChild);
                    }
                    currNew.children.Add(newChild);
                }
            }
            return newRoot;
        }
    }
}
