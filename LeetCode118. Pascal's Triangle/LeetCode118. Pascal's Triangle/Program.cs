using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode118.Pascal_s_Triangle
{
	class Program
	{
		//https://leetcode.com/problems/pascals-triangle/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.Generate(5);
		}
		public class Solution
		{
			public IList<IList<int>> Generate(int numRows)
			{
				if (numRows == 0) return new List<IList<int>>();
				var resp = new List<IList<int>>() { new List<int>() { 1 } };
				while (--numRows > 0)
				{
					AddLine(resp);
				}
				return resp;
			}
			private void AddLine(IList<IList<int>> p)
			{
				var last = p.Last();
				var newLine = new List<int>();
				for (int i = 0; i <= last.Count; ++i)
				{
					if (i == 0 || i == last.Count)
					{
						newLine.Add(1);
					}
					else
					{
						newLine.Add(last[i] + last[i - 1]);
					}
				}
				p.Add(newLine);
			}
		}
	}
}
