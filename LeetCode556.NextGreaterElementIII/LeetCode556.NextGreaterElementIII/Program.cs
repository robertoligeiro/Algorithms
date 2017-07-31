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
        }

        public class Solution
        {
            public int NextGreaterElement(int n)
            {
                var num = n.ToString();
                num = new string(num.Reverse().ToArray());
                var sb = new StringBuilder();
                var hasSwap = false;
                for(int i = 0; i < num.Length; ++i)
                {
                    //if (i + 1 < num.Length && num[i] > num[i + 1])
                    //{
                    //    sb.Append(num[i + 1]);
                    //    sb.Append(num[i]);
                    //    if(i + 2 < num.Length)
                    //        sb.Append(num.ToCharArray(), i + 2, num.Length - i - 2);
                    //    break;
                    //}
                    if (!hasSwap)
                    {
                        var index = HasSmallerInFront(num, i + 1);
                        if (index != -1)
                        {
                        }
                    }
                    else
                    {
                        sb.Append(num[i]);
                    }
                }
                num = new string(sb.ToString().Reverse().ToArray());
                var resp = Int64.Parse(num);
                if (resp > Int32.MaxValue) return -1;

                return resp == n ? -1 : (int)resp;
            }

            private int HasSmallerInFront(string num, int startIndex)
            {
                for (int i = startIndex; i < num.Length; ++i)
                {
                    if (num[startIndex - 1] > num[i]) return i;
                }
                return -1;
            }
        }

    }
}
