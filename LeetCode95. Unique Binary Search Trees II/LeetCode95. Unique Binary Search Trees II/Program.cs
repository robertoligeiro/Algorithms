﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode95.Unique_Binary_Search_Trees_II
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.GenerateTrees(3);
        }
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

		/**
		 * Definition for a binary tree node.
		 * public class TreeNode {
		 *     public int val;
		 *     public TreeNode left;
		 *     public TreeNode right;
		 *     public TreeNode(int x) { val = x; }
		 * }
		 */
		public class Solution
		{
			public IList<TreeNode> GenerateTrees(int n)
			{
				if (n == 0) return new List<TreeNode>();
				return CreateBsts(1, n);
			}

			private IList<TreeNode> CreateBsts(int left, int right)
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
