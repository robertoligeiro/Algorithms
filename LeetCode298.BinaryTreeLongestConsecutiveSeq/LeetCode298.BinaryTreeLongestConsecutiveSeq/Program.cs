using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode298.BinaryTreeLongestConsecutiveSeq
{
	//https://leetcode.com/problems/binary-tree-longest-consecutive-sequence/description/
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
			public int LongestConsecutive(TreeNode root)
			{
				var max = 0;
				LongestConsecutive(root, ref max);
				return max;
			}
			private int LongestConsecutive(TreeNode n, ref int max)
			{
				if (n == null) return 0;
				var l = LongestConsecutive(n.left, ref max);
				if (n.left != null && n.left.val != n.val + 1)
				{
					l = 0;
				}
				l++;
				var r = LongestConsecutive(n.right, ref max);
				if (n.right != null && n.right.val != n.val + 1)
				{
					r = 0;
				}
				r++;
				max = Math.Max(max, Math.Max(l, r));
				return Math.Max(l, r);
			}
		}
	}
}
