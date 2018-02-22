using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMerge_Two_Sorted_Lists
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.MergeTwoLists(new ListNode(1) { next = new ListNode(2)}, new ListNode(0));
		}
		public class ListNode
		{
			public int val;
			public ListNode next;
			public ListNode(int x) { val = x; }
		}
		public class Solution
		{
			public ListNode MergeTwoLists(ListNode l1, ListNode l2)
			{
				var resp = new ListNode(-1);
				var iResp = resp;
				while (l1 != null && l2 != null)
				{
					if (l1.val < l2.val)
					{
						iResp.next = l1;
						l1 = l1.next;
					}
					else
					{
						iResp.next = l2;
						l2 = l2.next;
					}
					iResp = iResp.next;
				}
				iResp.next= l1 != null ? l1 : l2;
				return resp.next;
			}
		}
	}
}
