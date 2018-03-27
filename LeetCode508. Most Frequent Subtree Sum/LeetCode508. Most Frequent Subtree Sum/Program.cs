using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode508.Most_Frequent_Subtree_Sum
{
	class Program
	{
		//https://leetcode.com/problems/most-frequent-subtree-sum/description/
		static void Main(string[] args)
		{
			var t = new TreeNode(5) { left = new TreeNode(2), right = new TreeNode(-3) };
			var s = new Solution();
			var r = s.FindFrequentTreeSum(t);
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
			public int[] FindFrequentTreeSum(TreeNode root)
			{
				if (root == null) return new int[0];
				var m = new Dictionary<int, List<int>>();
				FindFrequentTreeSum(root, m);

				var max = 0;
				var resp = new List<int>();
				foreach (var t in m)
				{
					max = Math.Max(max, t.Value.Count);
				}
				foreach (var t in m)
				{
					if (t.Value.Count == max)
						resp.Add(t.Key);
				}
				return resp.ToArray();
			}
			private int FindFrequentTreeSum(TreeNode n, Dictionary<int, List<int>> m)
			{
				if (n == null) return 0;
				var l = FindFrequentTreeSum(n.left, m);
				var r = FindFrequentTreeSum(n.right, m);
				var v = l + r + n.val;
				List<int> i;
				if (m.TryGetValue(v, out i)) i.Add(n.val);
				else
				{
					i = new List<int>() { v };
					m.Add(v, i);
				}
				return v;
			}
		}
	}
}
