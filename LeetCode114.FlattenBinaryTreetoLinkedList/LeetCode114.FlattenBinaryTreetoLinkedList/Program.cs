using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode114.FlattenBinaryTreetoLinkedList
{
	class Program
	{
		//https://leetcode.com/problems/flatten-binary-tree-to-linked-list/description/
		static void Main(string[] args)
		{
			var t = new TreeNode(1) { left = new TreeNode(2) { left=new TreeNode(4), right = new TreeNode(3)}, right = new TreeNode(5) };
			//var t = new TreeNode(1) { right = new TreeNode(2)};
			var s = new Solution();
			s.Flatten(t);
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
			private TreeNode prev;
			public void Flatten(TreeNode root)
			{
				if (root == null) return;
				Flatten(root.right);
				Flatten(root.left);
				root.right = prev;
				root.left = null;
				prev = root;
			}
		}
	}
}
