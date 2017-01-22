using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            var n1 = new TreeNode(1);
            var n2 = new TreeNode(2);
            var n3 = new TreeNode(3);
            var n4 = new TreeNode(4);
            var n5 = new TreeNode(5);
            var n6 = new TreeNode(6);
            var n7 = new TreeNode(7);
            var n8 = new TreeNode(8);
            var n9 = new TreeNode(9);
            var n10 = new TreeNode(10);

            //build bst to delete nodes from
            n3.left = n2;
            n2.left = n1;
            n3.right = n5;
            n5.left = n4;
            n5.right = n9;
            n9.left = n7;
            n9.right = n10;
            n7.right = n8;

            var d = DeleteNodeBST(n3, 2);
            d = DeleteNodeBST(n3, 1);
            d = DeleteNodeBST(n3, 5);
            d = DeleteNodeBST(n3, 10);
            d = DeleteNodeBST(n3, 9);

            // reconstruct and compute exterior
            var pre = new List<TreeNode>() { n1, n2, n4, n5, n3, n6, n8, n7 };
            var inO = new List<TreeNode>() { n4, n2, n5, n1, n8, n6, n3, n7 };
            var r = ReconstructTreePreIn.reconstruct(pre, inO);
            var ext = ComputeTreeExterior.compute(r);
            //List<TreeNode> l = new List<TreeNode>() { new TreeNode(1), new TreeNode(2), new TreeNode(4), null, null, new TreeNode(5), null, null, new TreeNode(3), null, null };
            //var r = ReconstructWMarkers.reconstructPreOrderMarkers(l);
        }

        public static TreeNode DeleteNodeBST(TreeNode root, int v)
        {
            return DeleteNode(root, v);
        }

        public static TreeNode DeleteNode(TreeNode n, int v)
        {
            if (n == null) return n;

            // found node, delete it
            if (n.val == v)
            {
                //leaf
                if (n.left == null && n.right == null)
                {
                    return null;
                }

                // no left child
                if (n.left == null)
                {
                    return n.right;
                }

                // no right child
                if (n.right == null)
                {
                    return n.left;
                }

                // has both
                var successor = FindSuccessor(n.right);
                successor.left = n.left;

                if (successor != n.right)
                {
                    var temp = successor.right;
                    successor.right = n.right;
                    n.right.left = temp;
                }
                else
                {
                    n.right = null;
                }

                return successor;
            }

            // recurse finding the node
            if (n.val > v)
            {
                n.left = DeleteNode(n.left, v);
            }
            else
            {
                n.right = DeleteNode(n.right, v);
            }

            return n;
        }

        public static TreeNode FindSuccessor(TreeNode n)
        {
            if (n.left == null) return n;
            return FindSuccessor(n.left);
        }
        public class ComputeTreeExterior
        {
            public static List<TreeNode> compute(TreeNode root)
            {
                var result = new List<TreeNode>();
                computeLeftAndLeaves(root, result, true);
                computeRight(root.right, result);
                return result;
            }

            private static void computeLeftAndLeaves(TreeNode n, List<TreeNode> r, bool isBorder)
            {
                if (n == null) return;
                if (isBorder || (n.left == null && n.right == null))
                {
                    r.Add(n);
                }

                computeLeftAndLeaves(n.left, r, isBorder);
                computeLeftAndLeaves(n.right, r, isBorder && n.left == null);
            }

            private static void computeRight(TreeNode n, List<TreeNode> r)
            {
                if (n != null && n.right != null)
                {
                    r.Add(n);
                    computeRight(n.right, r);
                }
            }
        }
        public class ReconstructTreePreIn
        {
            public static TreeNode reconstruct(List<TreeNode> pre, List<TreeNode>inO)
            {
                    var n = pre[0];
                    pre.RemoveAt(0);
                    int index = inO.IndexOf(n);
                    var left = new TreeNode[index];
                    var right = new TreeNode[inO.Count - index - 1];
                    inO.CopyTo(0, left, 0, index);
                    inO.CopyTo(index + 1, right, 0, right.Length);
                    n.left = left.Length == 0 ? null : reconstruct(pre, left.ToList());
                    n.right = right.Length == 0 ? null : reconstruct(pre, right.ToList());
                    return n;
            }
        }
        public class ReconstructWMarkers
        {
            public static TreeNode reconstructPreOrderMarkers(List<TreeNode> pre)
            {
                return reconstruct(pre);
            }

            private static TreeNode reconstruct(List<TreeNode> pre)
            {
                var n = pre[0];
                pre.RemoveAt(0);
                if (n != null)
                {
                    n.left = reconstruct(pre);
                    n.right = reconstruct(pre);
                    return n;
                }
                return null;
            }
        }
        public class TreeNode
        {
            public int val { get; set; }
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }

            public TreeNode(int i) { val = i; left = null; right = null; }
        }
    }
}
