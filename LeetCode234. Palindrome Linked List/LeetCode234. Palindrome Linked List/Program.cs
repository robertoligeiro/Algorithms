using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode234.Palindrome_Linked_List
{
	class Program
	{
		//https://leetcode.com/problems/palindrome-linked-list/description/
		static void Main(string[] args)
		{
			var l = new ListNode(1) { next = new ListNode(2) { next = new ListNode(2) { next = new ListNode(1)} } };
			var s = new Solution();
			var r = s.IsPalindrome(l);
		}
		public class ListNode
		{
			public int val;
			public ListNode next;
			public ListNode(int x) { val = x; }
		}
		public class Solution
		{
			public bool IsPalindrome(ListNode head)
			{
				if (head == null) return true;
				var slow = head;
				var fast = head;
				ListNode prev = null;
				while (fast != null && fast.next != null)
				{
					prev = slow;
					slow = slow.next;
					fast = fast.next.next;
				}
				if (fast != null)
				{
					prev = slow;
					slow = slow.next;
				}
				prev.next = null;
				slow = Reverse(slow);
				while (slow != null)
				{
					if (head.val != slow.val) return false;
					head = head.next;
					slow = slow.next;
				}
				return true;
			}
			private ListNode Reverse(ListNode n)
			{
				ListNode prev = null;
				var curr = n;
				while (curr != null)
				{
					var next = curr.next;
					curr.next = prev;
					prev = curr;
					curr = next;
				}
				return prev != null?prev:n;
			}
		}
	}
}
