using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode623.AddOneRowtoTree
{
    class Program
    {
        //https://leetcode.com/problems/add-one-row-to-tree/tabs/description
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
            public TreeNode AddOneRow(TreeNode root, int v, int d)
            {
                if (d == 1) return new TreeNode(v) { left = root };
                var l = 1;
                var q1 = new Queue<TreeNode>();
                var q2 = new Queue<TreeNode>();
                q1.Enqueue(root);
                while (q1.Count > 0 || q2.Count > 0)
                {
                    if (l == d - 1)
                    {
                        AddOneRow(q1, v);
                        return root;
                    }
                    MoveFromQueues(q1, q2);
                    l++;
                    if (l == d - 1)
                    {
                        AddOneRow(q2, v);
                        return root;
                    }
                    MoveFromQueues(q2, q1);
                    l++;
                }
                return root;
            }
            private void MoveFromQueues(Queue<TreeNode> from, Queue<TreeNode> to)
            {
                while (from.Count > 0)
                {
                    var curr = from.Dequeue();
                    if (curr.left != null) to.Enqueue(curr.left);
                    if (curr.right != null) to.Enqueue(curr.right);
                }
            }
            private void AddOneRow(Queue<TreeNode> q, int vaule)
            {
                while (q.Count > 0)
                {
                    var curr = q.Dequeue();
                    var left = curr.left;
                    var rigth = curr.right;
                    curr.left = new TreeNode(vaule) { left = left };
                    curr.right = new TreeNode(vaule) { right = rigth };
                }
            }
        }
    }
}
