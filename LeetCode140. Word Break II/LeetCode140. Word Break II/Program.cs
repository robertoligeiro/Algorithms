using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode140.Word_Break_II
{
	class Program
	{
		//https://leetcode.com/problems/word-break-ii/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			//var r = s.WordBreak("catsanddog", new List<string>() { "cat", "cats", "and", "sand", "dog" });
			//var r = s.WordBreak("abcd", new List<string>() { "a", "abc", "b", "cd" });
			var r = s.WordBreak("aaaaaaa", new List<string>() { "aa", "aaaa"});

		}
		public class Solution
		{
			public IList<string> WordBreak(string s, IList<string> wordDict)
			{
				var memo = new Dictionary<int, List<string>>();
				var ret = WordBreak(s, 0, new HashSet<string>(wordDict), memo);
				return ret == null ? new List<string>() : ret;
			}

			private IList<string> WordBreak(string s, int index, HashSet<string> words, Dictionary<int, List<string>> memo)
			{
				var resp = new List<string>();
				if (index == s.Length)
				{
					return resp;
				}

				if (memo.TryGetValue(index, out resp))
				{
					return resp.Count == 0 ? null : resp;
				}
				resp = new List<string>();
				for (int i = index + 1; i <= s.Length; ++i)
				{
					if (words.Contains(s.Substring(index, i - index)))
					{
						var ret = WordBreak(s, i, words, memo);
						if (ret == null) continue;
						var p = new StringBuilder(s.Substring(index, i - index));
						foreach (var ss in ret)
						{
							p.Append(" " + ss);
						}
						resp.Add(p.ToString());
					}
				}
				memo.Add(index, resp);
				return resp.Count == 0 ? null : resp;
			}
		}
	}
}
