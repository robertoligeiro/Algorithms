using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode495.TeemoAttacking
{
    class Program
    {
        //https://leetcode.com/problems/teemo-attacking/#/description
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.FindPoisonedDuration(new int[] { 1, 4 }, 2);
            r = s.FindPoisonedDuration(new int[] { 1, 2 }, 2);
            r = s.FindPoisonedDuration(new int[] { 1, 2, 3, 6 }, 3);
        }

        public class Solution
        {
            public int FindPoisonedDuration(int[] timeSeries, int duration)
            {
                var intervals = new List<Tuple<int, int>>();
                foreach(var i in timeSeries)
                {
                    intervals.Add(new Tuple<int, int>(i, i + duration - 1));
                }
                if (intervals.Count == 0) return 0;

                var poisonedDuration = new List<Tuple<int, int>>();
                var curr = intervals[0];
                for (int i = 1; i < intervals.Count; ++i)
                {
                    if (curr.Item2 < intervals[i].Item1)
                    {
                        poisonedDuration.Add(curr);
                        curr = intervals[i];
                    }
                    else
                    {
                        curr = new Tuple<int, int>(curr.Item1, intervals[i].Item2);
                    }
                }
                poisonedDuration.Add(curr);
                var poisonedHeart = 0;
                foreach (var t in poisonedDuration)
                {
                    poisonedHeart += (t.Item2 - t.Item1) + 1;
                }
                return poisonedHeart;
            }
        }
    }
}
