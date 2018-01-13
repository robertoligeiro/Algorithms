using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsValidBst
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
			public bool IsValidBST(TreeNode r)
			{
				TreeNode prev = null;
				return IsValidBST(r, ref prev);
			}

			private bool IsValidBST(TreeNode n, ref TreeNode prev)
			{
				if (n == null) return true;
				if (!IsValidBST(n.left, ref prev)) return false;
				if (prev != null && prev.val >= n.val) return false;
				prev = n;
				return IsValidBST(n.right, ref prev);
			}
		}
	}
}
