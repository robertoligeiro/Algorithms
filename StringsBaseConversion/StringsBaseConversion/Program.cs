using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsBaseConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = BaseConversion("615", 7, 13);
        }

        public static string BaseConversion(string s, int b1, int b2)
        {
            int vB1 = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                vB1 = vB1 * b1 + s[i] - '0';
            }

            StringBuilder r = new StringBuilder();
            while (vB1 > 0)
            {
                var rem = vB1 % b2;

                if (rem < 10)
                {
                    r.Append(rem);
                }
                else
                {
                    rem = 'A' + rem - 10;
                    char c = Convert.ToChar(rem);
                    r.Append(c);
                }
                vB1 /= b2;
            }

            return new string(r.ToString().Reverse().ToArray());
        }
    }
}
