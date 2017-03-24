using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesComputeRightSiblingUsingQueues
{
    class Program
    {
        public class TreeNode
        {
            public int val { get; set; }
            public TreeNode next { get; set; }
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
        }
        static void Main(string[] args)
        {
            // full tree
            var n0 = new TreeNode() { val = 5, };
            var n1 = new TreeNode() { val = 3, };
            var n2 = new TreeNode() { val = 7, };
            var n3 = new TreeNode() { val = 1, };
            var n4 = new TreeNode() { val = 6, };
            var n5 = new TreeNode() { val = 8, };
            n0.left = n1;
            n0.right = n2;
            n1.left = n3;
            n2.left = n4;
            n2.right = n5;

            ComputeSibling(n0);
        }

        public static void ComputeSibling(TreeNode n)
        {
            var q1 = new Queue<TreeNode>();
            var q2 = new Queue<TreeNode>();
            q1.Enqueue(n);
            while (q1.Count > 0)
            {
                TreeNode prev = null;
                while (q1.Count > 0)
                {
                    var curr = q1.Dequeue();
                    curr.next = prev;
                    prev = curr;
                    if(curr.right != null) q2.Enqueue(curr.right);
                    if (curr.left != null) q2.Enqueue(curr.left);
                }
                prev = null;
                while (q2.Count > 0)
                {
                    var curr = q2.Dequeue();
                    curr.next = prev;
                    prev = curr;
                    if (curr.right != null) q1.Enqueue(curr.right);
                    if (curr.left != null) q1.Enqueue(curr.left);
                }
            }
        }
    }
}
