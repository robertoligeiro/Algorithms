using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode82.RemoveDuplicatesfromSortedListII
{
    //https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/#/description
    class Program
    {
        static void Main(string[] args)
        {
            var n1 = new ListNode(1);
            var n2 = new ListNode(1);
            var n3 = new ListNode(2);
            n1.next = n2;
            n2.next = n3;
            var s = new Solution();
            var r = s.DeleteDuplicates(n1);
        }
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public class Solution
        {
            public ListNode DeleteDuplicates(ListNode head)
            {
                if (head == null) return null;
                if (head.next == null) return head;

                var dummy = new ListNode(-1);
                var it = dummy;
                var curr = head.next;
                var prev = head;
                var nAdd = prev;
                while (curr != null)
                {
                    if (curr.val != prev.val)
                    {
                        it.next = prev;
                        it = it.next;
                        it.next = null;
                        prev = curr;
                        curr = curr.next;
                        continue;
                    }

                    nAdd = prev;
                    while (curr != null && curr.val == nAdd.val)
                    {
                        curr = curr.next;
                    }

                    prev = curr;
                    curr = curr != null ? curr.next : null;
                }
                if (prev != null && prev.val == nAdd.val) return dummy.next;
                it.next = prev;
                return dummy.next;
            }
        }
    }
}
