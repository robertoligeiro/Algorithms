using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingMergeDisjointIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = MergeInterval(new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(-4,-1),
                new Tuple<int, int>(0,2),
                new Tuple<int, int>(3,6),
                new Tuple<int, int>(7,9),
                new Tuple<int, int>(11,12),
                new Tuple<int, int>(14,17)
            },
            new Tuple<int, int>(1,8));
        }

        public static List<Tuple<int, int>> MergeInterval(List<Tuple<int, int>> a, Tuple<int, int> i)
        {
            var resp = new List<Tuple<int, int>>();
            var count = 0;
            foreach (var t in a)
            {
                count++;
                if (i.Item1 > t.Item2)
                {
                    resp.Add(t);
                    continue;
                }

                if (i.Item2 > t.Item2)
                {
                    i = new Tuple<int, int>(Math.Min(i.Item1, t.Item1), Math.Max(i.Item2, t.Item2));
                }
                else
                {
                    i = new Tuple<int, int>(Math.Min(i.Item1, t.Item1), t.Item2);
                    resp.Add(i);
                    break;
                }
            }
            a.RemoveRange(0, count);
            resp.AddRange(a);
            return resp;
        }
    }
}
