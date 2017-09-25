using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode395.LongestSubstringwAtLeastKRepChars
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.LongestSubstring("aaabb", 3); //3
            r = s.LongestSubstring("aaabbb", 3); //3
            r = s.LongestSubstring("bbaaacbd", 3); //3
            r = s.LongestSubstring("abcabcabcdabcabc", 3); //9
            r = s.LongestSubstring("aacbbdbc", 2); //3
        }

        public class Solution
        {
            public int LongestSubstring(string s, int k)
            {
                if (string.IsNullOrEmpty(s)) return 0;
                var b = new List<char>();
                var h = new List<char>();
                PopulateHist(s, k, b, h);
                if (b.Count == 0 && h.Count > 0)
                {
                    return s.Length;
                }
                else if (b.Count == 0 || h.Count == 0) return 0;

                var mid = s.IndexOf(b.First());
                var lower = mid > 0 ? s.Substring(0, mid) : string.Empty;
                var upper = mid < s.Length ? s.Substring(mid + 1, s.Length - mid - 1) : string.Empty;
                var cLower = LongestSubstring(lower, k);
                var cUpper = LongestSubstring(upper, k);
                return Math.Max(cLower, cUpper);
            }

            public void PopulateHist(string s, int k, List<char> b, List<char> h)
            {
                var hist = new Dictionary<char, int>();
                foreach (var c in s)
                {
                    var count = 0;
                    if (hist.TryGetValue(c, out count)) { hist[c] = ++count; }
                    else hist.Add(c, 1);
                }

                foreach (var t in hist)
                {
                    if (t.Value < k) b.Add(t.Key);
                    else h.Add(t.Key);
                }
            }
        }

        // Solution 2 - code is cleaner, but is worse is perf.
        public class Solution2
        {
            public int LongestSubstring(string s, int k)
            {
                if (string.IsNullOrEmpty(s)) return 0;
                var hist = new Dictionary<char, int>();
                foreach (var c in s)
                {
                    var count = 0;
                    if (hist.TryGetValue(c, out count)) { hist[c] = ++count; }
                    else hist.Add(c, 1);
                }
                return LongestSubstring(s, k, hist);
            }

            private int LongestSubstring(string s, int k, Dictionary<char, int> m)
            {
                if (string.IsNullOrWhiteSpace(s)) return 0;
                var max = s.Length;
                foreach (var t in m)
                {
                    if (t.Value < k)
                    {
                        var index = s.IndexOf(t.Key);
                        if (index != -1)
                        {
                            var left = LongestSubstring(s.Substring(0, index), k);
                            var right = LongestSubstring(s.Substring(index + 1, s.Length - index - 1), k);
                            max = Math.Max(left, right);
                        }
                    }
                }
                return max;
            }
        }


    }
}
