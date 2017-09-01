using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode436.Find_Right_Interval
{
    class Program
    {
        //https://leetcode.com/problems/find-right-interval/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.FindRightInterval(new Interval[] { new Interval(3, 4), new Interval(2, 3), new Interval(1, 2) });
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
            public int[] FindRightInterval(Interval[] intervals)
            {
                var sortedStarts = new List<Tuple<int,int>>();
                var sortedEnds = new List<Tuple<int, int>>();
                for (int i = 0; i < intervals.Length; ++i)
                {
                    sortedStarts.Add(new Tuple<int, int>(intervals[i].start, i));
                    sortedEnds.Add(new Tuple<int, int>(intervals[i].end, i));
                }
                sortedStarts.Sort();
                sortedEnds.Sort();
                var resp = new int[intervals.Length];
                for (int i = 0; i < sortedEnds.Count; ++i)
                {
                    var index = BinSearch(sortedStarts, sortedEnds[i]);
                    resp[sortedEnds[i].Item2] = index;
                }
                return resp;
            }

            private int BinSearch(List<Tuple<int, int>> starts, Tuple<int, int> curr)
            {
                var l = 0;
                var r = starts.Count - 1;
                while (l <= r)
                {
                    var mid = l + (r - l) / 2;
                    if (starts[mid].Item1 < curr.Item1)
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        if (mid > 0 && starts[mid - 1].Item1 >= curr.Item1)
                        {
                            r = mid - 1;
                        }
                        else return starts[mid].Item2;
                    }
                }
                return -1;
            }
        }
    }
}
