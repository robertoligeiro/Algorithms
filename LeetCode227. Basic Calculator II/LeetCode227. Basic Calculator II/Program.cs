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
				s = s.Replace(" ", string.Empty);
				int m = 0;
				int d = 0;
				while ((m = s.IndexOf('*')) > 0 || (d = s.IndexOf('/')) > 0)
				{
					s = DoMultOrDiv(s);
				}

				var qNum = new Queue<int>();
				var qOp = new Queue<char>();
				var num = string.Empty;
				foreach (var c in s)
				{
					if (char.IsDigit(c))
					{
						num += c;
					}
					else
					{
						qNum.Enqueue(int.Parse(num));
						qOp.Enqueue(c);
						num = string.Empty;
					}
				}
				qNum.Enqueue(int.Parse(num));

				var result = qNum.Dequeue();
				while (qNum.Count > 0)
				{
					result = qOp.Dequeue() == '+' ? result + qNum.Dequeue() : result - qNum.Dequeue();
				}

				return result;
			}

			private string DoMultOrDiv(string s)
			{
				var multIndex = s.IndexOf('*');
				var divIndex = s.IndexOf('/');
				var index = 0;
				if (multIndex == -1 && divIndex == -1) return s;
				if (multIndex == -1) index = divIndex;
				else if (divIndex == -1) index = multIndex;
				else index = Math.Min(multIndex, divIndex);
				 

				var left = string.Empty;
				int countLeft = index - 1;
				while (countLeft >= 0 && char.IsDigit(s[countLeft]))
				{
					left += s[countLeft--];
				}
				countLeft++;

				var right = string.Empty;
				var countRight = index + 1;
				while (countRight < s.Length && char.IsDigit(s[countRight]))
				{
					right += s[countRight++];
				}

				left = new string(left.Reverse().ToArray());
				var result = s[index] == '*' ? int.Parse(left) * int.Parse(right) : int.Parse(left) / int.Parse(right);

				return s.Substring(0, countLeft) + result.ToString() + s.Substring(countRight, s.Length - countRight);
			}
		}
	}
}
