using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode15._3Sumv2
{
    class Program
    {
        //https://leetcode.com/problems/3sum/tabs/description
        static void Main(string[] args)
        {
            var a = new int[] { 13, 14, 1, 2, -11, -11, -1, 5, -1, -11, -9, -12, 5, -3, -7, -4, -12, -9, 8, -13, -8, 2, -6, 8, 11, 7, 7, -6, 8, -9, 0, 6, 13, -14, -15, 9, 12, -9, -9, -4, -4, -3, -9, -14, 9, -8, -11, 13, -10, 13, -15, -11, 0, -14, 5, -4, 0, -3, -3, -7, -4, 12, 14, -14, 5, 7, 10, -5, 13, -14, -2, -6, -9, 5, -12, 7, 4, -8, 5, 1, -10, -3, 5, 6, -9, -5, 9, 6, 0, 14, -15, 11, 11, 6, 4, -6, -10, -1, 4, -11, -8, -13, -10, -2, -1, -7, -9, 10, -7, 3, -4, -2, 8, -13 };
            var s = new Solution();
            var r = s.ThreeSum(a);
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
