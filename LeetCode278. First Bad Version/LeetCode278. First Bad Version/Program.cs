using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode278.First_Bad_Version
{
	class Program
	{
		//https://leetcode.com/problems/first-bad-version/
		static void Main(string[] args)
		{
		}

		public class Solution //: VersionControl
		{
			public bool IsBadVersion(int version)
			{
				return true;
			}
			public int FirstBadVersion(int n)
			{
				var l = 1;
				var r = n;
				while(l<=r)
				{
					var mid = l + (r - l) / 2;
					if (IsBadVersion(mid))
					{
						r = mid - 1;
					}
					else l = mid + 1;
				}
				if (r == 0) return 1;
				return r;
			}
		}
	}
}
