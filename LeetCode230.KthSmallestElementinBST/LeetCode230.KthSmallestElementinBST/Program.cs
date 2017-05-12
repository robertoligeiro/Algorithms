using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode230.KthSmallestElementinBST
{
    class Program
    {
        static void Main(string[] args)
        {
            var n5 = new TreeNode(5);
            var n4 = new TreeNode(4);
            var n3 = new TreeNode(3);
            var n1 = new TreeNode(1);
            var n7 = new TreeNode(7);
            var n6 = new TreeNode(6);
            var n9 = new TreeNode(9);
            n5.left = n3;
            n5.right = n7;
            n3.left = n1;
            n3.right = n4;
            n7.left = n6;
            n7.right = n9;

            var s = new Solution();
            var r = s.KthSmallest(n5, 1);
            r = s.KthSmallest(n5, 2);
            r = s.KthSmallest(n5, 3);
            r = s.KthSmallest(n5, 4);
            r = s.KthSmallest(n5, 5);
            r = s.KthSmallest(n5, 6);
            r = s.KthSmallest(n5, 7);
        }

        //        /**
        //  Definition for a binary tree node.
        public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
  }
 
        public class Solution
        {
            public int KthSmallest(TreeNode root, int k)
            {
                return KthSmallest(root, ref k);
            }

            public int KthSmallest(TreeNode root, ref int k)
            {
                if (root == null) return -1;
                var v = KthSmallest(root.left, ref k);
                if (v != -1) return v;
                if (--k == 0) return root.val;
                return KthSmallest(root.right, ref k);
            }
        }
    }
}
