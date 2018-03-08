using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode150.Evaluate_Reverse_Polish_Notation
{
	class Program
	{
		static void Main(string[] args)
		{
		}

		public class Solution
		{
			//https://leetcode.com/problems/evaluate-reverse-polish-notation/description/
			public int EvalRPN(string[] tokens)
			{
				if (tokens == null || tokens.Length == 0) return 0;
				var s = new Stack<int>();
				foreach (var n in tokens)
				{
					if (n == "+" || n == "-" || n == "*" || n == "/")
					{
						var second = s.Pop();
						var first = s.Pop();
						var val = 0;
						switch (n)
						{
							case "+":
								val = first + second;
								break;
							case "-":
								val = first - second;
								break;
							case "*":
								val = first * second;
								break;
							case "/":
								val = first / second;
								break;
						}
						s.Push(val);
					}
					else
					{
						s.Push(int.Parse(n));
					}
				}
				return s.Pop();
			}
		}
	}
}
