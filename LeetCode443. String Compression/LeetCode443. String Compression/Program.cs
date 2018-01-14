using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode443.String_Compression
{
	class Program
	{
		//https://leetcode.com/problems/string-compression/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			//var c = new char[] { 'a', 'a', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'c', };
			var c = new char[] { 'a', 'a', 'b', 'b', 'c', 'c', 'c' };
			//var c = new char[] { 'a', 'a'};
			var r = s.Compress(c);
		}
		public class Solution
		{
			public int Compress(char[] chars)
			{
				if (chars == null || chars.Length == 0) return 0;
				if (chars.Length == 1) return 1;
				var newSize = 0;
				var i = 0;
				var count = 1;
				var prev = '0';
				while (i < chars.Length)
				{
					prev = chars[i];
					var j = i + 1;
					while (j < chars.Length && chars[j] == prev)
					{
						++count;
						++j;
					}
					chars[newSize++] = prev;
					if (count > 1)
					{
						var stringCount = count.ToString();
						foreach (var c in stringCount)
						{
							chars[newSize++] = c;
						}
					}
					count = 1;
					i = j;
				}
				if(newSize < chars.Length) chars[newSize] = prev;
				if (count > 1)
				{
					var stringCount = count.ToString();
					foreach (var c in stringCount)
					{
						chars[newSize++] = c;
					}
				}
				return newSize;
			}
		}
	}
}
