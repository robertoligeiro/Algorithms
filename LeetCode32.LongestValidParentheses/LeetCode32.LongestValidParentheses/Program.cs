using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode32.LongestValidParentheses
{
    class Program
    {
        //https://leetcode.com/problems/longest-valid-parentheses/#/description
        //solution: https://leetcode.com/problems/longest-valid-parentheses/#/solutions
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.LongestValidParentheses(")()())");
            r = s.LongestValidParentheses("(()");
            r = s.LongestValidParentheses("()(()");
            r = s.LongestValidParentheses("())");
        }

        public class Solution
        {
            public int LongestValidParentheses(string s)
            {
                var resp = 0;
                var localCount = 0;
                var par = new Stack<int>();
                for (int i = 0; i < s.Length; ++i)
                {
                    if (s[i] == '(')
                    {
                        par.Push(i);
                    }
                    else
                    {
                        if (par.Count > 0)
                        {
                            if (s[par.Peek()] == '(')
                            {
                                par.Pop();
                            }
                            else par.Push(i);
                        }
                        else par.Push(i);
                    }
                }

                if (par.Count == 0) return s.Length;
                int end = s.Length;
                int start = 0;
                while (par.Count > 0)
                {
                    start = par.Pop();
                    resp = Math.Max(resp, end - start - 1);
                    end = start;
                }
                resp = Math.Max(resp, end);

                return resp;
            }
        }
    }
}
