using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsEvenOddList
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
            var l = new Node { val = 0, next = new Node { val = 1, next = new Node { val = 2, next = new Node { val = 3, next = new Node { val = 4 } } } } };
            var r = EvenOddList(l);
        }

        public static Node EvenOddList(Node n)
        {
            var dEven = new Node();
            var dOdd = new Node();
            var iEven = dEven;
            var iOdd = dOdd;
            var even = true;
            while (n != null)
            {
                if (even)
                {
                    iEven.next = n;
                    iEven = iEven.next;
                }
                else
                {
                    iOdd.next = n;
                    iOdd = iOdd.next;
                }
                even = !even;
                n = n.next;
            }

            iEven.next = dOdd.next;
            iOdd.next = null;
            return dEven.next;
        }
    }
}
