using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode222.Count_Complete_Tree_Nodes
{
	class Program
	{
		//https://leetcode.com/problems/count-complete-tree-nodes/description/
		// solution is time exceeding on leetocde, but I'm happy with it.
		static void Main(string[] args)
		{
		}
		public class TreeNode
		{
			public int val;
			public TreeNode left;
			public TreeNode right;
			public TreeNode(int x) { val = x; }
		}
		public class Solution
		{
			public int CountNodes(TreeNode root)
			{
				if (root == null) return 0;
				var maxH = GetTreeH(root, 0);
				if (maxH == 0) maxH = 1;
				var leaves = 0;
				CountLeaves(root, 0, maxH - 1, ref leaves);
				return (int)(Math.Pow(2, maxH) - 1) + leaves;
			}

			private int GetTreeH(TreeNode root, int h)
			{
				if (root == null) return h - 1;
				return GetTreeH(root.left, h + 1);
			}

			private bool CountLeaves(TreeNode root, int h, int maxH, ref int count)
			{
				if (h == maxH)
				{
					if (root.left != null || root.right != null)
					{
						if (root.left != null) count++;
						if (root.right != null) count++;
						return true;
					}
					return false;
				}
				if (!CountLeaves(root.left, h + 1, maxH, ref count)) return false;
				return CountLeaves(root.right, h + 1, maxH, ref count);
			}
		}
	}
}
