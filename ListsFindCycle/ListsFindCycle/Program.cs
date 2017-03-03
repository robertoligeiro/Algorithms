using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsFindCycle
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
            var n1 = new Node { val = 0, next = new Node { val = 1, next = new Node { val = 2 } } };
            var n3 = new Node { val = 3 };
            var n4 = new Node { val = 4 };
            var n5 = new Node { val = 5 };
            var n6 = new Node { val = 6 };
            n3.next = n4;
            n4.next = n5;
            n5.next = n6;
            n6.next = n6;

            var r = HasCycle(n1);
            var r1 = HasCycle(n3);
        }

        public static Node HasCycle(Node n)
        {
            var slow = n;
            var fast = n;
            while (fast != null)
            {
                slow = slow.next;
                fast = fast.next?.next;
                if (slow == fast) break;
            }
            if (fast == null) return null;
            while (n != slow)
            {
                n = n.next;
                slow = slow.next;
            }
            return slow;
        }
    }
}
