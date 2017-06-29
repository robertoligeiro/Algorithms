using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode450.DeleteNodeinaBST
{
    class Program
    {
        static void Main(string[] args)
        {
            var s2 = new Solution2();
            var r = s2.BuildTree(new int[] { 1, 3, 4, 5, 7, 8, 9, 10 }, new int[] { 1, 4, 3, 8, 7, 9, 10, 5 });

            var s = new Solution();
            var d = s.DeleteNode(r, 1);
            d = s.DeleteNode(r, 3);
            d = s.DeleteNode(r, 5);
            //var s2 = new Solution2();
            //var r = s2.BuildTree(new int[] { 2, 3, 4, 5, 6, 7, }, new int[] { 2, 4, 3, 7, 6, 5 });

            //var s = new Solution();
            //var d = s.DeleteNode(r, 6);

        }
        public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
  }

        public class Solution
        {
            public TreeNode DeleteNode(TreeNode root, int key)
            {
                if (root == null) return null;
                if (root.val > key)
                {
                    root.left = DeleteNode(root.left, key);
                    return root;
                }
                if (root.val < key)
                {
                    root.right = DeleteNode(root.right, key);
                    return root;
                }

                //leaf
                if (root.left == null && root.right == null)
                {
                    return null;
                }
                //one child
                if (root.left == null || root.right == null)
                {
                    if (root.left == null)
                    {
                        var r = root.right;
                        root.right = null;
                        return r;
                    }
                    var t = root.left;
                    root.left = null;
                    return t;
                }
                //both
                TreeNode parent = null;
                var candidate = root.right;
                while (candidate.left != null)
                {
                    parent = candidate;
                    candidate = candidate.left;
                }

                if (parent != null)
                {
                    parent.left = candidate.right;
                    candidate.right = root.right;
                }

                candidate.left = root.left;
                root.left = null;
                root.right = null;
                return candidate;
            }
        }

        public class Solution2
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
