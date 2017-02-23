using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsIntToString
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = IntToString(-345);
        }

        public static string IntToString(int x)
        {
            bool isNeg = x < 0;
            StringBuilder s = new StringBuilder();
            x = isNeg ? -x : x;
            while (x > 0)
            {
                var p = x % 10;
                x /= 10;
                s.Append(p);
            }

            if (isNeg) s.Append("-");
            return new string(s.ToString().Reverse().ToArray());
        }
    }
}
