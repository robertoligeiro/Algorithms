using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode166.FractiontoRecurringDecimal
{
    class Program
    {
        //https://leetcode.com/problems/fraction-to-recurring-decimal/#/description
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.FractionToDecimal(1, 6);
            r = s.FractionToDecimal(1, 333);
            r = s.FractionToDecimal(1, 99);
            r = s.FractionToDecimal(4, 2);
            r = s.FractionToDecimal(2,3);
            r = s.FractionToDecimal(-2147483648, -1);
        }
        public class Solution
        {
            public string FractionToDecimal(int numerator, int denominator)
            {
                long numeratorN = numerator;
                long denominatorN = denominator;
                if (numeratorN == 0) return "0";
                if (denominatorN == 0) return "error";

                var integral = new StringBuilder();
                if (denominatorN < 0 && numeratorN < 0)
                {
                    numeratorN *= -1;
                    denominatorN *= -1;
                }
                if (denominatorN == 1 || denominatorN == -1) return (numeratorN * denominatorN).ToString();
                if ((numeratorN > 0 && denominatorN < 0) || (numeratorN < 0 && denominatorN > 0))
                {
                    integral.Append("-");
                    if (numeratorN < 0) numeratorN *= -1;
                    if (denominatorN < 0) denominatorN *= -1;
                }

                long rem = numeratorN % denominatorN;
                long num = numeratorN / denominatorN;
                integral.Append(num.ToString()+".");
                if (rem == 0) return integral.ToString();

                num = num > 0 ? num * 10 : rem * 10;
                var m = new Dictionary<long, int>();
                var dec = new List<long>();
                var index = 0;
                var hasPeriodic = false;
                while (num > 0)
                {
                    var d = num / denominatorN;
                    rem = num % denominatorN;
                    if (!m.TryGetValue(d, out index))
                    {
                        m.Add(d, dec.Count);
                        dec.Add(d);
                    }
                    else
                    {
                        hasPeriodic = true;
                        break;
                    }
                    num = rem * 10;
                }
                if (!hasPeriodic) integral.Append(string.Join("", dec));
                else
                {
                    if(index > 0) integral.Append(string.Join("", dec.GetRange(0, index)));
                    integral.Append("(");
                    integral.Append(string.Join("", dec.GetRange(index, dec.Count - index)));
                    integral.Append(")");
                }
                return integral.ToString();
            }
        }
    }
}
