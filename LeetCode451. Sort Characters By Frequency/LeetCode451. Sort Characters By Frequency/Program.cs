using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode451.Sort_Characters_By_Frequency
{
    class Program
    {
        //https://leetcode.com/problems/sort-characters-by-frequency/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.FrequencySort("    tree");
        }

        //no sorting.
        public class Solution
        {
            public string FrequencySort(string s)
            {
                var h = new Dictionary<char, int>();
                foreach (var c in s)
                {
                    var count = 0;
                    if (h.TryGetValue(c, out count))
                    {
                        h[c] = ++count;
                    }
                    else h.Add(c, 1);
                }

                var freqBucket = new string[s.Length + 1];
                foreach (var kvp in h)
                {
                    freqBucket[kvp.Value] += new string(Enumerable.Repeat(kvp.Key, kvp.Value).ToArray());
                }

                var resp = new StringBuilder();
                for (int i = freqBucket.Length - 1; i >= 0; --i)
                {
                    if (!string.IsNullOrEmpty(freqBucket[i]))
                    {
                        resp.Append(freqBucket[i]);
                    }
                }
                return resp.ToString();
            }
        }

        //with sorting. 
        //leetcode accepts both.
        public class Solution1
        {
            public string FrequencySort(string s)
            {
                var h = new Dictionary<char, int>();
                foreach (var c in s)
                {
                    var count = 0;
                    if (h.TryGetValue(c, out count))
                    {
                        h[c] = ++count;
                    }
                    else h.Add(c, 1);
                }

                var lTuples = h.ToList();
                lTuples.Sort(CompareKeyValuePair);
                var resp = new StringBuilder();
                foreach (var kvp in lTuples)
                {
                    resp.Append(new string(Enumerable.Repeat(kvp.Key, kvp.Value).ToArray()));
                }
                return resp.ToString();
            }

            private int CompareKeyValuePair(KeyValuePair<char, int> a, KeyValuePair<char, int> b)
            {
                return b.Value.CompareTo(a.Value);
            }
        }
    }
}
