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
			var s = new Solution();
			var r = s.CountNodes(new TreeNode(1) { left = new TreeNode(2) });
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
				var l = 0;
				var left = root;
				while (left != null)
				{
					++l;
					left = left.left;
				}
				var r = 0;
				var right = root;
				while (right != null)
				{
					++r;
					right = right.right;
				}
				if (l == r) return (int)Math.Pow(2, l) - 1;
				return CountNodes(root.left) +
						CountNodes(root.right) + 1;
			}
		}
	}
}
