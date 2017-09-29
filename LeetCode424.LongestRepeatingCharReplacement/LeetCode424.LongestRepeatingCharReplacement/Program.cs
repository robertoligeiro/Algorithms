using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode424.LongestRepeatingCharReplacement
{
    class Program
    {
        //https://leetcode.com/problems/longest-repeating-character-replacement/discuss/
        // SOLUTION: http://massivealgorithms.blogspot.com/2016/10/leetcode-424-longest-repeating.html
        static void Main(string[] args)
        {
            var s = new Solution();
            //var r = s.CharacterReplacement("AABABBA", 1);
            var r = s.CharacterReplacement("ABCDBAFGHA", 2);
        }
        public class Solution
        {
            public int CharacterReplacement(string s, int k)
            {
                int[] count = new int[128];
                int max = 0;
                int start = 0;
                for (int end = 0; end < s.Length; end++)
                {
                    max = Math.Max(max, ++count[s[end] - 'A']);
                    if (max + k <= end - start)
                        count[s[start++] - 'A']--;
                }
                return s.Length - start;
            }
        }
    }
}
