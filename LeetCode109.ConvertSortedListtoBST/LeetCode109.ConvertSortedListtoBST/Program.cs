using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode109.ConvertSortedListtoBST
{
	class Program
	{
		static void Main(string[] args)
		{
			var l = new ListNode(0) { next = new ListNode(1) { next = new ListNode(2) { next = new ListNode(3)} } };
			var s = new Solution();
			var t = s.SortedListToBST(l);
		}
		public class TreeNode
		{
			public int val;
			public TreeNode left;
			public TreeNode right;
			public TreeNode(int x) { val = x; }
		}

		public class ListNode
		{
			public int val;
			public ListNode next;
			public ListNode(int x) { val = x; }
		}

		public class Solution
		{
			public TreeNode SortedListToBST(ListNode head)
			{
				if (head == null) return null;
				if (head.next == null) return new TreeNode(head.val);

				ListNode prev = null;
				var slow = head;
				var fast = head;
				while (fast!=null && fast.next != null)
				{
					prev = slow;
					slow = slow.next;
					fast = fast.next.next;
				}

				if (prev != null) prev.next = null;
				var n = new TreeNode(slow.val);
				n.left = SortedListToBST(head);
				n.right = SortedListToBST(slow.next);
				return n;
			}
		}
	}
}
