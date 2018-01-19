using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode556.NextGreaterElementIII
{
    class Program
    {
        //https://leetcode.com/problems/next-greater-element-iii/description/
        //solution is here: http://www.geeksforgeeks.org/find-next-greater-number-set-digits/
        //my code is not working.
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.NextGreaterElement(1999999999);
			//var r = s.NextGreaterElement(41543);
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
				while (left < right)
				{
					t = numArray[right];
					numArray[right] = numArray[left];
					numArray[left] = t;
					left++;
					right--;
				}
				try
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
					if (s[i] <= s[i - 1]) return false;
				}
				return true;
			}

			private bool IsSortedDesc(char[] s)
			{
				for (int i = 1; i < s.Length; ++i)
				{
					if (s[i] > s[i - 1]) return false;
				}
				return true;
			}
		}
		//public class Solution
		//      {
		//          public int NextGreaterElement(int n)
		//          {
		//              var num = n.ToString();
		//              num = new string(num.Reverse().ToArray());
		//              var sb = new StringBuilder();
		//              var hasSwap = false;
		//              for(int i = 0; i < num.Length; ++i)
		//              {
		//                  //if (i + 1 < num.Length && num[i] > num[i + 1])
		//                  //{
		//                  //    sb.Append(num[i + 1]);
		//                  //    sb.Append(num[i]);
		//                  //    if(i + 2 < num.Length)
		//                  //        sb.Append(num.ToCharArray(), i + 2, num.Length - i - 2);
		//                  //    break;
		//                  //}
		//                  if (!hasSwap)
		//                  {
		//                      var index = HasSmallerInFront(num, i + 1);
		//                      if (index != -1)
		//                      {
		//                      }
		//                  }
		//                  else
		//                  {
		//                      sb.Append(num[i]);
		//                  }
		//              }
		//              num = new string(sb.ToString().Reverse().ToArray());
		//              var resp = Int64.Parse(num);
		//              if (resp > Int32.MaxValue) return -1;

		//              return resp == n ? -1 : (int)resp;
		//          }

		//          private int HasSmallerInFront(string num, int startIndex)
		//          {
		//              for (int i = startIndex; i < num.Length; ++i)
		//              {
		//                  if (num[startIndex - 1] > num[i]) return i;
		//              }
		//              return -1;
		//          }
		//      }

	}
}
