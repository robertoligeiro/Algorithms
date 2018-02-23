using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode632.Smallest_Range
{
	class Program
	{
		//https://leetcode.com/problems/smallest-range/description/
		static void Main(string[] args)
		{
			var i = new List<IList<int>>()
			{
				new List<int>() { 4, 10, 15, 24, 26 },
				new List<int>() { 0, 9, 12, 20 },
				new List<int>() { 5, 18, 22, 30 }
			};
			var s = new Solution();
			var r = s.SmallestRange(i);
		}
		public class Solution
		{
			public int[] SmallestRange(IList<IList<int>> nums)
			{
				var resp = new int[2];
				if (nums == null || nums.Count == 0) return resp;
				//var itemsRange = new List<Tuple<int, int>>();
				var itemsRange = new SortedDictionary<int, Queue<int>>();
				for (int i = 0; i < nums.Count; ++i)
				{
					Queue<int> q;
					if (itemsRange.TryGetValue(nums[i][0], out q))
					{
						q.Enqueue(i);
					}
					else
					{
						q = new Queue<int>();
						q.Enqueue(i);
						itemsRange.Add(nums[i][0], q);
					} 
					nums[i].RemoveAt(0);
				}
				var minRange = int.MaxValue;
				while (true)
				{
					var currRange = itemsRange.Last().Key - itemsRange.First().Key;
					if (currRange < minRange)
					{
						minRange = currRange;
						resp[0] = itemsRange.First().Key;
						resp[1] = itemsRange.Last().Key;
					}
					var toRemove = itemsRange.First();
					var indexToRemove = toRemove.Value.Dequeue();
					if (toRemove.Value.Count == 0)
					{
						itemsRange.Remove(toRemove.Key);
					}
					if (nums[indexToRemove].Count == 0) break;
					else
					{
						Queue<int> q;
						if (itemsRange.TryGetValue(nums[indexToRemove][0], out q))
						{
							q.Enqueue(indexToRemove);
						}
						else
						{
							q = new Queue<int>();
							q.Enqueue(indexToRemove);
							itemsRange.Add(nums[indexToRemove][0], q);
						}

						nums[indexToRemove].RemoveAt(0);
					}
				}
				return resp;
			}
		}
	}
}
