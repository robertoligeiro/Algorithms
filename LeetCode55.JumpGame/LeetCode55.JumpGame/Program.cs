using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode55.JumpGame
{
    class Program
    {
        //https://leetcode.com/problems/jump-game/description/
        //non optimal - the optimal solution is greedy, see here: https://leetcode.com/problems/jump-game/solution/#approach-4-greedy-accepted 
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.CanJump(new int[] { 2,3,1,1,4});
            r = s.CanJump(new int[] { 3, 2, 1, 0, 4 });
        }
        public class Solution
        {
            public bool CanJump(int[] nums)
            {
				var maxReach = nums.Length - 1;
				for (int i = nums.Length - 1; i >= 0; --i)
				{
					if (nums[i] + i >= maxReach) maxReach = i;
				}
				return maxReach == 0;
            }
        }
    }
}
