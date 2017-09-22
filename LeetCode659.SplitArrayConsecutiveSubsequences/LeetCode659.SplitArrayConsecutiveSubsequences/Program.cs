using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode659.SplitArrayConsecutiveSubsequences
{
    class Program
    {
        //https://leetcode.com/problems/split-array-into-consecutive-subsequences/description/
        // not passing in leetcode - time exceeded.
        // solution is based from here: https://leetcode.com/problems/split-array-into-consecutive-subsequences/discuss/
        static void Main(string[] args)
        {
            var s = new Solution();
            //var r = s.IsPossible(new int[] { 1, 2, 3, 3, 4, 4, 5, 5});
            //var r = s.IsPossible(new int[] { 1, 2, 3, 3, 4, 5 });
            var r = s.IsPossible(new int[] { 1, 2, 3, 4, 4, 5 });
        }
        public class Solution
        {
            public bool IsPossible(int[] nums)
            {
                var sequences = new List<SortedSet<int>>();

                foreach (var i in nums)
                {
                    var listsToAdd = new List<int>();
                    for(int index = 0; index < sequences.Count; ++index)
                    {
                        if (sequences[index].Last() == i - 1) listsToAdd.Add(index);
                    }
                    if (listsToAdd.Count == 0) sequences.Add(new SortedSet<int>() { i });
                    else
                    {
                        var min = int.MaxValue;
                        var indexToAdd = 0;
                        foreach(var index in listsToAdd)
                        {
                            if (sequences[index].Count < min)
                            {
                                min = sequences[index].Count;
                                indexToAdd = index;
                            }
                        }
                        sequences[indexToAdd].Add(i);
                    }
                }

                foreach (var l in sequences) if (l.Count < 3) return false;
                return true;
            }
        }
    }
}
