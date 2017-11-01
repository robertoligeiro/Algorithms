using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode116.PopulatingNextRightPointersNode
{
	class Program
	{
		//https://leetcode.com/problems/populating-next-right-pointers-in-each-node/description/
		// doesn't have c# option, did in c++ in leetcode.
		static void Main(string[] args)
		{
		}
		public class TreeNode
		{
			public int val;
			public TreeNode left;
			public TreeNode right;
			public TreeNode next;
			public TreeNode(int x) { val = x; }
		}

		public class Solution
		{
			public void Connect(TreeNode root)
			{
				if (root == null) return;
				var curr = root;
				while (curr != null)
				{
					if (curr.left == null) break;
					curr.left.next = curr.right;
					if (curr.next != null)
					{
						curr.right.next = curr.next.left;
					}
					curr = curr.next;
				}
				Connect(curr.left);
			}
		}
	}
}
