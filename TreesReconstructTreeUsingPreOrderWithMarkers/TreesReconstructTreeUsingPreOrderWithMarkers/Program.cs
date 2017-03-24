using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesReconstructTreeUsingPreOrderWithMarkers
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

            var pre = new LinkedList<int>();
            var values = new List<int>() { 5, 3, 1, -1, -1, -1, 7, 6, -1, -1, 8, -1, -1 };
            foreach (var i in values) pre.AddLast(i);
            var r = ReconstructTree(pre);
            var b = AreSame(r, n0);
        }
        public static TreeNode ReconstructTree(LinkedList<int> pre)
        {
            if (pre.Count == 0) return null;
            var v = pre.First();
            pre.RemoveFirst();
            if(v == -1) return null;
            var node = new TreeNode { val = v };
            node.left = ReconstructTree(pre);
            node.right = ReconstructTree(pre);
            return node;
        }
        public static bool AreSame(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null) return true;
            if ((t1 == null && t2 != null) || (t1 != null && t2 == null)) return false;
            if (t1.val != t2.val) return false;
            if (!AreSame(t1.left, t2.left)) return false;
            if (!AreSame(t1.right, t2.right)) return false;
            return true;
        }

    }
}
