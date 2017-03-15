using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesTreeInDepthOrder
{
    class Program
    {
        public class node
        {
            public int val { get; set; }
            public node left { get; set; }
            public node right { get; set; }
        }
        static void Main(string[] args)
        {
            var n0 = new node { val = 0 };
            var n1 = new node { val = 1 };
            var n2 = new node { val = 2 };
            var n3 = new node { val = 3 };
            var n4 = new node { val = 4 };
            var n5 = new node { val = 5 };
            n0.left = n1;
            n0.right = n2;
            n1.left = n3;
            n2.left = n4;
            n2.right = n5;

            var r = ComputeDepth(n0);
        }

        public static List<List<node>> ComputeDepth(node n)
        {
            var r = new List<List<node>>();
            var q1 = new Queue<node>();
            var q2 = new Queue<node>();
            q1.Enqueue(n);
            while (q1.Count > 0 || q1.Count > 0)
            {
                var l = EmptyQ(q1, q2);
                if (l.Count > 0) r.Add(l);
                l = EmptyQ(q2, q1);
                if (l.Count > 0) r.Add(l);
            }
            return r;
        }

        public static List<node> EmptyQ(Queue<node> source, Queue<node> output)
        {
            var l = new List<node>();
            while (source.Count > 0)
            {
                var t = source.Dequeue();
                if (t.left != null) output.Enqueue(t.left);
                if (t.right != null) output.Enqueue(t.right);
                l.Add(t);
            }
            return l;
        }
    }
}
