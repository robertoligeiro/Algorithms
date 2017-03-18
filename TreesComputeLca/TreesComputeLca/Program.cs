using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesComputeLca
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
            var n5 = new TreeNode() { val = 5 };
            var n6 = new TreeNode() { val = 6 };
            n0.left = n1;
            n0.right = n2;
            n1.left = n3;
            n2.right = n4;
            var r = ComputeLca(n0, n3, n4); //n0
            r = ComputeLca(n0, n1, n3); // n1
            r = ComputeLca(n0, n0, n3); // n0
            r = ComputeLca(n0, n2, n4); // n2
            r = ComputeLca(n0, n0, n4); // n0
            r = ComputeLca(n0, n5, n4); // null
            n5.left = n6;
            n2.left = n5;
            r = ComputeLca(n0, n6, n2); // n2
            r = ComputeLca(n0, n6, n3); // n0
            r = ComputeLca(n0, n6, n4); // n2
        }

        public class Lca
        {
            public TreeNode parent { get; set; }
            public int found;
        }
        public static TreeNode ComputeLca(TreeNode r, TreeNode a, TreeNode b)
        {
            var lca = new Lca();
            lca = ComputeLca(r, a, b, lca);
            return lca.found == 2 ? lca.parent : null;
        }
        public static Lca ComputeLca(TreeNode n, TreeNode a, TreeNode b, Lca lca)
        {
            if (n == null) return lca;
            var initialFound = lca.found;
            if (n == a || n == b)
            {
                lca.found++;
                if (lca.found == 1) lca.parent = n;
                if (lca.found == 2) return lca;
            }

            lca = ComputeLca(n.left, a, b, lca);
            if (lca.found == 2) return lca;
            if (initialFound == 0 && lca.found == 1) lca.parent = n;
            return ComputeLca(n.right, a, b, lca); 
        }
    }
}
