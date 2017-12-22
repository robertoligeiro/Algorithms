using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode628.MaximumProductofThreeNumbers
{
	//https://leetcode.com/problems/maximum-product-of-three-numbers/#/description
	class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
			var ss = new SolutionNew();
			//var r = s.MaximumProduct(new int[] { -2, 4, -1, -10, 1, 2, -20, 3, -10 });
			//var rr = ss.MaximumProduct(new int[] { -2, 4, -1, -10, 1, 2, -20, 3, -10 });
			var r = s.MaximumProduct(new int[] { -4,-3,-2,-1,60 });
			//var rr = ss.MaximumProduct(new int[] { -4, -3, -2, -1, 60 });
			//var rr = ss.MaximumProduct(new int[] { -1,-2,-3});
			var rr = ss.MaximumProduct(new int[] { 1000, 1000, 0 });
			//var rr = ss.MaximumProduct(new int[] { 1,2,3 });
			//var r = s.MaximumProduct(new int[] { 0,0,0 });
		}

		public class SolutionNew
		{
			public int MaximumProduct(int[] nums)
			{
				var max = new List<int>();
				var min = new List<int>();
				foreach (var i in nums)
				{
					if (max.Count < 3)
					{
						max.Add(i);
						min.Add(i);
						max.Sort((a, b) => -1 * a.CompareTo(b));
						min.Sort();
						continue;
					}
					max.Sort((a, b) => -1 * a.CompareTo(b));
					min.Sort();
					if (i > max[2]) max[2] = i;
					if (i < min[2]) min[2] = i;
				}
				var maxMin = 0;
				maxMin = min[0] * min[1] * max.Max();
				return Math.Max(max.Aggregate(1, (acc, val) => acc * val), maxMin);
			}
		}
		public class Solution
        {
            public int MaximumProduct(int[] nums)
            {
                var min = new SortedList<int,int>();
                var max = new SortedList<int,int>();
                foreach (var i in nums)
                {
                    var count = 0;
                    if (min.TryGetValue(i, out count))
                    {
                        min[i] = ++count;
                    }
                    else if (min.Count < 2) min.Add(i,1);
                    else if (min.Last().Key > i)
                    {
                        min.Remove(min.Last().Key);
                        min.Add(i,1);
                    }

                    if (max.TryGetValue(i, out count))
                    {
                        max[i] = ++count;
                    }
                    else if (max.Count < 3) max.Add(i,1);
                    else if (max.First().Key < i)
                    {
                        max.Remove(max.First().Key);
                        max.Add(i,1);
                    }
                }

                var maxList = new List<int>();
                foreach (var t in max)
                {
                    maxList.AddRange(Enumerable.Repeat(t.Key, t.Value));
                }
                maxList.RemoveRange(0, maxList.Count - 3);
                var minList = new List<int>();
                foreach (var t in min)
                {
                    minList.AddRange(Enumerable.Repeat(t.Key, t.Value));
                }

                return Math.Max(minList[0] * minList[1] * maxList[2],
                    maxList[0] * maxList[1] * maxList[2]);
            }
        }
    }
}
