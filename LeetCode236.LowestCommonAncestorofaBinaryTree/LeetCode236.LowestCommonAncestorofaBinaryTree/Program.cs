using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode236.LowestCommonAncestorofaBinaryTree
{
	//https://leetcode.com/submissions/detail/137620820/
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
			public class Lca
			{
				public int found;
				public TreeNode ancestor;
			}
			public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
			{
				if (root == null || p == null || q == null) return null;
				return LowestCommonAncestorHelper(root, p, q).ancestor;
			}

			private Lca LowestCommonAncestorHelper(TreeNode root, TreeNode p, TreeNode q)
			{
				if (root == null) return new Lca();
				var l = LowestCommonAncestorHelper(root.left, p, q);
				if (l.found == 2) return l;
				var r = LowestCommonAncestorHelper(root.right, p, q);
				if (r.found == 2) return r;
				var ret = new Lca() { found = l.found + r.found };
				if (root == p || root == q) ret.found++;
				if (ret.found == 2) ret.ancestor = root;
				return ret;
			}
		}
	}
}
