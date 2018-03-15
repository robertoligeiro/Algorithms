using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/next-permutation/#/description
//A simple algorithm from Wikipedia with C++ implementation(can be used in Permutations and Permutations II)
//Well, in fact the problem of next permutation has been studied long ago.From the Wikipedia page, in the 14th century, a man named Narayana Pandita gives the following classic and yet quite simple algorithm (with minor modifications in notations to fit the problem statement):

//Find the largest index k such that nums[k] < nums[k + 1]. If no such index exists, the permutation is sorted in descending order, just reverse it to ascending order and we are done.For example, the next permutation of[3, 2, 1] is [1, 2, 3].
//Find the largest index l greater than k such that nums[k] < nums[l].
//Swap the value of nums[k] with that of nums[l].
//Reverse the sequence from nums[k + 1] up to and including the final element nums[nums.size() - 1].
namespace LeetCode31.NextPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
			var a = new int[] { 1, 3, 2 };
			s.NextPermutation(a);
			a = new int[] { 1, 1, 5 };
			s.NextPermutation(a);
			a = new int[] { 1, 3, 2, 1 };
			s.NextPermutation(a);
			a = new int[] { 3, 2, 1 };
			s.NextPermutation(a);
			a = new int[] { 1, 1 };
			s.NextPermutation(a);
		}
		public class Solution
        {
            public void NextPermutation(int[] nums)
            {
				if (nums == null) return;
				var i = nums.Length-2;
				while (i >= 0)
				{
					if (nums[i] < nums[i + 1]) { break; }
					--i;
				}
				Array.Reverse(nums, i + 1, nums.Length - i - 1);
				if (i == -1) return;
				var temp = nums[i];
				var j = i + 1;
				while (j < nums.Length && nums[j] <= temp) { ++j; }
				nums[i] = nums[j];
				nums[j] = temp;
            }
        }
    }
}
