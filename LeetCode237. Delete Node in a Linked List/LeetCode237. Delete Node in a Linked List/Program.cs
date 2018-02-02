using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode237.Delete_Node_in_a_Linked_List
{
	class Program
	{
		//https://leetcode.com/problems/delete-node-in-a-linked-list/description/
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
			public void DeleteNode(ListNode node)
			{
				var prev = node;
				while (node.next != null)
				{
					node.val = node.next.val;
					prev = node;
					node = node.next;
				}
				prev.next = null;
			}
		}
	}
}
