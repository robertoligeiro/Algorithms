using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListisIsPalindrome
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
            var l0 = new Node { val = 0, next = new Node { val = 1 } };
            var l1 = new Node { val = 0, next = new Node { val = 0 } };
            var l2 = new Node { val = 0, next = new Node { val = 1, next = new Node { val = 0} } };
            var l3 = new Node { val = 0, next = new Node { val = 1, next = new Node { val = 1 } } };
            var l4 = new Node { val = 0, next = new Node { val = 1, next = new Node { val = 1, next = new Node { val = 0} } } };
            var l5 = new Node { val = 0, next = new Node { val = 1, next = new Node { val = 2, next = new Node { val = 0 } } } };

            var r = IsPalindrome(l0);
            r = IsPalindrome(l1);
            r = IsPalindrome(l2);
            r = IsPalindrome(l3);
            r = IsPalindrome(l4);
            r = IsPalindrome(l5);
        }

        public static bool IsPalindrome(Node n)
        {
            if (n == null || n.next == null) return true;
            var slow = n;
            var fast = n;
            Node prev = null;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                var next = slow.next;
                slow.next = prev;
                prev = slow;
                slow = next;
            }

            // even list
            if (fast == null) return AreSame(prev, slow);
            return AreSame(prev, slow.next);
        }

        public static bool AreSame(Node n1, Node n2)
        {
            while(n1 != null && n2 != null)
            {
                if (n1.val != n2.val) return false;
                n1 = n1.next;
                n2 = n2.next;
            }
            if (n1 != null || n2 != null) return false;
            return true;
        }
    }
}
