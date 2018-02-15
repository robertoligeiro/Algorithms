using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode750.Number_Of_Corner_Rectangles
{
	class Program
	{
		//https://leetcode.com/problems/number-of-corner-rectangles/description/
		static void Main(string[] args)
		{
			var g = new int[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
			var s = new Solution();
			var r = s.CountCornerRectangles(g);
		}
		public class Solution
		{
			public int CountCornerRectangles(int[,] grid)
			{
				var map = new Dictionary<Tuple<int, int>, int>();
				var resp = 0;
				for (int row = 0; row < grid.GetLength(0); ++row)
				{
					for (int col1 = 0; col1 < grid.GetLength(1); ++col1)
					{
						if (grid[row, col1] == 1)
						{
							for (int col2 = col1 + 1; col2 < grid.GetLength(1); ++col2)
							{
								if (grid[row, col2] == 1)
								{
									var t = new Tuple<int, int>(col1, col2);
									var count = 0;
									if (map.TryGetValue(t, out count))
									{
										resp += count;
										map[t] = ++count;
									}
									else
									{
										map.Add(t, 1);
									}
								}
							}
						}
					}
				}
				return resp;
			}
		}
	}
}
