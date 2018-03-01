using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode659.SplitArrayConsecutiveSubsequences
{
    class Program
    {
		//https://leetcode.com/problems/split-array-into-consecutive-subsequences/description/
		// solution is based from here: https://leetcode.com/problems/split-array-into-consecutive-subsequences/solution/
		static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.IsPossible(new int[] { 1, 2, 3, 3, 4, 4, 5, 5});
            //var r = s.IsPossible(new int[] { 1, 2, 3, 3, 4, 5 });
            //var r = s.IsPossible(new int[] { 1, 2, 3, 4, 4, 5 });
        }
        public class Solution
        {
            public bool IsPossible(int[] nums)
            {
				var counter = new Counter();
				var tails = new Counter();
				foreach (var i in nums)
				{
					counter.Add(i, 1);
				}

				foreach (var i in nums)
				{
					if (counter.Get(i) == 0)
					{
						continue;
					}
					else if (tails.Get(i) > 0)
					{
						tails.Add(i, -1);
						tails.Add(i + 1, 1);
					}
					else if (counter.Get(i + 1) > 0 && counter.Get(i + 2) > 0)
					{
						counter.Add(i + 1, -1);
						counter.Add(i + 2, -1);
						tails.Add(i + 3, 1);
					}
					else return false;
					counter.Add(i, -1);
				}
				return true;
            }

			public class Counter
			{
				private Dictionary<int, int> data = new Dictionary<int, int>();
				public int Get(int key)
				{
					if (data.ContainsKey(key)) return data[key];
					return 0;
				}

				public void Add(int k, int v)
				{
					var count = 0;
					if (data.TryGetValue(k, out count))
					{
						data[k] = (count + v);
					}
					else
					{
						data.Add(k, v);
					}
				}
			}
        }
    }
}
