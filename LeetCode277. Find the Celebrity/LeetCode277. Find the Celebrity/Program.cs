using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode277.Find_the_Celebrity
{
	//https://leetcode.com/problems/find-the-celebrity/description/
	class Program
	{
		static void Main(string[] args)
		{
		}
		/* The Knows API is defined in the parent class Relation.
      bool Knows(int a, int b); */

		public class Solution //: Relation
		{
			bool Knows(int a, int b) { return true; }
			public int FindCelebrity(int n)
			{
				var candidate = 0;
				for (int i = 1; i < n; ++i)
				{
					if (!Knows(i, candidate))
					{
						candidate = i;
					}
				}

				for (int i = 0; i < n; ++i)
				{
					if (i != candidate && (!Knows(i, candidate) || Knows(candidate,i))) return -1;
				}
				return candidate;
			}
		}
	}
}
