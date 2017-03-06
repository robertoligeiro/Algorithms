using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsListPivoting
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
            var l0 = new Node { val = 0, next = new Node { val = 7, next = new Node { val = 5, next = new Node { val = 3, next = new Node { val = 10, next = new Node { val = 2 } } } } } };
            var r = ListPivoting(l0, 4);
        }

        public static Node ListPivoting(Node n, int k)
        {
            var dLesser = new Node();
            var dGreater = new Node();
            var iLesser = dLesser;
            var iGreter = dGreater;
            while (n != null)
            {
                if (n.val < k)
                {
                    iLesser.next = n;
                    iLesser = iLesser.next;
                }
                else
                {
                    iGreter.next = n;
                    iGreter = iGreter.next;
                }

                n = n.next;
            }
            iLesser.next = dGreater.next;
            iGreter.next = null;
            return dLesser.next;
        }
    }
}
