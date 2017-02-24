using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsSpreadSheetColumnEncoder
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = GetColumnEncode("AAA");
        }

        public static int GetColumnEncode(string s)
        {
            var r = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                r = r * 26 + s[i] - 'A' + 1;
            }

            return r;
        }
    }
}
