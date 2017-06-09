using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode386.LexicographicalNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.LexicalOrder(13);
        }

        public class Solution
        {
            public IList<int> LexicalOrder(int n)
            {
                var res = new int[n];
                int cur = 1;
                for (int i = 0; i < n; i++)
                {
                    res[i] = cur;
                    if (cur * 10 <= n)
                    {
                        cur *= 10;
                    }
                    else
                    {
                        if (cur >= n)
                            cur /= 10;
                        cur += 1;
                        while (cur % 10 == 0)
                            cur /= 10;
                    }
                }
                return res;
            }
        }
    }
}
