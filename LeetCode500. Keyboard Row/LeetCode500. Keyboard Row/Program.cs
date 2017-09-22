using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode500.Keyboard_Row
{
    //https://leetcode.com/problems/keyboard-row/description/
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.FindWords(new string[] { "Hello", "Alaska", "Dad", "Peace" });
        }

        public class Solution
        {
            public string[] FindWords(string[] words)
            {
                var row0 = new HashSet<char>() { 'q','w','e','r','t','y','u','i','o','p'};
                var row1 = new HashSet<char>() { 'a','s','d','f','g','h','j','k','l'};
                var row2 = new HashSet<char>() { 'z','x','c','v','b','n','m'};
                var resp = new List<string>();
                foreach (var w in words)
                {
                    var s = w.ToLower();
                    if (CanAdd(s, row0)) resp.Add(w);
                    else if (CanAdd(s, row1)) resp.Add(w);
                    else if (CanAdd(s, row2)) resp.Add(w);
                }
                return resp.ToArray();
            }
            private bool CanAdd(string w, HashSet<char> row)
            {
                foreach (var c in w)
                {
                    if (!row.Contains(c)) return false;
                }
                return true;
            }
        }
    }
}
