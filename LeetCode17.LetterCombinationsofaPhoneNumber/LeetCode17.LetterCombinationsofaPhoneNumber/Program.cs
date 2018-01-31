using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode17.LetterCombinationsofaPhoneNumber
{
	class Program
	{
		//https://leetcode.com/problems/letter-combinations-of-a-phone-number/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.LetterCombinations("23");
		}

		public class Solution
		{
			private static string[] chars = new string[] { "0", "1", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
			public IList<string> LetterCombinations(string digits)
			{
				var resp = new List<string>();
				if (string.IsNullOrWhiteSpace(digits) || digits.Contains("0") || digits.Contains("1")) return resp;
				GetLetters(digits, 0, resp, string.Empty);
				return resp;
			}

			private void GetLetters(string d, int index, List<string> resp, string parc)
			{
				if (index == d.Length)
				{
					resp.Add(parc);
					return;
				}

				foreach (var c in chars[d[index] - '0'])
				{
					GetLetters(d, index + 1, resp, parc + c);
				}
			}
		}
	}
}
