using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode653.Two_Sum_IV___Input_is_a_BST
{
	class Program
	{
		//https://leetcode.com/problems/two-sum-iv-input-is-a-bst/description/
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
			public bool FindTarget(TreeNode root, int k)
			{
				var h = new HashSet<int>();
				return FindTarget(root, k, h);
			}

			private bool FindTarget(TreeNode n, int k, HashSet<int> h)
			{
				if (n == null) return false;
				if (h.Contains(n.val)) return true;

				h.Add(k - n.val);
				return FindTarget(n.left, k, h) || FindTarget(n.right, k, h);
			}
		}
	}
}
