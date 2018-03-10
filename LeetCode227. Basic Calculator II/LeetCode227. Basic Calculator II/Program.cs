using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode227.Basic_Calculator_II
{
	class Program
	{
		//https://leetcode.com/problems/basic-calculator-ii/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.Calculate("2*3+4");
			//var r = s.Calculate("14/3*2");
		}
		public class Solution
		{
			public int Calculate(string s)
			{
				var result = 0;
				var parcResults = new Stack<int>();
				var parcNum = 0;
				var sign = '+';
				for (int i = 0; i < s.Length; ++i)
				{
					if (char.IsDigit(s[i]))
					{
						parcNum = parcNum * 10 + s[i] - '0';
					}
					if((!char.IsDigit(s[i]) && s[i] != ' ') || i == s.Length-1)
					{
						if (sign == '+')
						{
							parcResults.Push(parcNum);
						}
						else if (sign == '-')
						{
							parcResults.Push(-parcNum);
						}
						else if (sign == '*')
						{
							parcResults.Push(parcResults.Pop()*parcNum);
						}
						else if (sign == '/')
						{
							parcResults.Push(parcResults.Pop() / parcNum);
						}
						sign = s[i];
						parcNum = 0;
					}
				}
				while (parcResults.Count > 0)
				{
					result += parcResults.Pop();
				}
				return result;
			}
		}
	}
}
