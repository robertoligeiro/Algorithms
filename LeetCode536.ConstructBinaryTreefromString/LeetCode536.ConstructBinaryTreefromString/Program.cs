using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode536.ConstructBinaryTreefromString
{
	class Program
	{
		//https://leetcode.com/problems/construct-binary-tree-from-string/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.Str2tree("4(2(3)(1))(6(5))");
			//var r = s.Str2tree("4");
			//var r = s.Str2tree("4(2(3)(1))(6(5))");
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
			public TreeNode Str2tree(string s)
			{
				if (string.IsNullOrEmpty(s)) return null;
				var pos = 0;
				return Str2tree(s, ref pos);
			}

			private TreeNode Str2tree(string s, ref int pos)
			{
				var sb = new StringBuilder();
				var isNeg = false;
				if (s[pos] == '-')
				{
					++pos;
					isNeg = true;
				}
				while (pos < s.Length && char.IsDigit(s[pos]))
				{
					sb.Append(s[pos++]);
				}
				var v = int.Parse(sb.ToString());
				if (isNeg) v = -v;
				var n = new TreeNode(v);
				if (pos >= s.Length) return n;
				if (pos < s.Length && s[pos++] == ')')
				{
					return n;
				}
				n.left = Str2tree(s, ref pos);
				if (pos < s.Length && s[pos++] == '(')
				{
					n.right = Str2tree(s, ref pos);
					pos++;
				}
				return n;
			}
		}
	}
}
