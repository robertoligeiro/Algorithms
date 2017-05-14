using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode106.ConstructBinTreefromInandPosOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
//            var r = s.BuildTree(new int[] { 1,2,3,4 }, new int[] { 3,4,2,1 });
            var r = s.BuildTree(new int[] { 2,1,3 }, new int[] { 2,3,1 });
        }
        ///**
        // * Definition for a binary tree node.
        public class TreeNode {
              public int val;
              public TreeNode left;
              public TreeNode right;
              public TreeNode(int x) { val = x; }
          }
         //*/
        public class Solution
        {
            public TreeNode BuildTree(int[] inorder, int[] postorder)
            {
                return BuildTree(new List<int>(inorder), new List<int>(postorder));
            }
            public TreeNode BuildTree(List<int> inorder, List<int> postorder)
            {
                if (inorder == null || inorder.Count == 0) return null;
                var r = new TreeNode(postorder.LastOrDefault());
                postorder.RemoveAt(postorder.Count - 1);
                var index = inorder.IndexOf(r.val);
                var left = index > 0 ? inorder.GetRange(0, index) : null;
                var right = index < inorder.Count ? inorder.GetRange(index + 1, inorder.Count - index - 1) : null;
                r.right = BuildTree(right, postorder);
                r.left = BuildTree(left, postorder);
                return r;
            }
        }
    }
}
