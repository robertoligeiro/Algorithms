using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode42.TrappingRainWater
{
    class Program
    {
        //https://leetcode.com/problems/trapping-rain-water/#/description
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.Trap(new int[] { 0,1,0,2,1,0,1,3,2,1,2,1});
        }

        public class Solution
        {
            public int Trap(int[] height)
            {
                var resp = 0;
                var l = 0;
                var r = height.Length - 1;
                var maxL = 0;
                var maxR = 0;
                while (l <= r)
                {
                    if (height[l] <= height[r])
                    {
                        if (height[l] >= maxL) maxL = height[l];
                        else resp += (maxL - height[l]);
                        l++;
                    }
                    else
                    {
                        if (height[r] >= maxR) maxR = height[r];
                        else resp += (maxR - height[r]);
                        r--;
                    }
                }
                return resp;
            }
        }
    }
}
