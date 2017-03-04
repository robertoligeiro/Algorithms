using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsRemoveK
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
            var l1 = new Node() { val = 0, next = new Node() { val = 3, next = new Node() { val = 4 } } };
            var l2 = new Node() { val = 1, next = new Node() { val = 2, next = new Node() { val = 5 } } };

            var r1 = RemoveK(l1, 0);
            var r2 = RemoveK(l2, 2);
        }

        public static Node RemoveK(Node n, int k)
        {
            var adv = n;
            while (k-- > 0)
            {
                adv = adv.next;
            }

            var curr = n;
            Node prev = null;
            while (adv.next != null)
            {
                adv = adv.next;
                prev = curr;
                curr = curr.next;
            }

            if (prev != null)
            {
                prev.next = curr.next;
                curr.next = null;
                return n;
            }

            var r = n.next;
            n.next = null;
            return r;
        }
    }
}
