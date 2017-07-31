using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode437.PathSumIII
{
    class Program
    {
        //https://leetcode.com/problems/path-sum-iii/description/
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
            public int PathSum(TreeNode root, int sum)
            {
                var treePath = new List<int>();
                var sumCount = 0;
                PathSum(root, sum, treePath, ref sumCount);
                return sumCount;
            }
            private void PathSum(TreeNode n, int sum, List<int> treePath, ref int sumCount)
            {
                if (n == null) return;
                treePath.Add(n.val);
                var localSum = 0;
                for (int i = treePath.Count - 1; i >= 0; --i)
                {
                    localSum += treePath[i];
                    if (localSum == sum)
                    {
                        sumCount++;
                    }
                }

                PathSum(n.left, sum, treePath, ref sumCount);
                PathSum(n.right, sum, treePath, ref sumCount);
                treePath.RemoveAt(treePath.Count - 1);
            }
        }
    }
}
