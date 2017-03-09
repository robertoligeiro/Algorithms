using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackPostingList
{
    class Program
    {
        public class node
        {
            public int val { get; set; }
            public int visited { get; set; }
            public node next { get; set; }
            public node post { get; set; }
            public node()
            {
                visited = -1;
            }
        }
        static void Main(string[] args)
        {
            var l0 = new node() { val = 0 };
            var l1 = new node() { val = 1 };
            var l2 = new node() { val = 2 };
            var l3 = new node() { val = 3 };
            l0.next = l1;
            l0.post = l2;
            l1.next = l2;
            l1.post = l3;
            l2.next = l3;
            l2.post = l1;
            l3.post = l3;

            PostingOrderingRec(l0, 0);
            l0.visited = -1;
            l1.visited = -1;
            l2.visited = -1;
            l3.visited = -1;
            PostOrderingStack(l0);
        }

        public static void PostOrderingStack(node n)
        {
            var i = 0;
            var s = new Stack<node>();
            s.Push(n);
            while (s.Count > 0)
            {
                var t = s.Pop();
                if (t.visited == -1)
                {
                    t.visited = i++;
                    if (t.next != null) s.Push(t.next);
                    s.Push(t.post);
                }
            }
        }
        public static bool PostingOrderingRec(node n, int pos)
        {
            if (n == null) return true;
            if (n.visited == -1)
            {
                n.visited = pos++;
                if (!PostingOrderingRec(n.post, pos))
                {
                    return PostingOrderingRec(n.next, pos);
                }

                return true;
            }
            return false;
        }
    }
}
