using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode345.Reverse_Vowels_of_a_String
{
	class Program
	{
		//https://leetcode.com/problems/reverse-vowels-of-a-string/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.ReverseVowels("leetcode");
		}

		public class Solution
		{
			public string ReverseVowels(string s)
			{
				var l = 0;
				var r = s.Length - 1;
				var sArray = s.ToArray();
				var h = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
				while (l < r)
				{
					while (l < r && !h.Contains(s[l])) { l++; }
					while (l < r && !h.Contains(s[r])) { r--; }
					if (l >= r) break;
					var t = s[l];
					sArray[l] = sArray[r];
					sArray[r] = t;
					l++;
					r--;
				}
				return new string(sArray);
			}
		}
	}
}
