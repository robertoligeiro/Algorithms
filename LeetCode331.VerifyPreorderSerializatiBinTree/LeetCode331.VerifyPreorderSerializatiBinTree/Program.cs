using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode331.VerifyPreorderSerializatiBinTree
{
	//https://leetcode.com/submissions/detail/130954960/
	class Program
	{
		static void Main(string[] args)
		{
			//my testcases
			//var s = new Solution();
			//var r = s.IsValidSerialization("1,2,4,#,#,#,3,#,#");
			//var r = s.IsValidSerialization("1,#,#,1");		
		}
		public class Solution
		{
			public bool IsValidSerialization(string preorder)
			{
				int pos = 0;
				var preOrderArray = preorder.Split(',');
				return IsValidSerialization(preOrderArray, ref pos) && pos == preOrderArray.Length - 1;
			}

			public bool IsValidSerialization(string[] preorder, ref int pos)
			{
				if (pos >= preorder.Length) return false;
				if (preorder[pos] == "#")
				{
					return true;
				}
				++pos;
				if (!IsValidSerialization(preorder, ref pos)) return false;
				++pos;
				return IsValidSerialization(preorder, ref pos);
			}
		}
	}
}
