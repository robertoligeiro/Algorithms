using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode165.Compare_Version_Numbers
{
	class Program
	{
		//https://leetcode.com/problems/compare-version-numbers/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.CompareVersion("1.1","1");
		}
		public class Solution
		{
			public int CompareVersion(string version1, string version2)
			{
				if (string.IsNullOrWhiteSpace(version1) && string.IsNullOrWhiteSpace(version2)) return 0;
				if (string.IsNullOrWhiteSpace(version1)) return -1;
				if (string.IsNullOrWhiteSpace(version2)) return 1;
				var v1 = version1.Split('.');
				var v2 = version2.Split('.');
				var i1 = 0;
				var i2 = 0;
				while (i1 < v1.Length || i2 < v2.Length)
				{
					if (i1 < v1.Length && i2 < v2.Length)
					{
						if (int.Parse(v1[i1]) > int.Parse(v2[i2])) return 1;
						if (int.Parse(v2[i2]) < int.Parse(v2[i2])) return -1;
						i1++;
						i2++;
					}
					else
					{
						if (i1 < v1.Length && int.Parse(v1[i1++]) != 0) return 1;
						if (i2 < v2.Length && int.Parse(v2[i2++]) != 0) return -1;
					}
				}
				return 0;
			}
		}
	}
}
