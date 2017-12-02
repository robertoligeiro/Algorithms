using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode646.Maximum_Length_of_Pair_Chain
{
	//https://leetcode.com/problems/maximum-length-of-pair-chain/description/
	class Program
	{
		static void Main(string[] args)
		{
		}
		public class Solution
		{
			public int FindLongestChain(int[,] pairs)
			{
				if (pairs == null || pairs.Length == 0) return 0;
				var pairsList = new List<Tuple<int, int>>();
				for (int i = 0; i < pairs.GetLength(0); ++i)
				{
					pairsList.Add(new Tuple<int, int>(pairs[i, 0], pairs[i, 1]));
				}
				pairsList.Sort(SortPairs);
				var curr = pairsList[0];
				var count = 1;
				for (int i = 0; i < pairsList.Count; ++i)
				{
					if (curr.Item2 < pairsList[i].Item1)
					{
						++count;
						curr = pairsList[i];
					}
				}
				return count;
			}

			public int SortPairs(Tuple<int, int> a, Tuple<int, int> b)
			{
				return a.Item2.CompareTo(b.Item2);
			}
		}
	}
}
