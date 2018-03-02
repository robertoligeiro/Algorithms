using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode328.Odd_Even_Linked_List
{
	//https://leetcode.com/problems/odd-even-linked-list/description/
	class Program
	{
		static void Main(string[] args)
		{
			var l = new ListNode(1) { next = new ListNode(2) { next = new ListNode(3) { next = new ListNode(4) { next = new ListNode(5) } } } };
			var s = new Solution();
			var r = s.OddEvenList(l);
		}
		public class ListNode
		{
			public int val;
			public ListNode next;
			public ListNode(int x) { val = x; }
		}
		public class Solution
		{
			public ListNode OddEvenList(ListNode head)
			{
				var even = new ListNode(-1);
				var iEven = even;
				var odd = new ListNode(-1);
				var iOdd = odd;
				while (head != null)
				{
					iOdd.next = head;
					iEven.next = head.next;
					head = head.next!=null?head.next.next:null;
					iEven = iEven.next;
					iOdd = iOdd.next;
				}
				if (iEven != null) iEven.next = null;
				iOdd.next = even.next;
				return odd.next;
			}
		}
	}
}
