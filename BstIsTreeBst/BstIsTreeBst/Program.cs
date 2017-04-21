using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstIsTreeBst
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
            var n4 = new TreeNode() { val = 9 };
            n0.left = n1;
            n0.right = n2;
            n1.left = n3;
            n2.right = n4;

            minSoFar = int.MinValue;
            var b = IsBst(n0); //true
            var n5 = new TreeNode() { val = 8 };
            n2.left = n5;

            minSoFar = int.MinValue;
            b = IsBst(n0); //false
            n5.val = 6 ;

            minSoFar = int.MinValue;
            b = IsBst(n0); //true;
        }
        public static int minSoFar = int.MinValue;
        public static bool IsBst(TreeNode r)
        {
            if (r == null) return true;
            if (IsBst(r.left))
            {
                if (r.val > minSoFar)
                {
                    minSoFar = r.val;
                    return IsBst(r.right);
                }
            }
            return false;
        }
    }
}
