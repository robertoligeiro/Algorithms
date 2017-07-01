using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode354.RussianDollEnvelopes
{
    class Program
    {
        //https://leetcode.com/problems/russian-doll-envelopes/#/description
        //solution based on:https://leetcode.com/problems/russian-doll-envelopes/#/solutions 
        static void Main(string[] args)
        {
            var s = new Solution();
            //var r = s.MaxEnvelopes(new int[,] { { 5, 4 }, { 6, 4 }, { 6, 7 }, { 2, 3 } });
            var r = s.MaxEnvelopes(new int[,] { { 4,5 }, { 4,6 }, { 6, 7 }, { 2, 3 }, { 1, 1 } });
            //r = s.MaxEnvelopes(new int[,] { { 5, 4 }, { 1, 5 }, { 6, 4 }, { 6, 7 }, { 2, 3 } });
            //var r = s.MaxEnvelopes(new int[,] { { 2, 100}, { 3, 200}, { 4, 300}, { 5, 500}, { 5, 400}, { 5, 250}, { 6, 370},{ 6, 360},{ 7, 380} });
        }

        public class Solution
        {
            public int MaxEnvelopes(int[,] envelopes)
            {
                var max = 0;
                var lTuples = new List<Tuple<int, int>>();
                for (int i = 0; i < envelopes.GetLength(0); ++i)
                {
                    lTuples.Add(new Tuple<int, int>(envelopes[i, 0], envelopes[i, 1]));
                }
                lTuples.Sort(CompareEvents);

                return LengthOfLIS(lTuples.Select(x => x.Item2).ToArray());
            }

            private int LengthOfLIS(int[] nums)
            {
                if (nums.Length == 0) return 0;
                var max = 1;
                var increaseCounterArray = Enumerable.Repeat(1, nums.Length).ToArray();
                var i = 1;
                while (i < nums.Length)
                {
                    var j = 0;
                    while (j < i)
                    {
                        if (nums[j] < nums[i])
                        {
                            increaseCounterArray[i] = Math.Max(increaseCounterArray[i], increaseCounterArray[j] + 1);
                            max = Math.Max(max, increaseCounterArray[i]);
                        }
                        ++j;
                    }
                    ++i;
                }
                return max;
            }

            private static int CompareEvents(Tuple<int, int> a, Tuple<int, int> b)
            {
                if (a.Item1 > b.Item1) return 1;
                if (a.Item1 < b.Item1) return -1;
                if (a.Item1 == b.Item1)
                {
                    if (a.Item2 > b.Item2) return -1;
                    if (a.Item2 < b.Item2) return 1;
                }
                return 1;
            }
        }
    }
}
