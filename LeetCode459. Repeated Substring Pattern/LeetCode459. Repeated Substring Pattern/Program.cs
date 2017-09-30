using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode459.Repeated_Substring_Pattern
{
    class Program
    {
        //https://leetcode.com/problems/repeated-substring-pattern/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.RepeatedSubstringPattern("aabaab");
        }

        public class Solution
        {
            public bool RepeatedSubstringPattern(string s)
            {
                for (int i = 1; i <= s.Length / 2; ++i)
                {
                    if (s.Length % i == 0)
                    {
                        var shiftedString = GetLeftShift(s, i);
                        if (shiftedString == s) return true;
                    }
                }
                return false;
            }
            private string GetLeftShift(string s, int index)
            {
                string ret = s.Substring(index);
                ret += s.Substring(0, index);
                return ret;
            }
        }

        //non optimal.
        public class Solution2
        {
            public bool RepeatedSubstringPattern(string s)
            {
                var sb = new StringBuilder();
                for (int i = 1; i <= s.Length/2; ++i)
                {
                    sb.Append(s[i - 1]);
                    var isRep = true;
                    for (int j = i; j < s.Length; j+=i)
                    {
                        if (j + i > s.Length || sb.ToString() != s.Substring(j, i))
                        {
                            isRep = false;
                            break;
                        }
                    }
                    if (isRep) return isRep;
                }
                return false;
            }
        }
    }
}
