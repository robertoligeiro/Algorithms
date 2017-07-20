using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode392.IsSubsequence
{
    class Program
    {
        //https://leetcode.com/problems/is-subsequence/#/description
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.IsSubsequence("abc", "ahbgdc");
        }
        public class Solution
        {
            public bool IsSubsequence(string s, string t)
            {
                var m = new Dictionary<char, Queue<int>>();
                for (int i = 0; i < t.Length; ++i)
                {
                    Queue<int> q;
                    if (m.TryGetValue(t[i], out q))
                    {
                        q.Enqueue(i);
                    }
                    else
                    {
                        q = new Queue<int>();
                        q.Enqueue(i);
                        m.Add(t[i], q);
                    }
                }

                var lastIndex = -1;
                foreach (var c in s)
                {
                    Queue<int> q;
                    if(!m.TryGetValue(c, out q))
                    {
                        return false;
                    }
                    var index = -1;
                    while (q.Count > 0)
                    {
                        index = q.Dequeue();
                        if (index > lastIndex)
                        {
                            break;
                        }
                    }
                    if (index == -1 || index < lastIndex) return false;
                    lastIndex = index;
                }
                return true;
            }
        }
    }
}
