using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesIsBalanced
{
    class Program
    {
        public class TreeNode
        {
            public int val { get; set; }
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
        }
        static void Main(string[] args)
        {
            // balanced tree
            var n0 = new TreeNode() { val = 0 };
            var n1 = new TreeNode() { val = 1 };
            var n2 = new TreeNode() { val = 2 };
            var n3 = new TreeNode() { val = 3 };
            var n4 = new TreeNode() { val = 4 };
            n0.left = n1;
            n0.right = n2;
            n1.left = n3;
            n2.right = n4;

            var b = IsBalanced(n0);
            var n5 = new TreeNode() { val = 5 };
            n2.left = n5;
            b = IsBalanced(n0);
            var n6 = new TreeNode() { val = 6 };
            n3.left = n6;
            b = IsBalanced(n0);
        }
        public static bool IsBalanced(TreeNode r)
        {
            return IsBalancedRec(r) != -1;
        }
        public static int IsBalancedRec(TreeNode n)
        {
            if (n == null) return 0;
            var l = IsBalancedRec(n.left);
            var r = IsBalancedRec(n.right);

            if (l == -1 || r == -1 || Math.Abs(l - r) > 1) return -1;
            return Math.Max(l, r) + 1;
        }
    }
}
