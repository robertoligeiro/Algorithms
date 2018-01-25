using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode369.Plus_One_Linked_List
{
	class Program
	{
		//https://leetcode.com/problems/plus-one-linked-list/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.PlusOne(new ListNode(9) { next = new ListNode(9) { next = new ListNode(9) } });
		}
		public class ListNode
		{
			public int val;
			public ListNode next;
			public ListNode(int x) { val = x; }
		}

		public class Solution
		{
			public ListNode PlusOne(ListNode head)
			{
				var c = PlusOneRec(head);
				if (c == 1) return new ListNode(1) { next = head };
				return head;
			}

			private int PlusOneRec(ListNode n)
			{
				if (n == null) return 1;
				var c = PlusOneRec(n.next);
				var sum = n.val + c;
				n.val = sum % 10;
				return sum > 9 ? 1 : 0;
			}
		}
	}
}
