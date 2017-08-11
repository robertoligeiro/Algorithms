using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode563.BinaryTreeTilt
{
    class Program
    {
        //https://leetcode.com/problems/binary-tree-tilt/description/
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
            public int FindTilt(TreeNode root)
            {
                var tilt = 0;
                FindTilt(root, ref tilt);
                return tilt;
            }
            private int FindTilt(TreeNode node, ref int tilt)
            {
                if (node == null) return 0;
                var l = FindTilt(node.left, ref tilt);
                var r = FindTilt(node.right, ref tilt);
                var localTilt = Math.Abs(l - r);
                tilt += localTilt;
                return node.val + l + r;
            }
        }
    }
}
