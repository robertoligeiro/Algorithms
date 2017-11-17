using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode669.Trim_a_Binary_Search_Tree
{
	class Program
	{
		//https://leetcode.com/problems/trim-a-binary-search-tree/description/
		static void Main(string[] args)
		{
			var t = BuildTree(new List<int>() { 0, 1, 2, 3, 4 }, 0, 4);
			var s = new Solution();
			var r = s.TrimBST(t, 0, 1);
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
			public TreeNode TrimBST(TreeNode root, int L, int R)
			{
				if (root == null) return null;
				if (root.val < L) return TrimBST(root.right, L, R);
				if (root.val > R) return TrimBST(root.left, L, R);
				root.left = TrimBST(root.left, L, R);
				root.right = TrimBST(root.right, L, R);
				if (root.val < L || root.val > R)
				{
					return root.left != null ? root.left : root.right;
				}
				return root;
			}
		}
		private static TreeNode BuildTree(List<int> values, int l, int r)
		{
			if (l > r) return null;
			var mid = l + (r - l) / 2;
			var root = new TreeNode(values[mid]);
			root.left = BuildTree(values, l, mid - 1);
			root.right = BuildTree(values, mid + 1, r);
			return root;
		}
	}
}
