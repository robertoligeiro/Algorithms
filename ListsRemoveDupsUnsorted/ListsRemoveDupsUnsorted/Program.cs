using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsRemoveDupsUnsorted
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = CreateList(new int[] { 1, 2, 3, 4 });
            RemoveDups(l);

            l = CreateList(new int[] { 1, 1, 1, 1, 1 });
            RemoveDups(l);

            l = CreateList(new int[] { 1, 2, 1, 2, 1 });
            RemoveDups(l);

            l = CreateList(new int[] { 1, 2, 1, 1, 3 });
            RemoveDups(l);
        }

        public class Node
        {
            public int val;
            public Node next;
        }

        public static void RemoveDups(Node n)
        {
            var h = new HashSet<int>();
            Node prev = null;
            while (n != null)
            {
                if (h.Add(n.val))
                {
                    prev = n;
                    n = n.next;
                }
                else
                {
                    prev.next = n.next;
                    n.next = null;
                    n = prev.next;
                }
            }
        }

        public static Node CreateList(int[] a)
        {
            var root = new Node() { val = a[0] };
            var it = root;
            for (int i = 1; i < a.Length; ++i)
            {
                var t = new Node() { val = a[i] };
                it.next = t;
                it = t;
            }

            return root;
        }
    }
}
