using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode448.FindAllNumbersDisappearedArray
{
    class Program
    {
        //https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.FindDisappearedNumbers(new int[] { 4,3,2,7,8,2,3,1});
            //var r = s.FindDisappearedNumbers(new int[] { 1, 1 });
        }

        public class Solution
        {
            public IList<int> FindDisappearedNumbers(int[] nums)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    //get the index since numbers are 1 - N
                    // do Math.Abs cause number could be seen before, hence it as marked negative
                    var index = Math.Abs(nums[i]) - 1;
                    if (nums[index] > 0)
                    {
                        nums[index] = -nums[index];
                    }
                }
                // resp = all numbers that are not negative
                var resp = new List<int>();
                for (int i = 0; i < nums.Length; ++i)
                {
                    if (nums[i] > 0) resp.Add(i + 1);
                }
                return resp;
            }
        }
    }
}
