using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode732.My_Calendar_III
{
	//https://leetcode.com/problems/my-calendar-iii/description/
	class Program
	{
		static void Main(string[] args)
		{
			var s = new MyCalendarThree();
			var r = 0;
			r = s.Book(10, 20);
			r = s.Book(50, 60);
			r = s.Book(10, 40);
			r = s.Book(5, 15);
			r = s.Book(5, 10);
			r = s.Book(25, 55);
		}

		public class EventsComparer : IComparer<Tuple<int, bool>>
		{
			public int Compare(Tuple<int, bool> a, Tuple<int, bool> b)
			{
				if (a.Item1.CompareTo(b.Item1) == 0)
				{
					if (a.Item2 == false) return -1;
					if (b.Item2 == false) return 1;
					return 0;
				}
				return a.Item1.CompareTo(b.Item1);
			}
		}
		public class MyCalendarThree
		{
			private SortedDictionary<Tuple<int,bool>, int> events = new SortedDictionary<Tuple<int, bool>, int>(new EventsComparer());
			public MyCalendarThree()
			{

			}

			public int Book(int start, int end)
			{
				this.AddEvent(start, true);
				this.AddEvent(end, false);
				return this.GetConcurrentEvents();
			}

			private int GetConcurrentEvents()
			{
				var max = 0;
				var concurrent = 0;
				foreach (var t in this.events)
				{
					if (t.Key.Item2)
					{
						concurrent += t.Value;
					}
					else
					{
						concurrent -= t.Value;
					}
					max = Math.Max(max, concurrent);
				}
				return max;
			}
			private void AddEvent(int time, bool isStart)
			{
				var t = new Tuple<int, bool>(time, isStart);
				var count = 0;
				if (this.events.TryGetValue(t, out count))
				{
					this.events[t] = ++count;
				}
				else this.events.Add(t, 1);
			}
		}
	}
}
