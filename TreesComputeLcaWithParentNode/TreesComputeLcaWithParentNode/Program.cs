using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesComputeLcaWithParentNode
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
            var r = ComputeLca(n0, n5); //expected: n0
            r = ComputeLca(n4, n5); // n2
            r = ComputeLca(n4, n2); //n2
            r = ComputeLca(n3, n4); //n0
            r = ComputeLca(n1, n3); //n1
            r = ComputeLca(n4, n1); //n0
        }

        public static TreeNode ComputeLca(TreeNode a, TreeNode b)
        {
            var ha = ComputeH(a);
            var hb = ComputeH(b);
            var diff = Math.Abs(ha - hb);

            if (ha > hb) a = WalkUp(a, diff);
            else b = WalkUp(b, diff);
            while (a != null && b != null && a != b)
            {
                a = a.parent;
                b = b.parent;
            }

            return a == b ? a : null;
        }

        public static TreeNode WalkUp(TreeNode n, int l)
        {
            while (l-- > 0)
            {
                n = n.parent;
            }
            return n;
        }
        public static int ComputeH(TreeNode n)
        {
            var h = 0;
            while (n != null)
            {
                h++;
                n = n.parent;
            }
            return h;
        } 
    }
}
