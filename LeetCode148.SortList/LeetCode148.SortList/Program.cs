using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode148.SortList
{
    class Program
    {
        //https://leetcode.com/problems/sort-list/#/description
        static void Main(string[] args)
        {
        }
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
        public class Solution
        {
            public ListNode SortList(ListNode head)
            {
                if (head == null) return null;
                if (head.next == null) return head;
                ListNode slow = head;
                ListNode fast = head;
                ListNode prev = null;
                while (fast != null && fast.next != null)
                {
                    prev = slow;
                    slow = slow.next;
                    fast = fast.next.next;
                }

                prev.next = null;
                var l = SortList(head);
                var r = SortList(slow);
                return Merge(l, r);
            }

            private ListNode Merge(ListNode l, ListNode r)
            {
                var dummy = new ListNode(-1);
                var it = dummy;
                while (l != null && r != null)
                {
                    if (l.val < r.val)
                    {
                        it.next = l;
                        l = l.next;
                    }
                    else
                    {
                        it.next = r;
                        r = r.next;
                    }
                    it = it.next;
                }

                it.next = l != null ? l : r;
                return dummy.next;
            }
        }
    }
}
