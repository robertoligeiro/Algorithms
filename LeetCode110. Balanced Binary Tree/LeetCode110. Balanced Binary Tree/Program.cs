using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode110.Balanced_Binary_Tree
{
	//https://leetcode.com/problems/balanced-binary-tree/
	class Program
	{
		static void Main(string[] args)
		{
		}
		public class Solution
		{
			public bool IsBalanced(TreeNode root)
			{
				return IsBalancedH(root) != -1;
			}

			public int IsBalancedH(TreeNode root)
			{
				if (root == null) return 0;
				int l = IsBalancedH(root.left);
				if (l == -1) return -1;
				int r = IsBalancedH(root.right);
				if (r == -1) return -1;

				if (Math.Abs(l - r) > 1) return -1;
				return Math.Max(l, r) + 1;
			}
		}
	}
}
