using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode108.ConvertSortedArraytoBinSearchTree
{
	class Program
	{
		//https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/description/
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
			public TreeNode SortedArrayToBST(int[] nums)
			{
				if (nums == null || nums.Length == 0) return null;
				return SortedArrayToBST(nums, 0, nums.Length - 1);
			}

			private TreeNode SortedArrayToBST(int[] nums, int l, int r)
			{
				if (l > r) return null;
				var mid = l + (r - l) / 2;
				var n = new TreeNode(nums[mid]);
				n.left = SortedArrayToBST(nums, l, mid - 1);
				n.right = SortedArrayToBST(nums, mid + 1, r);
				return n;
			}
		}
	}
}
