using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode473.MatchstickstoSquare
{
    class Program
    {
        //https://leetcode.com/problems/matchsticks-to-square/#/description
        // not working.
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.Makesquare(new int[] { 2,2,1,3,3,3});
        }

        public class Solution
        {
            public bool Makesquare(int[] nums)
            {
                if (nums.Length < 4) return false;
                var values = new List<int>(nums);
                values.Sort();
                var prev = values[0];
                var found = new List<int>() { prev };
                for (int i = 1; i < values.Count; ++i)
                {
                    if (values[i] == 0) continue;
                    var curr = values[i];
                    if (curr == prev)
                    {
                        found.Add(curr);
                        if (found.Count == 4) return true;
                    }
                    else
                    {
                        if (CanMakeSquare(values, found, i - found.Count)) return true;
                        prev = curr;
                        found = new List<int> { prev };
                    }
                }
                return CanMakeSquare(values, found, values.Count - found.Count);
            }

            private bool CanMakeSquare(List<int> values, List<int> found, int end)
            {
                if (end <= 0) return false;
                var used = new HashSet<int>();
                var combValues = new List<int>(values.GetRange(0, end));
                Comb(combValues, found, used, found.First(), 0);
                return found.Count == 4;
            }

            private bool Comb(List<int> values, List<int> found, HashSet<int> used, int tgt, int acc)
            {
                if (acc == tgt || found.Count == 4)
                {
                    found.Add(tgt);
                    return true;
                }
                var f = false;
                for (int i = 0; i < values.Count; ++i)
                {
                    if (used.Add(i))
                    {
                        acc += values[i];
                        if (!Comb(values, found, used, tgt, acc))
                        {
                            used.Remove(values[i]);
                            acc -= values[i];
                        }
                        else
                        {
                            f = true;
                            acc = 0;
                            if (found.Count == 4) break;
                        }
                    }
                }

                return f;
            }
        }
    }
}
