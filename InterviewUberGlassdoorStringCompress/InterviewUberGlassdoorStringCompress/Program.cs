using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewUberGlassdoorStringCompress
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = StringCompress("");
            r = StringCompress("a");
            r = StringCompress("aa");
            r = StringCompress("aab");
            r = StringCompress("aaabbzzddd");
            r = StringCompress("aaabbzzddde");
        }

        public static string StringCompress(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return s;
            var curr = s[0];
            var count = 1;
            var resp = new StringBuilder();
            for (int i = 1; i < s.Length; ++i)
            {
                if (s[i] != curr)
                {
                    resp.Append(count + curr.ToString());
                    count = 1;
                    curr = s[i];
                }
                else count++;
            }
            resp.Append(count + curr.ToString());
            return resp.ToString();
        }
    }
}
