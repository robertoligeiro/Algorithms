using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode539.MinimumTimeDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.FindMinDifference(new List<string>() { "23:59", "00:00" });
        }
        public class Solution
        {
            public int FindMinDifference(IList<string> timePoints)
            {
                double minSoFar = 1441;
                timePoints.ToList().Sort();
                TimeSpan prev = TimeSpan.Parse(timePoints[0]);
                for (int i = 1; i < timePoints.Count; ++i)
                {
                    TimeSpan curr = TimeSpan.Parse(timePoints[i]);
                    var diff = curr.TotalMinutes == 0 ? 1440 - prev.TotalMinutes : curr.TotalMinutes - prev.TotalMinutes;
                    minSoFar = diff < minSoFar ? diff : minSoFar;
                }

                return (int)minSoFar;
            }
        }
    }
}
