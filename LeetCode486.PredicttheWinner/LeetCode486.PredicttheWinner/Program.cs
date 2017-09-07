using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode486.PredicttheWinner
{
    class Program
    {
        //https://leetcode.com/problems/predict-the-winner/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.PredictTheWinner(new int[] {1,5,8,4 });
        }
        public class Solution
        {
            public bool PredictTheWinner(int[] nums)
            {
                return PredictTheWinner(nums, 0, nums.Length - 1, 1) >= 0;
            }

            private int PredictTheWinner(int[] nums, int start, int end, int turn)
            {
                if (start == end) return turn * nums[start];

                var getStart = (turn * nums[start]) + PredictTheWinner(nums, start + 1, end, -turn);
                var getEnd = (turn * nums[end]) + PredictTheWinner(nums, start, end - 1, -turn);

                if (turn == 1) return Math.Max(getStart, getEnd);
                return Math.Min(getStart, getEnd);
            }
        }
    }
}
