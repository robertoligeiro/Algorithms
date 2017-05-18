using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode337.HouseRobberIII
{
    class Program
    {
        static void Main(string[] args)
        {
        }

//        /**
// * Definition for a binary tree node.
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public class Solution
        {
            public int Rob(TreeNode root)
            {
                if (root == null) return 0;
                var v = 0;
                if (root.left != null)
                {
                    v += Rob(root.left.left);
                    v += Rob(root.left.right);
                }
                if (root.right != null)
                {
                    v += Rob(root.right.left);
                    v += Rob(root.right.right);
                }

                return Math.Max(root.val + v, Rob(root.left) + Rob(root.right));
            }
        }
    }
}
