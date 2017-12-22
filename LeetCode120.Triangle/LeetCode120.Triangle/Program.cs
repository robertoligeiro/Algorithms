using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode120.Triangle
{
    class Program
    {
        //https://leetcode.com/problems/triangle/#/description
        static void Main(string[] args)
        {
            //var triangle = new List<IList<int>>() { new List<int>() { 2 }, new List<int>() { 3, 4 }, new List<int>() { 6,5,1 } };
            var triangle = new List<IList<int>>() { new List<int>() { -1 }, new List<int>() { 3, 2 }, new List<int>() { 1, -2, -1 } };
            var s = new Solution();
            var r = s.MinimumTotal(triangle);
		}

		public class Solution
		{
			public int MinimumTotal(IList<IList<int>> triangle)
			{
				return MinimumTotal(triangle, new Dictionary<Tuple<int, int>, int>(), 0, 0);
			}

			private int MinimumTotal(IList<IList<int>> triangle, Dictionary<Tuple<int, int>, int> memo, int row, int col)
			{
				if (row == triangle.Count - 1) return triangle[row][col];
				var min = 0;
				var t = new Tuple<int, int>(row, col);
				if (memo.TryGetValue(t, out min)) return min;
				var left = MinimumTotal(triangle, memo, row + 1, col);
				var right = MinimumTotal(triangle, memo, row + 1, col + 1);
				min = triangle[row][col] + Math.Min(left,right);
				memo.Add(t, min);
				return min;
			}
		}
    }
}
