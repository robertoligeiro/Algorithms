using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode662.Maximum_Width_of_Binary_Tree
{
	//https://leetcode.com/problems/maximum-width-of-binary-tree/description/
	class Program
	{
		static void Main(string[] args)
		{
			//var t = new TreeNode(0) { left = new TreeNode(1) { left = new TreeNode(9), right = new TreeNode(10)}, right = new TreeNode(2) { right = new TreeNode(11)} };
			var t = new TreeNode(1) { left = new TreeNode(1) { left = new TreeNode(1) { left = new TreeNode(1) } }, right = new TreeNode(1) { right = new TreeNode(1) { right = new TreeNode(1)} } };
			var s = new Solution();
			var r = s.WidthOfBinaryTree(t);
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
			public int WidthOfBinaryTree(TreeNode root)
			{
				if (root == null) return 0;
				var max = 0;
				var q1 = new Queue<Tuple<int, TreeNode>>();
				var q2 = new Queue<Tuple<int, TreeNode>>();
				q1.Enqueue(new Tuple<int, TreeNode>(0, root));
				while (q1.Count > 0 || q2.Count > 0)
				{
					max = Math.Max(max, MoveQueues(q1, q2));
					max = Math.Max(max, MoveQueues(q2, q1));
				}
				return max;
			}

			private int MoveQueues(Queue<Tuple<int, TreeNode>> from, Queue<Tuple<int, TreeNode>> to)
			{
				if (from.Count == 0) return 0;
				var l = from.FirstOrDefault().Item1;
				var r = from.LastOrDefault().Item1;
				while (from.Count > 0)
				{
					var c = from.Dequeue();
					if (c.Item2.left != null) to.Enqueue(new Tuple<int, TreeNode>(2 * c.Item1, c.Item2.left));
					if (c.Item2.right != null) to.Enqueue(new Tuple<int, TreeNode>(2 * c.Item1 + 1, c.Item2.right));
				}

				return r == l ? 1 : (r - l) + 1;
			}
		}
	}
}
