using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode412.FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.FizzBuzz(16);
        }
        public class Solution
        {
            public IList<string> FizzBuzz(int n)
            {
                var r = new List<string>();
                for (int i = 1; i <= n; ++i)
                {
                    if (i % 3 == 0 && i % 5 == 0) r.Add("FizzBuzz");
                    else if (i % 3 == 0) r.Add("Fizz");
                    else if (i % 5 == 0) r.Add("Buzz");
                    else r.Add(i.ToString());
                }
                return r;
            }
        }
    }
}
