using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode382.Linked_List_Random_Node
{
    class Program
    {
        //https://leetcode.com/problems/linked-list-random-node/description/
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
            private ListNode head;
            private Random rand;
            /** @param head The linked list's head.
                Note that the head is guaranteed to be not null, so it contains at least one node. */
            public Solution(ListNode head)
            {
                rand = new Random();
                this.head = head;
            }

            /** Returns a random node's value. */
            public int GetRandom()
            {
                var curr = this.head;
                var res = curr.val;
                for(int i = 1;  curr.next != null; ++i)
                {
                    curr = curr.next;
                    if (rand.Next(i + 1) == i) res = curr.val;
                }
                return res;
            }
        }
    }
}
