using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingCalcNumberMaxConcurrentEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = CalcMaxConcurrentEvents(new List<Tuple<int, int>>() //resp 3 without commented code, with should be 4.
            {
                new Tuple<int, int>(1,5),
                new Tuple<int, int>(2,7),
                new Tuple<int, int>(4,5),
                new Tuple<int, int>(6,10),
                new Tuple<int, int>(8,9),
                new Tuple<int, int>(9,17),
                new Tuple<int, int>(11,13),
                new Tuple<int, int>(12,15),
                new Tuple<int, int>(14,15),
                //new Tuple<int, int>(4,6),
            });
        }

        public static int CompareEvents(Tuple<int, bool> a, Tuple<int, bool> b)
        {
            if (a.Item1 > b.Item1) return 1;
            if (a.Item1 < b.Item1) return -1;
            return a.Item2 == true ? -1 : 1;
        }
        public static int CalcMaxConcurrentEvents(List<Tuple<int, int>> events)
        {
            var maxSoFar = 0;
            var sortedEvents = new List<Tuple<int, bool>>();
            foreach (var e in events)
            {
                sortedEvents.Add(new Tuple<int, bool>(e.Item1, true));
                sortedEvents.Add(new Tuple<int, bool>(e.Item2, false));
            }

            sortedEvents.Sort(CompareEvents);
            var localCount = 0;
            foreach (var e in sortedEvents)
            {
                if (e.Item2) localCount++;
                else localCount--;
                maxSoFar = Math.Max(localCount, maxSoFar);
            }

            return maxSoFar;
        }
    }
}
