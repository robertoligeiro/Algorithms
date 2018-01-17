using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode13.Roman_to_Integer
{
	class Program
	{
		//https://leetcode.com/problems/roman-to-integer/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.RomanToInt("IV");
		}
		public class Solution
		{
			public int RomanToInt(string s)
			{
				if (string.IsNullOrWhiteSpace(s)) return 0;
				var numbers = new Dictionary<char, int>() { { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 } };

				int sum = numbers[s[s.Length - 1]];
				for (int i = s.Length - 2; i >= 0; --i)
				{
					if (numbers[s[i]] < numbers[s[i + 1]])
					{
						sum -= numbers[s[i]];
					}
					else
					{
						sum += numbers[s[i]];
					}
				}
				return sum;
			}
		}
	}
}
