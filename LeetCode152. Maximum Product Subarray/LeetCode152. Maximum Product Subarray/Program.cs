using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode152.Maximum_Product_Subarray
{
	//https://leetcode.com/problems/maximum-product-subarray/description/
	class Program
	{
		static void Main(string[] args)
		{
		}
		public class Solution
		{
			public int MaxProduct(int[] nums)
			{
				var maxSoFar = nums[0];
				var maxHerePre = 0;
				var minHerePre = 0;
				var maxHere = nums[0];
				var minHere = nums[0];
				for (int i = 1; i < nums.Length; ++i)
				{
					maxHerePre = Math.Max(nums[i], Math.Max(maxHere * nums[i], minHere * nums[i]));
					minHerePre = Math.Min(nums[i], Math.Min(minHere * nums[i], maxHere * nums[i]));
					maxHere = maxHerePre;
					minHere = minHerePre;
					maxSoFar = Math.Max(maxSoFar, maxHere);
				}
				return maxSoFar;
			}
		}
	}
}
