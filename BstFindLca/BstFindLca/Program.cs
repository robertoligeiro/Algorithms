using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstFindLca
{
    class Program
    {
        static void Main(string[] args)
        {
            // balanced tree
            var n0 = new TreeNode() { val = 5 };
            var n1 = new TreeNode() { val = 3 };
            var n2 = new TreeNode() { val = 7 };
            var n3 = new TreeNode() { val = 1 };
            var n4 = new TreeNode() { val = 9 };
            n0.left = n1;
            n0.right = n2;
            n1.left = n3;
            n2.right = n4;

            var b = FindLca(n0, n0, n3); //n0
            b = FindLca(n0, n1, n2); //n0
            b = FindLca(n0, n2, n4); //n2 
            b = FindLca(n0, n4, n3); //n0
        }

        public class TreeNode
        {
            public int val { get; set; }
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
        }

        public static TreeNode FindLca(TreeNode r, TreeNode n1, TreeNode n2)
        {
            if (r == null || n1 == null || n2 == null) return null;
            if (r.val < n1.val && r.val < n2.val) return FindLca(r.right, n1, n2);
            if (r.val > n1.val && r.val > n2.val) return FindLca(r.left, n1, n2);
            return r;
        }
    }
}
