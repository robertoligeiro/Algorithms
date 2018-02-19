using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode687.Longest_Univalue_Path
{
	class Program
	{
		//https://leetcode.com/problems/longest-univalue-path/description/
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
			public int LongestUnivaluePath(TreeNode root)
			{
				var max = 0;
				LongestUnivaluePath(root, ref max);
				return max;
			}

			private int LongestUnivaluePath(TreeNode root, ref int max)
			{
				if (root == null) return 0;
				var left = LongestUnivaluePath(root.left, ref max);
				if (root.left != null && root.left.val != root.val)
				{
					left = 0;
				}
				var right = LongestUnivaluePath(root.right, ref max);
				if (root.right != null && root.right.val != root.val)
				{
					right = 0;
				}
				max = Math.Max(max, right + left);
				return Math.Max(right, left) + 1;
			}
		}
	}
}
