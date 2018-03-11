using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode206.Reverse_Linked_List_Recursive
{
	class Program
	{
		//https://leetcode.com/problems/reverse-linked-list/
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
			public ListNode ReverseList(ListNode head)
			{
				if (head == null) return null;
				return Reverse(head, null);
			}
			private ListNode Reverse(ListNode n, ListNode prev)
			{
				var next = n.next;
				n.next = prev;
				if (next == null)
				{
					return n;
				}
				return Reverse(next, n);
			}
		}
	}
}
