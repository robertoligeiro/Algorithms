using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsIsBiColor
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
            var nOtherStart = new Node(100);

            n0.children.Add(n1);
            n0.children.Add(n2);
            n1.children.Add(n3);
            //n1.children.Add(n2); make it retur false
            n2.children.Add(n4);
            n3.children.Add(n5);
            nOtherStart.children.Add(n1);
            //nOtherStart.children.Add(n0); also make it fail

            var l = new List<Node>() { n0, nOtherStart,n1, n2,n3,n4,n5};
            var b = IsBicolored(l);
        }

        public class Node
        {
            public int val { get; set; }
            public int distance { get; set; }
            public List<Node> children;
            public Node(int v)
            {
                val = v;
                distance = -1;
                children = new List<Node>();
            }
        }

        public static bool IsBicolored(List<Node> g)
        {
            foreach (var n in g)
            {
                if (n.distance == -1 && !IsBicoloredFrom(n))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsBicoloredFrom(Node n)
        {
            var q = new Queue<Node>();
            q.Enqueue(n);
            n.distance = 0;
            while (q.Count > 0)
            {
                var curr = q.Dequeue();
                foreach (var c in curr.children)
                {
                    if (c.distance == -1)
                    {
                        c.distance = curr.distance + 1;
                        q.Enqueue(c);
                    }
                    else if(c.distance == curr.distance)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
