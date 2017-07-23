using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode208.ImplementTrie
{
    class Program
    {
        //https://leetcode.com/problems/implement-trie-prefix-tree/#/description
        static void Main(string[] args)
        {
            var trie = new Trie();
            trie.Insert("test");
            trie.Insert("roberto");
            trie.Insert("ana");
            trie.Insert("tests");
            trie.Insert("tesla");
            var b = trie.Search("roberto"); //true
            b = trie.Search("robert"); //false
            b = trie.StartsWith("robert"); //true
            b = trie.Search("ana"); //true
            b = trie.Search("test"); //true
            b = trie.Search("tests"); //true
            b = trie.Search("testss"); //false
            b = trie.StartsWith("testss"); //false
        }

        public class TrieNode
        {
            public int IsEnd = 0;
            public Dictionary<char, TrieNode> map = new Dictionary<char, TrieNode>();
        }
        public class Trie
        {
            private TrieNode head = new TrieNode() { IsEnd = 1 };

            /** Initialize your data structure here. */
            public Trie()
            {

            }

            /** Inserts a word into the trie. */
            public void Insert(string word)
            {
                var curr = this.head;
                foreach (var c in word)
                {
                    TrieNode next;
                    if (!curr.map.TryGetValue(c, out next))
                    {
                        next = new TrieNode();
                        curr.map.Add(c, next);
                    }
                    curr = next;
                }
                curr.IsEnd++;
            }

            /** Returns if the word is in the trie. */
            public bool Search(string word)
            {
                return SearchPath(word, true);
            }

            /** Returns if there is any word in the trie that starts with the given prefix. */
            public bool StartsWith(string prefix)
            {
                return SearchPath(prefix, false);
            }

            private bool SearchPath(string word, bool checkEnd)
            {
                var curr = this.head;
                foreach (var c in word)
                {
                    TrieNode next;
                    if (!curr.map.TryGetValue(c, out next)) return false;
                    curr = next;
                }

                if (checkEnd) return curr.IsEnd > 0;
                return true;
            }
        }

    }
}
