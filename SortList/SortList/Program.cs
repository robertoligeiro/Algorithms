using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortList
{
    class Program
    {
        public class node : IComparable<node>
        {
            public int val { get; set; }
            public node next { get; set; }

            public int CompareTo(node other)
            {
                if (this.val > other.val) return 1;
                return -1;
            }
        }

        public static node SortList(node n)
        {
            if (n == null || n.next == null) return n;

            node fast = n;
            node slow = n;
            node preSlow = null;
            while (fast != null && fast.next != null)
            {
                preSlow = slow;
                slow = slow.next;
                fast = fast.next != null ? fast.next.next : null;
            }

            preSlow.next = null;

            var l = SortList(n);
            var r = SortList(slow);
            return MergeLists(l,r);
        }

        public static node MergeLists(node l, node r)
        {
            var dummyHead = new node();
            var it = dummyHead;
            while (l != null && r != null)
            {
                if (l.val < r.val)
                {
                    it.next = l;
                    l = l.next;
                }
                else
                {
                    it.next = r;
                    r = r.next;
                }

                it = it.next;
            }

            it.next = l != null ? l : r;
            return dummyHead.next;
        }

        static void Main(string[] args)
        {
            var n = new node() { val = 10, next = new node { val = 5, next = new node { val = 2, next = new node { val = 0, next = new node { val = 13, next = null } } } } };
            var l = new List<node>();
            while (n != null)
            {
                l.Add(n);
                n = n.next;
            }
            l.Sort();

            var r = SortList(n);
        }
    }
}
