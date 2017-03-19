using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesFindPathWithSum
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
            var n0 = new TreeNode() { val = 1 };
            var n1 = new TreeNode() { val = 3 };
            var n2 = new TreeNode() { val = 5 };
            var n3 = new TreeNode() { val = 1 };
            var n4 = new TreeNode() { val = 2 };
            var n5 = new TreeNode() { val = 3 };
            n0.left = n1;
            n0.right = n2;
            n1.left = n3;
            n2.left = n4;
            n2.right = n5;
            var r = FindPathWithSum(n0, 8); //expected: n0, n2, n4
            r = FindPathWithSum(n0, 15); //null;
            r = FindPathWithSum(n0, 7); //n2, n4;
            r = FindPathWithSum(n0, 4); //n2, n4;
        }

        public static List<TreeNode> FindPathWithSum(TreeNode r, int t)
        {
            var path = new List<TreeNode>();
            return FindPathWithSum(r, t, path);
        }
        public static List<TreeNode> FindPathWithSum(TreeNode r, int t, List<TreeNode> path)
        {
            if (r == null) return null;
            var currPath = new List<TreeNode>(path);
            currPath.Add(r);
            int sum = 0;
            for (int i = currPath.Count - 1; i >= 0; --i)
            {
                sum += currPath[i].val;
                if (sum == t)
                {
                    return new List<TreeNode>(currPath.GetRange(i, currPath.Count - i));
                }
            }
            var response = FindPathWithSum(r.left, t, currPath);
            if (response != null) return response;
            return FindPathWithSum(r.right, t, currPath);
        }

    }
}
