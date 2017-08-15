using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode212.Word_Search_II
{
    class Program
    {
        //https://leetcode.com/problems/word-search-ii/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var b = new char[,]
            {
              {'o','a','a','n'},
              {'e','t','a','e'},
              {'i','h','k','r'},
              {'i','f','l','v'}
            };
            var r = s.FindWords(b, new string[] { "oath", "pea", "eat", "rain" });
            //var b = new char[,] { { 'a', 'b' }, { 'c', 'd' } };
            //var r = s.FindWords(b, new string[] { "ab", "cb", "ad", "bd", "ac", "ca", "da", "bc", "db", "adcb", "dabc", "abb", "acb" });

            //var b = new char[,] { { 'a' } };
            //var r = s.FindWords(b, new string[] { "a" });
        }

        public class Solution
        {
            public IList<string> FindWords(char[,] board, string[] words)
            {
                var m = new Dictionary<char, HashSet<string>>();
                foreach (var w in words)
                {
                    HashSet<string> l;
                    if (m.TryGetValue(w[0], out l))
                    {
                        l.Add(w);
                    }
                    else
                    {
                        m[w[0]] = new HashSet<string>() { w };
                    }
                }

                var resp = new HashSet<string>();
                for (int row = 0; row < board.GetLength(0); ++row)
                {
                    for (int col = 0; col < board.GetLength(1); ++col)
                    {
                        HashSet<string> lWords;
                        if (m.TryGetValue(board[row, col], out lWords))
                        {
                            var word = new StringBuilder();
                            word.Append(board[row, col]);
                            var t = new Tuple<int, int>(row, col);
                            FindWord(board, word, t, new HashSet<Tuple<int, int>>() { t }, lWords, resp);
                        }
                    }
                }
                return resp.ToList();
            }

            private bool FindWord(char[,] board, StringBuilder parc, Tuple<int, int> pos, HashSet<Tuple<int, int>> visited, HashSet<string> words, HashSet<string> found)
            {
                if (parc.Length > 0 && words.Contains(parc.ToString()))
                {
                    found.Add(parc.ToString());
                }

                var adj = GetAdj(board, pos);
                foreach (var t in adj)
                {
                    if (visited.Add(t))
                    {
                        parc.Append(board[t.Item1, t.Item2]);
                        if (WordsPrefixCheck(words, parc.ToString()))
                        {
                            FindWord(board, parc, t, visited, words, found);
                        }
                        parc.Remove(parc.Length - 1, 1);
                        visited.Remove(t);
                    }
                }
                return false;
            }

            private bool WordsPrefixCheck(HashSet<string> words, string prefix)
            {
                foreach (var w in words)
                {
                    if (w.StartsWith(prefix)) return true;
                }
                return false;
            }
            private List<Tuple<int, int>> GetAdj(char[,] board, Tuple<int, int> pos)
            {
                var up = pos.Item1 - 1;
                var down = pos.Item1 + 1;
                var left = pos.Item2 - 1;
                var right = pos.Item2 + 1;
                var resp = new List<Tuple<int, int>>();
                if (up >= 0) resp.Add(new Tuple<int, int>(up, pos.Item2));
                if (down < board.GetLength(0)) resp.Add(new Tuple<int, int>(down, pos.Item2));
                if (left >= 0) resp.Add(new Tuple<int, int>(pos.Item1, left));
                if (right < board.GetLength(1)) resp.Add(new Tuple<int, int>(pos.Item1, right));
                return resp;
            }
        }
    }
}
