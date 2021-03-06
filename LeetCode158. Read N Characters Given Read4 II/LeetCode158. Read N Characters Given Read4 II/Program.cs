﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode158.Read_N_Characters_Given_Read4_II
{
	//https://leetcode.com/problems/read-n-characters-given-read4-ii-call-multiple-times/description/
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			char[] b = new char[4];
			var r = s.Read(b, 2);
			r = s.Read(b, 1);
		}

		public class Reader4
		{
			public int Read4(char[] buff)
			{
				Array.Copy("ab".ToArray(), buff, 2);
				return 2;
			}
		}
		public class Solution : Reader4
		{
			/**
			 * @param buf Destination buffer
			 * @param n   Maximum number of characters to read
			 * @return    The number of characters read
			 */

			private char[] read4Buffer = new char[4];
			private int charsAvailable = 0;
			private int nextAvailable = 0;

			public int Read(char[] buf, int n)
			{
				var index = 0;
				while (n > 0)
				{
					char c = ' ';
					if (this.ReadNext(ref c))
					{
						buf[index++] = c;
						n--;
					}
					else break;
				}
				return index;
			}

			private bool ReadNext(ref char c)
			{
				if (this.nextAvailable < this.charsAvailable)
				{
					c = this.read4Buffer[this.nextAvailable++];
					return true;
				}
				else
				{
					if (this.ReadFromRead4() > 0) return ReadNext(ref c);
				}
				return false;
			}
			private int ReadFromRead4()
			{
				var ret = this.Read4(this.read4Buffer);
				if (ret == 0) this.charsAvailable = -1;
				else
				{
					this.nextAvailable = 0;
					this.charsAvailable = ret;
				}
				return ret;
			}
		}
	}
}
