using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode11.ContainerWithMostWater
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public class Solution
        {
            //https://leetcode.com/problems/container-with-most-water/#/description
            public int MaxArea(int[] height)
            {
                var max = 0;
                var dist = height.Length - 1;
                var left = 0;
                var right = height.Length - 1;
                while (left < right)
                {
                    if (height[left] == height[right])
                    {
                        max = Math.Max(max, height[left] * dist);
                        left++;
                        right--;
                        dist -= 2;
                    }
                    else if (height[left] > height[right])
                    {
                        max = Math.Max(max, height[right] * dist);
                        right--;
                        dist--;
                    }
                    else
                    {
                        max = Math.Max(max, height[left] * dist);
                        left++;
                        dist--;
                    }
                }
                return max;
            }
        }
    }
}
