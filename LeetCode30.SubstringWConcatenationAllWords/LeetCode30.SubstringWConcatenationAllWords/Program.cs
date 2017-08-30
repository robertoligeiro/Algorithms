using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode30.SubstringWConcatenationAllWords
{
    //https://leetcode.com/problems/substring-with-concatenation-of-all-words/description/
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.FindSubstring("barfoothefoobarmanfooba", new string[] {"foo","bar" });
        }
        public class Solution
        {
            public IList<int> FindSubstring(string s, string[] words)
            {
                //build dictionary with words, and hash starts
                var map = new Dictionary<string, int>();
                var starts = new HashSet<char>();
                var wordSize = 0;
                foreach (var word in words)
                {
                    wordSize = word.Length;
                    var count = 0;
                    if (map.TryGetValue(word, out count))
                    {
                        map[word] = ++count;
                    }
                    else map.Add(word, 1);
                    starts.Add(word[0]);
                }

                //check
                var resp = new List<int>();
                for (int i = 0; i < s.Length; ++i)
                {
                    if (starts.Contains(s[i]))
                    {
                        var localMap = new Dictionary<string, int>(map);
                        var end = CheckWords(s, i, localMap, wordSize);
                        if (end != -1)
                        {
                            resp.Add(i);
                        }
                    }
                }
                return resp;
            }

            private int CheckWords(string s, int start, Dictionary<string, int> words, int wordSize)
            {
                int i = start;
                while (i < s.Length)
                {
                    if (i + wordSize <= s.Length)
                    {
                        var word = s.Substring(i, wordSize);
                        var count = 0;
                        if (words.TryGetValue(word, out count))
                        {
                            if (--count == 0) words.Remove(word);
                            else words[word] = count;
                            if (words.Count == 0) return i;
                        }
                        else return -1;
                    }
                    else break;
                    i += wordSize;
                }
                if (words.Count == 0) return i;
                return -1;
            }
        }
    }
}
