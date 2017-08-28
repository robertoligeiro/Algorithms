using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode279.Perfect_Squares
{
    class Program
    {
        //https://leetcode.com/problems/perfect-squares/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.NumSquares(8829);
        }
        public class Solution
        {
            public int NumSquares(int n)
            {
                var sqr = Math.Sqrt(n);
                if (sqr / (int)sqr == 1) return 1;
                var lSqr = GetSqrs((int)sqr);
                return NumSquares(n, lSqr, new Dictionary<int, int>(), 0);
            }

            private int NumSquares(int rest, List<int> squares, Dictionary<int,int> memo, int added)
            {
                if (memo.ContainsKey(rest))
                {
                    return memo[rest] + added - 1;
                }
                if (rest == 0) return added;

                var sqr = Math.Sqrt(rest);
                if (sqr / (int)sqr == 1) return added+1;

                var respMin = int.MaxValue;
                for (int i = 0; i < squares.Count; ++i)
                {
                    if (rest - squares[i] >= 0)
                    {
                        int min = NumSquares(rest - squares[i], squares, memo, added + 1);
                        respMin = Math.Min(min, respMin);
                        if (!memo.ContainsKey(rest))
                        {
                            memo.Add(rest, respMin - added);
                        }
                    }
                }
                return respMin;
            }
            private List<int> GetSqrs(int n)
            {
                var resp = new List<int>() { 1 };
                for (int i = 2; i <= n; ++i) resp.Add(i * i);
                return resp;
            }
        }
    }
}
