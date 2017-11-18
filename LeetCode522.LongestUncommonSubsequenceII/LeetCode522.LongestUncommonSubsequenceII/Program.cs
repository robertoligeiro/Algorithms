using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode522.LongestUncommonSubsequenceII
{
	class Program
	{
		//https://leetcode.com/problems/longest-uncommon-subsequence-ii/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.FindLUSlength(new string[] { "abc", "df", "abc"  });
		}

		public class Solution
		{
			public int FindLUSlength(string[] strs)
			{
				var sortedStringsByLen = strs.OrderBy(x => x.Length).Reverse().ToList();
				var dups = GetDuplicates(strs);
				for (int i = 0; i < sortedStringsByLen.Count; ++i)
				{
					if (!dups.Contains(sortedStringsByLen[i]))
					{
						if (i == 0) return sortedStringsByLen[i].Length;
						for (int j = 0; j < i; ++j)
						{
							if (IsSubSequ(sortedStringsByLen[j], sortedStringsByLen[i])) break;
							if (j == i - 1) return sortedStringsByLen[i].Length;
						}
					}
				}
				return -1;
			}

			//IsSub has to be checked as below because of this phrase: 
			//A subsequence is a sequence that can be derived from one sequence by deleting 
			//some characters without changing the order of the remaining elements.
			private bool IsSubSequ(string source, string sub)
			{
				var iSource = 0;
				var iSub = 0;
				while (iSource < source.Length && iSub < sub.Length)
				{
					if (source[iSource] == sub[iSub])
					{
						iSub++;
					}
					iSource++;
				}

				return iSub == sub.Length;
			}
			private HashSet<string> GetDuplicates(string[] strs)
			{
				var dups = new HashSet<string>();
				var set = new HashSet<string>();
				foreach (var s in strs)
				{
					if (!set.Add(s)) dups.Add(s);
				}
				return dups;
			}
		}
	}
}
