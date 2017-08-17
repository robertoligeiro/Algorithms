using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode95.Unique_Binary_Search_Trees_II
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.GenerateTrees(3);
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
            public IList<TreeNode> GenerateTrees(int n)
            {
                if (n== 0) return new List<TreeNode>();
                var roots = Enumerable.Range(1, n).ToList();
                return GenerateTrees(roots);
            }

            private List<TreeNode> GenerateTrees(List<int> roots)
            {
                var resp = new List<TreeNode>();
                if (roots.Count == 0)
                {
                    resp.Add(new TreeNode(-1));
                    return resp;
                }

                for (int i = 0; i < roots.Count; ++i)
                {
                    List<int> left = new List<int>();
                    if (i > 0) left = roots.GetRange(0, i);
                    List<int> right = new List<int>();
                    if (i < roots.Count - 1) right = roots.GetRange(i + 1, roots.Count - i - 1);
                    GenerateTrees(roots[i], left, right, resp);
                }

                return resp;
            }
            private void GenerateTrees(int i, List<int> left, List<int> right, List<TreeNode> resp)
            {
                List<TreeNode> leftTrees = GenerateTrees(left);
                List<TreeNode> rightTrees = GenerateTrees(right);
                foreach (var leftRoot in leftTrees)
                {
                    foreach (var rightRoot in rightTrees)
                    {
                        var root = new TreeNode(i);
                        root.left = leftRoot.val == -1 ? null : leftRoot;
                        root.right = rightRoot.val == -1 ? null: rightRoot;
                        resp.Add(root);
                    }
                }
            }
        }
    }
}
