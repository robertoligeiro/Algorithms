using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesGenerateBsts
{
	class Program
	{
		static void Main(string[] args)
		{
			var r = GenerateTrees(3);
		}
		public class TreeNode
		{
			public int val;
			public TreeNode left;
			public TreeNode right;
			public TreeNode(int x) { val = x; }
		}
		public static List<TreeNode> GenerateTrees(int n)
		{
			var source = Enumerable.Range(1, n).ToList();
			return GenerateTrees(source);
		}

		public static List<TreeNode> GenerateTrees(List<int> n)
		{
			if (n.Count == 0)
			{
				return new List<TreeNode>() { new TreeNode(-1) };
			}
			var resp = new List<TreeNode>();
			for (int i = 0; i < n.Count; ++i)
			{
				var left = GenerateTrees(n.GetRange(0, i));
				var rigth = GenerateTrees(n.GetRange(i + 1, n.Count - i - 1));
				resp.AddRange(GetCombinedTrees(n[i], left, rigth));
			}
			return resp;
		}

		public static List<TreeNode> GetCombinedTrees(int i, List<TreeNode> left, List<TreeNode> right)
		{
			var resp = new List<TreeNode>();
			foreach (var l in left)
			{
				foreach (var r in right)
				{
					var n = new TreeNode(i) { left = l.val == -1 ? null : l, right = r.val == -1 ? null : r };
					resp.Add(n);
				}
			}
			return resp;
		}
	}
}
