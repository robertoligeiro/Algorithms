using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsStringToInt
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = StringToInt("-456");
        }

        public static int StringToInt(string s)
        {
            bool isNeg = s[0] == '-';
            int i = isNeg ? 1 : 0;
            int acc = 0;
            for (; i < s.Length; ++i)
            {
                acc = acc * 10 + (s[i] - '0');
            }

            return isNeg ? -acc : acc;
        }
    }
}
