using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode143.Reorder_List
{
	class Program
	{
		//https://leetcode.com/problems/reorder-list/description/
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
			public void ReorderList(ListNode head)
			{
				if (head == null || head.next == null || head.next.next == null) return;

				//split the list in two
				var runner = head;
				var slower = head;
				while (runner.next != null && runner.next.next != null)
				{
					slower = slower.next;
					runner = runner.next.next;
				}

				//reverse the second half
				var reversed = slower.next;
				slower.next = null;
				ListNode prev = null;
				var next = reversed.next;
				while (reversed != null)
				{
					reversed.next = prev;
					prev = reversed;
					reversed = next;
					next = next != null ? next.next : null;
				}

				//merge the two
				var it1 = head;
				var it2 = prev;
				while (it1 != null)
				{
					var t1 = it1.next;
					var t2 = it2 != null ? it2.next : null;
					it1.next = it2;
					it1 = t1;
					if (it2 != null)
					{
						it2.next = it1;
						it2 = t2;
					}
				}
			}
		}
	}
}
