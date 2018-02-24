using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode336.Palindrome_Pairs
{
	class Program
	{
		//https://leetcode.com/problems/palindrome-pairs/description/
		static void Main(string[] args)
		{
		}
		public class Solution
		{
			public IList<IList<int>> PalindromePairs(string[] words)
			{
				var map = new Dictionary<string, int>();
				for (int i = 0; i < words.Length; ++i)
				{
					map.Add(new string(words[i].Reverse().ToArray()), i);
				}

				var resp = new List<IList<int>>();
				var index = 0;
				if (map.TryGetValue(string.Empty, out index))
				{
					for (int i = 0; i < words.Length; ++i)
					{
						if (words[i] != string.Empty && IsPalindrome(words[i]))
						{
							resp.Add(new List<int> { index, i });
						}
					}
				}
				for (int i = 0; i < words.Length; ++i)
				{
					for (int j = words[i].Length - 1; j >= 0; --j)
					{
						var left = words[i].Substring(0, j);
						var right = words[i].Substring(j);

						if (map.ContainsKey(left) && IsPalindrome(right) && map[left] != i)
						{
							resp.Add(new List<int> { i, map[left] });
						}
						if (map.ContainsKey(right) && IsPalindrome(left) && map[right] != i)
						{
							resp.Add(new List<int> { map[right], i });
						}
					}
				}

				return resp;
			}

			private bool IsPalindrome(string s)
			{
				int l = 0, r = s.Length - 1;
				while (l < r)
				{
					if (s[l] != s[r]) return false;
					++l;--r;
				}
				return true;
			}
		}
	}
}
