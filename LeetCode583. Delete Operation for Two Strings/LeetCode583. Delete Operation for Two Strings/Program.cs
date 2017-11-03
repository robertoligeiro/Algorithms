using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode583.Delete_Operation_for_Two_Strings
{
	class Program
	{
		//https://leetcode.com/problems/delete-operation-for-two-strings/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.MinDistance("sea", "eat");
			//var r = s.MinDistance("ab", "a");
		}

		//optimal: from here https://leetcode.com/problems/delete-operation-for-two-strings/solution/ #2
		public class Solution
		{
			public int MinDistance(string a, string b)
			{
				if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
				{
					if (string.IsNullOrEmpty(a)) return b.Length;
					return a.Length;
				}
				var memo = new int[a.Length + 1, b.Length + 1];
				return a.Length + b.Length - 2 * LongestCommonSubsequence(a, b, a.Length, b.Length, memo);
			}

			public static int LongestCommonSubsequence(string a, string b, int sizeA, int sizeB, int[,] memo)
			{
				if (sizeA == 0 || sizeB == 0) return 0;
				if(memo[sizeA, sizeB] != 0) return memo[sizeA, sizeB];
				if (a[sizeA-1] == b[sizeB-1])
				{
					memo[sizeA, sizeB] = LongestCommonSubsequence(a, b, sizeA - 1, sizeB - 1, memo) + 1;
				}
				else
				{
					memo[sizeA, sizeB] = Math.Max(LongestCommonSubsequence(a, b, sizeA - 1, sizeB, memo), LongestCommonSubsequence(a, b, sizeA, sizeB - 1, memo));
				}
				return memo[sizeA, sizeB];
			}
		}

		//my nonoptimal, but works.
		public class Solution2
		{
			public int MinDistance(string a, string b)
			{
				var memo = new Dictionary<Tuple<string, string>, int>();
				return MinDistance(a.ToList(), b.ToList(), memo, 0);
			}

			private int MinDistance(List<char> a, List<char> b, Dictionary<Tuple<string, string>, int> memo, int acc)
			{
				var sa = new string(a.ToArray());
				var sb = new string(b.ToArray());
				if ((a.Count == 1 && b.Count == 0) || (a.Count == 0 && b.Count == 1)) return ++acc;
				if ((sa == sb) || (a.Count == 0 && b.Count == 0))
				{
					return acc;
				}
				var t = new Tuple<string, string>(sa,sb);
				var count = 0;
				if (memo.TryGetValue(t, out count)) return count;

				List<char> toRemove = a.Count > b.Count ? a : b;
				count = int.MaxValue;
				for (int i = 0; i < toRemove.Count; ++i)
				{
					var removed = new List<char>(toRemove);
					removed.RemoveAt(i);
					var ret = 0;
					if (a.Count > b.Count)
					{
						ret = MinDistance(removed, b, memo, acc + 1);
					}
					else ret = MinDistance(a, removed, memo, acc + 1);
					count = Math.Min(count, ret);
				}
				count = count == int.MaxValue ? Math.Max(a.Count, b.Count) : count;
				memo.Add(t, count);
				return count;
			}
		}
	}
}
