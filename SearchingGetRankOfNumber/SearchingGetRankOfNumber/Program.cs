using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingGetRankOfNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var rank = -1;
            GetRank.KeepTrack(5);
            rank = GetRank.GetRankOfNumber(5);
            GetRank.KeepTrack(1);
            rank = GetRank.GetRankOfNumber(1);
            GetRank.KeepTrack(4);
            rank = GetRank.GetRankOfNumber(4);
            GetRank.KeepTrack(4);
            rank = GetRank.GetRankOfNumber(4);
            GetRank.KeepTrack(5);
            rank = GetRank.GetRankOfNumber(5);
            GetRank.KeepTrack(9);
            rank = GetRank.GetRankOfNumber(9);
            GetRank.KeepTrack(7);
            rank = GetRank.GetRankOfNumber(7);
            GetRank.KeepTrack(13);
            rank = GetRank.GetRankOfNumber(13);
            GetRank.KeepTrack(3);
            rank = GetRank.GetRankOfNumber(3);
            rank = GetRank.GetRankOfNumber(1);
            rank = GetRank.GetRankOfNumber(4);
            rank = GetRank.GetRankOfNumber(14);
        }

        public class Node
        {
            public int val { get; set; }
            public int post { get; set; }
            public Node next { get; set; }
        }
        public class GetRank
        {
            private static Dictionary<int, int> cache = new Dictionary<int, int>();
            private static Node head;
            public static void KeepTrack(int val)
            {
                if (head == null)
                {
                    head = new Node() { val = val, post = 0 };
                    cache.Add(val, 0);
                    return;
                }

                if (cache.ContainsKey(val)) return;

                var newNode = new Node() { val = val, post = -1 };
                var curr = head;
                Node prev = null;
                while (curr != null && curr.val > newNode.val)
                {
                    newNode.post = curr.post;
                    curr.post++;
                    cache[curr.val] = curr.post;
                    prev = curr;
                    curr = curr.next;
                }

                if (prev == null)
                {
                    newNode.post = head.post + 1;
                    newNode.next = head;
                    head = newNode;
                }
                else
                {
                    var t = prev.next;
                    prev.next = newNode;
                    newNode.next = t;
                }

                cache.Add(newNode.val, newNode.post);
            }

            public static int GetRankOfNumber(int val)
            {
                var count = 0;
                if (cache.TryGetValue(val, out count)) return count;
                return -1;
            }
        }
    }
}
