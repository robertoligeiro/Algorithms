using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode86.Partition_List
{
    //https://leetcode.com/problems/partition-list/description/
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.Partition(new ListNode(2) { next = new ListNode(1) }, 2);
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public class Solution
        {
            public ListNode Partition(ListNode head, int x)
            {
                var dummySmaller = new ListNode(0);
                var itSmaller = dummySmaller;
                var dummyGreater = new ListNode(0);
                var itGreater = dummyGreater;
                while (head != null)
                {
                    if (head.val < x)
                    {
                        itSmaller.next = head;
                        itSmaller = itSmaller.next;
                    }
                    else
                    {
                        itGreater.next = head;
                        itGreater = itGreater.next;
                    }
                    head = head.next;
                }
                itGreater.next = null;
                itSmaller.next = dummyGreater.next;
                return dummySmaller.next;
            }
        }
    }
}
