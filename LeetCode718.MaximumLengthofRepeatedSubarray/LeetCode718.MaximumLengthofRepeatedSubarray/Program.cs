using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode718.MaximumLengthofRepeatedSubarray
{
	//https://leetcode.com/problems/maximum-length-of-repeated-subarray/solution/
	//not passing in leetcode, time exceeded.
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.FindLength(new int[] { 1, 0, 1, 0, 0, 0, 0, 0, 1, 1 }, new int[] { 1, 1, 0, 1, 1, 0, 0, 0, 0, 0 });
		}
		public class Solution
		{
			public int FindLength(int[] A, int[] B)
			{
				List<int> smaller;
				List<int> bigger;
				if (A.Length > B.Length)
				{
					smaller = new List<int>(B);
					bigger = new List<int>(A);
				}
				else
				{
					smaller = new List<int>(A);
					bigger = new List<int>(B);
				}

				var hist = new Dictionary<int, List<int>>();
				GetArrayIndexes(bigger, hist);
				var index = 0;
				var resp = 0;
				while (index < smaller.Count)
				{
					List<int> l;
					if (hist.TryGetValue(smaller[index], out l))
					{
						var localResp = GetLenRepeated(smaller, index, bigger, l);
						resp = Math.Max(resp, localResp);
					}
					index++;
				}
				return resp;
			}

			private int GetLenRepeated(List<int> from, int indexFrom, List<int> toCompare, List<int> indexes)
			{
				var max = 0;
				var pathFound = new HashSet<int>();
				foreach (var index in indexes)
				{

					var fromIt = indexFrom;
					var toIt = index;
					while (fromIt < from.Count && toIt < toCompare.Count)
					{
						if ((from[fromIt] != toCompare[toIt]) || !pathFound.Add(toIt)) break;
						else
						{
							++fromIt;
							++toIt;
						}
						max = Math.Max(max, fromIt - indexFrom);
					}
				}
				return max;
			}

			private void GetArrayIndexes(List<int> a, Dictionary<int, List<int>> hist)
			{
				for(int i = 0; i < a.Count;++i)
				{
					List<int> l;
					if (hist.TryGetValue(a[i], out l))
					{
						l.Add(i);
					}
					else hist.Add(a[i], new List<int>() { i });
				}
			}
		}
	}
}
