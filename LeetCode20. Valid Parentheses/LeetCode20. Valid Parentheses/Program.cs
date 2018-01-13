using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode20.Valid_Parentheses
{
	class Program
	{
		static void Main(string[] args)
		{
		}
		public class Solution
		{
			public bool IsValid(string s)
			{
				var st = new Stack<char>();
				foreach (var c in s)
				{
					if (c == '(')
						st.Push(')');
					else if (c == '{')
						st.Push('}');
					else if (c == '[')
						st.Push(']');
					else if (st.Count == 0 || st.Pop() != c)
						return false;
				}
				return st.Count == 0;
			}
		}
	}
}
