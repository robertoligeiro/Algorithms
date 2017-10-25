using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode99.Recover_Binary_Search_Tree
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
			public void RecoverTree(TreeNode root)
			{
				var inOrder = new List<int>();
				InOrder(root, inOrder);
				inOrder.Sort();
				InOrderFix(root, new Queue<int>(inOrder));
			}

			private void InOrder(TreeNode n, List<int> inOrder)
			{
				if (n == null) return;
				InOrder(n.left, inOrder);
				inOrder.Add(n.val);
				InOrder(n.right, inOrder);
			}
			private void InOrderFix(TreeNode n, Queue<int> inOrder)
			{
				if (n == null) return;
				InOrderFix(n.left, inOrder);
				n.val = inOrder.Dequeue();
				InOrderFix(n.right, inOrder);
			}
		}
	}
}
