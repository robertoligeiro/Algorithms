using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode124.Binary_Tree_Maximum_Path_Sum
{
	//https://leetcode.com/problems/binary-tree-maximum-path-sum/description/
	class Program
	{
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
			public int MaxPathSum(TreeNode root)
			{
				if (root == null) return 0;
				var max = int.MinValue;
				MaxPathSum(root, ref max);
				return max;
			}
			private int MaxPathSum(TreeNode n, ref int max)
			{
				if (n == null) return 0;
				var left = Math.Max(0, MaxPathSum(n.left, ref max));
				var rigth = Math.Max(0, MaxPathSum(n.right, ref max));
				max = Math.Max(max, left + rigth + n.val);
				return Math.Max(left, rigth) + n.val;
			}
		}
	}
}
