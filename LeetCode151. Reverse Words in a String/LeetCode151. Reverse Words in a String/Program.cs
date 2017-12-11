using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode151.Reverse_Words_in_a_String
{
	class Program
	{
		//https://leetcode.com/problems/reverse-words-in-a-string/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.ReverseWords("the sky     is blue ");
		}
		public class Solution
		{
			public string ReverseWords(string s)
			{
				s = s.Trim(' ');
				if (string.IsNullOrEmpty(s)) return string.Empty;
				var sArray = s.ToArray();
				ReverseString(sArray, 0, sArray.Length - 1);
				var index = 0;
				while (index < sArray.Length)
				{
					while (index < sArray.Length && sArray[index] == ' ') index++;
					var l = index;
					while (index < sArray.Length && sArray[index] != ' ') index++;
					var r = index-1;
					ReverseString(sArray, l,r);
				}
				var nextWrite = 0;
				index = 0;

				while (index < sArray.Length)
				{
					if (sArray[index] != ' ')
					{
						sArray[nextWrite++] = sArray[index++];
						continue;
					}
					sArray[nextWrite++] = sArray[index++];
					while (index < sArray.Length && sArray[index] == ' ') index++;
				}
				return new string(sArray, 0, nextWrite);
			}

			private void ReverseString(char[]s,int l, int r)
			{
				while (l < r)
				{
					var t = s[l];
					s[l] = s[r];
					s[r] = t;
					l++;r--;
				}
			}
		}
	}
}
