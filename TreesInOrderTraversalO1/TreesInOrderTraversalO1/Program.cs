using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesInOrderTraversalO1
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
            var r = InOrder(n0);
        }

        public static List<TreeNode> InOrder(TreeNode r)
        {
            var curr = r;
            TreeNode prev = null;
            var resp = new List<TreeNode>();
            while (curr != null)
            {
                TreeNode next = null;
                if (curr.parent == prev)
                {
                    if (curr.left != null)
                    {
                        next = curr.left;
                    }
                    else
                    {
                        resp.Add(curr);
                        next = curr.right != null ? curr.right : curr.parent;
                    }
                }
                else
                {
                    if (curr.left == prev)
                    {
                        resp.Add(curr);
                        next = curr.right != null ? curr.right : curr.parent;
                    }
                    else
                    {
                        next = curr.parent;
                    }
                }
                prev = curr;
                curr = next;
            }
            return resp;
        }
    }
}
