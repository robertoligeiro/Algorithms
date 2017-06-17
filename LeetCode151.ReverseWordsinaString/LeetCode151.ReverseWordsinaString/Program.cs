using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode151.ReverseWordsinaString
{
    //https://leetcode.com/problems/reverse-words-in-a-string/#/description
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            //var ss = "   the   sky blue sky   ";
            var ss = "   a   b  c d   e  ";
            ss = s.ReverseWords(ss);
        }

        public class Solution
        {
            public string ReverseWords(string s)
            {
                if (string.IsNullOrEmpty(s)) return string.Empty;
                s = RemoveSpaces(s);
                s = ReverseString(s, 0, s.Length-1);
                s = s.Trim(' ');
                var start = -1;
                for (int i = 0; i < s.Length; ++i)
                {
                    if (s[i] != ' ' && start == -1)
                    {
                        start = i;
                    }
                    if (s[i] == ' ' && start != -1)
                    {
                        s = ReverseString(s, start, i - 1);
                        start = -1;
                    }
                }

                if(start != -1) s = ReverseString(s, start, s.Length - 1);
                return s;
            }

            public string ReverseString(string s, int start, int end)
            {
                var sArray = s.ToList().ToArray();
                while (start < end)
                {
                    var t = sArray[start];
                    sArray[start] = sArray[end];
                    sArray[end] = t;
                    start++;
                    end--;
                }

                return new string(sArray);
            }

            public string RemoveSpaces(string s)
            {
                var sb = new StringBuilder();
                var countSpace = 1;
                foreach (var c in s)
                {
                    if (c == ' ' && ++countSpace > 1) continue;
                    sb.Append(c);
                    if (c != ' ') countSpace = 0;
                }

                return sb.ToString();
            }

        }
    }
}
