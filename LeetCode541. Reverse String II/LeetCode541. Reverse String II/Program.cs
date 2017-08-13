using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode541.Reverse_String_II
{
    class Program
    {
        //https://leetcode.com/problems/reverse-string-ii/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.ReverseStr("abcdefg",2);
        }

        public class Solution
        {
            public string ReverseStr(string s, int k)
            {
                var resp = new char[s.Length];
                var start = 0;
                var reversed = new Stack<char>();
                var count = 0;
                for (int i = 0; i < s.Length; ++i)
                {
                    if (count < k) reversed.Push(s[i]);
                    else if (count == 2 * k)
                    {
                        Array.Copy(reversed.ToArray(), 0, resp, start, reversed.Count);
                        start = i;
                        reversed.Clear();
                        reversed.Push(s[i]);
                        count = 0;
                    }
                    else
                    {
                        resp[i] = s[i];
                    }

                    count++;
                }
                Array.Copy(reversed.ToArray(), 0, resp, start, reversed.Count);
                return new string(resp);
            }
        }
    }
}
