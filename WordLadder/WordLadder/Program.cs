using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadder
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution2();
            var i = s.LadderLength("hit", "cog", new HashSet<string>() { "hot", "dot", "dog", "lot", "log" });
        }

        public class Solution2
        {
            public class node
            {
                public bool resultInTarget { get; set; }
                public List<node> childs { get; set; }
                public string word { get; set; }
                public node()
                {
                    
                    resultInTarget = false;
                    childs = new List<node>();
                }
            }
            public List<List<string>> LadderLength(string beginWord, string endWord, ISet<string> wordList)
            {
                var wToGo = new List<string>() { beginWord };
                var wFound = new HashSet<string>() { beginWord };
                if (beginWord == endWord) return null;
                var root = new node() { childs = new List<node>() { new node() { word = beginWord } } };
                int found = -1;
                CreateTree(root, endWord, wFound, wordList, 0, ref found);
                List<List<string>> resp = new List<List<string>>();
                getPaths(root.childs.First(), resp, new List<string>());
                return null;
            }

            public void getPaths(node root, List<List<string>> resp, List<string> currPath)
            {
                currPath.Add(root.word);
                if (root.resultInTarget)
                {
                    resp.Add(currPath);
                    return;
                }

                foreach (var child in root.childs)
                {
                    var nPath = new List<string>(currPath);
                    getPaths(child, resp, nPath);
                }
            }
            public void CreateTree(node root, string tgt, ISet<string> wFound, ISet<string> wordList, int h, ref int found)
            {
                h++;
                if (root.childs.Count == 0 || (found != -1 && h > found)) return;

                foreach (var child in root.childs)
                {
                    for (int i = 0; i < child.word.Length; ++i)
                    {
                        foreach (var c in alpha)
                        {
                            if (c != child.word[i])
                            {
                                var t = child.word.ToCharArray();
                                t[i] = c;
                                var newWord = new string(t);
                                if (tgt == newWord)
                                {
                                    child.childs.Add(new node() { word = newWord, resultInTarget = true});
                                    found = found == -1 ? h + 1 : found; 
                                    return;
                                }
                                if (wordList.Contains(newWord) && !wFound.Contains(newWord))
                                {
                                    wFound.Add(newWord);
                                    child.childs.Add(new node() { word = newWord});
                                }
                            }
                        }
                    }

                    CreateTree(child, tgt, wFound, wordList, h, ref found);
                }
            }

            public char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower().ToCharArray();

        }

        public class Solution
        {
            public int LadderLength(string beginWord, string endWord, ISet<string> wordList)
            {
                var wToGo = new List<string>() { beginWord };
                var wFound = new HashSet<string>() { beginWord };
                if (beginWord == endWord) return 1;
                return RecurseWords(wToGo, wFound, endWord, wordList, 2);
            }

            public char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower().ToCharArray();
            public int RecurseWords(List<string> wToGo, ISet<string> wFound, string endWord, ISet<string> wordList, int h)
            {
                if (wToGo.Count == 0) return 0;

                var newToGo = new List<string>();
                foreach (var w in wToGo)
                {
                    for (int i = 0; i < w.Length; ++i)
                    {
                        foreach (var c in alpha)
                        {
                            if (c != w[i])
                            {
                                var t = w.ToCharArray();
                                t[i] = c;
                                var newWord = new string(t);
                                if (endWord == newWord) return h;
                                if (wordList.Contains(newWord) && !wFound.Contains(newWord))
                                {
                                    wFound.Add(newWord);
                                    newToGo.Add(newWord);
                                }
                            }
                        }
                    }
                }

                return RecurseWords(newToGo, wFound, endWord, wordList, ++h);
            }

        }
    }
}
