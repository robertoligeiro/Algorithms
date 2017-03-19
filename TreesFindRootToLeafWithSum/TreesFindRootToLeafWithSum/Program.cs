using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesFindRootToLeafWithSum
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
            var n1 = new TreeNode() { val = 3 };
            var n2 = new TreeNode() { val = 5 };
            var n3 = new TreeNode() { val = 1 };
            var n4 = new TreeNode() { val = 2 };
            var n5 = new TreeNode() { val = 3 };
            n0.left = n1;
            n0.right = n2;
            n1.left = n3;
            n2.left = n4;
            n2.right = n5;
            var r = FindRootToLeafSum(n0, 8); //expected: true
            r = FindRootToLeafSum(n0, 15); //false;
        }

        public static bool FindRootToLeafSum(TreeNode r, int t)
        {
            return FindRootToLeafSum(r, t, 0);
        }
        public static bool FindRootToLeafSum(TreeNode r, int t, int p)
        {
            if (r == null) return false;
            var currSum = p + r.val;
            if (r.left == null && r.right == null) return currSum == t;
            return FindRootToLeafSum(r.left, t, currSum) || FindRootToLeafSum(r.right, t, currSum);
        }
    }
}
