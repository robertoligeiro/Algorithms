using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode218.The_Skyline_Problem
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.GetSkyline(new int[,] { { 2, 9 ,10 }, { 3 ,7, 15 }, { 5, 12 ,12 }, { 15 ,20 ,10 }, { 19 ,24, 8 } });
			//var r = s.GetSkyline(new int[,] { { 0, 2, 3 }, { 2, 5, 3 } });
			//var r = s.GetSkyline(new int[,] { { 1, 2, 1 }, { 1, 2, 2 }, { 1, 2, 3 } });
		}
		public class Solution
		{
			public class SkylinePoint
			{
				public int x;
				public int h;
				public bool isStart;
			}
			public IList<int[]> GetSkyline(int[,] buildings)
			{
				var points = new List<SkylinePoint>();
				for (int i = 0; i < buildings.GetLength(0); ++i)
				{
					var start = new SkylinePoint() { x = buildings[i, 0], h = buildings[i, 2], isStart = true };
					var end = new SkylinePoint() { x = buildings[i, 1], h = buildings[i, 2], isStart = false };
					points.Add(start);
					points.Add(end);
				}
				points.Sort(SortPoints);

				var sortedPoints = new List<int>();
				sortedPoints.Add(0);
				var resp = new List<int[]>();
				var currMax = 0;
				foreach (var p in points)
				{
					if (p.isStart)
					{
						sortedPoints.Add(p.h);
					}
					else
					{
						sortedPoints.Remove(p.h);
					}
					sortedPoints.Sort();
					if (sortedPoints.LastOrDefault() != currMax)
					{
						currMax = sortedPoints.LastOrDefault();
						resp.Add(new int[] { p.x, currMax });
					}
				}
				return resp;
			}

			private int SortPoints(SkylinePoint a, SkylinePoint b)
			{
				if (a.x.Equals(b.x))
				{
					if (a.isStart.Equals(b.isStart))
					{
						if(a.isStart == true) return b.h.CompareTo(a.h);
						return a.h.CompareTo(b.h);
					}
					return b.isStart.CompareTo(a.isStart);
				}
				return a.x.CompareTo(b.x);
			}
		}
	}
}
