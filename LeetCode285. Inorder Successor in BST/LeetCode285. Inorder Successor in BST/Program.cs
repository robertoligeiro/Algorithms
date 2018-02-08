using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode285.Inorder_Successor_in_BST
{
	class Program
	{
		//https://leetcode.com/problems/inorder-successor-in-bst/description/
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
			public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
			{
				if (p == null) return null;
				TreeNode resp = null;
				while(root != null)
				{
					if (root.val > p.val)
					{
						resp = root;
						root = root.left;
					}
					else
					{
						root = root.right;
					}
				}
				return resp;
			}
		}
	}
}
