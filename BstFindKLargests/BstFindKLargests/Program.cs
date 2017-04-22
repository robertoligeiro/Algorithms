using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstFindKLargests
{
    class Program
    {
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

            var b = FindKLargests(n0, 0);
            b = FindKLargests(n0, 1);
            b = FindKLargests(n0, 2);
            b = FindKLargests(n0, 3);
            b = FindKLargests(n0, 4);
            b = FindKLargests(n0, 5);
        }

        public class TreeNode
        {
            public int val { get; set; }
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
        }

        public static List<TreeNode> FindKLargests(TreeNode r, int k)
        {
            var resp = new List<TreeNode>();
            GetLargestsK(r, resp, k);
            return resp;
        }

        public static void GetLargestsK(TreeNode r, List<TreeNode> resp, int k)
        {
            if (r == null || resp.Count == k) return;
            GetLargestsK(r.right, resp, k);
            if (resp.Count < k)
            {
                resp.Add(r);
            }
            GetLargestsK(r.left, resp, k);
        }
    }
}
