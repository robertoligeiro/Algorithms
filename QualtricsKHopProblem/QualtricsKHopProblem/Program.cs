using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualtricsKHopProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("slc", "sea"),
                new Tuple<string, string>("sea", "lax"),
                new Tuple<string, string>("sea", "cwz"),
                new Tuple<string, string>("lax", "nyc"),
            };

            var r = kHop("slc", "nyc", 3, l);
        }

        public static bool kHop(string src, string dest, int hops, List<Tuple<string, string>> tickets)
        {
            if (hops < 0) return false;
            hops--;
            foreach (var t in tickets)
            {
                if (src == t.Item1)
                {
                    if (hops == 0 && t.Item2 == dest) return true;

                    var localTickets = new List<Tuple<string, string>>(tickets);
                    localTickets.Remove(t);
                    if (kHop(t.Item2, dest, hops, localTickets)) return true;
                }
            }

            return false;
        }
    }
}
