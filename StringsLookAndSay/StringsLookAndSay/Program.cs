using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsLookAndSay
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = LookAndSay(5);
        }

        public static List<List<int>> LookAndSay(int n)
        {
            var r = new List<List<int>>() { new List<int>() { 1 } };
            LookAndSay(--n, r);
            return r;
        }

        public static void LookAndSay(int n, List<List<int>> r)
        {
            if (n == 0) return;
            var curr = r.LastOrDefault();
            var count = 1;
            var prev = curr[0];
            var l = new List<int>();
            for (int i = 1; i < curr.Count; ++i)
            {
                if (prev == curr[i]) count++;
                else
                {
                    l.Add(count);
                    l.Add(prev);
                    count = 1;
                    prev = curr[i];
                }
            }
            l.Add(count);
            l.Add(prev);
            r.Add(l);
            LookAndSay(--n, r);
        }
    }
}
