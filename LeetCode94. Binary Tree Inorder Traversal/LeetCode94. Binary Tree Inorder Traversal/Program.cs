using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode94.Binary_Tree_Inorder_Traversal
{
	class Program
	{
		//https://leetcode.com/problems/binary-tree-inorder-traversal/description/
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
			public IList<int> InorderTraversal(TreeNode root)
			{
				var r = new List<int>();
				InorderTraversal(root, r);
				return r;
			}
			public void InorderTraversal(TreeNode n, List<int> r)
			{
				if (n == null) return;
				InorderTraversal(n.left, r);
				r.Add(n.val);
				InorderTraversal(n.right, r);
			}
		}
	}
}
