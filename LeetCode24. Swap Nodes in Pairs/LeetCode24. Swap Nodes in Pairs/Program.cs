using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode24.Swap_Nodes_in_Pairs
{
	class Program
	{
		//https://leetcode.com/problems/swap-nodes-in-pairs/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.SwapPairs(new ListNode(1) { next = new ListNode(2) { next = new ListNode(3) { next = new ListNode(4)} } });
		}

		public class ListNode
		{
			public int val;
			public ListNode next;
			public ListNode(int x) { val = x; }
		}

		public class Solution
		{
			public ListNode SwapPairs(ListNode head)
			{
				if (head == null) return null;
				var odd = new ListNode(0);
				var iOdd = odd;
				var even = new ListNode(0);
				var iEven = even;
				while (head != null)
				{
					iOdd.next = head;
					iEven.next = head.next;
					iOdd = iOdd.next;
					iEven = iEven.next;
					if (head.next != null) head = head.next.next;
					else head = null;
				}
				if (iOdd != null) iOdd.next = null;
				if (iEven != null) iEven.next = null;
				var resp = new ListNode(0);
				var iResp = resp;
				iOdd = odd.next;
				iEven = even.next;
				while (iOdd != null || iEven != null)
				{
					if (iEven != null)
					{
						iResp.next = iEven;
						iResp = iResp.next;
						iEven = iEven.next;
					}
					if (iOdd != null)
					{
						iResp.next = iOdd;
						iResp = iResp.next;
						iOdd = iOdd.next;
					}
				}
				if (iResp != null) iResp.next = null;
				return resp.next;
			}
		}
	}
}
