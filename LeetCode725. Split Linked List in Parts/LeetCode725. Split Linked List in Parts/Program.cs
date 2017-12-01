using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode725.Split_Linked_List_in_Parts
{
	//https://leetcode.com/problems/split-linked-list-in-parts/description/
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
			public ListNode[] SplitListToParts(ListNode root, int k)
			{
				var size = GetSize(root);
				var sizeNewList = size / k;
				var rest = size % k;
				var resp = new List<ListNode>();
				while (k-- > 0)
				{
					var count = sizeNewList;
					var newRoot = new ListNode(-1);
					var it = newRoot;
					while (root != null && count-- > 0)
					{
						it.next = root;
						root = root.next;
						it = it.next;
					}
					if (rest-- > 0)
					{
						it.next = root;
						if (root != null) root = root.next;
						it = it.next;
					}

					it.next = null;
					resp.Add(newRoot.next);
				}
				return resp.ToArray();
			}

			private int GetSize(ListNode n)
			{
				int count = 0;
				while (n != null)
				{
					n = n.next;
					++count;
				}
				return count;
			}
		}
	}
}
