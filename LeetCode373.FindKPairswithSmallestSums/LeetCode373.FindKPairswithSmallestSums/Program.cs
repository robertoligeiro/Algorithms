using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode373.FindKPairswithSmallestSums
{
    class Program
    {
        //https://leetcode.com/problems/find-k-pairs-with-smallest-sums/tabs/description
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.KSmallestPairs(new int[] { 1, 1, 2 }, new int[] { 1, 2, 3 }, 10);
            r = s.KSmallestPairs(new int[] {  }, new int[] {  }, 2);
        }

        public class Solution
        {
            public class Pair : IComparable
            {
                public int sum;
                public int[] nums;

                public int CompareTo(object obj)
                {
                    var p2 = obj as Pair;
                    return this.sum.CompareTo(p2.sum);
                }
            }
            public IList<int[]> KSmallestPairs(int[] nums1, int[] nums2, int k)
            {
                if (nums1 == null || nums2 == null || nums1.Length == 0 || nums2.Length == 0) return new List<int[]>();
                var first = nums1[0] <= nums2[0] ? nums1 : nums2;
                var second = nums1[0] <= nums2[0] ? nums2 : nums1;
                var resp = new List<Pair>();
                for (int i = 0; i < first.Length; ++i)
                {
                    for (int j = 0; j < second.Length; ++j)
                    {
                        if (resp.Count > k && (first[i] >= resp.Last().sum || second[j] >= resp.Last().sum)) continue;
                        var p = new Pair() { sum = first[i] + second[j], nums = new int[] { first[i], second[j] } };
                        if (resp.Count < k)
                        {
                            resp.Add(p);
                        }
                        else
                        {
                            resp.Sort();
                            if (resp.Last().sum > p.sum)
                            {
                                resp.RemoveAt(resp.Count - 1);
                                resp.Add(p);
                            }
                        }
                    }
                }
                var respPair = resp.Select(x => x.nums).ToList();
                respPair.Sort(ComparePairs);
                return respPair;
            }

            private int ComparePairs(int[] p1, int[] p2)
            {
                var p0 = p1[0].CompareTo(p2[0]);
                if (p0 == 0)
                {
                    return p1[1].CompareTo(p2[1]);
                }
                return p0;
            }
        }
    }
}
