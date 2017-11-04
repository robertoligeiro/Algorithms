using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode447.Number_of_Boomerangs
{
	class Program
	{
		//https://leetcode.com/problems/number-of-boomerangs/description/
		static void Main(string[] args)
		{
		}

		public class Solution
		{
			public int NumberOfBoomerangs(int[,] points)
			{
				var n = points.GetLength(0);
				var count = 0;
				for (int i = 0; i < n; ++i)
				{
					var map = new Dictionary<int, int>();
					for (int j = 0; j < n; ++j)
					{
						if (i == j) continue;
						var dist = (points[i, 0] - points[j, 0]) * (points[i, 0] - points[j, 0]) 
							+ (points[i, 1] - points[j, 1]) * (points[i, 1] - points[j, 1]);
						var v = 0;
						if (map.TryGetValue(dist, out v)) map[dist] = ++v;
						else map.Add(dist, 0);
					}
					foreach (var v in map.Values)
					{
						count += v*(v + 1);
					}
				}
				return count;
			}
		}
	}
}
