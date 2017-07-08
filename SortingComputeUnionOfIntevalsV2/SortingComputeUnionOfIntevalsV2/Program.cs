using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingComputeUnionOfIntevalsV2
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<Interval>()
            {
                new Interval() { start = new Tuple<int, bool>(0,true), end = new Tuple<int, bool>(3, false)},
                new Interval() { start = new Tuple<int, bool>(1,true), end = new Tuple<int, bool>(1,true)},
                new Interval() { start = new Tuple<int, bool>(2,true), end = new Tuple<int, bool>(4,true)},
                new Interval() { start = new Tuple<int, bool>(3,true), end = new Tuple<int, bool>(4,false)},
                new Interval() { start = new Tuple<int, bool>(5,true), end = new Tuple<int, bool>(7,false)},
                new Interval() { start = new Tuple<int, bool>(7,true), end = new Tuple<int, bool>(8,false)},
                new Interval() { start = new Tuple<int, bool>(8,true), end = new Tuple<int, bool>(11,false)},
                new Interval() { start = new Tuple<int, bool>(9,false), end = new Tuple<int, bool>(11,true)},
                new Interval() { start = new Tuple<int, bool>(12,true), end = new Tuple<int, bool>(16,true)},
                new Interval() { start = new Tuple<int, bool>(12,true), end = new Tuple<int, bool>(14,false)},
                new Interval() { start = new Tuple<int, bool>(13,false), end = new Tuple<int, bool>(15,false)},
                new Interval() { start = new Tuple<int, bool>(16,false), end = new Tuple<int, bool>(17,false)},
            };

            var r = UnionIntervals(l);
        }

        public class Interval
        {
            public Tuple<int, bool> start { get; set; }
            public Tuple<int, bool> end { get; set; }
        }

        public static List<Interval> UnionIntervals(List<Interval> intervals)
        {
            var resp = new List<Interval>();
            resp.Sort(CompareIntervals);
            var curr = intervals[0];
            for (int i = 1; i < intervals.Count; ++i)
            {
                var next = intervals[i];
                if (curr.end.Item1 >= next.start.Item1)
                {
                    if (curr.end.Item1 <= next.end.Item1)
                    {
                        if (curr.end.Item1 < next.end.Item1 ||
                           curr.end.Item2 == false)
                        {
                            curr.end = next.end;
                        }
                    }
                }
                else
                {
                    resp.Add(curr);
                    curr = next;
                }
            }
            resp.Add(curr);
            return resp;
        }

        public static int CompareIntervals(Interval a, Interval b)
        {
            if (a.start.Item1 < b.start.Item1 || 
                (a.start.Item1 == b.start.Item1 && a.start.Item2 == true)) return -1;
            return 1;
        }
    }
}
