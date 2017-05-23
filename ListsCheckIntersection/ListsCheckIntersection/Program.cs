using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsCheckIntersection
{
    class Program
    {
        static void Main(string[] args)
        {
            var n0 = new Node() { val = 0 };
            var n1 = new Node() { val = 1 };
            var n2 = new Node() { val = 2 };
            var n3 = new Node() { val = 3 };
            var n4 = new Node() { val = 4 };
            var n5 = new Node() { val = 5 };
            n0.next = n1;
            n1.next = n2;
            n2.next = n5;
            n3.next = n4;
            n4.next = n5;

            var r = GetIntersection(n0, n3);
            n4.next = null;
            r = GetIntersection(n0, n3);
        }

        public class Node
        {
            public int val;
            public Node next;
        }

        public static Node GetSizeAndTail(Node n, ref int s)
        {
            if (n == null) return null;
            s = 1;
            while (n.next != null)
            {
                n = n.next;
                s++;
            }
            return n;
        }

        public static Node GetIntersection(Node n1, Node n2)
        {
            var sn1 = 0;
            var sn2 = 0;
            var t1 = GetSizeAndTail(n1, ref sn1);
            var t2 = GetSizeAndTail(n2, ref sn2);
            if (t1 != t2) return null;

            var diff = Math.Abs(sn1 - sn2);
            if (sn1 > sn2)
            {
                while (diff-- > 0) n1 = n1.next;
            }
            else while (diff-- > 0) n2 = n2.next;

            while (n1 != n2)
            {
                n1 = n1.next;
                n2 = n2.next;
            }
            return n1;
        }
    }
}
