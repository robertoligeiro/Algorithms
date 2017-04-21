using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstFindFirstOccurence
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
            var n0 = new TreeNode() { val = 5 };
            var n1 = new TreeNode() { val = 3 };
            var n2 = new TreeNode() { val = 7 };
            var n3 = new TreeNode() { val = 1 };
            var n4 = new TreeNode() { val = 7 };
            n0.left = n1;
            n0.right = n2;
            n1.left = n3;
            n2.right = n4;

            var b = FindFirst(n0, 7); //return n2

            var n5 = new TreeNode() { val = 7 };
            n2.left = n5;
            b = FindFirst(n0, 7); // return n5

            b = FindFirst(n0, 2); // null
        }
        public static TreeNode FindFirst(TreeNode r, int val)
        {
            if (r == null) return null;
            if (val > r.val) return FindFirst(r.right, val);
            if (val < r.val || (r.left != null && r.left.val == val)) return FindFirst(r.left, val);
            return r;
        }
    }
}
