using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsReverseSublist
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
            var n1 = new Node { val = 0, next = new Node { val = 1, next = new Node { val = 2, next = new Node { val = 3 } } } };
            var n2 = new Node { val = 0, next = new Node { val = 1, next = new Node { val = 2, next = new Node { val = 3 } } } };

            var r1 = ReverseSubList(n1, 1, 2);
            var r2 = ReverseSubList(n2, 0, 3);
        }

        public static Node ReverseSubList(Node n, int s, int e)
        {
            Node connectS = null;
            Node connectE = null;
            Node subStart = n;
            Node curr = n;
            e = e - s;
            while (s-- > 0)
            {
                connectS = curr;
                curr = curr.next;
                subStart = curr;
            }

            while (e-- > 0)
            {
                curr = curr.next;
                connectE = curr.next;
            }

            Node prev = null;
            curr = subStart;
            while (curr != connectE)
            {
                var next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            if (connectS != null)
            {
                subStart.next = connectE;
                connectS.next = prev;
                return n;
            }
            subStart.next = connectE;
            return prev;
        }
    }
}
