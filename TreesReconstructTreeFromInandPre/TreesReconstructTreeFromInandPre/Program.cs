using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesReconstructTreeFromInandPre
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

            var ino = new List<int>() { 1, 3, 5, 6, 7, 8 };
            var pre = new List<int>() { 5, 3, 1, 7, 6, 8 };
            var r = ReconstructTree(ino, pre);
            var b = AreSame(r, n0);
        }

        public static TreeNode ReconstructTree(List<int> inO, List<int> pre)
        {
            if (inO.Count == 0) return null;
            var node = new TreeNode { val = pre[0] };
            var i = inO.FindIndex(x => x == pre[0]);
            pre.RemoveAt(0);
            var rightChilds = inO.Count - i - 1;
            var left = new List<int>(inO.GetRange(0, inO.Count - rightChilds -1));
            var right = new List<int>(inO.GetRange(i + 1, rightChilds));
            node.left = ReconstructTree(left, pre);
            node.right = ReconstructTree(right, pre);
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
