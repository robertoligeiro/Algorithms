using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode139.Word_Break
{
	//https://leetcode.com/problems/word-break/description/
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.WordBreak("aaaaaaa", new List<string>() { "aaaa", "aaa" });
			//var r = s.WordBreak("leetcode", new List<string>() { "leet", "code", "cod", "lee" });
			//var r = s.WordBreak("aaaaaaaa", new List<string>() { "aaa", "aa", "a" });
			//var r = s.WordBreak("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabaabaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 
			//	new List<string>() { "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa", "ba" });
			//var r = s.WordBreak("ccacccbcab",
			//	new List<string>() { "cc", "bb", "aa", "bc", "ac", "ca", "ba", "cb" });
		}

		public class Solution
		{
			public bool WordBreak(string s, IList<string> wordDict)
			{
				return WordBreak(s, 0, new HashSet<string>(wordDict), new int[s.Length]);
			}

			private bool WordBreak(string s, int index, HashSet<string> words, int[] memo)
			{
				if (index == s.Length) return true;
				if (memo[index] != 0) return false;
				for (int i = index; i < s.Length; ++i)
				{
					if (words.Contains(s.Substring(index, i-index+1)) && WordBreak(s, i + 1, words, memo))
					{
						return true;
					}
				}
				memo[index] = -1;
				return false;
			}
		}
	}
}
