using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePickOneSumLeafsInTree
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class TreeNode
        {
             public int val;
             public TreeNode left;
             public TreeNode right;
             public TreeNode(int x) { val = x; }
        }

        public class Solution
        {
            public int SumNumbers(TreeNode root)
            {
                var leafs = new List<int>();
                GetSumToLeafs(root, 0, 0, leafs);
                var tot = 0;
                foreach (var i in leafs) tot += i;
                return tot;
            }

            public void GetSumToLeafs(TreeNode r, int acc, int mult, List<int> l)
            {
                if (r == null) return;

                var lAcc = acc * mult + r.val;
                if (r.left == null && r.right == null)
                {
                    l.Add(lAcc);
                    return;
                }
                mult = 10;
                if (r.left != null) GetSumToLeafs(r.left, lAcc, mult, l);
                if (r.right != null) GetSumToLeafs(r.right, lAcc, mult, l);
            }
        }
    }
}
