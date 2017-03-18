using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesIsSymetric
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
            var n2 = new TreeNode() { val = 1 };
            var n3 = new TreeNode() { val = 2 };
            var n4 = new TreeNode() { val = 2 };
            n0.left = n1;
            n0.right = n2;
            n1.left = n3;
            n2.right = n4;

            var b = IsSymetric(n0);
            var n5 = new TreeNode() { val = 5 };
            n2.left = n5;
            b = IsSymetric(n0);
            var n6 = new TreeNode() { val = 5 };
            n1.right = n6;
            b = IsSymetric(n0);
        }
        public static bool IsSymetric(TreeNode r)
        {
            if (r == null) return true;
            return IsSymetric(r.left, r.right);
        }
        public static bool IsSymetric(TreeNode l, TreeNode r)
        {
            if (l == null && r == null) return true;
            if ((l == null || r == null) || r.val != l.val) return false;
            return IsSymetric(l.left, r.right) && IsSymetric(l.right, r.left);
        }
    }
}
