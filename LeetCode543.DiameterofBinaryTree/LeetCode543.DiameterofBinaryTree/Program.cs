using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode543.DiameterofBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        public class Solution
        {
            public int DiameterOfBinaryTree(TreeNode root)
            {
                var maxDia = 0;
                DiameterOfBinaryTree(root, ref maxDia);
                return maxDia;
            }
            private int DiameterOfBinaryTree(TreeNode root, ref int max)
            {
                if (root == null) return 0;
                var l = DiameterOfBinaryTree(root.left, ref max);
                var r = DiameterOfBinaryTree(root.right, ref max);
                max = Math.Max(max, l + r);
                return Math.Max(l, r) + 1;
            }
        }
    }
}
