using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode66.Plus_One
{
	class Program
	{
		//https://leetcode.com/problems/plus-one/description/
		static void Main(string[] args)
		{
		}
		public class Solution
		{
			public int[] PlusOne(int[] digits)
			{
				var resp = new List<int>();
				var sum = PlusOne(digits, 0, resp);
				if (sum == 1) resp.Add(1);
				resp.Reverse();
				return resp.ToArray();
			}
			private int PlusOne(int[] digits, int index, List<int> resp)
			{
				if (index == digits.Length)
				{
					return 1;
				}

				var sum = digits[index] + PlusOne(digits, index + 1, resp);
				resp.Add(sum % 10);
				return sum == 10 ? 1 : 0;
			}
		}
		// iterative using stack
		//public class Solution
		//{
		//	public int[] PlusOne(int[] digits)
		//	{
		//		var s = new Stack<int>();
		//		foreach (var i in digits)
		//		{
		//			s.Push(i);
		//		}

		//		var resp = new List<int>();
		//		var carry = 1;
		//		while (s.Count > 0)
		//		{
		//			var sum = s.Pop() + carry;
		//			resp.Add(sum % 10);
		//			carry = sum == 10 ? 1 : 0;
		//		}
		//		if (carry == 1) resp.Add(1);
		//		resp.Reverse();
		//		return resp.ToArray();
		//	}
		//}
	}
}
