using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode530.MinimumAbsoluteDifferenceinBST
{
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
			public int GetMinimumDifference(TreeNode root)
			{
				var min = int.MaxValue;
				TreeNode prev = null;
				GetMinimumDifference(root, ref prev, ref min);
				return min;
			}

			private void GetMinimumDifference(TreeNode n, ref TreeNode prev, ref int min)
			{
				if (n == null) return;
				GetMinimumDifference(n.left, ref prev, ref min);
				if (prev != null)
				{
					min = Math.Min(min, n.val - prev.val);
				}
				prev = n;
				GetMinimumDifference(n.right, ref prev, ref min);
			}
		}
	}
}
