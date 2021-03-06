﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode15._3SumToZero
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
            //var r = s.ThreeSum(new int[] { 0, 0, 0, 0 });
        }

        public class Solution
        {
            public IList<IList<int>> ThreeSum(int[] nums)
            {
                var lnums = new List<int>(nums);
                lnums.Sort();
                var resp = new List<IList<int>>();
                for (int i = 0; i < lnums.Count; ++i)
                {
                    if (i == 0 || lnums[i] != lnums[i - 1])
                    {
                        var l = i + 1;
                        var r = lnums.Count - 1;
                        while (l < r)
                        {
                            var sum = lnums[i] + lnums[l] + lnums[r];
                            if (sum == 0)
                            {
                                resp.Add(new List<int>() { lnums[i], lnums[l], lnums[r] });
                                while (l < r && lnums[l] == lnums[l + 1]) l++;
                                while (l < r && lnums[r] == lnums[r - 1]) r--;
                                l++;
                                r--;
                            }
                            else
                            {
                                if (sum > 0) r--;
                                else l++;
                            }
                        }
                    }
                }
                return resp;
            }
        }


    }
}
