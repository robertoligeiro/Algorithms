using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode179.LargestNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            //var r = s.LargestNumber(new int[] { 3,30,34,5,9});
            var r = s.LargestNumber(new int[] { 824, 938, 1399, 5607, 6973, 5703, 9609, 4398, 8247 });
            //var r = s.LargestNumber(new int[] { 3, 43, 48, 94, 85, 33, 64, 32, 63, 66 });
            //var r = s.LargestNumber(new int[] { 121,12 });
        }

        public class Solution
        {
            public string LargestNumber(int[] nums)
            {
                if (nums == null || nums.Length == 0) return string.Empty;

                var s = new List<string>();
                var t = 0;
                foreach (var i in nums)
                {
                    s.Add(i.ToString());
                    t += i;
                }
                if (t == 0) return "0";

                s.Sort(Compare);
                return string.Join("", s.ToArray());
            }

            public int Compare(string s1, string s2)
            {
                string ss1 = s1 + s2;
                string ss2 = s2 + s1;
                return ss2.CompareTo(ss1);
            }
        }
    }
}
