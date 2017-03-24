using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesComputeExteriorOfTree
{
    class Program
    {
        public class TreeNode
        {
            public int val { get; set; }
            public TreeNode parent { get; set; }
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
        }
        static void Main(string[] args)
        {
            // balanced tree
            var n0 = new TreeNode() { val = 5, };
            var n1 = new TreeNode() { val = 3, parent = n0 };
            var n2 = new TreeNode() { val = 7, parent = n0 };
            var n3 = new TreeNode() { val = 1, parent = n1 };
            var n4 = new TreeNode() { val = 6, parent = n2 };
            var n5 = new TreeNode() { val = 8, parent = n2 };
            n0.left = n1;
            n0.right = n2;
            n1.left = n3;
            n2.left = n4;
            n2.right = n5;

            var r = ComputeExteriorOfTree(n0);
        }

        public static List<TreeNode> ComputeExteriorOfTree(TreeNode n)
        {
            var left = ComputeVertice(n, direction.left);
            var leaves = ComputeLinkedList(n);
            var right = ComputeVertice(n.right, direction.right);
            if (left.Count <= 1) return left;
            left.RemoveAt(left.Count - 1);
            leaves.RemoveAt(leaves.Count - 1);
            right.Reverse();
            leaves.AddRange(right);
            left.AddRange(leaves);
            return left;
        }

        public enum direction {left, right };
        public static List<TreeNode> ComputeVertice(TreeNode r, direction d)
        {
            var resp = new List<TreeNode>();
            while (r != null)
            {
                resp.Add(r);
                r = d == direction.left ? r.left : r.right;
            }
            return resp;
        }
        public static List<TreeNode> ComputeLinkedList(TreeNode r)
        {
            var resp = new List<TreeNode>();
            ComputeLinkedList(r, resp);
            return resp;
        }

        public static void ComputeLinkedList(TreeNode n, List<TreeNode> r)
        {
            if (n == null) return;
            if (n.left == null && n.right == null)
            {
                r.Add(n);
                return;
            }
            ComputeLinkedList(n.left, r);
            ComputeLinkedList(n.right, r);
        }
    }
}
