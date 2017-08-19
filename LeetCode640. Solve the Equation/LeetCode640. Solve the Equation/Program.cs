using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode640.Solve_the_Equation
{
    class Program
    {
        //https://leetcode.com/problems/solve-the-equation/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.SolveEquation("x+5-3+x=6+x-2");
            r = s.SolveEquation("x=x");
            r = s.SolveEquation("2x=x");
            r = s.SolveEquation("2x+3x-6x=x+2");
            r = s.SolveEquation("x=x+2");
            r = s.SolveEquation("-x=1");
            r = s.SolveEquation("x=100");
            r = s.SolveEquation("x-10=10-x+x+2x");
        }

        public class expression
        {
            public int x;
            public int num;
        }
        public class Solution
        {
            public string SolveEquation(string equation)
            {
                var expressions = equation.Split('=');
                var leftSide = GetExpression(expressions[0]);
                var rightSide = GetExpression(expressions[1]);

                var x = leftSide.x - rightSide.x;
                var num = rightSide.num - leftSide.num;
                if (x == 0)
                {
                    if(num != 0) return "No solution";
                    return "Infinite solutions";
                }
                var result = num / x;
                return "x="+result.ToString();
            }

            private expression GetExpression(string exp)
            {
                var expression = new expression();
                var s = new Stack<char>();
                foreach (var c in exp)
                {
                    s.Push(c);
                }
                var sb = new StringBuilder();
                var isX = false;
                var count = 0;
                var rest = false;
                while (s.Count > 0)
                {
                    var c = s.Pop();
                    if (c == 'x')
                    {
                        isX = true;
                        rest = true;
                    }
                    else
                    if (Char.IsDigit(c))
                    {
                        sb.Append(c);
                        rest = true;
                    }
                    else
                    {
                        count = 1;
                        if (sb.Length > 0)
                        {
                            var n = sb.ToString();
                            count = int.Parse(new string(n.Reverse().ToArray()));
                        }
                        if (c == '-') count *= -1;
                        if (isX) expression.x += count;
                        else expression.num += count;
                        sb.Clear();
                        isX = false;
                        rest = false;
                    }
                }
                if (!rest) return expression;
                count = 1;
                if (sb.Length > 0)
                {
                    var n = sb.ToString();
                    count = int.Parse(new string(n.Reverse().ToArray()));
                }
                if (isX) expression.x += count;
                else expression.num += count;

                return expression;
            }
        }
    }
}
