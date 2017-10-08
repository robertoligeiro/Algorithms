using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode22.Generate_Parentheses
{
    class Program
    {
        //https://leetcode.com/problems/generate-parentheses/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.GenerateParenthesis(3);
        }
        public class Solution
        {
            public IList<string> GenerateParenthesis(int n)
            {
                var resp = new List<string>();
                GenerateParenthesis(n, n, resp, string.Empty);
                return resp;
            }
            private void GenerateParenthesis(int left, int right, List<string> resp, string parc)
            {
                if (left == 0 && right == 0)
                {
                    resp.Add(parc);
                    return;
                }

                if (left > 0)
                {
                    GenerateParenthesis(left - 1, right, resp, parc + "(");
                }
                if (right > left)
                {
                    GenerateParenthesis(left, right - 1, resp, parc + ")");
                }
            }
        }
    }
}
