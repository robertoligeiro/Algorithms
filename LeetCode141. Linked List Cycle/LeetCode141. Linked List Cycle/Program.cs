using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode141.Linked_List_Cycle
{
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
			public bool HasCycle(ListNode head)
			{
				var fast = head;
				var slow = head;
				while (fast != null && fast.next != null)
				{
					fast = fast.next.next;
					slow = slow.next;
					if (fast == slow) return true;
				}
				return false;
			}
		}
	}
}
