using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode637.Average_of_Levels_in_Binary_Tree
{
	class Program
	{
		//https://leetcode.com/problems/average-of-levels-in-binary-tree/
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
			public IList<double> AverageOfLevels(TreeNode root)
			{
				var resp = new List<double>();
				if (root == null) return resp;
				var q1 = new Queue<TreeNode>();
				var q2 = new Queue<TreeNode>();
				q1.Enqueue(root);
				while (q1.Count > 0 || q2.Count > 0)
				{
					MoveQueuesGetAvr(q1, q2,resp);
					MoveQueuesGetAvr(q2, q1, resp);
				}
				return resp;
			}

			private void MoveQueuesGetAvr(Queue<TreeNode> from, Queue<TreeNode> to, List<double> r)
			{
				if (from.Count == 0) return;
				double acc = 0;
				double div = from.Count;
				while (from.Count > 0)
				{
					var curr = from.Dequeue();
					acc += curr.val;
					if (curr.left != null) to.Enqueue(curr.left);
					if (curr.right != null) to.Enqueue(curr.right);
				}
				r.Add(acc / div);
			}
		}
	}
}
