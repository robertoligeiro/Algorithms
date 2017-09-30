using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode45.Jump_Game_II
{
    class Program
    {
        //https://leetcode.com/problems/jump-game-ii/description/
        // it is time exceeding in leetcode. best algo is greedy, but I'm ok with this one.
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.Jump(new int[] { 2,3,1,1,4});
        }

        public class Solution
        {
            public int Jump(int[] nums)
            {
                var q1 = new Queue<int>();
                var q2 = new Queue<int>();
                var visited = new HashSet<int>();
                var count = 0;
                q1.Enqueue(0);
                while (q1.Count > 0 || q2.Count > 0)
                {
                    while (q1.Count > 0)
                    {
                        var v = q1.Dequeue();
                        if (v >= nums.Length - 1) return count;
                        for (int i = nums[v]; i > 0; --i)
                        {
                            var index = v + i;
                            if (visited.Add(index)) q2.Enqueue(index);
                        }
                    }
                    count++;
                    while (q2.Count > 0)
                    {
                        var v = q2.Dequeue();
                        if (v >= nums.Length - 1) return count;
                        for (int i = nums[v]; i > 0; --i)
                        {
                            var index = v + i;
                            if (visited.Add(index)) q1.Enqueue(index);
                        }
                    }
                    count++;
                }
                return 0;
            }
        }
    }
}
