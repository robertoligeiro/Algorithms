using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode89.Gray_Code
{
	class Program
	{
		//https://leetcode.com/problems/gray-code/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.GrayCode(2);
		}

		public class Solution
		{
			public IList<int> GrayCode(int n)
			{
				var resp = new List<int>();
				resp.Add(0);
				for (int i = 0; i < n; ++i)
				{
					var size = resp.Count-1;
					for (; size >= 0; size--)
					{
						var v = resp[size] | 1 << i;
						resp.Add(v);
					}
				}
				return resp;
			}
		}
	}
}
