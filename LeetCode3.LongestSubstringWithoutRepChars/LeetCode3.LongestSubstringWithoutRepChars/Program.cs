using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode3.LongestSubstringWithoutRepChars
{
    class Program
    {
        //https://leetcode.com/problems/longest-substring-without-repeating-characters/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            //var r = s.LengthOfLongestSubstring("abba");
            var r = s.LengthOfLongestSubstring("abcabcbb");
        }
        public class Solution
        {
            public int LengthOfLongestSubstring(string s)
            {
                var lastWithout = 0;
                var max = 0;
                var m = new Dictionary<char, int>();
                for (int i = 0; i < s.Length; ++i)
                {
                    var index = 0;
                    if (m.TryGetValue(s[i], out index))
                    {
                        var localDist = i - lastWithout;
                        max = Math.Max(localDist, max);
                        lastWithout = lastWithout < index + 1 ? index + 1 : lastWithout;
                        m[s[i]] = i;
                    }
                    else m.Add(s[i], i);
                }
                return Math.Max(max, s.Length - lastWithout);
            }
        }
    }
}
