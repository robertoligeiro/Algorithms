using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesFindKthInOrder
{
    class Program
    {
        public class TreeNode
        {
            public int val { get; set; }
            public int childs { get; set; }
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
        }
        static void Main(string[] args)
        {
            // balanced tree
            var n0 = new TreeNode() { val = 5, childs = 6 };
            var n1 = new TreeNode() { val = 3, childs = 2 };
            var n2 = new TreeNode() { val = 7, childs = 3 };
            var n3 = new TreeNode() { val = 1, childs = 1 };
            var n4 = new TreeNode() { val = 6, childs = 1 };
            var n5 = new TreeNode() { val = 8, childs = 1 };
            n0.left = n1;
            n0.right = n2;
            n1.left = n3;
            n2.left = n4;
            n2.right = n5;
            var r = FindKth(n0, 1); //expected: n3
            r = FindKth(n0, 2); // n1
            r = FindKth(n0, 3); //n0
            r = FindKth(n0, 4); //n4
            r = FindKth(n0, 5); //n2
            r = FindKth(n0, 6); //n5
            r = FindKth(n0, 7); //null
        }
        public static TreeNode FindKth(TreeNode r, int k)
        {
            if (r == null) return null;
            int leftChilds = r.left != null ? r.left.childs : 0;
            if (k == leftChilds + 1) return r;
            if (k <= leftChilds) return FindKth(r.left, k);
            return FindKth(r.right, k - (leftChilds + 1));
        }
    }
}
