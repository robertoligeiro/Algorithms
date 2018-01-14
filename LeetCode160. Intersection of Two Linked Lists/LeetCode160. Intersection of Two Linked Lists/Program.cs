using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode160.Intersection_of_Two_Linked_Lists
{
	class Program
	{
		//https://leetcode.com/problems/intersection-of-two-linked-lists/description/
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
			public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
			{
				if (headA == null || headB == null) return null;

				ListNode lastA = null;
				var s1 = GetSizeAndLastNode(headA, ref lastA);
				ListNode lastB = null;
				var s2 = GetSizeAndLastNode(headB, ref lastB);

				if (lastA != lastB) return null;
				var diff = Math.Abs(s1 - s2);
				if (s1 > s2)
				{
					while (diff-- > 0) headA = headA.next;
				}
				else if (s2 > s1)
				{
					while (diff-- > 0) headB = headB.next;
				}
				while (headA != null)
				{
					if (headA == headB) return headA;
					headA = headA.next;
					headB = headB.next;
				}
				return null;
			}

			private int GetSizeAndLastNode(ListNode n, ref ListNode last)
			{
				var s = 0;
				while (n != null)
				{
					last = n;
					n = n.next;
					s++;
				}
				return s;
			}
		}
	}
}
