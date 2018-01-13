using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode42.Trapping_Rain_Water
{
	//https://leetcode.com/problems/trapping-rain-water/description/
	class Program
	{
		static void Main(string[] args)
		{
		}
		public class Solution
		{
			public int Trap(int[] height)
			{
				var maxL = 0;
				var maxR = 0;
				var l = 0;
				var r = height.Length - 1;
				var resp = 0;
				while (l <= r)
				{
					if (height[l] <= height[r])
					{
						if (height[l] >= maxL) maxL = height[l];
						else resp += maxL - height[l];
						l++;
					}
					else
					{
						if (height[r] >= maxR) maxR = height[r];
						else resp += maxR - height[r];
						r--;
					}
				}
				return resp;
			}
		}
	}
}
