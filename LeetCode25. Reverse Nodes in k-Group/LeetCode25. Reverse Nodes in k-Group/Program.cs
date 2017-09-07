using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode25.Reverse_Nodes_in_k_Group
{
    class Program
    {
        //https://leetcode.com/problems/reverse-nodes-in-k-group/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var l1 = new ListNode(1) { next = new ListNode(2) { next = new ListNode(3) { next = new ListNode(4) { next = new ListNode(5) } } } };
            var l2 = new ListNode(1) { next = new ListNode(2) { next = new ListNode(3) { next = new ListNode(4) } } };
            var l3 = new ListNode(1);
            var r = s.ReverseKGroup(l3, 2);
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public class Solution
        {
            public ListNode ReverseKGroup(ListNode head, int k)
            {
                ListNode prevStart = null;
                ListNode nextHead = null;
                ListNode curr = head;
                while (curr != null)
                {
                    var start = curr;
                    var count = k;
                    while (curr != null && count-- > 0)
                    {
                        curr = curr.next;
                    }

                    if (curr == null && count != 0)
                    {
                        return nextHead != null ? nextHead : head;
                    }

                    var reversed = ReverseListCount(start, k);
                    if (nextHead == null) nextHead = reversed;
                    if (prevStart != null) prevStart.next = reversed;
                    start.next = curr;
                    prevStart = start;
                }
                return nextHead;
            }

            private ListNode ReverseListCount(ListNode head, int k)
            {
                ListNode prev = null;
                while (k-- > 0)
                {
                    var next = head.next;
                    head.next = prev;
                    prev = head;
                    head = next;
                }
                return prev;
            }
        }
    }
}
