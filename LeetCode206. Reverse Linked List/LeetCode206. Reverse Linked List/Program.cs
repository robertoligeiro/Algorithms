using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode206.Reverse_Linked_List
{
	class Program
	{
		//https://leetcode.com/problems/reverse-linked-list/description/
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
				ListNode prev = null;
				var curr = head;
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
	}
}
