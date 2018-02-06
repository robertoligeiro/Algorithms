using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode157.Read_N_Characters_Given_Read4
{
	class Program
	{
		//https://leetcode.com/problems/read-n-characters-given-read4/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var b = new char[1];
			var r = s.Read(b, 1);
		}

		/* The Read4 API is defined in the parent class Reader4.
      int Read4(char[] buf); */

		public class Solution //: Reader4
		{
			private char[] intBuf = new char[4];
			private int available;
			private int next = 0;
			int Read4(char[] buf)
			{
				intBuf = new char[] { 'a' };
				return 1;
			}
			/**
			 * @param buf Destination buffer
			 * @param n   Maximum number of characters to read
			 * @return    The number of characters read
			 */
			public int Read(char[] buf, int n)
			{
				int i = 0;
				while (n > 0)
				{
					--n;
					char c = ' ';
					if (ReadFromIntBuf(ref c))
					{
						buf[i++] = c;
					}
					else break;
				}
				return i;
			}

			private bool ReadFromIntBuf(ref char c)
			{
				if (available > 0)
				{
					available--;
					c = intBuf[next++];
					return true;
				}
				else
				{
					available = Read4(intBuf);
					if (available > 0)
					{
						next = 0;
						return ReadFromIntBuf(ref c);
					}
				}
				return false;
			}
		}
	}
}
