using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode652.Find_Duplicate_Subtrees
{
	//https://leetcode.com/problems/find-duplicate-subtrees/description/
	class Program
	{
		static void Main(string[] args)
		{
			//var tree = new TreeNode(2) { left = new TreeNode(2) { left = new TreeNode(3)}, right = new TreeNode(2) { left = new TreeNode(3)} };
			var tree = new TreeNode(0) { left = new TreeNode(0) { left = new TreeNode(0) }, right = new TreeNode(0) { right = new TreeNode(0) { left = new TreeNode(0), right = new TreeNode(0)} } };
			var s = new Solution();
			var r = s.FindDuplicateSubtrees(tree);
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
			public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
			{
				var visited = new HashSet<string>();
				var added = new HashSet<string>();
				var resp = new List<TreeNode>();
				FindDuplicateSubtreesPostOrder(root, visited, added, resp);
				return resp;
			}

			private string FindDuplicateSubtreesPostOrder(TreeNode n, HashSet<string> visited, HashSet<string> added, List<TreeNode> resp)
			{
				if (n == null) return "#";
				var ret = n.val +
					FindDuplicateSubtreesPostOrder(n.left, visited, added, resp) +
					FindDuplicateSubtreesPostOrder(n.right, visited, added, resp);
				if(!visited.Add(ret))
				{
					if (added.Add(ret))
					{
						resp.Add(n);
					}
				}
				return ret;
			}
		}
	}
}
