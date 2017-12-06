using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode655.Print_Binary_Tree
{
	class Program
	{
		//https://leetcode.com/problems/print-binary-tree/description/
		static void Main(string[] args)
		{
			var root = new TreeNode(1) { left = new TreeNode(2) { right = new TreeNode(4) }, right = new TreeNode(3) { left = new TreeNode(5) } };
			var s = new Solution();
			var r = s.PrintTree(root);
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
			public IList<IList<string>> PrintTree(TreeNode root)
			{
				if (root == null) return new List<IList<string>>();
				var treeH = GetTreeH(root);
				var rootSize = Math.Pow(2, treeH) - 1;
				var parc = Enumerable.Repeat(string.Empty, (int)rootSize).ToList();
				var resp = new List<IList<string>>();
				for (int i = 0; i < treeH; ++i)
				{
					resp.Add(new List<string>(parc));
				}
				GetTreeMatrix(root, resp, 0, parc.Count - 1, 0);
				return resp;
			}

			private void GetTreeMatrix(TreeNode n, List<IList<string>> resp, int start, int end, int h)
			{
				if (n == null) return;
				var mid = start + (end - start) / 2;
				resp[h][mid] = n.val.ToString();
				GetTreeMatrix(n.left, resp, start, mid - 1, h + 1);
				GetTreeMatrix(n.right, resp, mid + 1, end, h + 1);
			}
			private int GetTreeH(TreeNode n)
			{
				if (n == null) return 0;
				var left = GetTreeH(n.left);
				var right = GetTreeH(n.right);
				return Math.Max(left, right) + 1;
			}
		}
	}
}