using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePatchingArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.MinPatches(new int[] { 1,2,2}, 5);
            //var r = s.MinPatches(new int[] { }, 8);
        }

        public class Solution
        {
            public int MinPatches(int[] nums, int n)
            {
                var sums = new HashSet<int>();
                GetCombinationSums(nums, sums, 0, 0);
                if (sums.Count == n) return 0;

                var countPatches = 0;
                for (int i = 1; i <= n; ++i)
                {
                    if (!sums.Contains(i))
                    {
                        countPatches++;
                        sums = AddPatch(sums, i);
                        sums.Add(i);
                        if (sums.Count == n) return countPatches;
                    }
                }
                return countPatches;
            }

            public HashSet<int> AddPatch(HashSet<int> h, int p)
            {
                var r = new HashSet<int>();
                foreach (var i in h)
                {
                    r.Add(i);
                    r.Add(i + p);
                }
                return r;
            }

            public void GetCombinationSums(int[] nums, HashSet<int> sums, int start, int curr)
            {
                if(curr != 0) sums.Add(curr);

                for (int i = start; i < nums.Length; ++i)
                {
                    curr += nums[i];
                    GetCombinationSums(nums, sums, i + 1, curr);
                    curr -= nums[i];
                }
            }
        }
    }
}
