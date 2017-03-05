using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsShiftRightByK
{
    class Program
    {
        public class Node
        {
            public int val { get; set; }
            public Node next { get; set; }
        }
        static void Main(string[] args)
        {
            var l = new Node { val = 2, next = new Node { val = 3, next = new Node { val = 5, next = new Node { val = 3, next = new Node { val = 2 } } } } };
            var r = ShiftList(l, 3);
        }

        public static Node ShiftList(Node n, int k)
        {
            var s = GetSize(n);
            var shift = k % s;
            if (shift == 0) return n;

            var diff = s - k;
            var curr = n;
            Node prev = null;
            while (diff-- > 0)
            {
                prev = curr;
                curr = curr.next;
            }

            var head = curr;
            prev.next = null;

            while (curr.next != null)
            {
                curr = curr.next;
            }
            curr.next = n;
            return head;
        }

        public static int GetSize(Node n)
        {
            int r = 0;
            while (n != null)
            {
                n = n.next;
                r++;
            }
            return r;
        }
    }
}
