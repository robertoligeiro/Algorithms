using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstFindFirstBiggerThanK
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

            var b = FindLargestkBookSol(n0, 1); //3
            var n5 = new TreeNode() { val = 8 };
            n4.left = n5;
            b = FindLargestkBookSol(n0, 5); //7
            b = FindLargestkBookSol(n0, 7); //8
            b = FindLargestkBookSol(n0, 8); //9;
            b = FindLargestkBookSol(n0, 9); //null;
        }
        public static TreeNode FindLargestKMySol(TreeNode r, int k)
        {
            var sparents = new Stack<TreeNode>();
            while (r != null)
            {
                if (r.val == k) break;
                sparents.Push(r);
                if (r.val > k) r = r.left;
                else r = r.right; 
            }

            if (r == null) return null;
            if (r.right != null) //left most child on right tree
            {
                r = r.right;
                while (r.left != null) r = r.left;
                return r;
            }
            while (sparents.Count > 0 && sparents.Peek().left != r)
            {
                r = sparents.Pop();
            }
            return sparents.Count > 0 ? sparents.Peek():null;
        }

        public static TreeNode FindLargestkBookSol(TreeNode r, int k)
        {
            TreeNode maxSoFar = null;
            while (r != null)
            {
                if (r.val > k)
                {
                    maxSoFar = r;
                    r = r.left;
                }
                else
                {
                    r = r.right;
                }
            }

            return maxSoFar;
        }
    }
}
