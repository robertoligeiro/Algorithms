﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode776.Split_BST
{
	//https://leetcode.com/problems/split-bst/description/
	class Program
	{
		static void Main(string[] args)
		{
			var t = new TreeNode(4) { left = new TreeNode(2) { left = new TreeNode(1), right = new TreeNode(3) }, right = new TreeNode(6) };
			var s = new Solution();
			var r = s.SplitBST(t, 2);
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
			public TreeNode[] SplitBST(TreeNode root, int V)
			{
				if (root == null) return new TreeNode[2];
				if (root.val > V) // go left
				{
					var resp = SplitBST(root.left, V);
					root.left = resp[0];
					resp[0] = root;
					return resp;
				}
				else // go right
				{
					var resp = SplitBST(root.right, V);
					root.right = resp[1];
					resp[1] = root;
					return resp;
				}
			}
		}
	}
}
