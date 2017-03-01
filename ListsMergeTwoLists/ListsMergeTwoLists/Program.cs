using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsMergeTwoLists
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
            var r = MergeLists(l1, l2);
        }

        public static Node MergeLists(Node l1, Node l2)
        {
            var dummyHead = new Node();
            var curr = dummyHead;
            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    curr.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    curr.next = l2;
                    l2 = l2.next;
                }
                curr = curr.next;
            }

            curr.next = l1 == null ? l2 : l1;
            return dummyHead.next;
        }
    }
}
