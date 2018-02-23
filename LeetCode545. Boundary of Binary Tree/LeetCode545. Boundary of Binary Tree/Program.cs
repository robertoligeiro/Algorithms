using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode545.Boundary_of_Binary_Tree
{
	class Program
	{
		//https://leetcode.com/problems/boundary-of-binary-tree/description/
		static void Main(string[] args)
		{
			var t = new TreeNode(1) { right = new TreeNode(2) { left = new TreeNode(3), right = new TreeNode(4) } };
			var s = new Solution();
			var r = s.BoundaryOfBinaryTree(t);
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
			private enum direction { left, right};
			public IList<int> BoundaryOfBinaryTree(TreeNode root)
			{
				var resp = new List<int>();
				if (root == null) return resp;
				resp.Add(root.val);
				GetBound(root.left, resp, direction.left);
				GetLeaves(root.left, resp);
				GetLeaves(root.right, resp);
				GetBound(root.right, resp, direction.right);
				return resp;
			}

			private void GetLeaves(TreeNode n, List<int> leaves)
			{
				if (n == null) return;
				if(n.left == null&&n.right==null)
				{
					leaves.Add(n.val);
					return;
				}
				GetLeaves(n.left, leaves);
				GetLeaves(n.right, leaves);
			}
			private void GetBound(TreeNode n, List<int> bound, direction d)
			{
				if (n == null) return;
				if (n.left == null && n.right == null) return;
				if(d == direction.left) bound.Add(n.val);
				if (d == direction.left)
				{
					if (n.left != null)
					{
						GetBound(n.left, bound, d);
					}
					else GetBound(n.right, bound, d);
					return;
				}
				else
				{
					if (n.right != null)
					{
						GetBound(n.right, bound, d);
					}
					else GetBound(n.left, bound, d);
				}
				if (d == direction.right) bound.Add(n.val);
			}
		}
	}
}
