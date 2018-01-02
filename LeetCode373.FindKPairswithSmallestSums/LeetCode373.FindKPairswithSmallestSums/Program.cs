using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode373.FindKPairswithSmallestSums
{
    class Program
    {
        //https://leetcode.com/problems/find-k-pairs-with-smallest-sums/tabs/description
        static void Main(string[] args)
        {
            var s = new Solution();

			var r = s.KSmallestPairs(new int[] { 1, 1, 2 }, new int[] { 1, 2, 3 }, 10);

			r = s.KSmallestPairs(new int[] {  }, new int[] {  }, 2);
        }

		public class Solution
		{
			public IList<int[]> KSmallestPairs(int[] nums1, int[] nums2, int k)
			{
				var resp = new List<int[]>();
				if (nums1.Length == 0 || nums2.Length == 0 || k <= 0) return resp;

				var sorted = new SortedDictionary<int, HashSet<Tuple<int, int>>>();
				sorted.Add(nums1[0] + nums2[0], new HashSet<Tuple<int, int>>() { new Tuple<int, int>(0, 0) });
				while (k-- > 0 && sorted.Count > 0)
				{
					var t = sorted.First();
					var indexes = t.Value.First();

					//clean-up
					t.Value.Remove(indexes);

					resp.Add(new int[] { nums1[indexes.Item1], nums2[indexes.Item2] });

					if (indexes.Item1 + 1 < nums1.Length)
					{
						var newindexes = new Tuple<int, int>(indexes.Item1 + 1, indexes.Item2);
						var val = nums1[newindexes.Item1] + nums2[newindexes.Item2];
						AddToSorted(sorted, val, newindexes);
					}

					if (indexes.Item2 + 1 < nums2.Length)
					{
						var newindexes = new Tuple<int, int>(indexes.Item1, indexes.Item2 + 1);
						var val = nums1[newindexes.Item1] + nums2[newindexes.Item2];
						AddToSorted(sorted, val, newindexes);
					}

					if (t.Value.Count == 0) sorted.Remove(t.Key);
				}
				return resp;
			}

			public void AddToSorted(SortedDictionary<int, HashSet<Tuple<int, int>>> s, int val, Tuple<int, int> t)
			{
				HashSet<Tuple<int, int>> h;
				if (s.TryGetValue(val, out h))
				{
					h.Add(t);
				}
				else
				{
					s.Add(val, new HashSet<Tuple<int, int>>() { t });
				}
			}
		}
    }
}
