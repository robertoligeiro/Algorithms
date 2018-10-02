using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode606.ConstructStringfromBinaryTree
{
    class Program
    {
        //https://leetcode.com/problems/construct-string-from-binary-tree/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r0 = new TreeNode(1) { left = new TreeNode(2) { left = new TreeNode(4) }, right = new TreeNode(3) };
            var r = s.Tree2str(r0);
        }

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

		public class Solution
		{
			public string Tree2str(TreeNode t)
			{
				if (t == null) return string.Empty;
				var l = Tree2str(t.left);
				var r = Tree2str(t.right);
				if (!string.IsNullOrEmpty(l) || !string.IsNullOrEmpty(r))
				{
					l = "(" + l + ")";
				}
				if (!string.IsNullOrEmpty(r))
				{
					r = "(" + r + ")";
				}
				return t.val + l + r;
			}
		}
	}
}
