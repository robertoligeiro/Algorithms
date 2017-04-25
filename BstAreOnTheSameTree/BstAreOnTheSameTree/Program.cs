using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstAreOnTheSameTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = Insert(null, 19);
            //left tree
            Insert(root, 7);
            Insert(root, 3);
            //right
            Insert(root, 43);
            Insert(root, 23);
            Insert(root, 37);
            Insert(root, 29);
            Insert(root, 41);
            Insert(root, 31);
            Insert(root, 47);
            Insert(root, 53);

            var b = AreOnTheSameTree(GetNode(root, 19), GetNode(root, 23), GetNode(root, 37)); //true
            b = AreOnTheSameTree(GetNode(root, 43), GetNode(root, 23), GetNode(root, 31)); //true
            b = AreOnTheSameTree(GetNode(root, 43), GetNode(root, 23), GetNode(root, 53)); //false
            b = AreOnTheSameTree(GetNode(root, 23), GetNode(root, 23), GetNode(root, 37)); //false
            b = AreOnTheSameTree(GetNode(root, 19), GetNode(root, 7), GetNode(root, 3)); //true
            b = AreOnTheSameTree(GetNode(root, 19), GetNode(root, 7), GetNode(root, 23)); //false
            b = AreOnTheSameTree(GetNode(root, 19), GetNode(root, 3), GetNode(root, 7)); //false
        }

        public class TreeNode
        {
            public int val { get; set; }
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
        }

        public static bool AreOnTheSameTree(TreeNode anc, TreeNode mid, TreeNode des)
        {
            if (anc == null || mid == null || des == null ||
               anc == mid || mid == des || des == anc
                ) return false;
            return HasPath(anc, mid) && HasPath(mid, des);
        }

        public static bool HasPath(TreeNode n1, TreeNode n2)
        {
            if (n1 == null) return false;
            if (n1 == n2) return true;
            if (n1.val > n2.val) return HasPath(n1.left, n2);
            return HasPath(n1.right, n2);
        }

        public static TreeNode GetNode(TreeNode r, int val)
        {
            if (r == null) return null;
            if (r.val == val) return r;
            if (r.val > val) return GetNode(r.left, val);
            return GetNode(r.right, val);
        }
        public static TreeNode Insert(TreeNode r, int val)
        {
            if (r == null)
            {
                return new TreeNode() { val = val };
            }

            if (r.val == val) return r;
            if (r.val > val) r.left = Insert(r.left, val);
            else r.right = Insert(r.right, val);
            return r;
        }

    }
}
