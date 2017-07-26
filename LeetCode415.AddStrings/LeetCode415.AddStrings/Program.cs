using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode415.AddStrings
{
    class Program
    {
        //https://leetcode.com/problems/add-strings/#/description
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.AddStrings("99", "1");
        }

        public class Solution
        {
            public string AddStrings(string num1, string num2)
            {
                var len1 = num1.Length - 1;
                var len2 = num2.Length - 1;
                var resp = new StringBuilder();
                var carry = 0;
                while (len1 >= 0 || len2 >= 0)
                {
                    var n1 = 0;
                    var n2 = 0;
                    if (len1 >= 0)
                    {
                        n1 = num1[len1--] - '0';
                    }
                    if (len2 >= 0)
                    {
                        n2 = num2[len2--] - '0';
                    }
                    var sum = n1 + n2 + carry;
                    carry = 0;
                    if (sum > 9)
                    {
                        sum %= 10;
                        carry = 1;
                    }
                    resp.Append(sum.ToString());
                }
                if (carry == 1) resp.Append(1);
                return new string(resp.ToString().Reverse().ToArray());
            }
        }
    }
}
