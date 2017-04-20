using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingLinkedListSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var n0 = new Node() { val = 0 };
            var n4 = new Node() { val = 4 };
            var n2 = new Node() { val = 2 };
            var n7 = new Node() { val = 7 };
            var n3 = new Node() { val = 3 };
            var n1 = new Node() { val = 1 };

            n7.next = n4;
            n4.next = n0;
            n0.next = n2;
            n2.next = n3;
            n3.next = n1;
            var r = SortList(n7);
        }

        public class Node
        {
            public int val;
            public Node next;
        }

        public static Node SortList(Node r)
        {
            if (r == null) return null;
            if (r.next == null) return r;
            var slow = r;
            var fast = r;
            Node prev = null;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                prev = slow;
                slow = slow.next;
            }

            prev.next = null;
            var l1 = SortList(r);
            var l2 = SortList(slow);
            return MergeLists(l1, l2);
        }

        public static Node MergeLists(Node l1, Node l2)
        {
            var dummy = new Node();
            var it = dummy;
            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    it.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    it.next = l2;
                    l2 = l2.next;
                }
                it = it.next;
            }

            it.next = l1 != null ? l1 : l2;
            return dummy.next;
        }
    }
}
