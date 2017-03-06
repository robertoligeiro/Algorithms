using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsSumLists
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
            //var l0 = new Node { val = 9, next = new Node { val = 9, next = new Node { val = 9 } } };
            //var l1 = new Node { val = 1, next = new Node { val = 1, next = new Node { val = 1, next = new Node { val = 9} } } };
            var l0 = new Node { val = 9};
            var l1 = new Node { val = 1};
            var r = SumLists(l0, l1);
        }

        public static Node SumLists(Node l1, Node l2)
        {
            var dResp = new Node();
            var iResp = dResp;
            var carry = 0;
            while (l1 != null || l2 != null)
            {
                var sum = carry;

                if (l1 != null) { sum += l1.val; l1 = l1.next; }
                if (l2 != null) { sum += l2.val; l2 = l2.next; }
                iResp.next = new Node() { val = sum % 10 };
                iResp = iResp.next;
                carry = sum / 10;
            }

            if (carry == 1)
            {
                iResp.next = new Node() { val = 1 };
            }
            return dResp.next;
        }
    }
}
