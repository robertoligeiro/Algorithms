using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesComputeRightSiblingCompleteTree
{
    class Program
    {
        public class TreeNode
        {
            public int val { get; set; }
            public TreeNode next { get; set; }
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
        }
        static void Main(string[] args)
        {
            // full tree
            var n0 = new TreeNode() { val = 5, };
            var n1 = new TreeNode() { val = 3,  };
            var n2 = new TreeNode() { val = 7,  };
            var n3 = new TreeNode() { val = 1,  };
            var n4 = new TreeNode() { val = 6,  };
            var n5 = new TreeNode() { val = 8,  };
            var n6 = new TreeNode() { val = 4, };
            n0.left = n1;
            n0.right = n2;
            n1.left = n3;
            n1.right = n6;
            n2.left = n4;
            n2.right = n5;

            ComputeSibling(n0);
        }

        public static void ComputeSibling(TreeNode n)
        {
            while (n != null && n.left != null)
            {
                FillSiblings(n);
                n = n.left;
            }
        }

        public static void FillSiblings(TreeNode n)
        {
            while (n != null)
            {
                n.left.next = n.right;
                if (n.next != null)
                {
                    n.right.next = n.next.left;
                }
                n = n.next;
            }
        }
    }
}
