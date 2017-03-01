using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsReverseLinkedList
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
            var l = new Node() { val = 0, next = new Node { val = 1, next = new Node { val = 3, next = new Node { val = 4 } } } };
            var r = ReverseList(l);
        }

        public static Node ReverseList(Node l)
        {
            Node curr = l;
            Node prev = null;
            while (curr != null)
            {
                var next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            return prev;
        }
    }
}
