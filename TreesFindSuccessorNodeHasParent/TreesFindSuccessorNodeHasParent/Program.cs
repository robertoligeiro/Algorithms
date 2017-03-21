using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesFindSuccessorNodeHasParent
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
            var r = SuccessorNode(n0); //expected: n4
            r = SuccessorNode(n1); // n0
            r = SuccessorNode(n2); //n5
            r = SuccessorNode(n3); //n1
            r = SuccessorNode(n4); //n2
            r = SuccessorNode(n5); //null
        }

        public static TreeNode SuccessorNode(TreeNode n)
        {
            if (n == null) return null;
            //if has right child, get left most from right
            if (n.right != null)
            {
                n = n.right;
                while(n.left != null)
                {
                    n = n.left;
                }
                return n;
            }

            //If it doesn't have r.child, get first parent from left tree
            while (n.parent != null && n.parent.left != n)
            {
                n = n.parent;
            }

            return n.parent;
        }
    }
}
