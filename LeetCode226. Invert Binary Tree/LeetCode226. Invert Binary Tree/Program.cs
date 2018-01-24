using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode226.Invert_Binary_Tree
{
	class Program
	{
		//https://leetcode.com/problems/invert-binary-tree/description/
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
			public TreeNode InvertTree(TreeNode root)
			{
				if (root == null) return null;
				var l = InvertTree(root.left);
				var r = InvertTree(root.right);
				root.left = r;
				root.right = l;
				return root;
			}
		}
	}
}
