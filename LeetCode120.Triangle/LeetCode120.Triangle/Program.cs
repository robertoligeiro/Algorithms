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
                return GetMinPath(triangle, 0, 0, 0, new Dictionary<Tuple<int,int>, int>());
            }

            public int GetMinPath(IList<IList<int>> triangle, int row, int col, int acc, Dictionary<Tuple<int,int>, int> m)
            {
                if (row == triangle.Count || col == triangle[row].Count) return 0;
                var left = new Tuple<int, int>(row + 1, col);
                var right = new Tuple<int, int>(row + 1, col+1);
                var leftVal = 0;
                if (!m.TryGetValue(left, out leftVal))
                {
                    leftVal = GetMinPath(triangle, left.Item1, left.Item2, acc, m);
                }
                var rightVal = 0;
                if (!m.TryGetValue(right, out rightVal))
                {
                    rightVal = GetMinPath(triangle, right.Item1, right.Item2, acc, m);
                }

                acc += triangle[row][col] + Math.Min(leftVal, rightVal);
                m.Add(new Tuple<int, int>(row, col), acc);
                return acc;
            }
        }
    }
}
