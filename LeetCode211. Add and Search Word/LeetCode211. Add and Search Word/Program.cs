using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode211.Add_and_Search_Word
{
    class Program
    {
        //https://leetcode.com/problems/add-and-search-word-data-structure-design/description/
        static void Main(string[] args)
        {
            var w = new WordDictionary();
            w.AddWord("dad");
            var b = w.Search("dad");
            b = w.Search("da");
            b = w.Search("dadd");
            b = w.Search(".ad");
            b = w.Search(".at");
        }

        public class TrieNode
        {
            public Dictionary<char, TrieNode> map = new Dictionary<char, TrieNode>();
            public bool isEnd;
        }
        public class WordDictionary
        {
            private TrieNode trie;
            /** Initialize your data structure here. */
            public WordDictionary()
            {
                trie = new TrieNode();
            }

            /** Adds a word into the data structure. */
            public void AddWord(string word)
            {
                if (!string.IsNullOrWhiteSpace(word)) this.AddWordToTrie(word, this.trie, 0);
            }

            /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
            public bool Search(string word)
            {
                return this.Search(word, this.trie, 0);
            }

            private bool Search(string word, TrieNode n, int index)
            {
                var curr = n;
                for(int i = index; i < word.Length; ++i)
                {
                    if (word[i] != '.')
                    {
                        TrieNode next;
                        if (curr.map.TryGetValue(word[i], out next))
                        {
                            curr = next;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        foreach (var t in curr.map.Values)
                        {
                            if (Search(word, t, i + 1)) return true;
                        }
                        return false;
                    }
                }
                return curr.isEnd;
            }

            private void AddWordToTrie(string s, TrieNode n, int index)
            {
                TrieNode curr;
                if (!n.map.TryGetValue(s[index], out curr))
                {
                    curr = new TrieNode();
                    n.map.Add(s[index], curr);
                }

                if (index == s.Length - 1)
                {
                    curr.isEnd = true;
                }
                else
                {
                    AddWordToTrie(s, curr, index + 1);
                }
            }
        }
    }
}
