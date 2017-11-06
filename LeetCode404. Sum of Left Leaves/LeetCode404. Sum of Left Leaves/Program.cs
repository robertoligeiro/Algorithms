using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode404.Sum_of_Left_Leaves
{
	//https://leetcode.com/problems/sum-of-left-leaves/description/
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
			public int SumOfLeftLeaves(TreeNode root)
			{
				return SumOfLeftLeaves(root, null, 0);
			}
			private int SumOfLeftLeaves(TreeNode n, TreeNode parent, int acc)
			{
				if (n == null) return acc;
				if (n.left == null && n.right == null && (parent != null && parent.left == n))
				{
					return acc + n.val;
				}
				return SumOfLeftLeaves(n.left, n, acc) + SumOfLeftLeaves(n.right, n, acc);
			}
		}

		public class Solution1
		{
			public int SumOfLeftLeaves(TreeNode root)
			{
				if (root == null) return 0;
				var sum = 0;
				SumOfLeftLeaves(root.left, true, ref sum);
				SumOfLeftLeaves(root.right, false, ref sum);
				return sum;
			}
			private void SumOfLeftLeaves(TreeNode n, bool pickNode, ref int sum)
			{
				if (n == null) return;
				if (n.left == null && n.right == null && pickNode)
				{
					sum += n.val;
					return;
				}
				SumOfLeftLeaves(n.left, true, ref sum);
				SumOfLeftLeaves(n.right, false, ref sum);
			}
		}
	}
}
