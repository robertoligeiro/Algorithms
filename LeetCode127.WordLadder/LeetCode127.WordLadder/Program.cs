using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode127.WordLadder
{
    //https://leetcode.com/problems/word-ladder/description/
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            //var r = s.LadderLength("hit", "cog", new List<string>() { "hot", "cog", "dot", "dog", "hit", "lot", "log" });
            //var r = s.LadderLength("a", "c", new List<string>() { "a", "b", "c" });
            var r = s.LadderLength("hot", "dog", new List<string>() { "hot", "dog", "dot" });
        }
        public class Solution
        {
            public int LadderLength(string beginWord, string endWord, IList<string> wordList)
            {
                var words = new HashSet<string>(wordList);
                return LadderLength(beginWord, endWord, words);
            }

            private int LadderLength(string begin, string end, HashSet<string> words)
            {
                var q1 = new Queue<string>();
                var q2 = new Queue<string>();
                q1.Enqueue(begin);
                var pathCount = 1;
                while (q1.Count > 0 || q2.Count > 0)
                {
                    while (q1.Count > 0)
                    {
                        var curr = q1.Dequeue();
                        if (curr == end) return pathCount;
                        GetChildWords(curr, words, q2);
                    }
                    pathCount++;
                    while (q2.Count > 0)
                    {
                        var curr = q2.Dequeue();
                        if (curr == end) return pathCount;
                        GetChildWords(curr, words, q1);
                    }
                    pathCount++;
                }
                return 0;
            }

            private void GetChildWords(string begin, HashSet<string> words, Queue<string> resp)
            {
                var beginArr = begin.ToArray();
                for (int i = 0; i < begin.Length; ++i)
                {
                    var charAt = beginArr[i];
                    for (char letter = 'a'; letter <= 'z'; letter++)
                    {
                        if (letter == charAt) continue;
                        beginArr[i] = letter;
                        var newWord = new string(beginArr);
                        if (words.Remove(newWord))
                        {
                            resp.Enqueue(newWord);
                        }
                        beginArr[i] = charAt;
                    }
                }
            }
        }
    }
}
