using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode56.Merge_Intervals
{
	//https://leetcode.com/problems/merge-intervals/solution/
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.Merge(new List<Interval>() { new Interval(8, 10), new Interval(1, 3), new Interval(15, 18), new Interval(2, 6) });
		}
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
				if (intervals == null || intervals.Count == 0) return resp;

				var inter = new List<Interval>(intervals);
				inter.Sort(SortIntervals);
				var curr = inter[0];
				for (int i = 0; i < inter.Count; ++i)
				{
					if (curr.end >= inter[i].start)
					{
						curr.end = Math.Max(curr.end, inter[i].end);
					}
					else
					{
						resp.Add(curr);
						curr = inter[i];
					}
				}
				resp.Add(curr);
				return resp;
			}

			private int SortIntervals(Interval a, Interval b)
			{
				if (a.start == b.start) return a.end.CompareTo(b.end);
				return a.start.CompareTo(b.start);
			}
		}
	}
}
