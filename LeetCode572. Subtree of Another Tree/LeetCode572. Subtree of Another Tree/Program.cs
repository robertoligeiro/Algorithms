using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode572.Subtree_of_Another_Tree
{
    class Program
    {
        //https://leetcode.com/problems/subtree-of-another-tree/description/
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
            public bool IsSubtree(TreeNode s, TreeNode t)
            {
                if (s == null && t == null) return true;
                if (s == null || t == null) return false;
                if (s.val == t.val)
                {
                    if (IsSameTree(s, t)) return true;
                }
                return IsSubtree(s.left, t) || IsSubtree(s.right, t);
            }

            private bool IsSameTree(TreeNode s, TreeNode t)
            {
                if (s == null && t == null) return true;
                if (s == null || t == null) return false;
                if (s.val != t.val)
                {
                    return false;
                }
                return IsSameTree(s.left, t.left) && IsSameTree(s.right, t.right);
            }
        }
    }
}
