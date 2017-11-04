using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2.Add_Two_Numbers
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
			public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
			{
				var dummy = new ListNode(-1);
				var it = dummy;
				var carry = 0;
				while (l1 != null || l2 != null)
				{
					var val = carry;
					if (l1 != null) { val += l1.val; l1 = l1.next; }
					if (l2 != null) { val += l2.val; l2 = l2.next; }
					carry = val > 9 ? 1 : 0;
					val = val % 10;
					it.next = new ListNode(val);
					it = it.next;
				}
				if (carry == 1) it.next = new ListNode(1);
				return dummy.next;
			}
		}
	}
}
