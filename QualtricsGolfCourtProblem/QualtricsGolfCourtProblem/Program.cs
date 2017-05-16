using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualtricsGolfCourtProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<TeamEvent>()
            {
                new TeamEvent() { start = 9, end = 11, count = 2},
                new TeamEvent() { start = 11, end = 13, count = 3},
                new TeamEvent() { start = 12, end = 13, count = 4},
                new TeamEvent() { start = 14, end = 15, count = 5},
            };
            var r = GetMaxPeopleSimultaneosly(l); //resp: s12,e13, tot7
        }

        public class TeamEvent
        {
            public int start;
            public int end;
            public int count;
        }

        public class Event : IComparable
        {
            public int time;
            public bool isStart;
            public int count;

            public int CompareTo(object obj)
            {
                var ev = obj as Event;
                if (this.time == ev.time) return this.isStart ? -1 : 1;
                return this.time.CompareTo(ev.time);
            }
        }

        public static TeamEvent GetMaxPeopleSimultaneosly(List<TeamEvent> e)
        {
            var maxSoFar = new TeamEvent();
            var lEvents = new List<Event>();
            foreach (var ev in e)
            {
                var st = new Event() { time = ev.start, isStart = true, count = ev.count };
                var end = new Event() { time = ev.end, isStart = false, count = ev.count };
                lEvents.Add(st);
                lEvents.Add(end);
            }

            lEvents.Sort();
            var currMax = new TeamEvent();
            foreach (var ev in lEvents)
            {
                if (ev.isStart)
                {
                    currMax.start = ev.time;
                    currMax.count += ev.count;
                }
                else
                {
                    if(currMax.count == maxSoFar.count)
                    {
                        maxSoFar.end = ev.time;
                    }
                    currMax.count -= ev.count;
                }

                if (currMax.count > maxSoFar.count)
                {
                    maxSoFar.count = currMax.count;
                    maxSoFar.start = currMax.start;
                }
            }

            return maxSoFar;
        }
    }
}
