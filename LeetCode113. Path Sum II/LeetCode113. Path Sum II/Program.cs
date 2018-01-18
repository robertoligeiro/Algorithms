using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode113.Path_Sum_II
{
	class Program
	{
		//https://leetcode.com/problems/path-sum-ii/description/
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
			public IList<IList<int>> PathSum(TreeNode root, int sum)
			{
				var resp = new List<IList<int>>();
				var path = new List<int>();
				PathSum(root, resp, path, sum);
				return resp;
			}
			private void PathSum(TreeNode n, List<IList<int>> resp, List<int> path, int sum)
			{
				if (n == null) return;
				sum -= n.val;
				if (n.left == null && n.right == null)
				{
					if (sum == 0)
					{
						var p = new List<int>(path);
						p.Add(n.val);
						resp.Add(p);
					}
					return;
				}

				path.Add(n.val);
				PathSum(n.left, resp, path, sum);
				PathSum(n.right, resp, path, sum);
				path.RemoveAt(path.Count - 1);
			}
		}
	}
}
