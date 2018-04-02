using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateBsts
{
	class Program
	{
		static void Main(string[] args)
		{
			var r = Solution.CreateBsts(4);
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
			public static List<TreeNode> CreateBsts(int n)
			{
				return CreateBsts(1, n);
			}

			private static List<TreeNode> CreateBsts(int left, int right)
			{
				var resp = new List<TreeNode>();
				if (left > right)
				{
					resp.Add(new TreeNode(-1));
					return resp;
				}
				if (left == right)
				{
					resp.Add(new TreeNode(left));
					return resp;
				}

				for (int i = left; i <= right; ++i)
				{
					var lTree = CreateBsts(left, i - 1);
					var rTree = CreateBsts(i + 1, right);
					foreach (var l in lTree)
					{
						foreach (var r in rTree)
						{
							var n = new TreeNode(i);
							n.left = l.val == -1 ? null : l;
							n.right = r.val == -1 ? null : r;
							resp.Add(n);
						}
					}
				}
				return resp;
			}
		}
	}
}
