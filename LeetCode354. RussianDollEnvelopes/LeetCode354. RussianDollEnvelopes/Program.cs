using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode354.RussianDollEnvelopes
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.MaxEnvelopes(new int[,] { { 5, 4 }, { 6, 4 }, { 6, 7 }, { 2, 3 } });
            r = s.MaxEnvelopes(new int[,] { { 5, 4 }, { 1, 5 }, { 6, 4 }, { 6, 7 }, { 2, 3 } });
            r = s.MaxEnvelopes(new int[,] { { 2, 100}, { 3, 200}, { 4, 300}, { 5, 500}, { 5, 400}, { 5, 250}, { 6, 370},{ 6, 360},{ 7, 380} });
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
                lTuples.Sort();
                var usedIndex = new HashSet<int>();
                for (int i = 0; i < lTuples.Count; ++i)
                {
                    //if (usedIndex.Add(i))
                    //{
                        var s = new Stack<Tuple<int, int>>();
                        s.Push(lTuples[i]);
                        for (int j = i + 1; j < lTuples.Count; ++j)
                        {
                            if (s.Peek().Item1 < lTuples[j].Item1 && s.Peek().Item2 < lTuples[j].Item2)
                            {
                                s.Push(lTuples[j]);
                                usedIndex.Add(j);
                            }
                        }

                        max = Math.Max(max, s.Count);
                    //}
                }

                return max;
            }
        }
    }
}
