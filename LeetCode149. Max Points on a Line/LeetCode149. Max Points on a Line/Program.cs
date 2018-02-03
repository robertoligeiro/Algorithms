using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode149.Max_Points_on_a_Line
{
	//https://leetcode.com/problems/max-points-on-a-line/description/
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.MaxPoints(new Point[] { new Point { x = 1, y = 1 },
				new Point { x = 2, y = 1 },
				new Point { x = 2, y = 2 },
				new Point { x = 3, y = 1 },
				new Point { x = 3, y = 3 },
				new Point { x = 4, y = 4 },
			});
		}
		public class Point {
			public int x;
			public int y;
			public Point() { x = 0; y = 0; }
			public Point(int a, int b) { x = a; y = b; }
		}
		public class Solution
		{
			public int MaxPoints(Point[] points)
			{
				var max = 0;
				for (int i = 0; i < points.Length; ++i)
				{
					var map = new Dictionary<decimal, int>();
					var infinite = 0;
					var samePoint = 1;
					for (int j = i + 1; j < points.Length; ++j)
					{
						if (points[i].x == points[j].x && points[i].y == points[j].y)
						{
							samePoint++;
						}
						else if (points[i].x == points[j].x)
						{
							infinite++;
						}
						else
						{
							decimal slope = ((decimal)points[i].y - points[j].y) / (points[i].x - points[j].x);
							var count = 0;
							if (map.TryGetValue(slope, out count))
							{
								map[slope] = ++count;
							}
							else map.Add(slope, 1);
						}
					}

					var localMax = 0;
					foreach (var t in map)
					{
						localMax = Math.Max(localMax, t.Value);
					}
					localMax = Math.Max(localMax, infinite);
					localMax += samePoint;
					max = Math.Max(max, localMax);
				}
				return max;
			}
		}
	}
}
