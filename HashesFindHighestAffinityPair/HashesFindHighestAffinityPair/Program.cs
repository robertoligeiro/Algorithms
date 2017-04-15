using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashesFindHighestAffinityPair
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("ayhoo", "ap42"),
                new Tuple<string, string>("oogleg", "ap42"),
                new Tuple<string, string>("tweeter", "th1"),
                new Tuple<string, string>("oogleg", "aa314"),
                new Tuple<string, string>("oogleg", "aa314"),
                new Tuple<string, string>("oogleg", "th1"),
                new Tuple<string, string>("tweeter", "aa314"),
                new Tuple<string, string>("tweeter", "ap42"),
                new Tuple<string, string>("ayhoo", "aa314"),
            };

            var r = FindMaxAffinity(l);
        }

        public static Tuple<string, string> FindMaxAffinity(List<Tuple<string, string>> a)
        {
            var pagesPerUser = new Dictionary<string, HashSet<string>>();
            var affinities = new Dictionary<Tuple<string, string>, int>();
            var maxSoFar = 0;
            var resp = new Tuple<string, string>(string.Empty, string.Empty);
            foreach (var t in a)
            {
                HashSet<string> pagesUser;
                if (pagesPerUser.TryGetValue(t.Item2, out pagesUser))
                {
                    if (pagesUser.Add(t.Item1) && pagesUser.Count >= 2)
                    {
                        foreach (var page in pagesUser)
                        {
                            if (page != t.Item1)
                            {
                                var pair = GetTuple(t.Item1, page);
                                var count = 0;
                                if (affinities.TryGetValue(pair, out count))
                                {
                                    affinities[pair] = ++count;
                                    if (count > maxSoFar)
                                    {
                                        maxSoFar = count;
                                        resp = pair;
                                    }
                                }
                                else
                                {
                                    affinities.Add(pair, 1);
                                }
                            }
                        }
                    }
                }
                else
                {
                    pagesPerUser.Add(t.Item2, new HashSet<string>() { t.Item1 });
                }
            }
            return resp;
        }

        public static Tuple<string, string> GetTuple(string a, string b)
        {
            if (string.Compare(a,b) > 0)
            {
                return new Tuple<string, string>(a, b);
            }
            return new Tuple<string, string>(b, a);
        }
    }
}
