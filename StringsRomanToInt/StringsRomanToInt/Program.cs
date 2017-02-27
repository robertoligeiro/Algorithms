using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsRomanToInt
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = RomanToInt("lix");
        }

        public static int RomanToInt(string r)
        {
            var rValues = new Dictionary<char, int>() { { 'i', 1 }, { 'v', 5 }, { 'x', 10 },
                                                        { 'l', 50 }, { 'c', 100 }, { 'd', 500 }, { 'm', 1000 } };

            var acc = rValues[r.LastOrDefault()];
            int i = r.Length - 2;
            while (i>=0)
            {
                if (rValues[r[i]] >= rValues[r[i+1]])
                {
                    acc += rValues[r[i]];
                }
                else
                {
                    acc -= rValues[r[i]];
                }
                i--;
            }
            return acc;
        }
    }
}
