using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashesTriesFindShortestPath
{
    class Program
    {
        static void Main(string[] args)
        {
            var resp = GetMaxPrefix(new List<string>() { "dog","be","cut"}, "cat"); //ca
            resp = GetMaxPrefix(new List<string>() { "dog", "be", "cut","catsd" }, "cat"); //empty, prefix is all there
            resp = GetMaxPrefix(new List<string>() { "dog", "be", "cad" }, "cat"); //cat
        }

        public class TrieNode
        {
            public Dictionary<char, TrieNode> d = new Dictionary<char, TrieNode>();
        }

        public static TrieNode BuildTrie(List<string> words)
        {
            var root = new TrieNode();
            root.d.Add(' ', new TrieNode());
            foreach (var w in words)
            {
                var curr = root.d.FirstOrDefault().Value;
                foreach (var c in w)
                {
                    TrieNode next;
                    if (curr.d.TryGetValue(c, out next))
                    {
                        curr = next;
                    }
                    else
                    {
                        var t = new TrieNode();
                        curr.d.Add(c, t);
                        curr = t;
                    }
                }
            }
            return root;
        }

        public static string GetMaxPrefix(List<string> words, string prefix)
        {
            var trie = BuildTrie(words);
            string resp = string.Empty;
            trie = trie.d.FirstOrDefault().Value;
            foreach (var c in prefix)
            {
                resp += c;
                TrieNode next;
                if (trie.d.TryGetValue(c, out next))
                {
                    trie = next;
                }
                else
                {
                    return resp;
                }
            }

            return string.Empty;
        }
    }
}
