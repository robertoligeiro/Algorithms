using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode46.Permutations
{
    //https://leetcode.com/problems/permutations/description/
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.Permute(new int[] { 1, 2, 3 });
        }
        public class Solution
        {
            public IList<IList<int>> Permute(int[] nums)
            {
                var counters = Enumerable.Repeat(1, nums.Length).ToList();
                var parc = new List<int>();
                var resp = new List<IList<int>>();
                Permute(nums, counters, parc, resp);
                return resp;
            }
            private void Permute(int[] nums, List<int> counters, List<int> parc, List<IList<int>> resp)
            {
                if (parc.Count == nums.Length)
                {
                    resp.Add(new List<int>(parc));
                    return;
                }

                for (int i = 0; i < counters.Count; ++i)
                {
                    if (counters[i] == 1)
                    {
                        counters[i] = 0;
                        parc.Add(nums[i]);
                        Permute(nums, counters, parc, resp);
                        counters[i] = 1;
                        parc.RemoveAt(parc.Count - 1);
                    }
                }
            }
        }
    }
}
