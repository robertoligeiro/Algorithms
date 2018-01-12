using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode445.Add_Two_Numbers_II
{
	//https://leetcode.com/submissions/detail/135836066/
	class Program
	{
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
			public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
			{
				if (l1 == null && l2 == null) return null;
				if (l1 == null) return l2;
				if (l2 == null) return l1;
				var rL1 = ReverseList(l1);
				var rL2 = ReverseList(l2);
				var carry = 0;
				ListNode h = null;
				while (rL1 != null || rL2 != null)
				{
					int v1 = 0, v2 = 0;
					if (rL1 != null)
					{
						v1 = rL1.val;
						rL1 = rL1.next;
					}
					if (rL2 != null)
					{
						v2 = rL2.val;
						rL2 = rL2.next;
					}
					var val = v1 + v2 + carry;
					carry = val > 9 ? 1 : 0;
					var n = new ListNode(val % 10) { next = h };
					h = n;
				}
				if (carry == 1) return new ListNode(1) { next = h };
				return h;
			}

			private ListNode ReverseList(ListNode n)
			{
				ListNode prev = null;
				ListNode curr = n;
				while (curr != null)
				{
					var next = curr.next;
					curr.next = prev;
					prev = curr;
					curr = next;
				}
				return prev;
			}
		}
		public class SolutionNew
		{
			public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
			{
				if (l1 == null && l2 == null) return null;
				if (l1 == null) return l2;
				if (l2 == null) return l1;
				var s1 = new Stack<int>();
				var s2 = new Stack<int>();
				while (l1 != null)
				{
					s1.Push(l1.val);
					l1 = l1.next;
				}
				while (l2 != null)
				{
					s2.Push(l2.val);
					l2 = l2.next;
				}
				ListNode h = null;
				var carry = 0;
				while (s1.Count > 0 || s2.Count > 0)
				{
					int v1 = 0, v2 = 0;
					if (s1.Count > 0) v1 = s1.Pop();
					if (s2.Count > 0) v2 = s2.Pop();
					var val = v1 + v2 + carry;
					carry = val > 9 ? 1 : 0;
					var n = new ListNode(val % 10) { next = h };
					h = n;
				}
				if (carry == 1) return new ListNode(1) { next = h };
				return h;
			}
		}
	}
}
