using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode266.Palindrome_Permutation
{
	class Program
	{
		static void Main(string[] args)
		{
		}
		public class Solution
		{
			public bool CanPermutePalindrome(string s)
			{
				var h = new HashSet<char>();
				foreach (var c in s)
				{
					if (!h.Add(c))
					{
						h.Remove(c);
					}
				}
				return h.Count <= 1;
			}
		}
	}
}
