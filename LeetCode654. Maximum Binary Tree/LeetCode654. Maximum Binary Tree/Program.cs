using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode654.Maximum_Binary_Tree
{
    class Program
    {
        //https://leetcode.com/problems/maximum-binary-tree/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.ConstructMaximumBinaryTree(new int[] { 3, 2, 1, 6, 0, 5 });
        }

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        public class Solution
        {
            public TreeNode ConstructMaximumBinaryTree(int[] nums)
            {
                return ConstructMaximumBinaryTree(new List<int>(nums));
            }
            public TreeNode ConstructMaximumBinaryTree(List<int> nums)
            {
                if (nums == null || nums.Count == 0) return null;

                var index = nums.IndexOf(nums.Max());
                var n = new TreeNode(nums[index]);
                n.left = ConstructMaximumBinaryTree(nums.GetRange(0, index));
                n.right = ConstructMaximumBinaryTree(nums.GetRange(index + 1, nums.Count - index - 1));
                return n;
            }
        }
    }
}
