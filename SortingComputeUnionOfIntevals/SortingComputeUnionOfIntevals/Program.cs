using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingComputeUnionOfIntevals
{
    class Program
    {
        static void Main(string[] args)
        {
            var events = new List<Event>()
            {
                new Event { start = new Point { val = 0, isClosed = false}, end = new Point { val = 3, isClosed = false} },
                new Event { start = new Point { val = 1, isClosed = true}, end = new Point { val = 1, isClosed = true} },
                new Event { start = new Point { val = 2, isClosed = true}, end = new Point { val = 4, isClosed = true} },
                new Event { start = new Point { val = 3, isClosed = true}, end = new Point { val = 4, isClosed = false} },
                new Event { start = new Point { val = 5, isClosed = true}, end = new Point { val = 7, isClosed = false} },
                new Event { start = new Point { val = 7, isClosed = true}, end = new Point { val = 8, isClosed = false} },
                new Event { start = new Point { val = 8, isClosed = true}, end = new Point { val = 11, isClosed = false} },
                new Event { start = new Point { val = 9, isClosed = false}, end = new Point { val = 11, isClosed = true} },
                new Event { start = new Point { val = 12, isClosed = false}, end = new Point { val = 16, isClosed = true} },
                new Event { start = new Point { val = 12, isClosed = true}, end = new Point { val = 14, isClosed = true} },
                new Event { start = new Point { val = 13, isClosed = false}, end = new Point { val = 15, isClosed = false} },
                new Event { start = new Point { val = 16, isClosed = false}, end = new Point { val = 17, isClosed = false} },
            };

            var r = CalcIntervals(events);
        }

        public class Point : IComparable
        {
            public int val { get; set; }
            public bool isClosed { get; set; }

            public int CompareTo(object obj)
            {
                Point p = obj as Point;
                if (p.val > val) return -1;
                if (p.val < val) return 1;
                if (p.val == val)
                {
                    if (isClosed) return -1;
                }
                return 1;
            }
        }
        public class Event
        {
            public Point start { get; set; }
            public Point end { get; set; }
        }

        public static int CompareEvents(Event a, Event b)
        {
            return a.start.CompareTo(b.start);

        }
        public static List<Event> CalcIntervals(List<Event> a)
        {
            var response = new List<Event>();
            if (a == null || a.Count == 0) return response;
            a.Sort(CompareEvents);
            response.Add(a.FirstOrDefault());
            a.RemoveAt(0);
            var curr = response[0];
            foreach (var e in a)
            {
                if (e.start.val <= curr.end.val)
                {
                    if (e.end.val > curr.end.val)
                    {
                        curr.end = e.end;
                    }
                    else
                    {
                        if (e.end.val == curr.end.val)
                        {
                            curr.end.isClosed = curr.end.isClosed || e.end.isClosed;
                        }
                    }
                }
                else
                {
                    response.Add(e);
                    curr = e;
                }
            }

            return response;
        }
    }
}
