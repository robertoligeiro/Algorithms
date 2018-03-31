using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode663.Equal_Tree_Partition
{
	class Program
	{
		//https://leetcode.com/problems/equal-tree-partition/description/
		static void Main(string[] args)
		{
			var t = new TreeNode(5) { left = new TreeNode(10), right = new TreeNode(10) { left = new TreeNode(2), right = new TreeNode(3) } };
			//var t = new TreeNode(0) { left = new TreeNode(-1), right = new TreeNode(1)};
			var s = new Solution();
			var r = s.CheckEqualTree(t);
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
			public bool CheckEqualTree(TreeNode root)
			{
				var v = new List<int>();
				var total =  CheckEqualTree(root, v);
				if (total % 2 != 0) return false;
				//remove last, root 
				v.RemoveAt(v.Count - 1);
				total /= 2;
				foreach (var i in v)
				{
					if (i == total) return true;
				}
				return false;
			}
			private int CheckEqualTree(TreeNode n, List<int> v)
			{
				if (n == null)
				{
					return 0;
				}
				var l = CheckEqualTree(n.left, v);
				var r = CheckEqualTree(n.right, v);
				var tVal = l + r + n.val;
				v.Add(tVal);
				return tVal;
			}
		}
	}
}
