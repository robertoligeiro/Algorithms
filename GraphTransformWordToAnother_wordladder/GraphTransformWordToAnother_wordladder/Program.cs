using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTransformWordToAnother_wordladder
{
    class Program
    {
        static void Main(string[] args)
        {
            var i = GetWordDistance(new HashSet<string>() { "hot", "dot", "dog", "lot", "log" }, "hot", "log");
        }

        public class Node
        {
            public string w { get; set; }
            public int d { get; set; }
        }

        public static int GetWordDistance(HashSet<string> d, string s, string t)
        {
            var q = new Queue<Node>();
            q.Enqueue(new Node() { w = s, d = 0 });
            d.Remove(s);
            while (q.Count > 0)
            {
                var curr = q.Dequeue();
                if (curr.w == t) return curr.d;

                for (int i = 0; i < curr.w.Length; ++i)
                {
                    for (char letter = 'a'; letter <= 'z'; letter++)
                    {
                        var newS = curr.w.ToCharArray();
                        newS[i] = letter;
                        var newW = new string(newS);
                        if (d.Contains(newW))
                        {
                            q.Enqueue(new Node() { w = newW, d = curr.d+1});
                            d.Remove(newW);
                        }
                    }
                }
            }

            return -1;
        }
    }
}
