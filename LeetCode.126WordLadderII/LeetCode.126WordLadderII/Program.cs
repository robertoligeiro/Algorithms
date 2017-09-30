using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._126WordLadderII
{
    class Program
    {
        //time limit exceeded.
        //https://leetcode.com/submissions/detail/121243492/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.FindLadders("hit", "cog", new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" });
            //var r = s.FindLadders("a", "c", new List<string>() { "a", "b", "c" });
            //var r = s.FindLadders("hot", "dog", new List<string>() { "hot", "dog", "dot" });
        }

        public class Solution
        {
            public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
            {
                var words = new HashSet<string>(wordList);
                var resp = new List<IList<string>>();
                LadderLength(beginWord, endWord, words, resp);
                return resp;
            }

            private void LadderLength(string begin, string end, HashSet<string> words, List<IList<string>> resp)
            {
                var q1 = new Queue<string>();
                var q2 = new Queue<string>();
                var map = new Dictionary<string, HashSet<string>>();
                q1.Enqueue(begin);
                var original = new HashSet<string>(words);
                var pathCount = 1;
                var shouldBreak = false;
                while (q1.Count > 0 || q2.Count > 0)
                {
                    while (q1.Count > 0)
                    {
                        var curr = q1.Dequeue();
                        if (curr == end)
                        {
                            shouldBreak = true;
                            break;
                        }
                        GetChildWords(curr, words, q2, map, original);
                    }
                    if (shouldBreak) break;
                    pathCount++;
                    while (q2.Count > 0)
                    {
                        var curr = q2.Dequeue();
                        if (curr == end)
                        {
                            shouldBreak = true;
                            break;
                        }
                        GetChildWords(curr, words, q1, map, original);
                    }
                    if (shouldBreak) break;
                    pathCount++;
                }
                GetPaths(begin, end, map, new HashSet<string>(), resp, new List<string>(), pathCount);
            }

            private void GetPaths(string curr, string end, Dictionary<string, HashSet<string>> map,
                HashSet<string> visited, List<IList<string>> resp, List<string> parc, int pathcount)
            {
                if (parc.Count >= pathcount) return;
                if (!visited.Add(curr)) return;
                parc.Add(curr);
                if (curr == end)
                {
                    resp.Add(new List<string>(parc));
                    parc.RemoveAt(parc.Count - 1);
                    visited.Remove(curr);
                    return;
                }
                if (map.ContainsKey(curr))
                {
                    foreach (var c in map[curr])
                    {
                        GetPaths(c, end, map, visited, resp, parc, pathcount);
                    }
                }
                parc.RemoveAt(parc.Count - 1);
                visited.Remove(curr);
            }

            private void GetChildWords(string begin, HashSet<string> words, Queue<string> resp, Dictionary<string, HashSet<string>> map, HashSet<string> orignal)
            {
                var beginArr = begin.ToArray();
                HashSet<string> l;
                if (!map.TryGetValue(begin, out l))
                {
                    l = new HashSet<string>();
                    map.Add(begin, l);
                }
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
                        if (orignal.Contains(newWord)) l.Add(newWord);
                        beginArr[i] = charAt;
                    }
                }
            }
        }
}
}
