using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode102.BinaryTreeLevelOrderTraversal
{
	class Program
	{
		//https://leetcode.com/problems/binary-tree-level-order-traversal/description/
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
			public IList<IList<int>> LevelOrder(TreeNode root)
			{
				var resp = new List<IList<int>>();
				if (root == null) return resp;
				var q1 = new Queue<TreeNode>();
				var q2 = new Queue<TreeNode>();
				q1.Enqueue(root);
				while (q1.Count > 0 || q2.Count > 0)
				{
					GetChildren(q1, q2, resp);
					GetChildren(q2, q1, resp);
				}
				return resp;
			}
			private void GetChildren(Queue<TreeNode> from, Queue<TreeNode> to, List<IList<int>> resp)
			{
				if (from.Count == 0) return;
				var level = new List<int>();
				while (from.Count > 0)
				{
					var curr = from.Dequeue();
					level.Add(curr.val);
					if (curr.left != null) to.Enqueue(curr.left);
					if (curr.right != null) to.Enqueue(curr.right);
				}
				resp.Add(level);
			}
		}
	}
}
