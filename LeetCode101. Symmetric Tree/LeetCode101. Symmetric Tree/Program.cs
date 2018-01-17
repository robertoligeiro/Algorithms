using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode101.Symmetric_Tree
{
	class Program
	{
		//https://leetcode.com/problems/symmetric-tree/description/
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
			public bool IsSymmetric(TreeNode root)
			{
				if (root == null) return true;
				return IsSymmetric(root.left, root.right);
			}

			private bool IsSymmetric(TreeNode l, TreeNode r)
			{
				if (l == null && r == null) return true;
				if (l == null || r == null) return false;
				if (l.val != r.val) return false;
				return IsSymmetric(l.left, r.right) && IsSymmetric(l.right, r.left);
			}
		}
	}
}
