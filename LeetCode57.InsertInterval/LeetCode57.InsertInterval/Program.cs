using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode57.InsertInterval
{
    class Program
    {
        //https://leetcode.com/problems/insert-interval/#/description
        static void Main(string[] args)
        {
            var s = new Solution();
            //var r = s.Insert(new List<Interval>() { new Interval(1, 3), new Interval(6, 9) }, new Interval(2, 5));
            var r = s.Insert(new List<Interval>() { new Interval(1, 2), new Interval(3, 5), new Interval(6, 7), new Interval(8, 10), new Interval(12, 16) }, new Interval(4, 9));
        }

        public class Interval {
      public int start;
      public int end;
      public Interval() { start = 0; end = 0; }
      public Interval(int s, int e) { start = s; end = e; }
  }

        public class Solution
        {
            public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval)
            {
                var resp = new List<Interval>();
                int i = 0;
                while (i < intervals.Count && intervals[i].end < newInterval.start)
                {
                    resp.Add(intervals[i]);
                    ++i;
                }

                while (i < intervals.Count && newInterval.start <= intervals[i].end && newInterval.end >= intervals[i].start)
                {
                    newInterval = new Interval(Math.Min(intervals[i].start, newInterval.start), Math.Max(intervals[i].end, newInterval.end));
                    ++i;
                }

                resp.Add(newInterval);
                resp.AddRange(intervals.ToList().GetRange(i, intervals.Count - i));
                return resp;
            }
        }
    }
}
