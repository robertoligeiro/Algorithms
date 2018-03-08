using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode169.Majority_Element
{
	class Program
	{
		//https://leetcode.com/problems/majority-element/description/
		static void Main(string[] args)
		{
		}

		public class Solution
		{
			public int MajorityElement(int[] nums)
			{
				int countMaj = 1;
				int majEle = nums[0];
				for (int i = 1; i < nums.Length; i++)
				{
					if (nums[i] == majEle)
					{
						countMaj++;
						continue;
					}

					if (countMaj-- <= 0)
					{
						majEle = nums[i];
						countMaj = 1;
					}
				}

				return majEle;
			}
		}
	}
}
