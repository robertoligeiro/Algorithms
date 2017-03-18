using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesSumRootToLeafBinaryTree
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
            var n0 = new TreeNode() { val = 1 };
            var n1 = new TreeNode() { val = 0 };
            var n2 = new TreeNode() { val = 1 };
            var n3 = new TreeNode() { val = 1 };
            var n4 = new TreeNode() { val = 0 };
            var n5 = new TreeNode() { val = 1 };
            n0.left = n1;
            n0.right = n2;
            n1.left = n3;
            n2.left = n4;
            n2.right = n5;
            var r = SumBinaryTree(n0);
        }

        public static int SumBinaryTree(TreeNode r)
        {
            return SumBinaryTree(r, 0);
        }
        public static int SumBinaryTree(TreeNode n, int parc)
        {
            if (n == null) return 0;
            var sum = parc * 2 + n.val;
            if (n.left == null && n.right == null) return sum;
            return SumBinaryTree(n.left, sum) + SumBinaryTree(n.right, sum);
        }
    }
}
