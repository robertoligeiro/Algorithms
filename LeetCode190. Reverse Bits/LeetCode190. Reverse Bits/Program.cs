using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode190.Reverse_Bits
{
	class Program
	{
		//https://leetcode.com/problems/reverse-bits/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.reverseBits(19);
		}
		public class Solution
		{
			public uint reverseBits(uint n)
			{
				uint result = 0;
				for(int i = 0; i<32;++i)
				{
					uint b = 0;
					if ((n & 1) == 1) b = 1;
					n >>= 1;
					result = result * 2 + b;
				}
				return result;
			}
		}
	}
}
