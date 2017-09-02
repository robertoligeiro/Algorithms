using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode147.Insertion_Sort_List
{
    class Program
    {
        //https://leetcode.com/problems/insertion-sort-list/description/
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
            public ListNode InsertionSortList(ListNode head)
            {
                if (head == null) return null;
                var dummyHead = new ListNode(-1);
                dummyHead.next = head;
                var s = new Stack<ListNode>();
                var prev = head;
                var curr = head.next;
                while (curr != null)
                {
                    var next = curr.next;
                    var it = dummyHead.next;
                    while (it != curr)
                    {
                        s.Push(it);
                        prev = it;
                        it = it.next;
                    }
                    while (s.Count > 0 && s.Peek().val > curr.val)
                    {
                        s.Pop();
                    }

                    //new root
                    if (s.Count == 0)
                    {
                        prev.next = next;
                        curr.next = dummyHead.next;
                        dummyHead.next = curr;
                    } //swap items
                    else
                    {
                        prev.next = next;
                        curr.next = s.Peek().next;
                        s.Peek().next = curr;
                    }
                    curr = next;
                }
                return dummyHead.next;
            }
        }
    }
}
