using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode273.Integer_to_English_Words
{
	class Program
	{
		//https://leetcode.com/problems/integer-to-english-words/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.NumberToWords(50868);
		}

		public class Solution
		{
			private static string[] belowTen = new string[10]
				{ "","One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };

			private static string[] belowTwenty = new string[10]
				{"Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};

			private static string[] belowHundred = new string[10]
				{"", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"};
			public string NumberToWords(int num)
			{
				if (num == 0) return "Zero";
				return helper(num);
			}
			private string helper(int num)
			{
				string result = string.Empty;
				if (num < 10) result = belowTen[num];
				else if (num < 20) result = belowTwenty[num - 10];
				else if (num < 100) result = belowHundred[num / 10] + " " + helper(num % 10);
				else if (num < 1000) result = helper(num / 100) + " Hundred " + helper(num % 100);
				else if (num < 1000000) result = helper(num / 1000) + " Thousand " + helper(num % 1000);
				else if (num < 1000000000) result = helper(num / 1000000) + " Million " + helper(num % 1000000);
				else result = helper(num / 1000000000) + " Billion " + helper(num % 1000000000);
				return result.Trim();
			}
		}
	}
}
