using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode673.NumberofLongIncreasingSubsequence
{
	class Program
	{
		//https://leetcode.com/problems/number-of-longest-increasing-subsequence/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			//var r = s.FindNumberOfLIS(new int[] { 1,3,5,4,7});
			//var r = s.FindNumberOfLIS(new int[] { 2,2,2,2,2 });
			var r = s.FindNumberOfLIS(new int[] { 1, 2, 4, 3, 5, 4, 7, 2 });
		}

		public class IncSizeAndCounter
		{
			public int incSize;
			public int incCounter;
			public IncSizeAndCounter(int size, int counter)
			{
				incSize = size;
				incCounter = counter;
			}
		}
		public class Solution
		{
			public int FindNumberOfLIS(int[] nums)
			{
				if (nums == null || nums.Length == 0) return 0;
				if (nums.Length == 1) return 1;

				var incSeqCounter = new List<IncSizeAndCounter>();
				for (int i = 0; i < nums.Length; ++i)
				{
					incSeqCounter.Add(new IncSizeAndCounter(1, 1));
				}
				var index = 1;
				var maxInc = 0;
				var maxIncCounter = 0;
				while (index < nums.Length)
				{
					var runner = 0;
					while (runner < index)
					{
						if (nums[runner] < nums[index])
						{
							var runnerIncSize = incSeqCounter[runner].incSize;
							if (incSeqCounter[index].incSize < runnerIncSize + 1)
							{
								incSeqCounter[index].incSize = runnerIncSize + 1;
								incSeqCounter[index].incCounter = incSeqCounter[runner].incCounter;
							}else
							if (incSeqCounter[index].incSize == runnerIncSize + 1)
							{
								incSeqCounter[index].incCounter += incSeqCounter[runner].incCounter;
							}
						}
						runner++;
						maxInc = Math.Max(maxInc, incSeqCounter[index].incSize);
					}
					index++;
				}

				foreach (var incSizeAndCounter in incSeqCounter)
				{
					if (incSizeAndCounter.incSize == maxInc)
					{
						maxIncCounter += incSizeAndCounter.incCounter;
					}
				}
				return maxIncCounter;
			}
		}
	}
}
