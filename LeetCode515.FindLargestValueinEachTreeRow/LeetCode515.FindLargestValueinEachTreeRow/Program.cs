using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode515.FindLargestValueinEachTreeRow
{
	class Program
	{
		//https://leetcode.com/problems/find-largest-value-in-each-tree-row/description/
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
			public IList<int> LargestValues(TreeNode root)
			{
				if (root == null) return new List<int>();
				var resp = new List<int>();
				var q1 = new Queue<TreeNode>();
				var q2 = new Queue<TreeNode>();
				q1.Enqueue(root);
				while (q1.Count > 0 || q2.Count > 0)
				{
					var max = int.MinValue;
					bool getValue = false;
					while (q1.Count > 0)
					{
						getValue = true;
						var curr = q1.Dequeue();
						max = Math.Max(curr.val, max);
						if (curr.left != null) q2.Enqueue(curr.left);
						if (curr.right != null) q2.Enqueue(curr.right);
					}
					if (getValue) resp.Add(max);
					getValue = false;
					var max = int.MinValue;
					while (q2.Count > 0)
					{
						getValue = true;
						var curr = q2.Dequeue();
						max = Math.Max(curr.val, max);
						if (curr.left != null) q1.Enqueue(curr.left);
						if (curr.right != null) q1.Enqueue(curr.right);
					}
					if (getValue) resp.Add(max);
				}
				return resp;
			}
		}
	}
}
