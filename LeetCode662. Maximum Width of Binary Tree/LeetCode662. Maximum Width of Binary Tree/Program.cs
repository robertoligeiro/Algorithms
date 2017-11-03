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
		}
		public class TreeNode
		{
			public int val;
			public TreeNode left;
			public TreeNode right;
			public TreeNode(int x) { val = x; }
		}
		public class TreeNodePos
		{
			public int pos;
			public TreeNode n;
			public TreeNodePos(int x, TreeNode t) { pos = x; n = t; }
		}
		public class Solution
		{
			private static TreeNode voidNode = new TreeNode(-1);

			public int WidthOfBinaryTree(TreeNode root)
			{
				if (root == null) return 0;
				var q1 = new Queue<TreeNodePos>();
				var q2 = new Queue<TreeNodePos>();
				q1.Enqueue(new TreeNodePos(1, root));
				var maxWidth = 1;
				while (q1.Count > 0 || q2.Count > 0)
				{
					var levelWidth = GetQueueWidth(q1, q2);
					if (levelWidth == -1) return maxWidth;
					maxWidth = Math.Max(maxWidth, levelWidth);
					levelWidth = GetQueueWidth(q2, q1);
					if (levelWidth == -1) return maxWidth;
					maxWidth = Math.Max(maxWidth, levelWidth);
				}
				return maxWidth;
			}

			private int GetQueueWidth(Queue<TreeNodePos> from, Queue<TreeNodePos> to)
			{
				var widthStart = -1;
				var widthEnd = 0;
				while (from.Count > 0)
				{
					var curr = from.Dequeue();
					if (curr.n != voidNode)
					{
						if (widthStart == -1) widthStart = curr.pos;
						widthEnd = curr.pos;
						var leftPos = (curr.pos * 2) - 1;
						var rightPos = curr.pos * 2;
						if (curr.n.left != null) to.Enqueue(new TreeNodePos(leftPos, curr.n.left));
						else to.Enqueue(new TreeNodePos(leftPos, voidNode));
						if (curr.n.right != null) to.Enqueue(new TreeNodePos(rightPos, curr.n.right));
						else to.Enqueue(new TreeNodePos(rightPos, voidNode));
					}
				}
				if (widthStart == -1) return -1;
				return widthEnd - widthStart + 1;
			}
		}

		public class Solution2
		{
			private static TreeNode voidNode = new TreeNode(-1);

			public int WidthOfBinaryTree(TreeNode root)
			{
				if (root == null) return 0;
				var q1 = new Queue<TreeNode>();
				var q2 = new Queue<TreeNode>();
				q1.Enqueue(root);
				var maxWidth = 1;
				while (q1.Count > 0 || q2.Count > 0)
				{
					var levelWidth = GetQueueWidth(q1, q2);
					if (levelWidth == -1) return maxWidth;
					maxWidth = Math.Max(maxWidth, levelWidth);
					levelWidth = GetQueueWidth(q2, q1);
					if (levelWidth == -1) return maxWidth;
					maxWidth = Math.Max(maxWidth, levelWidth);
				}
				return maxWidth;
			}

			private int GetQueueWidth(Queue<TreeNode> from, Queue<TreeNode> to)
			{
				var widthStart = -1;
				var widthEnd = 0;
				var i = 0;
				while (from.Count > 0)
				{
					var curr = from.Dequeue();
					if (curr != voidNode)
					{
						if (widthStart == -1) widthStart = i;
						widthEnd = i;
						if (curr.left != null) to.Enqueue(curr.left);
						else to.Enqueue(voidNode);
						if (curr.right != null) to.Enqueue(curr.right);
						else to.Enqueue(voidNode);
					}
					else
					{
						to.Enqueue(voidNode);
						to.Enqueue(voidNode);
					}
					i++;
				}
				if (widthStart == -1) return -1;
				return widthEnd - widthStart + 1;
			}
		}
	}
}
