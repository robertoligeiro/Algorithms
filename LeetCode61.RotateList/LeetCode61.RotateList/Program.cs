using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode61.RotateList
{
    class Program
    {
        //https://leetcode.com/problems/rotate-list/#/description
        static void Main(string[] args)
        {
            var n1 = new ListNode(1);
            var n2 = new ListNode(2);
            var n3 = new ListNode(3);
            var n4 = new ListNode(4);
            var n5 = new ListNode(5);
            n1.next = n2; n2.next = n3; n3.next = n4; n4.next = n5;

            var s = new Solution();
            var r = s.RotateRight(n1, 24);
        }

        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public class Solution
        {
            public ListNode RotateRight(ListNode head, int k)
            {
                if (head == null) return null;
                var size = GetSize(head);
                k = k % size;
                if (k == 0) return head;
                var runner = head;
                while (k-- > 0)
                {
                    runner = runner.next;
                }

                ListNode nHead = head;
                ListNode prev = null;
                ListNode tail = null;
                while (runner != null)
                {
                    prev = nHead;
                    nHead = nHead.next;
                    tail = runner;
                    runner = runner.next;
                }

                prev.next = null;
                tail.next = head;
                return nHead;
            }

            private int GetSize(ListNode head)
            {
                var size = 1;
                while (head.next != null)
                {
                    head = head.next;
                    size++;
                }
                return size;
            }
        }
    }
}
