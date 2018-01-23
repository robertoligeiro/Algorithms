using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode314.BinTreeVerticalOrderTraversal
{
	class Program
	{
		//https://leetcode.com/problems/binary-tree-vertical-order-traversal/description/
		static void Main(string[] args)
		{
			var t = new TreeNode(3) { left = new TreeNode(9), right = new TreeNode(20) { left = new TreeNode(15), right = new TreeNode(17) } };
			var s = new Solution();
			var r = s.VerticalOrder(t);
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
			public int maxLeft = 0;
			public int maxRight = 0;
			public IList<IList<int>> VerticalOrder(TreeNode root)
			{
				var resp = new List<IList<int>>();
				if (root == null) return resp;
				TreeRange(root, 0, 0);
				
				for (int i = 0; i <= maxLeft + maxRight; ++i)
				{
					resp.Add(new List<int>());
				}

				var qIndex = new Queue<int>();
				var nodes = new Queue<TreeNode>();
				nodes.Enqueue(root);
				qIndex.Enqueue(maxLeft);
				while (nodes.Count > 0)
				{
					var curr = nodes.Dequeue();
					var col = qIndex.Dequeue();
					resp[col].Add(curr.val);
					if (curr.left != null)
					{
						nodes.Enqueue(curr.left);
						qIndex.Enqueue(col - 1);
					}
					if (curr.right != null)
					{
						nodes.Enqueue(curr.right);
						qIndex.Enqueue(col + 1);
					}
				}
				return resp;
			}


			private void TreeRange(TreeNode n, int left, int right)
			{
				if (n == null) return;
				maxLeft = Math.Max(maxLeft, left);
				maxRight = Math.Max(maxRight, right);
				TreeRange(n.left, left + 1, right - 1);
				TreeRange(n.right, left - 1, right + 1);
			}
		}
	}
}
