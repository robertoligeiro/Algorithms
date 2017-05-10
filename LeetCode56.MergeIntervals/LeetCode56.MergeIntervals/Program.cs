using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode56.MergeIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<Interval>() { new Interval(1,3), new Interval(8,10), new Interval(2, 6), new Interval(15,18)};
            //var l = new List<Interval>() { new Interval(2, 3), new Interval(4, 5), new Interval(6, 7), new Interval(8, 9), new Interval(1, 10)};
            var s = new Solution();
            var r = s.Merge(l);
        }

 //**
 //Definition for an interval.
  public class Interval {
      public int start;
      public int end;
      public Interval() { start = 0; end = 0; }
      public Interval(int s, int e) { start = s; end = e; }
  }
 
        public class Solution
        {
            public IList<Interval> Merge(IList<Interval> intervals)
            {
                var resp = new List<Interval>();
                if (intervals == null) return resp;
                var inter = new List<Interval>(intervals);
                inter.Sort(CompareIntervals);
                var curr = inter.FirstOrDefault();
                for (int i = 1; i < inter.Count; ++i)
                {
                    if (inter[i].start <= curr.end)
                    {
                        curr.end = Math.Max(curr.end, inter[i].end);
                        curr.start = Math.Min(curr.start, inter[i].start);
                    }
                    else
                    {
                        resp.Add(curr);
                        curr = new Interval(inter[i].start, inter[i].end);
                    }
                }

                if (curr != null) resp.Add(curr);
                return resp;
            }

            public int CompareIntervals(Interval a, Interval b)
            {
                if (a.start > b.start) return 1;
                if (a.start < b.start) return -1;
                if (a.start == b.start)
                {
                    if (a.end > b.end) return 1; 
                }
                return -1;
            }
        }
    }
}
