using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode19.RemoveNthNodeFromEndofList
{
    class Program
    {
        //https://leetcode.com/problems/remove-nth-node-from-end-of-list/description/
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
            public ListNode RemoveNthFromEnd(ListNode head, int n)
            {
                var runner = head;
                while (n-- > 0)
                {
                    runner = runner.next;
                }

                if (runner == null)
                {
                    var ret = head.next;
                    head.next = null;
                    return ret;
                }

                var nodeToDelete = head;
                ListNode prev = null;
                while (runner != null)
                {
                    prev = nodeToDelete;
                    nodeToDelete = nodeToDelete.next;
                    runner = runner.next;
                }
                prev.next = nodeToDelete.next;
                nodeToDelete.next = null;
                return head;
            }
        }
    }
}
