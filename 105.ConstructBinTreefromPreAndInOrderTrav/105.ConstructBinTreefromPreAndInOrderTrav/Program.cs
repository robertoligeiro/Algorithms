using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _105.ConstructBinTreefromPreAndInOrderTrav
{
    //https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/#/description
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.BuildTree(new int[] { 5, 3, 1, 4, 7 }, new int[] { 1, 3, 4, 5, 7 });
        }

  public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
  }

        public class Solution
        {
            public TreeNode BuildTree(int[] preorder, int[] inorder)
            {
                var sPre = new Stack<int>();
                for (var i = preorder.Length - 1; i >= 0; --i) sPre.Push(preorder[i]);
                var inL = new List<int>(inorder);
                return BuildTree(sPre, inL);
            }

            private TreeNode BuildTree(Stack<int> pre, List<int> ino)
            {
                if (ino.Count == 0) return null;
                var node = new TreeNode(pre.Pop());
                var index = ino.IndexOf(node.val);
                var left = new List<int>();
                if (index > 0)
                {
                    left.AddRange(ino.GetRange(0, index));
                }
                var right = new List<int>();
                if (index < ino.Count - 1)
                {
                    right.AddRange(ino.GetRange(index + 1, ino.Count - index - 1));
                }
                node.left = BuildTree(pre, left);
                node.right = BuildTree(pre, right);
                return node;
            }
        }
    }
}
