using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode554.Brick_Wall
{
	//https://leetcode.com/problems/brick-wall/description/
	class Program
	{
		static void Main(string[] args)
		{
			var wall = new List<IList<int>>()
				{ new List<int>{1,2,2,1},
				new List<int>{3,1,2},
				new List<int>{1,3,2},
				new List<int>{2,4},
				new List<int>{3,1,2},
				new List<int>{1,3,1,1}};
			var s = new Solution();
			var r = s.LeastBricks(wall);
		}

		public class Solution
		{
			public int LeastBricks(IList<IList<int>> wall)
			{
				var intervalsCount = new Dictionary<int, int>();
				var minCrosses = int.MaxValue;
				foreach (var l in wall)
				{
					var acc = l.FirstOrDefault();
					for (int i = 1; i <= l.Count - 1; ++i)
					{
						var count = 0;
						if (intervalsCount.TryGetValue(acc, out count))
						{
							intervalsCount[acc] = ++count;
							var countCrosses = wall.Count - count;
							minCrosses = Math.Min(minCrosses, countCrosses);
						}
						else
						{
							intervalsCount.Add(acc, 1);
							minCrosses = Math.Min(minCrosses, wall.Count - 1);
						}
						acc += l[i];
					}
				}

				return minCrosses == int.MaxValue? wall.Count:minCrosses;
			}
		}
	}
}
