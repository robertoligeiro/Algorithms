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

            var pre = new List<TreeNode>() { n1, n2, n4, n5, n3, n6, n8, n7 };
            var inO = new List<TreeNode>() { n4, n2, n5, n1, n8, n6, n3, n7 };
            var r = ReconstructTreePreIn.reconstruct(pre, inO);
            var ext = ComputeTreeExterior.compute(r);
            //List<TreeNode> l = new List<TreeNode>() { new TreeNode(1), new TreeNode(2), new TreeNode(4), null, null, new TreeNode(5), null, null, new TreeNode(3), null, null };
            //var r = ReconstructWMarkers.reconstructPreOrderMarkers(l);
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
