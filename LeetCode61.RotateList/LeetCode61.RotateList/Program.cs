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
            var r = s.RotateRight(n1, 2);
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

                //find new head
                var distToNewHead = size - k;
                var newHead = head;
                ListNode tail = null;
                while (distToNewHead-- > 0)
                {
                    tail = newHead;
                    newHead = newHead.next;
                }

                //connect new tail
                tail.next = null;
                tail = newHead;
                while (tail.next != null)
                {
                    tail = tail.next;
                }
                tail.next = head;
                return newHead;
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
