using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode199.BinaryTreeRightSideView
{
    //https://leetcode.com/problems/binary-tree-right-side-view/#/description
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
            public IList<int> RightSideView(TreeNode root)
            {
                var resp = new List<int>();
                if (root == null) return resp; 

                var q1 = new Queue<TreeNode>();
                var q2 = new Queue<TreeNode>();
                q1.Enqueue(root);
                while (q1.Count > 0 && q2.Count > 0)
                {
                    var add = true;
                    while (q1.Count > 0)
                    {
                        var curr = q1.Dequeue();
                        if (add)
                        {
                            resp.Add(curr.val);
                            add = false;
                        }
                        if (curr.right != null) q2.Enqueue(curr.right);
                        if (curr.left != null) q2.Enqueue(curr.left);
                    }
                    add = true;
                    while (q2.Count > 0)
                    {
                        var curr = q2.Dequeue();
                        if (add)
                        {
                            resp.Add(curr.val);
                            add = false;
                        }
                        if (curr.right != null) q1.Enqueue(curr.right);
                        if (curr.left != null) q1.Enqueue(curr.left);
                    }
                }

                return resp;
            }
        }

        public class Solution2
        {
            public IList<int> RightSideView(TreeNode root)
            {
                var resp = new List<int>();
                var maxh = -1;
                GetView(root, resp, 0, ref maxh);
                return resp;
            }
            private static int GetView(TreeNode n, List<int> r, int h, ref int maxh)
            {
                if (n == null) return h - 1;
                if (h > maxh) r.Add(n.val);
                var maxR = GetView(n.right, r, h + 1, ref maxh);
                maxh = Math.Max(maxh, maxR);
                var maxL = GetView(n.left, r, h + 1, ref maxh);
                return Math.Max(maxL, maxh);
            }
        }
    }
}
