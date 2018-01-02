using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode11.ContainerWithMostWater
{
	//https://leetcode.com/problems/container-with-most-water/#/description
	class Program
    {
        static void Main(string[] args)
        {
			var s = new Solution();

			var r = s.MaxArea(new int[] { 1, 4, 2, 5, 6, 2, 3 });
		}

		public class Solution
		{
			public int MaxArea(int[] height)
			{
				var max = 0;
				var i = 0;
				var j = height.Length - 1;
				while (i < j)
				{
					var area = Math.Min(height[i], height[j]) * (j - i);
					max = Math.Max(max, area);
					if (height[i] == height[j])
					{
						++i; --j;
					}
					else if (height[i] > height[j]) --j;
					else ++i;
				}
				return max;
			}
		}
    }
}
