using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode167.Two_Sum_II_Inputarrayissorted
{
    //https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/description/
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.TwoSum(new int[] { 2,7,11,15}, 9);
        }
        public class Solution
        {
            public int[] TwoSum(int[] numbers, int target)
            {
                var l = 0;
                var r = numbers.Length - 1;
                while (l < r)
                {
                    var num = numbers[l] + numbers[r];
                    if (num == target) return new int[] { l+1, r+1 };
                    if (num > target) r--;
                    else l++;
                }
                return null;
            }
        }
    }
}
