using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode252.Meeting_Rooms
{
	class Program
	{
		//https://leetcode.com/problems/meeting-rooms/description/
		static void Main(string[] args)
		{
		}

		public class Interval {
			public int start;
			public int end;
			public Interval() { start = 0; end = 0; }
			public Interval(int s, int e) { start = s; end = e; }
		}

		public class Solution
		{
			public bool CanAttendMeetings(Interval[] intervals)
			{
				var sortedIntervals = new List<Interval>(intervals);
				sortedIntervals.Sort(SortIntervals);
				for (int i = 1; i < sortedIntervals.Count; ++i)
				{
					if (sortedIntervals[i].start < sortedIntervals[i - 1].end) return false;
				}
				return true;
			}

			private int SortIntervals(Interval a, Interval b)
			{
				if (a.start.Equals(b.start)) return b.end.CompareTo(a.end);
				return a.start.CompareTo(b.start);
			}
		}
	}
}
