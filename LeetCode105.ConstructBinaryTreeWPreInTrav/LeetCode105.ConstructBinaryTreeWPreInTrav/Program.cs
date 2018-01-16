using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode105.ConstructBinaryTreeWPreInTrav
{
	class Program
	{
		//https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/description/
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
			public TreeNode BuildTree(int[] preorder, int[] inorder)
			{
				var pre = new Queue<int>(preorder);
				return BuildTree(pre, new List<int>(inorder), 0, inorder.Length - 1);
			}

			private TreeNode BuildTree(Queue<int> pre, List<int> inorder, int l, int r)
			{
				if (l > r) return null;
				var v = pre.Dequeue();
				var index = inorder.IndexOf(v);
				var n = new TreeNode(v);
				n.left = BuildTree(pre, inorder, l, index - 1);
				n.right = BuildTree(pre, inorder, index + 1, r);
				return n;
			}
		}
	}
}
