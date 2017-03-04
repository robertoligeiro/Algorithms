using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsHasOverlapWithCycles
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
            var n0 = new Node { val = 0 };
            var n1 = new Node { val = 1 };
            var n2 = new Node { val = 2 };
            var n3 = new Node { val = 3 };
            var n4 = new Node { val = 4 };
            var n5 = new Node { val = 5 };
            var n6 = new Node { val = 6 };
            var n7 = new Node { val = 7 };

            //l1 - n0-n1-n2-n4
            n0.next = n1;
            n1.next = n2;
            n2.next = n4;

            //l2 - n3-n4-n5-n6-n4
            n3.next = n4;
            n4.next = n5;
            n5.next = n6;
            n6.next = n4;

            //r should be n4
            var r = HasOverlap(n0, n3);
        }
        public static Node HasOverlap(Node l1, Node l2)
        {
            Node sCycle1;
            Node sCycle2;
            var sL1 = GetSize(l1, out sCycle1);
            var sL2 = GetSize(l2, out sCycle2);

            //both have no cycles
            if (sL1 != -1 && sL2 != -1) return HasOverlapNoCycle(l1, sL1, l2, sL2);
            // just one has cycle, can't have overlap
            if ((sL1 == -1 && sL2 != -1) || (sL1 != -1 && sL2 == -1)) return null;
            // overlap may occur before both enters the cycle, or be the cycle start
            if (sCycle2 == sCycle1) return GetOverLapWithCycle(l1, l2, sCycle1);
            // they may be in different cycles, if not, return start of any cycle
            return HasSameCycle(sCycle1, sCycle2);
        }

        public static Node HasSameCycle(Node sCycle1, Node sCycle2)
        {
            var curr = sCycle1;
            while (curr != sCycle2)
            {
                curr = curr.next;
                if (curr == sCycle1) return null;
            }

            return sCycle2;
        }

        public static Node GetOverLapWithCycle(Node l1, Node l2, Node sCycle1)
        {
            var sL1 = GetDistanceToNode(l1, sCycle1);
            var sL2 = GetDistanceToNode(l2, sCycle1);
            if (sL1 == sL2) return sCycle1;
            var diff = Math.Abs(sL1 - sL2);
            if (sL1 > sL2)
            {
                while (diff-- > 0)
                    l1 = l1.next;
            }
            else
            {
                while (diff-- > 0)
                    l2 = l2.next;
            }

            while (l1 != l2)
            {
                l1 = l1.next;
                l2 = l2.next;
            }

            return l1;
        }

        public static int GetDistanceToNode(Node l1, Node sCycle1)
        {
            var r = 0;
            while (l1 != sCycle1)
            {
                l1 = l1.next;
                r++;
            }

            return r;
        }

        public static Node HasOverlapNoCycle(Node l1, int sL1, Node l2, int sL2)
        {
            var diff = Math.Abs(sL1 - sL2);
            if (sL1 > sL2)
            {
                while (diff-- > 0)
                {
                    l1 = l1.next;
                }
            }
            else
            {
                while (diff-- > 0)
                {
                    l1 = l1.next;
                }
            }
            while (l1 != null && l1 != l2)
            {
                l1 = l1.next;
                l2 = l2.next;
            }

            return l1;
        }

        public static int GetSize(Node l, out Node sCycle)
        {
            int r = 0;
            var curr = l;
            var fast = l;
            while (l != null)
            {
                r++;
                curr = curr.next;
                if(fast != null)
                    fast = fast?.next.next;
                if (fast == curr) break;
            }
            // there's no cycle
            sCycle = null;
            if (fast == null) return r;

            //there's a cycle, get start of cycle
            curr = l;
            while (curr != fast)
            {
                curr = curr.next;
                fast = fast.next;
            }
            sCycle = curr;
            return -1;
        }
    }
}
