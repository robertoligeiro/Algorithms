using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode521.LongestUncommonSubsequenceI
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            //var r = s.FindLUSlength("aefawfawfawfaw", 
            //                        "aefawfeawfwafwaef");
            var r = s.FindLUSlength("aaa",
                                    "aaa");
        }

        public class Solution
        {
            public int FindLUSlength(string a, string b)
            {
                var parc = new StringBuilder();
                var count = 0;
                var max = 0;
                foreach (var c in a)
                {
                    count++;
                    parc.Append(c);
                    var s = parc.ToString();
                    if (b.IndexOf(s) == -1)
                    {
                        max = count;
                    }
                }
                count = 0;
                parc.Clear();
                foreach (var c in b)
                {
                    count++;
                    parc.Append(c);
                    var s = parc.ToString();
                    if (a.IndexOf(s) == -1)
                    {
                        max = Math.Max(max, count);
                    }
                }

                return max == 0? -1: max;
            }
        }
    }
}
