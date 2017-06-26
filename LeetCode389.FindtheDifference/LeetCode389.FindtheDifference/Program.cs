using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode389.FindtheDifference
{
    class Program
    {
        //https://leetcode.com/problems/find-the-difference/#/description
        static void Main(string[] args)
        {
        }
        public class Solution
        {
            public char FindTheDifference(string s, string t)
            {
                var h = new Dictionary<char,int>();
                foreach (var c in s)
                {
                    var count = 0;
                    if (h.TryGetValue(c, out count))
                    {
                        h[c] = ++count;
                    }
                    else h.Add(c, 1);
                }
                foreach (var c in t)
                {
                    var count = 0;
                    if (h.TryGetValue(c, out count))
                    {
                        if (--count == 0)
                        {
                            h.Remove(c);
                        }
                        else h[c] = count;
                    }
                    else return c;
                }

                return h.FirstOrDefault().Key;
            }
        }
    }
}
