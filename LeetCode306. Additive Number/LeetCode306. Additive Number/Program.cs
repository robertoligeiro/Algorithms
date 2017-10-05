using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode306.Additive_Number
{
    class Program
    {
        //https://leetcode.com/problems/additive-number/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            //var r = s.IsAdditiveNumber("112358");
            var r = s.IsAdditiveNumber("199100199");
        }
        public class Solution
        {
            public bool IsAdditiveNumber(string num)
            {
                return IsAdditiveNumber(num, 0, 0, 0, 0);
            }
            private bool IsAdditiveNumber(string num, int index, int prevprev, int prev, int acc)
            {
                if (index == num.Length)
                {
                    if (prev == 0) return false;
                    return prev == acc - prevprev;
                }
                var sb = new StringBuilder();
                for (int i = index; i < num.Length; ++i)
                {
                    sb.Append(num[i]);
                    var parc = int.Parse(sb.ToString());
                    if (prev == 0 && acc == 0)
                    {
                        if (IsAdditiveNumber(num, i + 1, 0, 0, parc)) return true;
                    }
                    else if (prev == 0)
                    {
                        if (IsAdditiveNumber(num, i + 1, 0, parc, parc + acc)) return true;
                    }
                    else
                    {
                        if (acc == parc)
                        {
                            if (IsAdditiveNumber(num, i + 1, prev, parc, parc + prev))
                            {
                                return true;
                            }
                        }
                        if (parc > acc) return false;
                    }
                }
                return false;
            }
        }
    }
}
