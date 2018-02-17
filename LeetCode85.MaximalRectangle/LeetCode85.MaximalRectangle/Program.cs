using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode85.MaximalRectangle
{
    class Program
    {
		//https://leetcode.com/problems/maximal-rectangle/description/
		static void Main(string[] args)
        {
            var s = new Solution();
            //var m = new char[5, 8]
            //    {
            //        {'1','1','1','1','1','1','1','1'},
            //        {'1','1','1','1','1','1','1','0'},
            //        {'1','1','1','1','1','1','1','0'},
            //        {'1','1','1','1','1','0','0','0'},
            //        {'0','1','1','1','1','0','0','0'}
            //    };
            var m = new char[4, 5]
            {
                {'1', '0', '1', '0', '0' },
                {'1', '0', '1', '1', '1'},
                {'1', '1', '1', '1', '1'},
                {'1', '0', '0', '1', '0'},
            };
            var r = s.MaximalRectangle(m);
        }

		public class Solution
		{
			public int MaximalRectangle(char[,] matrix)
			{
				var maxRect = 0;
				var hist = new int[matrix.GetLength(1)];
				for (int row = 0; row < matrix.GetLength(0); ++row)
				{
					for (int col = 0; col < matrix.GetLength(1); ++col)
					{
						if (matrix[row, col] == '1')
						{
							hist[col]++;
						}
						else
						{
							hist[col] = 0;
						}
					}
					var localMax = MaxRectangleInHist(hist);
					maxRect = Math.Max(maxRect, localMax);
				}
				return maxRect;
			}

			private int MaxRectangleInHist(int[] h)
			{
				var s = new Stack<int>();
				int i = 0;
				var localArea = 0;
				var maxArea = 0;
				while (i < h.Length)
				{
					if (s.Count == 0 || h[s.Peek()] <= h[i])
					{
						s.Push(i++);
					}
					else
					{
						while (s.Count > 0 && h[s.Peek()] > h[i])
						{
							var top = s.Pop();
							if (s.Count == 0)
							{
								localArea = h[top] * i;
								maxArea = Math.Max(maxArea, localArea);
							}
							else
							{
								localArea = h[top] * (i - s.Peek() - 1);
								maxArea = Math.Max(maxArea, localArea);
							}
						}
					}
				}
				while (s.Count > 0)
				{
					var top = s.Pop();
					if (s.Count == 0)
					{
						localArea = h[top] * i;
						maxArea = Math.Max(maxArea, localArea);
					}
					else
					{
						localArea = h[top] * (i - s.Peek() - 1);
						maxArea = Math.Max(maxArea, localArea);
					}
				}

				return maxArea;
			}
		}
		// old solution using graph walking, less efficient.
		//public class Solution
		//{
		//    public int MaximalRectangle(char[,] matrix)
		//    {
		//        var max = 0;
		//        for (int i = 0; i < matrix.GetLongLength(0); ++i)
		//        {
		//            for (int j= 0; j < matrix.GetLongLength(1); ++j)
		//            {
		//                if (matrix[i, j] == '1')
		//                {
		//                    var s = IsRectangleGetSize(matrix, i, j);
		//                    if (s > max) max = s;
		//                }
		//            }
		//        }

		//        return max;
		//    }

		//    public int IsRectangleGetSize(char[,] m, int r, int c)
		//    {
		//        var countW = 0;
		//        var countH = 0;
		//        var maxArea = 0;
		//        for (int i = r; i < m.GetLongLength(0); ++i)
		//        {
		//            var lw = 0;
		//            for (int j = c; j < m.GetLongLength(1); ++j)
		//            {
		//                if (m[i, j] == '1') lw++;
		//                else
		//                {
		//                    if (j == c) return maxArea;
		//                    break;
		//                }
		//            }
		//            if (countW == 0 || lw < countW)
		//            {
		//                countW = lw;
		//            }
		//            countH++;
		//            var localArea = countH * countW;
		//            maxArea = Math.Max(maxArea, localArea);
		//        }
		//        return maxArea;
		//    }
		//}
	}
}
