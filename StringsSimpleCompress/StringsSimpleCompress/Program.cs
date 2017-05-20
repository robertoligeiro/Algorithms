using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsSimpleCompress
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = SimpleCompress("aabcccaaa");
            r = SimpleCompress("a");
            r = SimpleCompress("abcd");
            r = SimpleCompress("aaa");
            r = SimpleCompress("aaaa");
        }

        public static string SimpleCompress(string s)
        {
            var resp = new StringBuilder();
            for (int i = 0; i < s.Length; ++i)
            {
                resp.Append(s[i]);
                var count = 1;
                while (i + 1 < s.Length && s[i] == s[i + 1])
                {
                    ++count;
                    ++i;
                }
                resp.Append(count.ToString());
            }
            return resp.ToString();
        }
    }
}
