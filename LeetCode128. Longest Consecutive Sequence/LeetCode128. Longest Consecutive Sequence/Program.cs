using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode128.Longest_Consecutive_Sequence
{
	//https://leetcode.com/problems/longest-consecutive-sequence/description/
	class Program
	{
		static void Main(string[] args)
		{
		}
		public class Solution
		{
			public int LongestConsecutive(int[] nums)
			{
				var map = new HashSet<int>();
				foreach (var i in nums)
				{
					map.Add(i);
				}
				var max = 0;
				foreach (var i in nums)
				{
					//value is still in the map 
					if (map.Remove(i))
					{
						//check if positive and negative track are also in the map
						var localMax = 1;
						var seed = i;
						//remove from map so won't count the path again
						while (map.Remove(--seed)) localMax++;
						seed = i;
						while (map.Remove(++seed)) localMax++;
						max = Math.Max(localMax, max);
					}
				}
				return max;
			}
		}
	}
}
