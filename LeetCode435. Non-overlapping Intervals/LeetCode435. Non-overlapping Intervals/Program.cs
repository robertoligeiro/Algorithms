using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode435.Non_overlapping_Intervals
{
    class Program
    {
        //https://leetcode.com/problems/non-overlapping-intervals/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var i1 = new Interval[] { new Interval(1, 3), new Interval(3, 4), new Interval(2, 3), new Interval(1, 2) };
            var i2 = new Interval[] { new Interval(1, 2), new Interval(1, 2), new Interval(1, 2) };
            var i3 = new Interval[] { new Interval(1, 2), new Interval(2, 3) };
            var r = s.EraseOverlapIntervals(i1);
        }

        public class Interval
        {
            public int start;
            public int end;
            public Interval() { start = 0; end = 0; }
            public Interval(int s, int e) { start = s; end = e; }
        }

        public class Solution
        {
            public int EraseOverlapIntervals(Interval[] intervals)
            {
                if (intervals == null || intervals.Length == 0) return 0;
                Array.Sort(intervals, SortIntervals);
                var countNotRemoved = 1;
                var end = intervals[0].end;
                for (int i = 1; i < intervals.Length; ++i)
                {
                    if (intervals[i].start >= end)
                    {
                        countNotRemoved++;
                        end = intervals[i].end;
                    }
                }

                return intervals.Length - countNotRemoved;
            }

            public int SortIntervals(Interval i1, Interval i2)
            {
                return i1.end.CompareTo(i2.end);
            }
        }
    }
}
