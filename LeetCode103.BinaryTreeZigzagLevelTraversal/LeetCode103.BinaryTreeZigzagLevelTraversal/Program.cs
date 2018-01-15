using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode103.BinaryTreeZigzagLevelTraversal
{
	class Program
	{
		//https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/description/
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
			public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
			{
				var resp = new List<IList<int>>();
				if (root == null) return resp;
				var s1 = new Stack<TreeNode>();
				var s2 = new Stack<TreeNode>();
				s1.Push(root);
				while (s1.Count > 0 || s2.Count > 0)
				{
					var l = new List<int>();
					while (s1.Count > 0)
					{
						var curr = s1.Pop();
						l.Add(curr.val);
						if (curr.left != null) s2.Push(curr.left);
						if (curr.right != null) s2.Push(curr.right);
					}
					if (l.Count > 0) resp.Add(new List<int>(l));
					l = new List<int>();
					while(s2.Count > 0)
					{
						var curr = s2.Pop();
						l.Add(curr.val);
						if (curr.right != null) s1.Push(curr.right);
						if (curr.left != null) s1.Push(curr.left);
					}
					if (l.Count > 0) resp.Add(new List<int>(l));
				}
				return resp;
			}
		}
	}
}
