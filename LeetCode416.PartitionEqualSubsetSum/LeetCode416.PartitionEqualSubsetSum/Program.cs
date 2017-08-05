using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode416.PartitionEqualSubsetSum
{
    class Program
    {
        //https://leetcode.com/submissions/detail/112647069/
        // my version is non optimal, best solution is DP similar to knapsack
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.CanPartition(new int[] { 2, 5, 11, 5 }); //false
            r = s.CanPartition(new int[] { 1, 5, 11, 5 }); //true
            r = s.CanPartition(new int[] { 1, 1, 1, 1 }); //true
            r = s.CanPartition(new int[] { 1, 2, 3, 4, 5, 6, 7 }); //true
        }
        public class Solution
        {
            public bool CanPartition(int[] nums)
            {
                var targetValue = 0;
                foreach (var i in nums)
                {
                    targetValue += i;
                }
                if (targetValue % 2 != 0) return false;
                var numsList = new List<int>(nums);
                targetValue/= 2;
                var resp = GetCombination(numsList, targetValue);
                foreach (var d in resp)
                {
                    var sum = 0;
                    foreach (var i in nums)
                    {
                        var count = 0;
                        if (!d.TryGetValue(i, out count)) sum += i;
                        else
                        {
                            if (--count == 0) d.Remove(i);
                            else d[i] = count;
                        }
                        if (sum > targetValue) break;
                    }
                    if (sum == targetValue) return true;
                }
                return false;
            }

            public List<Dictionary<int, int>> GetCombination(List<int> nums, int targetValue)
            {
                nums.Sort();
                var resp = new List<Dictionary<int, int>>();
                var parc = new Dictionary<int, int>();
                GetCombination(nums, 0, 0, targetValue, resp, parc);
                return resp;
            }

            public void GetCombination(List<int> nums, int index, int sum, int target, List<Dictionary<int, int>> resp, Dictionary<int, int> parc)
            {
                if (sum == target)
                {
                    resp.Add(new Dictionary<int, int>(parc));
                }
                if (index >= nums.Count || sum > target) return;

                for (int i = index; i < nums.Count; ++i)
                {
                    var count = 0;
                    if(parc.TryGetValue(nums[i], out count))
                    {
                        parc[nums[i]] = ++count;
                    }
                    else parc.Add(nums[i],1);
                    sum += nums[i];
                    GetCombination(nums, i + 1, sum, target, resp, parc);
                    if (--parc[nums[i]] == 0) parc.Remove(nums[i]);
                    sum -= nums[i];
                }
            }
        }
    }
}
