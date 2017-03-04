using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsRemoveDupsFromSorted
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
            var l1 = new Node() { val = 0, next = new Node() { val = 0, next = new Node() { val = 1, next = new Node { val = 1, next = new Node { val = 2} } } } };
            RemoveDupsFromList(l1);
        }

        public static void RemoveDupsFromList(Node n)
        {
            var curr = n;
            while (curr != null)
            {
                var next = curr.next;
                while(next != null && next.val == curr.val)
                {
                    var t = next.next;
                    next.next = null;
                    next = t;
                }

                curr.next = next;
                curr = next;
            }
        }
    }
}
