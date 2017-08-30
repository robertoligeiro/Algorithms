using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode98.Validate_Binary_Search_Tree
{
    class Program
    {
        //https://leetcode.com/problems/validate-binary-search-tree/description/
        static void Main(string[] args)
        {
            var n0 = new TreeNode(1) { left = new TreeNode(1) };
            var s = new Solution();
            var r = s.IsValidBST(n0);
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
            public bool IsValidBST(TreeNode r, ref TreeNode prev)
            {
                if (r == null) return true;
                if (!IsValidBST(r.left, ref prev)) return false;
                if (prev != null && prev.val >= r.val) return false;
                prev = r;
                return IsValidBST(r.right, ref prev);
            }
        }
    }
}
