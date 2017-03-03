using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsHasOverlap
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
            var n0 = new Node { val = 0 };
            var n1 = new Node { val = 1 };
            var n2 = new Node { val = 2 };
            var n3 = new Node { val = 3 };
            var n4 = new Node { val = 4 };
            var n5 = new Node { val = 5 };
            var n6 = new Node { val = 6 };
            var n7 = new Node { val = 7 };

            n0.next = n2;
            n2.next = n3;
            n4.next = n5;
            n5.next = n6;

            var r = HasOverlap(n0, n4);
            n3.next = n7;
            n6.next = n7;
            r = HasOverlap(n0, n4);
        }

        public static Node HasOverlap(Node l1, Node l2)
        {
            var sL1 = GetSize(l1);
            var sL2 = GetSize(l2);
            var diff = Math.Abs(sL1 - sL2);
            if (sL1 > sL2)
            {
                while (diff-- > 0)
                {
                    l1 = l1.next;
                }
            }
            else
            {
                while (diff-- > 0)
                {
                    l1 = l1.next;
                }
            }
            while (l1 != null && l1 != l2)
            {
                l1 = l1.next;
                l2 = l2.next;
            }

            return l1;
        }

        public static int GetSize(Node l)
        {
            int r = 0;
            while (l != null)
            {
                r++;
                l = l.next;
            }
            return r;
        }
    }
}
