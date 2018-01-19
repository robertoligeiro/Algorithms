using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode131.Palindrome_Partitioning
{
	class Program
	{
		//https://leetcode.com/problems/palindrome-partitioning/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.Partition("aabaa");
		}

		public class Solution
		{
			public IList<IList<string>> Partition(string s)
			{
				var resp = new List<IList<string>>();
				var parc = new List<string>();
				Partition(s, 0, resp, parc);
				return resp;
			}

			private void Partition(string s, int index, List<IList<string>> resp, List<string> parc)
			{
				if(index == s.Length)
				{
					resp.Add(new List<string>(parc));
					return;
				}

				for (int i = index; i < s.Length; ++i)
				{
					if (IsPal(s, index, i))
					{
						parc.Add(s.Substring(index, i - index + 1));
						Partition(s, i + 1, resp, parc);
						parc.RemoveAt(parc.Count - 1);
					}
				}
			}
			private bool IsPal(string s, int l, int r)
			{
				while (l < r)
				{
					if (s[l] != s[r]) return false;
					l++; r--;
				}

				return true;
			}
		}

	}
}
