using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode677.Map_Sum_Pairs
{
    class Program
    {
        //https://leetcode.com/problems/map-sum-pairs/description/
        static void Main(string[] args)
        {
            var mapsum = new MapSum();
            mapsum.Insert("b", 1);
            mapsum.Insert("apple", 5);
            var r = mapsum.Sum("ap");
            mapsum.Insert("app", 2);
            r = mapsum.Sum("ap");
            r = mapsum.Sum("apx");
        }

        public class TriNode
        {
            public int value;
            public Dictionary<char, TriNode> map = new Dictionary<char, TriNode>();
        }
        public class MapSum
        {
            private TriNode root;
            private Dictionary<string, int> words;

            /** Initialize your data structure here. */
            public MapSum()
            {
                root = new TriNode();
                words = new Dictionary<string, int>();
            }

            public void Insert(string key, int val)
            {
                var oldVal = 0;
                if (words.TryGetValue(key, out oldVal))
                {
                    val -= oldVal;
                    words[key] = val;
                }
                else words.Add(key, val);

                var curr = this.root;
                foreach (var c in key)
                {
                    TriNode next;
                    if (!curr.map.TryGetValue(c, out next))
                    {
                        next = new TriNode();
                        curr.map.Add(c, next);
                    }
                    curr = next;
                    curr.value += val;
                }
            }

            public int Sum(string prefix)
            {
                var resp = 0;
                var curr = this.root;
                foreach (var c in prefix)
                {
                    TriNode next;
                    if (!curr.map.TryGetValue(c, out next)) return 0;
                    curr = next;
                    resp = curr.value;
                }
                return resp;
            }
        }
    }
}
