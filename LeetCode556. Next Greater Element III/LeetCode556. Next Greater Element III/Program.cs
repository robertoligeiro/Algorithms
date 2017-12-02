using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode556.Next_Greater_Element_III
{
	class Program
	{
		//https://leetcode.com/problems/next-greater-element-iii/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.NextGreaterElement(12443322);
			//var r = s.NextGreaterElement(21);
			//var r = s.NextGreaterElement(11);
		}
		public class Solution
		{
			public int NextGreaterElement(int n)
			{
				if (n < 9) return -1;
				var numArray = n.ToString().ToArray();
				//num sorted in ascending, swap last two digs
				char t;
				if (IsSortedAscending(numArray))
				{
					t = numArray[numArray.Length - 2];
					numArray[numArray.Length - 2] = numArray[numArray.Length - 1];
					numArray[numArray.Length - 1] = t;
					return int.Parse(new string(numArray));
				}
				// num sorted descending order, can't do it.
				if (IsSortedDesc(numArray)) return -1;

				//if none of the cases before, then:
				// 1. find from right to left a dPos position where n[i - 1] < n[i]
				var dPos = 0;
				for (int i = numArray.Length - 1; i >= 1; --i)
				{
					if (numArray[i - 1] < numArray[i])
					{
						dPos = i - 1;
						break;
					}
				}

				//2. find the firs changePos position from right to left that is bigger than dPos.
				var changePos = 0;
				for (int i = numArray.Length - 1; i >= 1; --i)
				{
					if (numArray[i] > numArray[dPos])
					{
						changePos = i;
						break;
					}
				}

				// 3. swap the 2 positions(dPos, changePos)
				t = numArray[dPos];
				numArray[dPos] = numArray[changePos];
				numArray[changePos] = t;

				// 4. revert the array for dPos + 1 to the end;
				var left = dPos + 1;
				var right = numArray.Length - 1;
				while(left < right)
				{
					t = numArray[right];
					numArray[right] = numArray[left];
					numArray[left] = t;
					left++;
					right--;
				}
				try//make sure the new number fits in an int32 num
				{
					return int.Parse(new string(numArray));
				}
				catch
				{
					return -1;
				}
			}

			private bool IsSortedAscending(char[] s)
			{
				for (int i = 1; i < s.Length; ++i)
				{
					if (s[i] <= s[i-1]) return false;
				}
				return true;
			}

			private bool IsSortedDesc(char[] s)
			{
				for (int i = 1; i < s.Length; ++i)
				{
					if (s[i] > s[i-1]) return false;
				}
				return true;
			}
		}
	}
}
