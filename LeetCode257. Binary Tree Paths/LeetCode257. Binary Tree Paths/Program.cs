using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode257.Binary_Tree_Paths
{
	class Program
	{
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
			//https://leetcode.com/problems/binary-tree-paths/description/
			public IList<string> BinaryTreePaths(TreeNode root)
			{
				var resp = new List<string>();
				if (root == null) return resp;
				var parc = new List<int>();
				GetPaths(root, parc, resp);
				return resp;
			}
			private void GetPaths(TreeNode n, List<int> parc, List<string> resp)
			{
				if (n == null) return;
				parc.Add(n.val);
				if (n.left == null && n.right == null)
				{
					resp.Add(string.Join("->", parc));
					parc.RemoveAt(parc.Count - 1);
					return;
				}
				GetPaths(n.left, parc, resp);
				GetPaths(n.right, parc, resp);
				parc.RemoveAt(parc.Count - 1);

			}
		}
	}
}
