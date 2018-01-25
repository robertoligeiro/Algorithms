using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode347.Top_K_Frequent_Elements
{
	class Program
	{
		//https://leetcode.com/problems/top-k-frequent-elements/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.TopKFrequent(new int[] { 1,1,1,2,2,3}, 2);
		}
		public class Solution
		{
			public IList<int> TopKFrequent(int[] nums, int k)
			{
				var map = new Dictionary<int, int>();
				foreach (var i in nums)
				{
					var count=0;
					if (map.TryGetValue(i, out count))
					{
						map[i] = ++count;
					}else map.Add(i, 1);
				}

				var buckets = new List<int>[nums.Length + 1];
				foreach (var t in map)
				{
					if (buckets[t.Value] == null)
					{
						buckets[t.Value] = new List<int>();
					}
					buckets[t.Value].Add(t.Key);
				}

				var resp = new List<int>();
				for (int i = buckets.Length - 1; i >= 0; --i)
				{
					if (buckets[i] != null)
					{
						foreach (var c in buckets[i])
						{
							resp.Add(c);
							if (resp.Count == k) return resp;
						}
					}
				}
				return resp;
			}
		}
	}
}
